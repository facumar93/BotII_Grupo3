using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Clase abstracta que repesenta las cartas.
    /// Implementación de polimorfismo por abstracción.
    /// </summary>
    public abstract class Card 
    {
        /// <summary>
        /// Identificador único de la carta
        /// </summary>
        public int Id{ get; private set;}

        public bool Free { get; set; }

        public Card(int id)
        {
            this.Id = id;
            Free = true; 
        }
    }
}