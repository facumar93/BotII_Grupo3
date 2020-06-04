using System;
using System.Collections.Generic;

namespace Library
{
    public class Round 
    {
        public IJudge judge;
        public Card blackCard { get; set;}
        private List<Card> listWhiteCardsAnswer { get; set; }

        /// <summary>
        /// Constructor de una ronda "round"
        /// </summary>
        /// <param name="judge">juez</param>
        /// <param name="blackCard">carta negra</param>
        public Round(IJudge judge, Card blackCard)
        {
            this.judge = judge;
            this.blackCard = blackCard;
            listWhiteCardsAnswer = new List<Card>();

        }

        /// <summary>
        /// Agrega las cartas blancas de respuesta a una lista "listWhiteCarsArwer"
        /// </summary>
        /// <param name="card"></param>
        public void AddAnswer(Card card)
        {
            listWhiteCardsAnswer.Add(card);
        }

        /// <summary>
        /// Método para declarar a un jugador "player" como juez "judge".
        /// </summary>
        /// <param name="player"></param>
        public void AssignJudge(User player)
        {
            judge = player;
        }

        /// <summary>
        /// Cambia el estado de la carta para que esté disponible en el mazo.
        /// </summary>
        public void GiveBackBlackCard()
        {
            blackCard.Free = true;
            foreach (Card card in listWhiteCardsAnswer)
            {
                card.Free = true;
            }
        }

        /// <summary>
        /// Enumera la lista de cartas blancas de respuesta "listWhiteCardsAnswer".
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Card> GetEnumeratorForListWhiteCardsAnswer()
        {
            return listWhiteCardsAnswer.GetEnumerator();
        }
    }
}