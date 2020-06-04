using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Clase abstracta que repesenta las cartas cumpliendo con
    /// princiopio de polimorfismos por abstracción
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