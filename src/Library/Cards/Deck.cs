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
        
        public void Load(string path)
        {
            List<string> cardListFromArchive;
            try
            {
                cardListFromArchive = Archive.Read(path);
                Card card1 = null;
            
                foreach (string card in cardListFromArchive)
                {
                    string [] cardItem = card.Split(";");
                    if (cardItem[0] == "blackCardText")
                    {
                        card1 = new BlackCardText(cards.Count, cardItem[1].Trim());
                        cards.Add(card1);
                    }
                    else if (cardItem[0] == "whiteCardText")
                    {
                        card1 = new WhiteCard(cards.Count, cardItem[1].Trim());
                        cards.Add(card1);
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
        
/*
        private bool IsBlack(TypeOfGameOptions typeOfGameOptions, int position) 
        {
            
            if (typeOfGameOptions == TypeOfGameOptions.IncompletTextAndAnswerText || typeOfGameOptions == TypeOfGameOptions.IncompletTextAndFreeAnswer) 
                return cards[position] is  BlackCardText;
            else
                return cards[position] is BlackCardImage;
        }


/*
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
*/
//comenté lo de arriba porque ahora solo vamos a jugar con cartas tipo texto
//habría q cambiar el path del load si se quiere agragar otro archivo con cartas tipo imagen
//lo de respuesta libre no sé como manejarlo ni si lo vamos a hacer
        public Card GetNextCardBlack()
        {
            lastCardBlack++;
            if(lastCardBlack==cards.Count)
                lastCardBlack=0;
            while (!cards[lastCardBlack].Free || !(cards[lastCardBlack] is BlackCardText))
            {
                lastCardBlack++;
                if(lastCardBlack == cards.Count)
                    lastCardBlack = 0;
            }
                
            cards[lastCardBlack].Free = false;

            return cards[lastCardBlack];
        }
    }
}
