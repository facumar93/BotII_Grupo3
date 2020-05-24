using System;
using System.Collections.Generic;

namespace Library
{
    public class Config 
    {
        
        public int RoundNum{get;set;}
        public int LimitTime{get;set;}

        public Config(int roundNum, int limitTime)
        {
            this.RoundNum=roundNum;
            this.LimitTime=limitTime;
        }
    	
        
        
    }
}