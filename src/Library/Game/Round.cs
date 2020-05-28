using System;

namespace Library
{
    public class Round 
    {
        public IJudge judge;
        public Card Black {get;set;}

        public Round(IJudge judge,Card cardBlack)
        {
            this.judge=judge;
            this.Black=cardBlack;

        }

        public void assignJudge(User player)
        {
            judge=player;
            
        }

        
    }
}