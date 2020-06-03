using System;
using System.Collections.Generic;

namespace Library
{
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