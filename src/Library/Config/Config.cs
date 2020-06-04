using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Esta clase representa la configuracion del juego y cumple con el principio de abstracciòn
    /// </summary>
    public class Configuration
    {

        public int JudgeNum { get; set; }  
        public int CountPlayer{ get; set; }
        public Configuration(int judgeNum,int countPlayer)
        {
            this.JudgeNum = judgeNum;
            this.CountPlayer = countPlayer;
        }
        /// <summary>
        /// Este método calcula  la cantidad de rondas que va a tener
        /// un juego según la cantidad de veces que un jugador es juez 
        /// sabiendo la cantidad de jugadores
        /// </summary>
        /// <returns></returns>
        public int RoundsCount()
        {
            throw new NotImplementedException();
        }
    }
}