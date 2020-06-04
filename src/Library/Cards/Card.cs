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
        public int id{get;set;}
        public bool Free { get; set; }

        public Card(int id)
        {
            this.id=id;
            Free = true; 
        }
    }
}