﻿﻿using System;
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
    public static class Program
    {
        /// <summary>
        /// La instancia del bot.
        /// </summary>
        private static TelegramBotClient Bot;

        /// <summary>
        /// El token provisto por Telegram al crear el bot.
        ///
        /// *Importante*:
        /// Para probar este ejemplo, crea un bot nuevo y eeemplaza este 
        /// token por el de tu bot.
        /// </summary>
        private static string Token = "1197891428:AAHjKKfBOPX2cryAx_a1af8RYj14fXePPUg";

        /// <summary>
        /// Punto de entrada.
        /// </summary>
        public static void Main()
        {
            try{

            
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
            }catch(IOException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Error,revise los archivos de configuracion o de cartas");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        /// <summary>
        /// Maneja las actualizaciones del bot (todo lo que llega), incluyendo
        /// mensajes, ediciones de mensajes, respuestas a botones, etc. En este
        /// ejemplo sólo manejamos mensajes de texto.
        /// </summary>
        /// <param name="update"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task HandleUpdateAsync(Update update, CancellationToken cancellationToken)
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

        static private string Analysis(string texto)
        {
            if(texto.ToLower().Contains("jugar"))
                return "jugar";
            else
                if(texto.ToLower().Contains("alias"))
                    return "alias";
                else
                    return "chau";
            
        }
        private static async void notifyPlayer(IEnumerator<Library.User> listUser)
        {
            while(listUser.MoveNext())
            {
                Library.User user=listUser.Current;
                await Bot.SendTextMessageAsync(user.ID, "Empieza el juego");
            }
            SingletonBot.Instance.StartGame();
            Library.User judge=(Library.User)SingletonBot.Instance.GetJudge();
            await Bot.SendTextMessageAsync(judge.ID, "Usted ahora es el juez");
            await Bot.SendTextMessageAsync(judge.ID, SingletonBot.Instance.AskBlackCard().ToString());

            listUser.Reset();
            while(listUser.MoveNext())
            {
                Library.User user=listUser.Current;
                if(user.ID!=judge.ID)
                {
                    await Bot.SendTextMessageAsync(user.ID, "Empieza el juego");
                }
                
            }
        }

        /// <summary>
        /// Maneja los mensajes que se envían al bot.
        /// </summary>
        /// <param name="message">El mensaje recibido</param>
        /// <returns></returns>
        private static async Task HandleMessageReceived(Message message)
        {
            Console.WriteLine($"Received a message from {message.From.FirstName} saying: {message.Text}");
            SingletonBot bot = SingletonBot.Instance;
            string response = "";
            string comando=Analysis(message.Text);
            switch(comando)
            {
                case "jugar": 
                    response="Excelente, dame un alias. Por favor ingrese la palabra alias";
                    break;
                case "alias":
                    try{
                        string userName=message.Text.Split(" ")[1];
                        bot.CreatUser(userName,message.Chat.Id);
                        bool empezo=bot.StartGame();
                        response="Bienvenido "+userName;
                    
                        if (empezo)
                        {
                            notifyPlayer(bot.GetListUser());
                        }
                    
                    }catch(UserException e)
                    {
                        response = e.Message;
                    }
                    
                    catch(FormatException ex)
                    {

                    }

                    catch(IndexOutOfRangeException ex)
                    {
                        response="Che, te dije alias separado con un espacio";
                    }
                    catch(Exception ex)
                    {
                        response="Sabes que, no tengo ni idea que paso";
                    }
                    break;
                    
                case "¿Cómo está el día?": 
                    response = "El día se presenta nublado con probabildiad de precipitaciones";
                    break;

                case "chau": 
                    response = "Chau! Que andes bien!";
                    break;

                case "foto":
                    // si nos piden una foto, mandamos la foto en vez de responder
                    // con un mensaje de texto.
                    await SendProfileImage(message);
                    return;
                

                default: 
                    response = "Disculpa, no se qué hacer con ese mensaje!";
                    break;
            }

            // enviamos el texto de respuesta
           await Bot.SendTextMessageAsync(message.Chat.Id, response);
            
        }

        /// <summary>
        /// Envía una imágen como respuesta al mensaje recibido.
        /// Como ejemplo enviamos siempre la misma foto.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        static async Task SendProfileImage(Message message)
        {
            await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.UploadPhoto);

            const string filePath = @"profile.jpeg";
            using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            var fileName = filePath.Split(Path.DirectorySeparatorChar).Last();
            await Bot.SendPhotoAsync(
                chatId: message.Chat.Id,
                photo: new InputOnlineFile(fileStream, fileName),
                caption: "Te ves bien!"
            );
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