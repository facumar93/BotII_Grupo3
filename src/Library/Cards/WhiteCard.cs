using System;




namespace Library 
{
    /// <summary>
    /// Esta clase representa una carta blanca (de respuesta) y hereda de de la clase "Card" 
    /// Implementa Polimorfismos por abstracción.
    /// </summary>
    public class WhiteCard : Card
    {
        public WhiteCard(int id) : base(id)
        {
            
        }


        public override bool Equals(object obj)
        {
            bool valido=false;
            if(obj is WhiteCard)
            {
                WhiteCard white=(WhiteCard)obj;
                if(white.id==id)
                    valido=true;
            }
            return valido;
        }

        public override int GetHashCode()
        {
            int hashCode = -1941850917;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + Free.GetHashCode();
            return hashCode;
        }

    }
}