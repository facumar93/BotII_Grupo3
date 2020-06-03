using System;
using System.Collections.Generic;
using static Library.Game;

namespace Library 
{

    /// <summary>
    /// This class represents the Bot. Patron Singleton, Fachada(Facade)
    /// </summary>
    public class SingletonBot
    {
        private static SingletonBot instance = null;
        public Config config { get; private set; }
        public List<Game> listOfGames { get; set; }


        /// <summary>
        /// Propery for instance Bot or return Bot
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
        /// Propery for instance new Config
        /// </summary>
        /// <param name="judgeNum">Cantidad de </param>
        /// <param name="countPlayer"></param>
        public void CreateConfiguration(int judgeNum , int countPlayer)
        { 
            if(judgeNum > 0 && countPlayer > 3)  //ESTO YA LO CONTROLAMOS EN SCREEN
                config = new Config(judgeNum , countPlayer);
            else
                throw new Exception("Número no adecuado al juego."); //DEBE SER MOSTRANDO EN LA VISUAL
        }

        /// <summary>
        /// Construct Propery to instance new list of games 
        /// </summary>

        private SingletonBot()
        {
            listOfGames = new List<Game>();
        }

        /// <summary>
        /// Propery for instance new Game and add to a list of games
        /// </summary>
        /// <param name="typeOfGameOption"></param>
        public void CreateGame(TypeOfGameOptions typeOfGameOption)
        {
            Game game = new Game(typeOfGameOption);
            listOfGames.Add(game);
            
        }
        /// <summary>
        /// Propery for instance new User and add to a list of users in Game class
        /// </summary>
        /// <param name="name">parameter represents the name of the player</param>
        public void CreatUser(string name)
        {
            User user = new User(name);
            listOfGames[listOfGames.Count-1].AddUserToUserList(user);
        }

        /// <summary>
        /// Propery for get the current game in list of games
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
        public void StartGame()
        {
            GetCurrentGame().DealCards();
        }

        /// <summary>
        /// Verifica si hay mas jugadores para jugar
        /// </summary>
        /// <returns>retorna true si hay mas jugadores</returns>
        public bool NextPlayer()
        {
            return GetCurrentGame().nextPlayer();
        }

        /// <summary>
        /// Recupera al jugador actual
        /// </summary>
        /// <returns>retorna User</returns>
        public User CurrentPlayer()
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


        public Black CardBlack()
        {
            return GetCurrentGame().CardBlack();
        }

        public IEnumerator<Card> EnumeratorCardsAnswer()
        {
            return GetCurrentGame().EnumeratorCardsAnswer();
        }

        public void Win(Card selection)
        {
            GetCurrentGame().decide(selection);
            GetCurrentGame().createNextRound();
        }
    }
}