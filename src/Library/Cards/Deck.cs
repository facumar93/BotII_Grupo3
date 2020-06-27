using System;
using System.Collections.Generic;
using System.IO;

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
        public void Load(string path)
        {
            List<string> cardListFromArchive;
            try
            {
                cardListFromArchive = Archive.Read(path);
            
                foreach (string card in cardListFromArchive)
                {
                    string[] cardItem = card.Split(";");
                    int cardId = 0;
                    if (cardItem[0] == "blackCardText")
                    {
                        BlackCard blackCard = new BlackCardText(cardId, cardItem[1]);
                        cards.Add(blackCard);
                        cardId ++;
                    }
                    else if (cardItem[0] == "whiteCardText")
                    {
                        WhiteCard whiteCard = new WhiteCard(cardId, cardItem[1]);
                        cards.Add(whiteCard);
                        cardId ++;
                    }
                }
            }
           
            catch(IndexOutOfRangeException e)
            {
                throw new IndexOutOfRangeException("Archivo incompleto");
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
