using System;

namespace Library 
{
    public class Screen
    {
        public static void StartConfiguration()
        {
            int cantidadTiempo;
            int cantidadRound;
            Console.WriteLine("Ingrese el tiempo");
            try{
                cantidadTiempo=Convert.ToInt32(Console.ReadLine());

            }
            catch(FormatException)
            {
                Console.WriteLine("Tiempo solamente numerico");
                cantidadTiempo=-1;
            }
            while(cantidadTiempo<=0)
            {
                Console.WriteLine("El tiempo deber ser mayor 0");
                try
                {
                    cantidadTiempo=Convert.ToInt32(Console.ReadLine());
                }
                catch(FormatException )
                {
                    Console.WriteLine("Tiempo solamente numerico");
                    cantidadTiempo=-1;
                }
            }
            Console.WriteLine("Ingrese la cantidad round");
            try{
                cantidadRound=Convert.ToInt32(Console.ReadLine());

            }
            catch(FormatException)
            {
                Console.WriteLine("Round solamente numerico");
                cantidadRound=-1;
            }
            while(cantidadRound<=0)
            {
                Console.WriteLine("El round deber ser mayor 0");
                try
                {
                    cantidadRound=Convert.ToInt32(Console.ReadLine());
                }
                catch(FormatException )
                {
                    Console.WriteLine("Round solamente numerico");
                    cantidadRound=-1;
                }
            }

            Config config=new Config(cantidadRound,cantidadTiempo);
            SingletonBot.Instance.config=config;
        }
         public static void StartGame()
        {
            Console.WriteLine("Entró"); 
            
            String[] optionsArray = new string[] {"Texto y cartas de respuesta","Texto y respuesta libre","Imagen y cartas de respuesta","Imagen y respuesta libre"};

            for (int i = 0 ; i < optionsArray.Length ; i++)
            {
                Console.WriteLine((i+1)+"-" + optionsArray[i]);
            }

            Console.WriteLine("Seleccione un modo de juego :");
            int opcion = Convert.ToInt32(Console.ReadLine());

            while (opcion > optionsArray.Length || opcion < 1)
            {
                Console.WriteLine("No ha ingrsado una opción válida, pruebe nuevamente :");
                opcion=Convert.ToInt32(Console.ReadLine());
            }
            GameType type=(GameType)(opcion-1);
            Game game=new Game(type);
            SingletonBot.Instance.StartGame(game);
        }
    }
}
