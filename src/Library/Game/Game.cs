using System;
using System.Collections.Generic;
namespace Library
{
    public class Game 
    {
        public GameType Type { get; set; }
        public List<User> userList { get; set; }
        public Deck deck { get; set; }
        public Game(GameType type)
        {
            Type = type;
            Deck deck = new Deck();
        }
        public void AddUser(User user)
        {
            userList.Add(user);
        }

        public void Deal()
        {
            int j=0;
            deck.ravel();
            for(int i=0;i<userList.Count;i++)
            {
                User user=userList[i];

    	        for(int l=1;l<=User.MAX_CARDS;l++)
                {
                    Card card=deck.GetCard(j);
                    user.addCard(card);
                    j++; 
                }
            
            }
        }

        public enum GameType
        {
            TEXT_PLUS_ANSWER_CARD,
            TEXT_PLUS_FREE_ANSWER,
            IMAGE_PLUS_ANSWER_CARD,
            IMAGE_PLUS_FREE_ANSWER
        }
    
    }
}