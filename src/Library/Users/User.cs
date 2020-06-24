using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// Clase que representa al usuario
    /// </summary>
    public  class User : IJudge , IPlayer
    {
        /// <summary>
        /// lista de las cartas del usuario ("mano").
        /// </summary>
        /// <typeparam name="Card">tipo Carta</typeparam>
        /// <returns></returns>
        private List<Card> userCards = new List<Card>();
        private long ID {get;set;}
        /// <summary>
        /// Nombre del usuario.
        /// </summary>
        /// <value></value>
        public string Name{ get; set; }

        /// <summary>
        /// Seteo del máximo de cartas blancas por usuario.
        /// </summary>
        public const int MaxCards = 10;

        /// <summary>
        /// Puntaje del usuario.
        /// </summary>
        /// <value></value>
        public int Points{ get; set; } 

        /// <summary>
        /// Constructor usuario.
        /// </summary>
        /// <param name="name">Nombre del usuario.</param>
        public User(String name, long id)
        {
            Name=name;
            ID=id;
        }

        /// <summary>
        /// Enumera las cartas del mazo.
        /// </summary>
        /// <returns>IEnumerator tipo Card.</returns>
        public IEnumerator<Card> EnumeratorCards()
        {
            return userCards.GetEnumerator();
        }

        /// <summary>
        /// Método para agregar cartas blancas a la mano del usuario "userCards".
        /// </summary>
        /// <param name="card">carta</param>
        public void AddCardToUser(Card card)
        {
            if (userCards.Count < MaxCards) 
                userCards.Add(card);
            else
                throw new Exception("No se puede dar mas de 10 cartas");
        }

        /// <summary>
        /// Verifica a que jugador corresponde la carta seleccionada por el juez.
        /// Agregado por Expert ya que User conoce userCards.
        /// </summary>
        /// <param name="select">Carta seleccionada por el juez.</param>
        /// <returns></returns>
        public bool Belongs(Card select)
        {
            return userCards.Contains(select);
        }

        /// <summary>
        /// Incrementa puntaje en 1.
        /// </summary>
        public void Win()
        {
           Points++;
        }

        /// <summary>
        /// Determina si el objeto especificado es igual al objeto actual.
        /// </summary>
        /// <param name="obj">objeto que se va a comparar con el actual</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            bool valido=false;
            if (obj is User)
            {
            User user=(User)obj;
                if (user.Name==this.Name)
                    valido=true;

            }
            return valido;
        }


        /// <summary>
        /// Devuelve una cadena que representa el objeto actual Nombre
        /// </summary>
        /// <returns>cadena que retorna el objeto actual Nombre</returns>
        public override String ToString()
        {
            return  Name;
        }

        /// <summary>
        /// Devuelve una carta de la mano del usuario según la posición en userCards.
        /// /// Agregado por Expert ya que User conoce userCards.
        /// </summary>
        /// <param name="position">Índice de la carta que se quiere devolver.</param>
        /// <returns></returns>
        public Card GetCard(int position)
        {
            return userCards[position];
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}