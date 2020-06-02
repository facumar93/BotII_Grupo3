using System;
using System.Collections.Generic;
using static Library.Game;

namespace Library 
{
    public class SingletonBot 
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

        public void CreateConfiguration(int judgeNum , int countPlayer)
        {
            if(judgeNum > 0 && countPlayer > 0)
            {
                config = new Config(judgeNum , countPlayer);
            }    
            else
            {
                throw new Exception("Error, numero tiene que ser positivo");
            }
                
        }
        private SingletonBot()
        {
            listGame = new List<Game>();
        }

        public void CreateGame(TypeOfGameOptions typeOfGameOption)
        {
            Game game = new Game(typeOfGameOption);
            listGame.Add(game);
            
        }
        public void AddUserToUserList(string name)
        {
            User user = new User(name);
            listGame[listGame.Count-1].AddUserToUserList(user);
        }
        private Game GetCurrentGame()
        {
            return listGame[listGame.Count-1];
        }
        public IJudge GetJudge()
        {
           return GetCurrentGame().GetJudge();
        }

        public User GetUserActually()
        {
            return GetCurrentGame().GetCurrentPlayer();
        } 


        public void AddNewGameToListOfGames(Game game) 
        {
            listGame.Add(game);
        }

        public void StartGame()
        {
            GetCurrentGame().DealCards();
        }

        public bool NextPlayer()
        {
            return GetCurrentGame().nextPlayer();
        }

        public User CurrentPlayer()
        {
            return GetCurrentGame().GetCurrentPlayer();
        }

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