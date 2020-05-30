using System;
using System.Collections.Generic;

namespace Library 
{
    public class SingletonBot
    {
        private static SingletonBot instance = null;
        public Config config { get; set; }
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

        public void AddNewGameToListOfGames(Game game) 
        {
            listGame.Add(game);
        }
        

        
    }
}