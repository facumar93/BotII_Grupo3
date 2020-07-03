using System;

namespace Library 
{
    /// <summary>
    /// Esta clase representa una carta blanca y hereda de de la clase "Card" 
    /// Implementa Polimorfismo por abstracción.
    /// </summary>
    public class WhiteCard : Card
    {
        public WhiteCard(int id, string text) : base(id, text)
        {

        }

        public override bool Equals(object obj)
        {
            bool valido=false;
            if(obj is WhiteCard)
            {
                WhiteCard white=(WhiteCard)obj;
                if(white.Id == Id)
                    valido=true;
            }
            return valido;
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