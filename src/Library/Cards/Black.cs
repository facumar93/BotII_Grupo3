using System;


namespace Library
{
    /// <summary>
    /// Esta clase representa una carta imagen y hereda de de la clase "Card" 
    /// cumploendo con polimorfismos por abstracción
    /// </summary>
    public class BlackCard : Card 
    {
        public BlackCard(int id):base(id)
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
            int hashCode = -1941850917;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + Free.GetHashCode();
            return hashCode;

        }
    }
}
