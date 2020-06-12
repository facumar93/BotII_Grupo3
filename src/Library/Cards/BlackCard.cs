using System;


namespace Library
{
    /// <summary>
    /// Esta clase representa las cartas negras y hereda de la clase "Card".
    /// Implementación de polimorfismo por abstracción al heredar de la clase abstracta Card
    /// </summary>
    public class BlackCard : Card 
    {
        public BlackCard(int id) : base(id)
        {

        }

        /// <summary>
        /// Permite comparar los ID de las cartas
        /// </summary>
        /// <param name="obj">Un objeto</param>
        /// <returns>true o false</returns>
        public override bool Equals(object obj)
        {
            bool valid = false;
            if(obj is BlackCard)
            {
                BlackCard black = (BlackCard)obj;
                if(black.id == id)
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
