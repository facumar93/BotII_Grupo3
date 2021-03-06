using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Esta clase representa la configuracion del juego.
    /// Agregado por SRP. La única razón de cambio es cambiar la configuración.
    /// </summary>
    public class Configuration
    {

        public int JudgeNum { get; set; }  
        public int CountPlayer{ get; set; }

        public string PathCards { get; set; }
        public TypeOfGameOptions GameType{ get; set; }
        public Configuration(string path, string pathCard)
        {   
            List<string> config = Archive.Read(path);
            string aux = config[0];
            string[] paraments = aux.Split(";");
            this.JudgeNum = Convert.ToInt32(paraments[0]);
            this.CountPlayer = Convert.ToInt32(paraments[1]);
            this.GameType=(TypeOfGameOptions)Convert.ToInt32(paraments[2]);
            PathCards = pathCard;
        }
        /// <summary>
        /// Este método calcula la cantidad de rondas que va a tener un juego según la cantidad de veces que un jugador es juez.
        /// Se realiza teniendo en cuenta la cantidad de jugadores dispuesta en la configuración.
        /// </summary>
        /// <returns>número de rondas</returns>
        public int RoundsCount()
        {
            return JudgeNum * CountPlayer;
        }
    }
}