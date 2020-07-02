using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Esta clase representa una carta negra de tipo imagen
    /// Implementación de Polimorfismo al heredar de la clase Picture
    /// </summary>
    public class BlackCardImage : Picture
    {
        private string text;

        public BlackCardImage(int id) : base(id)
        {
    
        }


        public override bool Equals(object obj)
        {
            bool valid = false;
            if(obj is Picture)
            {
                Picture text = (Picture)obj;
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
