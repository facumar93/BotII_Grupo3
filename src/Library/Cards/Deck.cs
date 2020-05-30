using System;
using System.Collections.Generic;

namespace Library
{
    public class Deck
    {
        private List<Card> cards{get;set;}
        private int lastCardWhite;
        private int lastCardBlack;
        public Deck()
        {
            cards = new List<Card>();
            lastCardWhite =  -1;
        }

        public void ravel()
        {

        }
        public void load()
        {
            //SingletonBot.Instance.config.
        }


        public Card GetNextCardWhite()
        {
            lastCardWhite++;
            while (!cards[lastCardWhite].Free || !(cards[lastCardWhite] is Answer))
            {

                lastCardWhite++;
                if(lastCardWhite==cards.Count)
                    lastCardWhite=0;
            }
                
            cards[lastCardWhite].Free=false;

            return cards[lastCardWhite];
        }
 
        private bool IsBlack(Game.GameType gameType, int position)
        {
            
            if (gameType == Game.GameType.TEXT_AND_ANSWER_CARD || gameType == Game.GameType.TEXT_AND_FREE_ANSWER) 
                return cards[position] is Text;
            else
                return cards[position] is Image;
        }
        public Card GetNextCardBlack(Game.GameType tipo)
        {

           lastCardBlack++;
            while (!cards[lastCardWhite].Free || !(IsBlack(tipo,lastCardBlack)))
            {
                lastCardBlack++;
                if(lastCardBlack==cards.Count)
                    lastCardBlack=0;
            }
                
            cards[lastCardBlack].Free=false;
            return cards[lastCardBlack];

        }
    }
}
