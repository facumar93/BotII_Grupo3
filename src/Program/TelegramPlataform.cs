using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using Library;
namespace Telegram.Bot.Examples.Echo


{
    /// <summary>
    /// Patrón Facade, Una clase que proporciona una interfaz simple
    /// a un subsistema complejo que contiene muchas partes móviles
    /// Polimorfismo, implementa interfaz IPlataform, la cual debe implementarse si se agregan otras plataformas.
    /// </summary>
    public class TelegramPlataform : Iplataform
    {
        /// <summary>
        /// La instancia del bot.
        /// </summary>
        private TelegramBotClient Bot;
        private Library.User userLast;

        /// <summary>
        /// El token provisto por Telegram al crear el bot.
        /// </summary>
        private string Token = "1233573256:AAHEaVfEcObCTrJ27hQJOclZ-eTtRKS8JPE";

        /// <summary>
        /// Punto de entrada.
        /// </summary>
        public void StartTelegram()
        {
            Bot = new TelegramBotClient(Token);
            var cts = new CancellationTokenSource();
            SingletonBot bot = SingletonBot.Instance; 
            bot.CreateGame("configuration.csv","cards.csv");
            // Comenzamos a escuchar mensajes. Esto se hace en otro hilo (en _background_).
            Bot.StartReceiving(
                new DefaultUpdateHandler(HandleUpdateAsync, HandleErrorAsync),
                cts.Token
            );

            Console.WriteLine($"Bot is Up!");

            // Esperamos a que el usuario aprete Enter en la consola para terminar el bot.
            Console.ReadLine();

            // Terminamos el bot.
            cts.Cancel();
        }

        /// <summary>
        /// Notifica al juez y le muestra su carta negra
        /// </summary>
        /// <returns></returns>
        private async void NotifyJudge()
        {
            SingletonBot bot = SingletonBot.Instance;
            Library.User judge = (Library.User)bot.GetJudge();
            Card cardBlack = bot.AskBlackCard();
            await Bot.SendTextMessageAsync(judge.ID, "Sos el juez");
            await Bot.SendTextMessageAsync(judge.ID, "Tu carta es "+ cardBlack.ToString());
        }
        /// <summary>
        /// Maneja las actualizaciones del bot (todo lo que llega), incluyendo
        /// mensajes, ediciones de mensajes, respuestas a botones, etc. En este
        /// ejemplo sólo manejamos mensajes de texto.
        /// </summary>
        /// <param name="update"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task HandleUpdateAsync(Update update, CancellationToken cancellationToken)
        {
            try 
            {
                // sólo respondemos a mensajes de texto
                if (update.Type == UpdateType.Message)
                {
                    await HandleMessageReceived(update.Message);
                }
            }
            catch(Exception e)
            {
                await HandleErrorAsync(e, cancellationToken);
            }
        }

        /// <summary>
        /// Notifica a todos los jugadores que empezó el juego.
        /// </summary>
        /// <returns></returns>
        private async void NotifyPlayer()
        {
            SingletonBot bot = SingletonBot.Instance;
            IEnumerator<Library.User> listUser = bot.GetListUser();
            while(listUser.MoveNext())
            {
                Library.User user = listUser.Current;
                await Bot.SendTextMessageAsync(user.ID, "Empieza el juego, espera que se repartan las cartas");
            }
        }

        /// <summary>
        /// Muestra a los jugadores que no son juez la carta negra, y sus cartas como opciones de respuesta.
        /// </summary>
        /// <returns></returns>
        private async void NotifyPlayerBlackCardAndWhiteCards()
        {
            SingletonBot bot = SingletonBot.Instance;
            Card blackCard = bot.AskBlackCard();
            await Bot.SendTextMessageAsync(userLast.ID, "Carta del juez: "+ blackCard.Text);
            IEnumerator<Card> iteratorCardWhite = userLast.EnumeratorCards();
            int i = 1;
            while(iteratorCardWhite.MoveNext())
            {
                Card card = iteratorCardWhite.Current;
                await Bot.SendTextMessageAsync(userLast.ID, "Opcion "+ i + ": " + card.ToString());
                i++;
            }
            await Bot.SendTextMessageAsync(userLast.ID, "Seleccione una carta ingresando el número elegido seguido de Opción. Ejemplo: Opción 1");
        }

        /// <summary>
        /// Método para captar determinadas palabras como parte del texto y retornarlas.
        /// De lo contrario devuelve el texto completo.
        /// </summary>
        /// <param name="text">texto que contiene la palabra a capturar</param>
        /// <returns>palabra capturada, de lo contrario texto completo</returns>
        private string Analysis(string text)
            {
                if (text.ToLower().Contains("alias"))
                    return "alias";
                else
                    if (text.ToLower().Contains("opcion"))
                    {
                        return "opcion";
                    }
                    else
                        return text.ToLower();
            }

