using System;
using System.Collections.Generic;

namespace Library
{
    public abstract class Card 
    {
        public bool Free { get; set;}

        public Card()
        {
            Free = true; 
        }
    }
}