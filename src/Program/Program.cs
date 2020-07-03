﻿using System;
using System.Collections.Generic;
using Telegram.Bot.Examples.Echo;


namespace Program
{
    public static class Program
    {
        public static void Main()
        {
            TelegramPlataform telegram = new TelegramPlataform();
            telegram.StartTelegram();
        }
    }
}