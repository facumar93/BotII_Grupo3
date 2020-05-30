using System;
using System.Collections.Generic;

namespace Library
{
    public  class User :IJudge,IPlayer
    {
        public const int MAX_CARDS = 10;
        private List<Card> cards = new List<Card>();
        
        public void addCard(Card card)
        {
            if (cards.Count < MAX_CARDS) //No debería ser necesario controlar acá.
                cards.Add(card);
            else
                throw new Exception("No se puede dar mas de 10 cartas");
        }

        
    }
}