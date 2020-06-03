using System;
using System.Collections.Generic;
using Library;

namespace Program
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            /*
            Deck deck = new Deck();
            deck.load();
            Console.WriteLine(deck.GetNextCardWhite());
            Console.WriteLine(deck.GetNextCardWhite());
            */
            
            List<Card> lista = new List<Card>();
            
            White white0 = new White(1);
            Black black0 = new Black(2);
            White white1 = new White(3);
            Black black1 = new Black(4);
            White white2 = new White(5);
            Black black2 = new Black(6);

            lista.Add(white0);
            lista.Add(black0);

            Console.WriteLine(lista[0]);
        }   
    }
} 