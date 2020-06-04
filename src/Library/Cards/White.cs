using System;




namespace Library 
{
    /// <summary>
    /// Esta clase representa una carta imagen y hereda de de la clase "Card" 
    /// cumploendo con polimorfismos por abstracción
    /// </summary>
    public class White : Card
    {
        public White(int id) : base(id)
        {
            
        }


        public override bool Equals(object obj)
        {
            bool valido=false;
            if(obj is White)
            {
                White white=(White)obj;
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