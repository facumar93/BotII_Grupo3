using System;


namespace Library
{
    /// <summary>
    /// Esta clase representa una carta negra y hereda de de la clase "Card" por el principio de herencia
    /// </summary>
    public class Black : Card 
    {
        public Black(int id):base(id)
        {

        } 
        public override bool Equals(object obj)
        {
            bool valido = false;
            if(obj is Black)
            {
                Black black = (Black)obj;
                if (black.id==id)
                    valido = true;
            }
            return valido;
        }
    }
}
