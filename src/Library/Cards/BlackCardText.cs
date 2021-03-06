using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Esta clase representa una carta negra de tipo texto
    /// Implementación de Polimorfismo al heredar de la clase BlackCard
    /// </summary>
    public class BlackCardText : Card
    {
        private string text;

        public BlackCardText(int id, string text) : base(id, text)
        {
    
        }


        public override bool Equals(object obj)
        {
            bool valid = false;
            if(obj is BlackCardText)
            {
                BlackCardText text = (BlackCardText)obj;
                if(text.Id == Id)
                    valid = true;
            }
            return valid;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}