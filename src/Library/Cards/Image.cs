using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Esta clase representa una carta imagen y hereda de de la clase "Card" 
    /// cumploendo con polimorfismos por abstracción
    /// </summary>
    public class Image : Card
    {

        public Image(int id) : base(id)
        {

        }

        public override bool Equals(object obj)
        {
            bool valid = false;
            if(obj is Image)
            {
                Image image = (Image)obj;
                if(image.id == id)
                    valid = true;
            }
            return valid;
        }
    }
}
