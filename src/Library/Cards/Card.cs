using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Clase abstracta que repesenta las cartas.
    /// Implementación de polimorfismo por abstracción, a efecto de obligar
    /// a las subclases a tener los métodos.
    /// </summary>
    public abstract class Card
    {
        /// <summary>
        /// Identificador único de la carta
        /// </summary>
        public int Id{ get; private set;}
        public string Text{ get; private set;}

        public bool Free { get; set; }

        public Card(int id, string text)
        {
            this.Id = id;
            this.Text = text;
            Free = true; 
        }

        public override string ToString()
        {
            return this.Text;
        }
    }
}