        /// <summary>
        /// Se muestra al juez las opciones de respuestas, y se le pide que seleccione la ganadora.
        /// </summary>
        /// <returns></returns>
        private async void NotifyJudge2()
        {
            SingletonBot bot = SingletonBot.Instance;
            IEnumerator<Card> iteratorCardWhite = bot.AskEnumeratorCardsAnswer();
            int i=1;
            Library.User judge = (Library.User)bot.GetJudge();
            await Bot.SendTextMessageAsync(judge.ID, "Selecciona la carta ganadora. Ejemplo: Opción 1");
            while(iteratorCardWhite.MoveNext())
            {
                Card card=iteratorCardWhite.Current;
                await Bot.SendTextMessageAsync(judge.ID, "Opcion " + i + ": " + card.ToString());
                i++;
            }

            await Bot.SendTextMessageAsync(judge.ID, "Seleccione una carta: ");
        }

        /// <summary>
        /// Notifica la carta ganadora a los jugadores
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        private async void notifyWin(Card card)
        {
            SingletonBot bot = SingletonBot.Instance;
            IEnumerator<Library.User> listUser=bot.GetListUser();
            while(listUser.MoveNext())
            {
                Library.User user = listUser.Current;
                await Bot.SendTextMessageAsync(user.ID, "El juez seleccionó esta carta :"+card);
            }
        }
        /// <summary>
        /// Maneja los mensajes que se envían al bot.
        /// </summary>
        /// <param name="message">El mensaje recibido</param>
        /// <returns></returns>
        private async Task HandleMessageReceived(Message message)
        {
            Console.WriteLine($"Received a message from {message.From.FirstName} saying: {message.Text}");
            SingletonBot bot = SingletonBot.Instance;
            string response = "";
            string comand = Analysis(message.Text);

            switch(comand)
            {
                case "/start":
                    response = "Bienvenid@ a Cards Against Programming! ¿Quieres jugar? Responde sí o no";
                    break;

                case "no":
                    response = "Te lo pierdes! Esperamos verte pronto.";
                    break;
                
                case "si":
                case "sí":
                    response = "Excelente! Responde cómo quieres llamarte seguido de la palabra alias. Ejemplo: alias Carmen.";
                    break;
                
                case "alias":
                    try{
                        string userName = message.Text.Split(" ")[1];
                        bot.CreatUser(userName, message.Chat.Id);
                        bool isStart = bot.StartGame();
                        response = "Bien " + userName + "! Se creó tu alias correctamente.";
                    
                        if (isStart)
                        {
                            NotifyPlayer();
                            NotifyJudge();
                            userLast = bot.AskCurrentPlayer();
                            NotifyPlayerBlackCardAndWhiteCards();
                        }
                    
                    }catch(UserException e)
                    {
                        response = e.Message;
                    }

                    catch(IndexOutOfRangeException)
                    {
                        response = "Che, te dije alias separado con un espacio";
                    }

                    catch(Exception)
                    {
                        response="Sabes que, no tengo ni idea que paso";
                    }
                    break;
                    
                case "opcion":
                case "opción":
                    try
                    {
                        Library.User judge = (Library.User)bot.GetJudge(); 
                        int number = Convert.ToInt32(message.Text.Split(" ")[1])-1;
                        if(number < 0 || number > 9)
                        {
                            response = "Debes elegir una opción del 1 al 10. Elemplo: Opción 1";
                        }
                        else
                               {
                                    if(bot.isAskNextPlayer())
                                    {
                                        userLast = bot.GetUserActually();
                                        Card cardSelect=userLast.GetCard(number);
                                        bot.AddAnswer(cardSelect);
                                        //Siguiente jugador, si hay muestro sus cartas y la pregunta
                                        NotifyPlayerBlackCardAndWhiteCards();
                                    }
                                    else
                                    {
                                        if(message.Chat.Id != judge.ID)
                                        {
                                            Card cardSelect = userLast.GetCard(number);
                                            Console.WriteLine(cardSelect);
                                            bot.AddAnswer(cardSelect);
                                            //Mostrar las cartas de respuesta de cada jugador
                                            NotifyJudge2();
                                        }
                                        else{//Responde el juez
                                            Card cardWin = bot.CardSelectWhite(number);
                                            notifyWin(cardWin);
                                            bot.AskWinner(cardWin);
                                            NotifyJudge();
                                            userLast = bot.GetUserActually();
                                            NotifyPlayerBlackCardAndWhiteCards();
                                        }
                                        
                                    }
                                    
                                }
                            
                        }

                    catch(FormatException)
                    {
                        response = "Debes elegir un número del 1 al 10. Elemplo: Opción 1";
                    }

                break;
               
                default: 
                    response = "Disculpa, no se qué hacer con ese mensaje!";
                    break;
            }

            // enviamos el texto de respuesta
           await Bot.SendTextMessageAsync(message.Chat.Id, response);  
        }

        /// <summary>
        /// Manejo de excepciones. 
        /// Por ahora simplemente la imprimimos en la consola.
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task HandleErrorAsync(Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(exception.Message);
            return Task.CompletedTask;
        }

    }
}