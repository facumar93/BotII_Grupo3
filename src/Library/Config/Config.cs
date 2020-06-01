using System;
using System.Collections.Generic;

namespace Library
{
    public class Config 
    {
        
        public int JudgeNum { get; set; } 
        

        public Config(int judgeNum)
        {
            this.JudgeNum = judgeNum;
            
        }

        internal int CountRound()
        {
            throw new NotImplementedException();
        }
    }
}