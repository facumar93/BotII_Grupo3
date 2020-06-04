using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Esta clase representa una carta negra de tipo texto
    /// Implementación de Polimorfismo al heredar de la clase BlackCard
    /// </summary>
    public class BlackCardText : BlackCard
    {

        public BlackCardText(int id) : base(id)
        {

        }

        public override bool Equals(object obj)
        {
            bool valid = false;
            if(obj is BlackCardText)
            {
                BlackCardText text = (BlackCardText)obj;
                if(text.id == id)
                    valid = true;
            }
            return valid;
        }
    }
}