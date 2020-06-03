using System;
using System.Collections.Generic;
namespace Library
{
    public class Game 
    {
        public TypeOfGameOptions typeOfGameOption { get; set; }
        public List<User> userList { get; set; }
        public List<Round> rounds { get; set; }
        public Deck deck { get; set; }

        public int NextPositionPlayer { get; set;} 

        
        public Game(TypeOfGameOptions typeOfGameOption)
        {
            this.typeOfGameOption = typeOfGameOption;
            userList = new List<User>();

            rounds=new List<Round>();

            Deck deck = new Deck();
            NextPositionPlayer = 0;
        }

        public IJudge GetJudge()
        {
            return rounds[rounds.Count-1].judge;
        } 
        public void AddUserToUserList(User user)
        {
            if(!userList.Contains(user))
                userList.Add(user);
            else

                throw new Exception("Usuario ya esta registrado");//DEBE MOSTRARSE EN LA VISUAL
        }
        public void DealCards() //Se deberían repartir cartas si, el modo de juego es con cartas blancas.

        {                       
            int j = 0;
            deck.ravel();
            for (int i = 0 ; i < userList.Count ; i++)
            {
                User user = userList[i];

    	        for (int l = 1 ; l <= User.MaxCards ; l++)
                {
                    Card card = deck.GetNextCardWhite();
                    user.addCardToUser(card);
                    j++; 
                }
            }

            User lastUserInList = userList[userList.Count-1];
            Round round = new Round(lastUserInList, deck.GetNextCardBlack(typeOfGameOption)); 
            rounds.Add(round);
        }

        public void decide(Card select)
        {
            foreach(User user in userList)
            {
                if(user.belongs(select))
                {
                    user.win();
                }
            }
        }

        public Black CardBlack()
        {
            return rounds[rounds.Count-1].black;
        }
        public void AddAnswer(Card card)
        {
            rounds[rounds.Count-1].AddAnswer(card);
        }

        public bool nextPlayer()
        {
            return !userList[NextPositionPlayer].Equals(rounds[rounds.Count - 1].judge);
        }

        //Precondicion :nextPlayer()

        public User GetCurrentPlayer()
        {
            User current = userList[NextPositionPlayer];
            NextPositionPlayer++;
            if(NextPositionPlayer == userList.Count)
                NextPositionPlayer = 0;
            return current;

        }
        public bool createNextRound()
        {
            rounds[rounds.Count - 1].GiveBack();
            NextPositionPlayer++;
            if(NextPositionPlayer == userList.Count)
                NextPositionPlayer = 0;
            bool validate = false;
            if(SingletonBot.Instance.config.CountRound() > rounds.Count)
            {
                Round round=new Round(userList[NextPositionPlayer], deck.GetNextCardBlack(typeOfGameOption)); //Agregué el método de Deck.
                rounds.Add(round);
                validate = true;
            }
            return validate;

        }
        public IEnumerator<Card> EnumeratorCardsAnswer() //Falta un return.
        {
            return rounds[rounds.Count - 1].EnumeratorCardsAnswer();
        }

    }
}