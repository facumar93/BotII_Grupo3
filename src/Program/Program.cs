using System;
using System.Collections.Generic;
using Library;

namespace Program
{
    public class Program
    {
        
        public static void Main(string[] args)
        {

            SingletonBot bot = SingletonBot.Instance; 
            Screen.SetConfiguration();
        }
        
    }
} 