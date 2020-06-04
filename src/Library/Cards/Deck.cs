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
            lastCardBlack = -1; //AGREGU'E ESTO
        }

        public void ravel()
        {

        }
        public void load()
        {
            WhiteCard white0 = new WhiteCard(1);
            BlackCard black0 = new  BlackCardText(2);
            WhiteCard white1 = new WhiteCard(3);
            BlackCard black1 = new  BlackCardText(4);
            WhiteCard white2 = new WhiteCard(5);
            BlackCard black2 = new  BlackCardText(6);
            BlackCard blackImage=new BlackCardImage(7);
            cards.Add(white0);
            cards.Add(black0);
            cards.Add(white1);
            cards.Add(black1);
            cards.Add(blackImage);
            cards.Add(white2);
            cards.Add(black2);

            foreach(Card card in cards) //este metodo para q est'a?
            {
                Console.WriteLine(card);
            }
        }


        public Card GetNextCardWhite()
        {
            lastCardWhite++;
            if(lastCardWhite==cards.Count)
                lastCardWhite=0;
            while (!cards[lastCardWhite].Free || !(cards[lastCardWhite] is WhiteCard))
            {
                lastCardWhite++;
                if(lastCardWhite == cards.Count)
                    lastCardWhite = 0;
            }
                
            cards[lastCardWhite].Free = false;

            return cards[lastCardWhite];
        }
        
 
        private bool IsBlack(TypeOfGameOptions typeOfGameOptions, int position) 
        {
            
            if (typeOfGameOptions == TypeOfGameOptions.IncompletTextAndAnswerText || typeOfGameOptions == TypeOfGameOptions.IncompletTextAndFreeAnswer) 
                return cards[position] is  BlackCardText;
            else
                return cards[position] is BlackCardImage;
        }
        public Card GetNextCardBlack(TypeOfGameOptions type)
        {
           lastCardBlack++;
           if(lastCardBlack == cards.Count)
                lastCardBlack=0;
            while (!cards[lastCardBlack].Free || !(IsBlack(type,lastCardBlack)))
            {
                lastCardBlack++;
                if(lastCardBlack==cards.Count)
                    lastCardBlack=0;
            }

            cards[lastCardBlack].Free = false;
            return cards[lastCardBlack];

        }
    }
}
