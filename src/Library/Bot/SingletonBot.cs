using System;
using System.Collections.Generic;
using static Library.Game;

namespace Library 
{
    public class SingletonBot //se adapta a cualq interfaz grafica
    {
        private static SingletonBot instance = null;
        public Config config { get; private set; }
        public List<Game> listGame { get; set; }

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
        private SingletonBot()
        {
            listGame = new List<Game>();
        }

        public void CreateGame(GameType type, List<User> listUser)
        {
            Game game = new Game(type, listUser);
            listGame.Add(game);
            game.Deal();
        }

        public IJudge GetJudge()
        {
            return listGame[listGame.Count-1].GetJudge();
        }
    
        public void AddNewGameToListOfGames(Game game) 
        {
            listGame.Add(game);
        }

        public void CreatConfiguration(int judgeNum)
        {
            Config config = new Config(judgeNum);
        }
    }
}