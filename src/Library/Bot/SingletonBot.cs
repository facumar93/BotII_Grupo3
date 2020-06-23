using System;
using System.Collections.Generic;

namespace Library 
{
    /// <summary>
    /// Representa al bot. Patrón Singleton y Facade
    /// </summary>
    public class SingletonBot
    {
        private static SingletonBot instance = null;
        public Configuration Configuration { get; private set; }
        public List<Game> ListOfGames { get; set; }


        /// <summary>
        /// Método para instanciar el Bot o retornarlo
        /// </summary>
        /// <value></value>
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
        /// Constructor, instancia una nueva lista de juegos 
        /// </summary>
        private SingletonBot()
        {
            ListOfGames = new List<Game>();
        }

        /// <summary>
        /// Instancia un nuevo juego y lo agrega a una lista
        /// </summary>
        /// <param name="path">path del archivo que contiene la configuración del juego</param>
        public void CreateGame(string path)
        {
            Configuration configuration = new Configuration(path);
            Game game = new Game(configuration);
            ListOfGames.Add(game);
            
        }
        /// <summary>
        /// Instancia un usuario y guarda en una lista de juegos
        /// Agregado por Creator
        /// </summary>
        /// <param name="name">parameter represents the name of the player</param>
        public void CreatUser(string name, int id)
        {
            User user = new User(name, id);
            ListOfGames[ListOfGames.Count-1].AddUserToUserList(user);
        }

        /// <summary>
        /// Retorna el juego actual en la lista de juegos
        /// </summary>
        private Game GetCurrentGame()
        {
            return ListOfGames[ListOfGames.Count-1];
        }

        /// <summary>
        /// Se recupera el juez de la mano actual
        /// </summary>
        /// <returns>devuelve juez</returns>
        public IJudge GetJudge()
        {
           return GetCurrentGame().GetJudge();
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
            ListOfGames.Add(game);
        }

        /// <summary>
        /// Comienza el juego repartiendo cartas y eligiendo un juez
        /// </summary>
        public void StartGame()
        {
            GetCurrentGame().DealCards();
        }

        /// <summary>
        /// Verifica si hay mas jugadores para jugar
        /// </summary>
        /// <returns>retorna true si hay mas jugadores</returns>
        public bool AskNextPlayer()
        {
            return GetCurrentGame().ToNextPlayer();
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
        /// Agrega un una carta White a una Round, es la jugada de Player 
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