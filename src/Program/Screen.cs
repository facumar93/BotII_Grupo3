using System;
using System.Collections.Generic;

namespace Library 

{
    /// <summary>
    ///This Class represents the "visual" of the bot
    /// </summary>
    public class Screen
    {
        /// <summary>
        /// Propery for get count of player and judge replays
        /// </summary>
        public static void SetConfiguration() //Se podría configurar tambien el tipo de juego y el ingreso de usuario acá.
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
                Console.WriteLine("Número de jugadores no permitido");//Sería lomismo ponerlo en catch?
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
            
            //Config config = new Config(judgeReplaysOnUser);´
            try
            {
                SingletonBot.Instance.CreateConfiguration(judgeReplaysOnUser,countPlayer);
                
            }
            catch(Exception ex)
            {
            
                Console.WriteLine(ex.Message);
            }
                
        }
        
         public static void StartConfigGame()
        {
            SingletonBot singletonBot = SingletonBot.Instance;
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
            while(aux < singletonBot.config.CountPlayer)
            {
                try
                {
                    Console.WriteLine("Ingrese un apodo para registrarse como jugador");
                    String name = Console.ReadLine();
                    singletonBot.AddUserToUserList(name);
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
        public static void StartGame()
        {
            SingletonBot aux = SingletonBot.Instance;
    	    for(int round=1;round<=aux.config.CountRound();round++)
            {
                Console.WriteLine("El juez : " + aux.GetJudge().ToString());
                Console.WriteLine("Mostrar pregunta :¨"+aux.CardBlack().ToString());
                Console.WriteLine("Empezar repartir respuesta");

                while(aux.NextPlayer())
                {
                    User user =aux.CurrentPlayer();
                    Console.WriteLine("Usuario :"+user.ToString());
                    Card card =seeCards(user.EnumeratorCards());
                    aux.AddAnswer(card);
                }

                Console.WriteLine("Veredicto");
                Card selection=seeCards(aux.EnumeratorCardsAnswer());
                aux.Win(selection);
            }

        }

        private static Card seeCards(IEnumerator<Card> enumerator)
        {
           
            Console.WriteLine("Seleccione una carta");
            
            int position=1;
            while(enumerator.MoveNext())
            {
                Card card=enumerator.Current;
                Console.WriteLine(position+":"+card.ToString());
                position++;
            }
            Console.Write("Seleccione una carta :");
            int pos=0;
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
            return user.GetCard(pos-1);

        }
    }
}
