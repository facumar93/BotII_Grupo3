using System;

namespace Library
{
    public class Round 
    {
        public IJudge judge;

        public void assignJudge(User player)
        {
            judge=player;
            
        }

        
    }
}