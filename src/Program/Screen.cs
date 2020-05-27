using System;
namespace Library 
{
    public class Screen
    {
        public static void StartConfiguration()
        {
            int quantityTime;
            int quantityRounds;
                        
            Console.WriteLine("Ingrese el tiempo");

            try{
                quantityTime=Convert.ToInt32(Console.ReadLine());

            }
            catch (FormatException)
            {
                Console.WriteLine("Tiempo solamente numerico");
                quantityTime=-1;
            }
            while (quantityTime <= 0)
            {
                Console.WriteLine("El tiempo deber ser mayor 0");
                try
                {
                    quantityTime = Convert.ToInt32(Console.ReadLine());
                }
                catch(FormatException )
                {
                    Console.WriteLine("Tiempo solamente numerico");
                    quantityTime =- 1;
                }
            }

            Console.WriteLine("Ingrese la cantidad round");

            try{
                quantityRounds = Convert.ToInt32(Console.ReadLine());

            }
            catch(FormatException)
            {
                Console.WriteLine("Round solamente numerico");
                quantityRounds =- 1;
            }
            while(quantityRounds <= 0)
            {
                Console.WriteLine("El round deber ser mayor 0");
                try
                {
                    quantityRounds = Convert.ToInt32(Console.ReadLine());
                }
                catch(FormatException )
                {
                    Console.WriteLine("Round solamente numerico");
                    quantityRounds =- 1;
                }
            }
            
            Config config = new Config(quantityRounds,quantityTime);
            SingletonBot.Instance.config=config;
        }

         public static void StartGame()
        {
            String[] optionsArray = new string[] {"Texto y cartas de respuesta","Texto y respuesta libre","Imagen y cartas de respuesta","Imagen y respuesta libre"};

            for (int i = 0 ; i < optionsArray.Length ; i++)
            {
                Console.WriteLine((i+1)+"-"+optionsArray[i]);
            }

            Console.WriteLine("Seleccione un modo de juego :");
            int opcion = Convert.ToInt32(Console.ReadLine());

            while (opcion > optionsArray.Length || opcion < 1)
            {
                Console.WriteLine("No ha ingrsado una opción válida, pruebe nuevamente :");
                opcion = Convert.ToInt32(Console.ReadLine());
            }
            
            Game.GameType type = (Game.GameType)(opcion-1);
            Game game = new Game(type);
            SingletonBot.Instance.StartGame(game);
        }
    }
}
