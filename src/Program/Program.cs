using System;
using Library;

namespace Program
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            SingletonBot bot = SingletonBot.Instance;
            Screen.StartConfiguration();
            Console.WriteLine(bot.config.LimitTime);
            
        }
    }
} 