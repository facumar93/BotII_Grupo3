using System;
using System.Collections.Generic;
using static Library.Game;

namespace Library 
{
    /// <summary>
    /// Representa al bot
    /// Patrón Singleton para asegurarse de que una clase tenga solo una instancia, 
    /// al tiempo que proporciona un punto de acceso global
    /// Patrón Facade, Una clase que proporciona una interfaz simple
    /// a un subsistema complejo que contiene muchas partes móviles(las demas clases)
    /// Patrón Mediator, reduce las dependencias entre los objetos

    /// </summary>
    public class SingletonBot
    {
        private static SingletonBot instance = null;
        public Configuration configuration { get; private set; }
        public List<Game> listOfGames { get; set; }


        /// <summary>
        /// Método para instanciar el Bot o retornarlo
        /// </summary>
        /// <value>instancia</value>

        public static SingletonBot Instance 
        {
            get 
            {
                if (instance == null)
                {
                    instance = new SingletonBot();
                  
                }
                return instance;
            }
        }

        /// <summary>
        /// Constructor del Juego, instancia una nueva lista de juegos 
        /// </summary>
        private SingletonBot()
        {
            listOfGames = new List<Game>();
        }

        /// <summary>
        /// Instancia un nuevo juego y lo agrega a una lista de juegos.
        /// Patrón Creator al crear una configuración y un juego.
        /// 
        /// </summary>
        /// <param name="typeOfGameOption"></param>
        public void CreateGame(string path,string pathCard)
        {
            configuration = new Configuration(path,pathCard);
            Game game = new Game(configuration);
            listOfGames.Add(game);
        }

        /// <summary>
        /// Instancia un usuario y guarda en una lista de juegos
        /// Agregado por Creator
        /// </summary>
        /// <param name="name">parameter represents the name of the player</param>
        public void CreatUser(string name,long id)
        {
            User user = new User(name,id);
            listOfGames[listOfGames.Count-1].AddUserToUserList(user);
            
        }

        /// <summary>
        /// Retorna el juego actual en la lista de juegos
        /// </summary>
        private Game GetCurrentGame()
        {
            return listOfGames[listOfGames.Count-1];
        }

        /// <summary>
        /// Se recupera el juez de la mano actual
        /// </summary>
        /// <returns>devuelve juez</returns>
        public IJudge GetJudge()
        {
           return GetCurrentGame().GetJudge();
        }

        public Card CardSelectWhite(int position)
        {
            return GetCurrentGame().CardSelectWhite(position);
        }

        /// <summary>
        /// Se recupera el usuario de la mano actual
        /// </summary>
        /// <returns>retorna usuario</returns>
        public User GetUserActually()
        {
            return GetCurrentGame().GetCurrentPlayer();
        } 

        /// <summary>
        /// Agrega un juego a una lista que contiene Games
        /// </summary>
        /// <param name="game">Recibe un Game</param>
        public void AddGameToListOfGames(Game game) 
        {
            listOfGames.Add(game);
        }

        /// <summary>
        /// Comienza el juego repartiendo cartas y eligiendo un juez
        /// </summary>
        public bool StartGame()
        {
            if(GetCurrentGame().CountPlayer() == this.configuration.CountPlayer)
            {
                GetCurrentGame().DealCards();
                return true;
            }
            else
            {
                return false;   
            }
            
        }

        public IEnumerator<User> GetListUser()
        {
            return GetCurrentGame().EnumeratorUser();
        }

        /// <summary>
        /// Verifica si hay mas jugadores para jugar
        /// </summary>
        /// <returns>retorna true si hay mas jugadores</returns>
        public bool isAskNextPlayer()
        {
            return GetCurrentGame().isToNextPlayer();
        }

        /// <summary>
        /// Recupera al jugador actual
        /// </summary>
        /// <returns>retorna User</returns>
        public User AskCurrentPlayer()
        {
            return GetCurrentGame().GetCurrentPlayer();
        }
        
        /// <summary>
        /// Agrega un una carta Blanca a una ronda, es la jugada de Player 
        /// </summary>
        /// <param name="card"></param>
        public void AddAnswer(Card card)
        {
            GetCurrentGame().AddAnswer(card);
        }

        /// <summary>
        /// Recupera la carta negra BlackCard que tiene Round
        /// </summary>
        /// <returns>retorna una carta negra</returns>
        public Card AskBlackCard() 
        {
            return GetCurrentGame().GetCurrentBlackCard();
        }

        /// <summary>
        /// Recupera una una lista enumerada del tipo Card
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Card> AskEnumeratorCardsAnswer()
        {
            return GetCurrentGame().EnumeratorCardsAnswer();
        }

        /// <summary>
        /// Recupera el ganador e inicia una nueva Round
        /// </summary>
        /// <param name="selection"></param>
        public void AskWinner(Card selection)
        {
            GetCurrentGame().Winner(selection);
            GetCurrentGame().CreateNextRound();
        }
    }
}