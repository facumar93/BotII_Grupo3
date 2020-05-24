using System;
using System.Collections.Generic;
namespace Library
{
    public class Game 
    {
        public GameType Type { get; set; }
        public List<User> userList { get; set; }
        public Game(GameType type)
        {
            Type = type;
        }
        public void AddUser(User user)
        {
            userList.Add(user);
        }
    
    }
}