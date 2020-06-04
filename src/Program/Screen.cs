using System;
using System.Collections.Generic;

namespace Library 

{
    /// <summary>
    /// Representa la visual del bot.
    /// </summary>
    public class Screen
    {
    
        /// <summary>
        /// Crea instacia del Bot.
        /// </summary>
        static SingletonBot singletonBot = SingletonBot.Instance;

        /// <summary>
        /// Método para configurar la cantidad de jugadores y número de veces en que un jugador es juez.  
        /// </summary>
        public static void SetConfiguration() 
        {
            int countPlayer;
            int judgeReplaysOnUser;
    
            Console.WriteLine("Ingrese la cantidad de jugadores, 4 como mínimo :"); 
            
            try
            {
                countPlayer = Convert.ToInt32(Console.ReadLine());
            }
            catch(FormatException)
            {
                Console.WriteLine("Ingrese valor numerico");
                countPlayer = 0;
            }
            while(countPlayer < 4) 
            {

                Console.WriteLine("Número de jugadores no permitido");

                try
                {
                    countPlayer = Convert.ToInt32(Console.ReadLine());
                }
                catch(FormatException )
                {
                    countPlayer = 0;
                }
            }
            
            Console.WriteLine("Ingrese la cantidad veces que todos los jugadores serán juez."); 
            
            try
            {
                judgeReplaysOnUser = Convert.ToInt32(Console.ReadLine());
            }
            catch(FormatException)
            {
                Console.WriteLine("Ingrese valor numerico");
                judgeReplaysOnUser = 0;
            }
            while(judgeReplaysOnUser < 1) 
            {
                Console.WriteLine("Es necesario una vez como mínimo");
                try
                {
                    judgeReplaysOnUser = Convert.ToInt32(Console.ReadLine());
                }
                catch(FormatException )
                {
                    Console.WriteLine("Ingrese la cantidad veces quiere ser Juez");
                    judgeReplaysOnUser = 0;
                }
            }
            try
            {
                singletonBot.CreateConfiguration(judgeReplaysOnUser,countPlayer);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
                
        }

        /// <summary>
        /// Método para seleccionar un tipo de juego, registrar usuario y dar inicio a un juego.
        /// </summary>
        
         public static void StartConfigGame()
        {
            String[] typeOfGameOptionsArray = new string[] {"CARTAS NEGRAS y CARTAS BLANCAS","CARTAS NEGRAS y RESPUESTA POR TECLADO"
            ,"CARTAS NEGRAS DE IMAGENES y CARTAS BLANCAS","CARTAS NEGRAS DE IMAGENES y RESPUESTA POR TECLADO"};

            for (int i = 0 ; i < typeOfGameOptionsArray.Length ; i++)
            {
                Console.WriteLine((i+1) + "-" +typeOfGameOptionsArray[i]);
            }

            Console.WriteLine("Seleccione un modo de juego :");
            int typeOfGameOptionsNumber = Convert.ToInt32(Console.ReadLine());

            while (typeOfGameOptionsNumber > typeOfGameOptionsArray.Length || typeOfGameOptionsNumber < 1)
            {
                Console.WriteLine("No ha ingresado una opción válida, pruebe nuevamente :");
                typeOfGameOptionsNumber = Convert.ToInt32(Console.ReadLine());
            }
            TypeOfGameOptions type = (TypeOfGameOptions)(typeOfGameOptionsNumber - 1);
            
            singletonBot.CreateGame(type);

            int aux = 0;
            while(aux < singletonBot.configuration.CountPlayer)
            {
                try
                {
                    Console.WriteLine("Ingrese un apodo para registrarse como jugador");
                    String name = Console.ReadLine();

                    singletonBot.CreatUser(name);

    	            aux++;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Error, ingrese otra vez");
                }
                
            }
            singletonBot.StartGame();

        
        }
        /// <summary>
        /// Método que permite el funcionamiento del juego mostrando por pantalla.
        /// </summary>
        public static void PlayGame()
        {
           
    	    for(int round = 1 ; round <= singletonBot.configuration.RoundsCount() ; round++)
            {
                Console.WriteLine("El juez : " + singletonBot.GetJudge().ToString());
                Console.WriteLine("Mostrar pregunta : " + singletonBot.AskBlackCard().ToString());
                Console.WriteLine("Empezar repartir respuesta");

                while(singletonBot.AskNextPlayer())
                {
                    User user = singletonBot.AskCurrentPlayer();
                    Console.WriteLine("Usuario :" + user.ToString());
                    Card card = PlayerSeeCards(user.EnumeratorCards());
                    singletonBot.AddAnswer(card);
                }

                Console.WriteLine("Veredicto");
                Card selection = PlayerSeeCards(singletonBot.AskEnumeratorCardsAnswer());
                singletonBot.AskWinner(selection);
            }

        }
        
        /// <summary>
        /// Método para que el usuario vea y seleccione cartas.
        /// </summary>
        /// <param name="enumerator"></param>
        /// <returns></returns>
        private static Card PlayerSeeCards(IEnumerator<Card> enumerator)
        {
           List<Card>lista=new List<Card>();
            Console.WriteLine("Seleccione una carta");
            
            int position = 1;
            while(enumerator.MoveNext())
            {
                Card card = enumerator.Current;
                lista.Add(card);
                Console.WriteLine(position + ":" + card.ToString());
                position++;
            }
            Console.Write("Seleccione una carta :");
            int pos = 0;

            try{
                pos=Convert.ToInt32(Console.ReadLine());
            }            
            catch(Exception ex)
            {
                Console.WriteLine("Solamente ingrese numero");
                pos=0;
            }

            while(pos<=0 || pos>10)
            {
                try{
                    Console.WriteLine("Error, selecione entre 1 a "+position);
                    pos=Convert.ToInt32(Console.ReadLine());
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Solamente ingrese numero");
                    pos=0;
                }
            }
            return lista[pos];
        }
    }
}
