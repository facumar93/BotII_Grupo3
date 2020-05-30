using System;
using System.Collections.Generic;

namespace Library
{
    public class Round 
    {
        public IJudge judge;
        public Card Black {get;set;}
        public List<Card> ListAnswer{get;set;}

        public Round(IJudge judge,Card cardBlack)
        {
            this.judge=judge;
            this.Black=cardBlack;
            ListAnswer=new List<Card>();

        }

        public void AddAnswer(Card card)
        {
            ListAnswer.Add(card);
        }
        public void AssignJudge(User player)
        {
            judge = player;
            
        }
        //Dar puntaje
        
    }
}