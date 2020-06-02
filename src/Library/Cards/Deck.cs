using System;
using System.Collections.Generic;

namespace Library
{
    public class Deck
    {
        private List<Card> cards{ get; set; }
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
            White white0 = new White();
            Black black0 = new Black();
            White white1 = new White();
            Black black1 = new Black();
            White white2 = new White();
            Black black2 = new Black();

            cards.Add(white0);
            cards.Add(black0);
            cards.Add(white1);
            cards.Add(black1);
            cards.Add(white2);
            cards.Add(black2);
    
        }


        public Card GetNextCardWhite()
        {
            lastCardWhite++;
            while (!cards[lastCardWhite].Free || !(cards[lastCardWhite] is White))
            {
                lastCardWhite++;
                if(lastCardWhite == cards.Count)
                    lastCardWhite = 0;
            }
                
            cards[lastCardWhite].Free = false;

            return cards[lastCardWhite];
        }
 
        private bool IsBlack(TypeOfGameOptions typeOfGameOptions, int position) //podría ser estatico porque se usa solo en GetNextCardBlack?
        {
            
            if (typeOfGameOptions == TypeOfGameOptions.IncompletTextAndAnswerText || typeOfGameOptions == TypeOfGameOptions.IncompletTextAndFreeAnswer) 
                return cards[position] is Black;
            else
                return cards[position] is Image;
        }
        public Black GetNextCardBlack(TypeOfGameOptions type)
        {

           lastCardBlack++;
            while (!cards[lastCardWhite].Free || !(IsBlack(type,lastCardBlack)))
            {
                lastCardBlack++;
                if(lastCardBlack==cards.Count)
                    lastCardBlack=0;
            }
                
            cards[lastCardBlack].Free = false;
            return (Black)cards[lastCardBlack];

        }
    }
}
