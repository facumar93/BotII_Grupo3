using System;
using System.Collections.Generic;

namespace Library
{
    public abstract class Card 
    {
        public bool Free { get; set;}
        int ID { get; set; }

        public Card(int id)
        {
            Free = true;
            ID = id;
        }
    }
}