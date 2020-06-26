using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Esta clase representa una carta negra de tipo imagen
    /// Implementación de Polimorfismo al heredar de la clase BlackCard
    /// </summary>
    public class BlackCardImage : BlackCard
    {

        public BlackCardImage(int id) : base(id)
        {

        }

        public override bool Equals(object obj)
        {
            bool valid = false;
            if(obj is BlackCardImage)
            {
                BlackCardImage image = (BlackCardImage)obj;
                if(image.id == id)
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
