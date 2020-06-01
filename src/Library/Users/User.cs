using System;
using System.Collections.Generic;

namespace Library
{
    public  class User :IJudge,IPlayer
    {
        public const int MaxCards = 10;
        private List<Card> cards = new List<Card>();
        public int Points{ get; set; }
        
        public void addCard(Card card)
        {
            if (cards.Count < MaxCards) //No debería ser necesario controlar acá.
                cards.Add(card);
            else
                throw new Exception("No se puede dar mas de 10 cartas");
        }
        public bool belongs(Card selectedCard)
        {
            return cards.Contains(selectedCard);
        }
        public void win()
        {
            Points = Points + 1;
        }

        
    }
}