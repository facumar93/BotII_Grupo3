using System;

namespace Library
{
    public class Game 
    {
        public GameType Type { get; set; }
        
        public Game(GameType type)
        {
            Type=type;
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