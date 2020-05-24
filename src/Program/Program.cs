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
            
            
        }
        public enum GameType
        {
            TEXT_PLUS_ANSWER_CARD,
            TEXT_PLUS_FREE_ANSWER,
            IMAGE_PLUS_ANSWER_CARD,
            IMAGE_PLUS_FREE_ANSWER
        }
    }
} 