using System;
using System.Collections.Generic;

namespace Library
{
    public  class User : IJudge , IPlayer
    {

        public List<Card> cards = new List<Card>();
        public string Name{get;set;}
        public const int MaxCards = 10;

        public int Points{get;set;}

        public User(String name)
        {
            Name=name;
        }

        public IEnumerator<Card>  EnumeratorCards()
        {
            return cards.GetEnumerator();
        }
        public void addCardToUser(Card card)
        {

            if (cards.Count < MaxCards) //Sería necesario controlar?.
                cards.Add(card);
            else
                throw new Exception("No se puede dar mas de 10 cartas");
        }

        public bool belongs(Card select)
        {
            return cards.Contains(select);
        }

        public void win()
        {
           Points++;
        }


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


        public override String ToString()
        {
            return  Name;
        }

        public Card GetCard(int position)
        {
            return cards[position];
        }


        public override int GetHashCode()
        {
            int hashCode = -309160608;
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Card>>.Default.GetHashCode(cards);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Points.GetHashCode();
            return hashCode;
        }

    }
}