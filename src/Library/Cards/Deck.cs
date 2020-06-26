using System;
using System.Collections.Generic;

namespace Library
{
    public class Deck
    {
        /// <summary>
        /// Lista de todas las cartas, tanto negras como blancas.
        /// </summary>
        /// <value>tipo Carta</value>
        private List<Card> cards{ get; set; }
        private int lastCardWhite;
        private int lastCardBlack;
        public Deck()
        {
            cards = new List<Card>();
            lastCardWhite =  -1;
            lastCardBlack = -1;
        }

        /// <summary>
        /// Método para entreverar el orden de la lista de cartas "cards".
        /// Agregado por Expert dado que Deck conoce todas las cartas.
        /// Falta implementación.
        /// </summary>
        public void Ravel()
        {

        }

        /// <summary>
        /// Método para cargar el contenido de las cartas desde un archivo externo.
        /// Contenido de prueba para los test.
        /// </summary>
        
        //***
        public void Load()
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

            foreach(Card card in cards) 
            {
                Console.WriteLine(card);
            }
        }

        /// <summary>
        /// Retorna la primera carta blanca disponible en la lista.
        /// Agregado por Expert dado que Deck conoce la lista de todas las cartas.
        /// </summary>
        /// <returns>WhiteCard</returns>
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

        /// <summary>
        /// Retorna la primera carta negra de la lista de cartas "cards", teniendo en cuenta que puede ser tipo imagen o texto.
        /// </summary>
        /// <param name="type">tipo de juego</param>
        /// <returns></returns>
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
