using System;
using System.Collections.Generic;

namespace Library
{
    public class Round 
    {
        public IJudge judge;
        public Black black { get; set;}
        private List<Card> ListAnswer { get; set; }

        public Round(IJudge judge, Black blackCard)
        {
            this.judge = judge;
            this.black = blackCard;
            ListAnswer = new List<Card>();

        }

        public void AddAnswer(Card card)
        {
            ListAnswer.Add(card);
        }
        public void AssignJudge(User player)
        {
            judge = player;
        }

        public void GiveBack()
        {
            black.Free = true;
            foreach (Card card in ListAnswer)
            {
                card.Free = true;
            }
        }

        //Dar puntaje

        public IEnumerator<Card> EnumeratorCardsAnswer()
        {
            return ListAnswer.GetEnumerator();
        }
    }
}