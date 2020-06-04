using System;
using System.Collections.Generic;
namespace Library
{
    /// <summary>
    /// Esta clase representa las funcionalidades principales del juego y cumple con el principio de abstraccion
    /// y expert
    /// </summary>
    public class Game 
    {
        /// <summary>
        /// Método que Representa los tipos de juego
        /// </summary>
        /// <value>tipo enum</value>
        public TypeOfGameOptions typeOfGameOption { get; set; }

        /// <summary>
        /// Lista que almacena los jugadores
        /// </summary>
        /// <value>tipo Usuario</value>
        private List<User> userList { get; set; }

        /// <summary>
        /// Lista que almacena las rondas
        /// </summary>
        /// <value>tipo Round</value>
        private List<Round> rounds { get; set; }

        /// <summary>
        /// Contiene un Deck 
        /// </summary>
        /// <value></value>
        public Deck deck { get; set; }

        /// <summary>
        /// atributo numero de Game
        /// </summary>
        /// <value></value>
        public int NextPositionPlayer { get; set;} 
        

        /// <summary>
        /// Constructor de Game
        /// Patrón Creator
        /// </summary>
        /// <param name="typeOfGameOption">Tipo de juego</param>
        public Game(TypeOfGameOptions typeOfGameOption)
        {
            this.typeOfGameOption = typeOfGameOption;
            userList = new List<User>();

            rounds=new List<Round>();

            Deck deck = new Deck();
            NextPositionPlayer = 0;
        }
        
        /// <summary>
        /// Obtiene el juez de la ronda actual
        /// </summary>
        /// <returns>Juez</returns>
        public IJudge GetJudge()
        {
            return rounds[rounds.Count-1].judge;
        }

        /// <summary>
        /// Agrega una ronda a la lista de rondas
        /// </summary>
        /// <param name = "round">Una ronda</param>
        public void Add(Round round)
        {
            rounds.Add(round);
        }

        /// <summary>
        /// Agrega un usuario a la lista de usuarios
        /// </summary>
        /// <param name="user">Un usuario</param>
        public void AddUserToUserList(User user)
        {
            if(!userList.Contains(user))
                userList.Add(user);
            else
                throw new Exception("Usuario ya esta registrado");
        }

        /// <summary>
        /// Reparte las cartas
        /// </summary>
        public void DealCards() 
        {                       
            int j = 0;
            deck.ravel();
            for (int i = 0 ; i < userList.Count ; i++)
            {
                User user = userList[i];

    	        for (int l = 1 ; l <= User.MaxCards ; l++)
                {
                    Card card = deck.GetNextCardWhite();
                    user.AddCardToUser(card);
                    j++; 
                }
            }

            User lastUserInList = userList[userList.Count-1];
            Round round = new Round(lastUserInList, deck.GetNextCardBlack(typeOfGameOption)); 
            rounds.Add(round);
        }

        /// <summary>
        /// Permite que User seleccione un ganador
        /// </summary>
        /// <param name="select">Carta seleccionada por el juez</param>
        public void Winner(Card select)
        {
            foreach(User user in userList)
            {
                if(user.belongs(select))
                {
                    user.win();
                }
            }
        }

        /// <summary>
        /// Permite retornar la carta negra actual de la ronda
        /// </summary>
        /// <returns>Carta negra</returns>
        public BlackCard GetCurrentBlackCard()
        {
            return rounds[rounds.Count-1].blackCard;
        }
        public void AddAnswer(Card card)
        {
            rounds[rounds.Count-1].AddAnswer(card);
        }

        // y GetCurrentPlayer - Diseño de patron Iterador(Iterator)
        /// <summary>
        ///  Metodo ToNextPlayer retorna falso si encuentra al Judge actual en la lista userList
        ///  Tanto ToNextPlayer() como GetCurrentPlayer cumplen con el patron Iterator 
        /// </summary>
        /// <returns>booleano</returns>
        public bool ToNextPlayer()
        {
            return !userList[NextPositionPlayer].Equals(rounds[rounds.Count - 1].judge);
        }

       
        /// <summary>
        /// Este método retorna el jugador actual
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

        /// <summary>
        /// Método que crea una nueva ronda 
        /// </summary>
        /// <returns></returns>
        public bool CreateNextRound() //No se usa validate
        {
            rounds[rounds.Count - 1].GiveBackBlackCard();
            NextPositionPlayer++;
            if(NextPositionPlayer == userList.Count)
                NextPositionPlayer = 0;
            bool validate = false;
            if(SingletonBot.Instance.configuration.RoundsCount() > rounds.Count)
            {
                Round round=new Round(userList[NextPositionPlayer], deck.GetNextCardBlack(typeOfGameOption)); //Agregué el método de Deck.
                rounds.Add(round);
                validate = true;
            }
            return validate;

        }
        /// <summary>
        /// Método que retorna
        /// una lista enumerada del tipo card de una ronda
        /// </summary>
        /// <returns>lista enumerad de tipo Card</returns> //Cómo comento esto ?
        public IEnumerator<Card> EnumeratorCardsAnswer() 
        {
            return rounds[rounds.Count - 1].GetEnumeratorForListWhiteCardsAnswer();
        }

    }
}