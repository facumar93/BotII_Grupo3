using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Esta clase representa la configuracion del juego.
    /// Agregado por SRP.
    /// </summary>
    public class Configuration
    {

        public int JudgeNum { get; set; }  
        public int CountPlayer{ get; set; }
        public TypeOfGameOptions GameType{get;set;}
        public Configuration(string path)
        {
            List<string> config=Archive.Read(path);
            string aux=config[0];
            string[] paraments=aux.Split(';');
            this.JudgeNum = Convert.ToInt32(paraments[0]);
            this.CountPlayer = Convert.ToInt32(paraments[1]);
            this.GameType=(TypeOfGameOptions)Convert.ToInt32(paraments[2]);
        }
        /// <summary>
        /// Este método calcula la cantidad de rondas que va a tener un juego según la cantidad de veces que un jugador es juez.
        /// Se realiza teniendo en cuenta la cantidad de jugadores.
        /// Falta implentación.
        /// </summary>
        /// <returns></returns>
        public int RoundsCount()
        {
            return JudgeNum*CountPlayer;
        }
    }
}