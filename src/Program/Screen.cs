using System;
namespace Library 
{
    public class Screen
    {
        public static void StartConfiguration()
        {
            int quantityTime;
            int quantityRounds;
                        
           

            Console.WriteLine("Ingrese la cantidad veces que quiere ser Juez en un partido");

            try
            {
                quantityRounds = Convert.ToInt32(Console.ReadLine());
            }
            catch(FormatException)
            {
                Console.WriteLine("Ingrese valor numerico");
                quantityRounds = 0;
            }
            while(quantityRounds < 1) //Se debería hacer tantas rondas como jugadores (como mínimo).
            {
                Console.WriteLine("Es necesario una vez como mínimo");
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
            
            Config config = new Config(quantityRounds);
            SingletonBot.Instance.config = config;
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
            int opcion = Convert.ToInt32(Console.ReadLine());

            while (opcion > optionsArray.Length || opcion < 1)
            {
                Console.WriteLine("No ha ingrsado una opción válida, pruebe nuevamente :");
                opcion = Convert.ToInt32(Console.ReadLine());
            }
            
            Game.GameType type = (Game.GameType)(opcion-1);
            Game game = new Game(type);
            SingletonBot.Instance.AddNewGameToListOfGames(game); //Se instancia varias veces el singleton, ¿es la idea en sí?, ¿da igual?
        }
    }
}
