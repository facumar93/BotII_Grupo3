using System;
using System.Collections.Generic;

namespace Library 
{
    public class SingletonBot
    {
        private static SingletonBot instance = null;
        public Config config { get; set; }
        public List<Game> listGame{get;set;}
        private SingletonBot()
        {
            listGame=new List<Game>();
        }

        public void StartGame(Game game)
        {
            listGame.Add(game);
        }
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

        
    }
}