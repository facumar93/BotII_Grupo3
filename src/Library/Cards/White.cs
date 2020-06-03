using System;




namespace Library 
{
    /// <summary>
    /// Esta clase representa una carta blanca y hereda de de la clase "Card" por Polimorfismo.
    /// </summary>
    public class White : Card
    {
        public White(int id) : base(id)
        {
            
        }

        public override bool Equals(object obj)
        {
            bool valido = false;
            if(obj is White)
            {
                White white = (White)obj;
                if (white.id == id)
                    valido = true;
            }
            return valido;
        }

        

    }
}