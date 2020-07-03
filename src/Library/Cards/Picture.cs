using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Clase abstracta que repesenta las cartas de tipo imagen.
    /// Implementación de polimorfismo por abstracción, a efecto de obligar
    /// a las subclases a tener los métodos.
    /// </summary>
    public abstract class Picture
    {
        /// <summary>
        /// Identificador único de la carta
        /// </summary>
        public int Id{ get; private set;}

        public bool Free { get; set; }

        public Picture(int id)
        {
            this.Id = id;
            Free = true; 
        }
    }
}
