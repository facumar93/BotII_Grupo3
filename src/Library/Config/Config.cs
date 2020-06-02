using System;
using System.Collections.Generic;

namespace Library
{
    public class Config 
    {
        //número de veces q cada jugador será juez en el juego
        //en función de esto se obtiene el número de rondas del juego
        //tener en cuenta que también se depende del número de jugadores del juego
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