using System;
using System.Collections.Generic;

namespace Library
{
    public class Config 
    {
        public int JudgeNum { get; set; }  
        public int CountPlayer{ get; set; }
        public Config(int judgeNum,int countPlayer)
        {
            this.JudgeNum = judgeNum;
            this.CountPlayer = countPlayer;
        }
        public int CountRound()
        {
            throw new NotImplementedException();
        }
    }
}