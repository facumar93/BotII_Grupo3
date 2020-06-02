using System;
using System.Collections.Generic;

namespace Library 
{
    public class Screen
    {
        public static void StartConfiguration()
        {
            int quantityTime;
            int quantityRounds;
                        
           

            Console.WriteLine("Ingrese la cantidad de rondas por juego");

            try
            {
                quantityRounds = Convert.ToInt32(Console.ReadLine());
            }
            catch(FormatException)
            {
                Console.WriteLine("Ingrese valor numérico");
                quantityRounds = 0;
            }
            while(quantityRounds < 1) //Se debería hacer tantas rondas como jugadores (como mínimo).
            {
                Console.WriteLine("Es necesario un mínimo de una ronda para inicial el juego");
                try
                {
                    quantityRounds = Convert.ToInt32(Console.ReadLine());
                }
                catch(FormatException )
                {
                    Console.WriteLine("Ingrese la cantidad veces quiere ser Juez");
                    quantityRounds = 0;
                }
            }
            try
            {
                SingletonBot.Instance.CreatConfiguration(quantityRounds);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

         public static void StartGame()
        {
            String[] optionsArray = new string[] {"CARTAS NEGRAS y CARTAS BLANCAS","CARTAS NEGRAS y RESPUESTA POR TECLADO"
            ,"CARTAS NEGRAS DE IMAGENES y CARTAS BLANCAS","CARTAS NEGRAS DE IMAGENES y RESPUESTA POR TECLADO"};

            for (int i = 0 ; i < optionsArray.Length ; i++)
            {
                Console.WriteLine((i+1)+"-"+optionsArray[i]);
            }

            Console.WriteLine("Seleccione un modo de juego :");
            int option = Convert.ToInt32(Console.ReadLine());

            while (option > optionsArray.Length || option < 1)
            {
                Console.WriteLine("No ha ingrsado una opción válida, pruebe nuevamente :");
                option = Convert.ToInt32(Console.ReadLine());
            }
            
            //Game.GameType type = (Game.GameType)(option-1);
            //List<User> listUser = new List<User>();
            //Game game = new Game(type, listUser);
            //SingletonBot.Instance.CreateGame(type, listUser); 
        }
    }
}
