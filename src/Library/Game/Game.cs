using System;
using System.Collections.Generic;
namespace Library
{
    public class Game 
    {
        public GameType gameType { get; set; }
        public List<User> userList { get; set; }
        public List<Round> rounds { get; set; }
        public Deck deck { get; set; }
        
        public int NextPositionPlayer{ get; set; }
        public enum GameType
        {
            TEXT_AND_ANSWER_CARD,
            TEXT_AND_FREE_ANSWER,
            IMAGE_AND_ANSWER_CARD,
            IMAGE_AND_FREE_ANSWER
        }
        public Game(GameType type, List<User> listUser)
        {
            gameType = type;
            userList = listUser;
            Deck deck = new Deck();
            NextPositionPlayer = 0;
        }

        public void AddUser(User user)
        {
            userList.Add(user);
        }
        public void Deal() //Se deberían repartir cartas si, el modo de juego es con cartas blancas.
        {
            int j=0;
            deck.ravel();
            for (int i = 0 ; i < userList.Count ; i++)
            {
                User user = userList[i];

    	        for (int l = 1 ; l <= User.MaxCards ; l++)
                {
                    Card card = deck.GetNextCardWhite();
                    user.addCard(card);
                    j++; 
                }
            }

            User lastUser = userList[userList.Count-1];
            Round round = new Round(lastUser, deck.GetNextCardBlack(gameType)); 
            rounds.Add(round);
        }

        public IJudge GetJudge()
        {
            return rounds[rounds.Count - 1].Judge;
        }

        public void selectWinnerCard(Card selectedCard) // decision del juez
        {
            foreach (User user in userList)
            {
                if (user.belongs(selectedCard))
                {
                    user.win();
                }
            }
        }
        
        public void AddAnswer(Card card)
        {
            rounds[rounds.Count-1].AddAnswer(card);
        }

        public bool nextPlayer()
        {
            return !userList[NextPositionPlayer].Equals(rounds[rounds.Count-1].Judge);
        }
        //Precondicion :nextPlayer()
        public User CurrentPlayer()
        {
            User current=userList[NextPositionPlayer];
            NextPositionPlayer++;
            if(NextPositionPlayer == userList.Count)
                NextPositionPlayer = 0;
            return current;

        }
        public bool createNextRound()
        {
            rounds[rounds.Count-1].GiveBack(); //devolver la carta negra y las cartas de los usuarios
            NextPositionPlayer++;
            if (NextPositionPlayer == userList.Count)
                NextPositionPlayer = 0;
            bool validate = false;
            if (SingletonBot.Instance.config.CountRound() > rounds.Count)
            {
                Round round = new Round(userList[NextPositionPlayer], deck.GetNextCardBlack(gameType));
                rounds.Add(round);
                validate = true;
            }
            return validate;
            
        }

    }
}