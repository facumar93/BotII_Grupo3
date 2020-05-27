using System;
using System.Collections.Generic;

namespace Library
{
    public class Deck
    {
        private List<Card> cards{get;set;}

        public Deck()
        {
            cards=new List<Card>();
        }

        public void ravel()
        {

        }
        public void load()
        {
            //SingletonBot.Instance.config.
        }

        public Card GetCard(int pos)
        {
            return cards[pos];
        }
    }
}
