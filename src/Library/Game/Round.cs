using System;
using System.Collections.Generic;

namespace Library
{
    public class Round 
    {
        public IJudge judge;
        public BlackCard blackCard { get; set;}
        private List<Card> listWhiteCardsAnswer { get; set; }

        public Round(IJudge judge, BlackCard blackCard)
        {
            this.judge = judge;
            this.blackCard = blackCard;
            listWhiteCardsAnswer = new List<Card>();

        }

        public void AddAnswer(Card card)
        {
            listWhiteCardsAnswer.Add(card);
        }
        public void AssignJudge(User player)
        {
            judge = player;
        }

        public void GiveBackBlackCard()
        {
            blackCard.Free = true;
            foreach (Card card in listWhiteCardsAnswer)
            {
                card.Free = true;
            }
        }

        //Dar puntaje

        public IEnumerator<Card> GetEnumeratorForListWhiteCardsAnswer()
        {
            return listWhiteCardsAnswer.GetEnumerator();
        }
    }
}