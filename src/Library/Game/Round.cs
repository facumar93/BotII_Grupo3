using System;
using System.Collections.Generic;

namespace Library
{
    public class Round 
    {
        public IJudge Judge;
        public Card BlackCard {get;set;}
        public List<Card> ListAnswer{get;set;}

        public Round(IJudge judge, Card blackCard)
        {
            this.Judge = judge;
            this.BlackCard = blackCard;
            ListAnswer = new List<Card>();

        }

        public void AddAnswer(Card card)
        {
            ListAnswer.Add(card);
        }
        public void AssignJudge(User player)
        {
            Judge = player;
            
        }

        internal void GiveBack() //devolver las cartas al mazo
        {
            BlackCard.Free = true;
            foreach (Card card in ListAnswer)
            {
                card.Free = true;
            }
        }
        

    }
}