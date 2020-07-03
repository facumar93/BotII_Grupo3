using System;
using System.Collections.Generic;

namespace Library
{
    public class Round 
    {
        /// <summary>
        /// Propiedad para obtener los distintos tipos de juego
        /// </summary>
        /// <value>tipo enum</value>
        public TypeOfGameOptions GameType { get; set; }
        public IJudge judge { get; set; }
        public Card BlackCard { get; set;}
        private List<Card> listWhiteCardsAnswer { get; set; }

        /// <summary>
        /// Constructor de una ronda "round"
        /// Patrón Creator, al crear una ronda se crea una lista de cartas.
        /// </summary>
        /// <param name="judge">juez</param>
        /// <param name="blackCard">carta negra</param>
        public Round(IJudge judge, Card blackCard)
        {
            this.judge = judge;
            BlackCard=blackCard;
            listWhiteCardsAnswer = new List<Card>();
        }

        /// <summary>
        /// Agrega las cartas blancas de respuesta a una lista "listWhiteCarsArwer"
        /// Agregado por Expert ya que la ronda conoce las cartas pertenecientes a la misma.
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
        public void GiveBackCard()
        {
            BlackCard.Free = true;
            foreach (Card card in listWhiteCardsAnswer)
            {
                card.Free = true;
            }
        }

        /// <summary>
        /// Enumera la lista de cartas blancas de respuesta "listWhiteCardsAnswer".
        /// Agregado por patrón Iterator para poder acceder a los elementos de la lista de cartas de respuesta
        /// sin exponer sus elementos.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Card> GetEnumeratorForListWhiteCardsAnswer()
        {
            return listWhiteCardsAnswer.GetEnumerator();
        }

        public Card CardSelectWhite(int position)
        {
            return listWhiteCardsAnswer[position];
        }
    }
}