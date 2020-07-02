using System;
using System.Collections.Generic;
using Library;
namespace Library
{
    /// <summary>
    /// Esta clase representa las funcionalidades principales del juego.
    /// </summary>
    public class Game 
    {
        

        /// <summary>
        /// Lista que almacena los usuarios.
        /// </summary>
        /// <value>tipo Usuario</value>
        private List<User> userList { get; set; }

        /// <summary>
        /// Lista que almacena las rondas.
        /// </summary>
        /// <value>tipo Round</value>
        private List<Round> rounds { get; set; }

        /// <summary>
        /// Propiedad para obtener un Deck.
        /// </summary>
        /// <value></value>
        public Deck Deck { get; set; }

        /// <summary>
        /// Propiedad para obtener la posición de los jugadores en la lista de usuarios "userList" del juego.
        /// </summary>
        /// <value></value>
        private int NextPositionPlayer { get; set;} 
        
        private Configuration Configuration{get;set;}
        /// <summary>
        /// Constructor de Game
        /// Patrón Creator para generar un mazo "Deck" al inicializar un juego
        /// </summary>
        
        public Game(Configuration configuration)
        {
            Configuration=configuration;
            userList = new List<User>();
            rounds = new List<Round>();
            Deck  = new Deck();
            Deck.Load(configuration.PathCards);
            NextPositionPlayer = 0;
        }

        public int CountPlayer()
        {
            return userList.Count;
        }

        /// <summary>
        /// Obtiene el juez "Judge" de la ronda actual
        /// </summary>
        /// <returns>Judge</returns>
        public IJudge GetJudge()
        {
            return rounds[rounds.Count-1].judge;
        }

        /// <summary>
        /// Agrega una ronda "round" a la lista de rondas "roundList".
        /// </summary>
        /// <param name = "round">Una ronda</param>
        /*public void Add(Round round)
        {
            rounds.Add(round);
        }*/

        /// <summary>
        /// Agrega un usuario a la lista de usuarios "userList"
        /// </summary>
        /// <param name="user">Un usuario</param>
        public void AddUserToUserList(User user)
        {
            if(!userList.Contains(user))
                userList.Add(user);
            else
                throw new UserException("Usuario ya esta registrado");
        }

        
        /// <summary>
        /// Se reparte a cada usuario de la lista del juego las cartas blancas.
        /// Se crea la primera ronda, de modo que el juez sea el último usuario de la lista.
        /// Agregado por Patrón expert, ya que Game se crean las listas de ronda y jugadores.
        /// </summary>
        public void DealCards() 
        {                       
            int j = 0;
            Deck.Ravel();
             
            for (int i = 0 ; i < userList.Count ; i++)
            {
                User user = userList[i];
 
    	        for (int l = 1 ; l <= User.MaxCards ; l++)
                {
                    Card card = Deck.GetNextCardWhite();
                   
                    user.AddCardToUser(card);
                    j++; 
                }
            }

            User lastUserInList = userList[userList.Count-1];
            Console.WriteLine("Entro");
            Round round = new Round(lastUserInList, Deck.GetNextCardBlack()); 
            rounds.Add(round);
        }

        public void ConfigRound( )
        {
            rounds[rounds.Count-1].BlackCard=Deck.GetNextCardBlack();
            rounds[rounds.Count-1].GameType=Configuration.GameType;
        }


        /// <summary>
        /// Método para que el juez seleccione al jugador.
        /// Agregado por expert, ya que en Game se crea la lista de jugadores.
        /// </summary>
        /// <param name="select">Carta seleccionada por el juez</param>
        public void Winner(Card select)
        {
            foreach(User user in userList)
            {
                if(user.Belongs(select))
                {
                    user.Win();
                }
            }
        }

        /// <summary>
        /// Retorna la carta negra actual de la ronda "blackCard"
        /// Agregado por expert ya que Game conoce las rondas.
        /// </summary>
        /// <returns>Carta negra</returns>
        public Card GetCurrentBlackCard()
        {
            Console.WriteLine("Aca :"+rounds[rounds.Count-1].ToString());
            return rounds[rounds.Count-1].BlackCard;
        }

        /// <summary>
        /// Método usado para responder en cada ronda con una carta blanca.
        /// Agregado por expert ya que Game conoce las rondas.
        /// </summary>
        /// <param name="card"></param>
        public void AddAnswer(Card card)
        {
            rounds[rounds.Count-1].AddAnswer(card);
        }

     
        /// <summary>
        ///  Metodo ToNextPlayer retorna falso si encuentra al juez "Judge" actual en la lista de jugadores "userList".
        ///  Agregado por patrón Iterator 
        /// </summary>
        /// <returns>booleano</returns>
        public bool isToNextPlayer()
        {
            return !userList[NextPositionPlayer].Equals(rounds[rounds.Count - 1].judge);
        }

       
        /// <summary>
        /// Este método retorna el jugador actual
        /// Agregado por patrón Iterator
        /// </summary>
        /// <returns></returns>
        public User GetCurrentPlayer()
        {
            User current = userList[NextPositionPlayer];
            NextPositionPlayer++;
            if(NextPositionPlayer == userList.Count)
                NextPositionPlayer = 0;
            return current;
        }

        // public User CurrentPlayer2(long ide)
        // {
        //     if (userList.Count > 0)
        //     {
        //         foreach (User user in userList)
        //         {  
        //             if (user.ID == ide)
        //             return user;
        //             else
        //             return null;
        //         }
        //     }
        //     else
        //     return null;
        // }

        public Card CardSelectWhite(int position)
        {
            return rounds[rounds.Count - 1].CardSelectWhite(position);
        }

        /// <summary>
        /// Crear siguientes rondas, devolviendo al mazo (vuelve a estar desocupada - True) la carta negra "blackCard" usada en la ronda anterior.
        /// </summary>
        /// <returns></returns>
        public bool CreateNextRound() 
        {
            rounds[rounds.Count - 1].GiveBackCard();
            NextPositionPlayer++;
            if(NextPositionPlayer == userList.Count)
                NextPositionPlayer = 0;
            bool validate = false;
            if(SingletonBot.Instance.configuration.RoundsCount() > rounds.Count)
            {
                Round round = new Round(userList[NextPositionPlayer], Deck.GetNextCardBlack());
                rounds.Add(round);
                validate = true;
            }
            return validate;

        }
        /// <summary>
        /// Método que retorna una lista enumerada del tipo Card de una ronda.
        /// </summary>
        /// <returns>lista enumerad de tipo Card</returns> 
        public IEnumerator<Card> EnumeratorCardsAnswer() 
        {
            return rounds[rounds.Count - 1].GetEnumeratorForListWhiteCardsAnswer();
        }

        public IEnumerator<User> EnumeratorUser()
        {
            return userList.GetEnumerator();
        }

    }
}