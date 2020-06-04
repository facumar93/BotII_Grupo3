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
            White white0 = new White(1);
            BlackCard black0 = new  BlackCard(2);
            White white1 = new White(3);
            BlackCard black1 = new  BlackCard(4);
            White white2 = new White(5);
            BlackCard black2 = new  BlackCard(6);

            cards.Add(white0);
            cards.Add(black0);
            cards.Add(white1);
            cards.Add(black1);
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
                return cards[position] is  BlackCard;
            else
                return cards[position] is Image;
        }
        public BlackCard GetNextCardBlack(TypeOfGameOptions type)
        {

           lastCardBlack++;
            while (!cards[lastCardWhite].Free || !(IsBlack(type,lastCardBlack)))
            {
                lastCardBlack++;
                if(lastCardBlack==cards.Count)
                    lastCardBlack=0;
            }
                
            cards[lastCardBlack].Free = false;
            return (BlackCard)cards[lastCardBlack];

        }


        //YO HAR'IA ESTO EN VEZ DE LOS DOS METODOS ANTERIORES
        //TENER EN CUENTA Q LAS IMAGENES SON CARTAS NEGRAS TMB
        public Card GetNextCardBlack()
        {
            lastCardBlack++;
            while (!cards[lastCardBlack].Free || (cards[lastCardWhite] is White))
            {
                lastCardBlack++;
                if(lastCardWhite == cards.Count)
                    lastCardWhite = 0;
            }
                
            cards[lastCardBlack].Free = false;

            return cards[lastCardBlack];
        }
    }
}
