using NUnit.Framework;
using Library;

namespace Library.Test
{
    public class TestGame
    {
        TypeOfGameOptions typeOfGameOptions;
        Game game;

        [SetUp]
        public void Setup()
        {
            typeOfGameOptions = new TypeOfGameOptions();
            
        

        }

        [Test]
        public void Test1()
        {
            game = new Game(typeOfGameOptions);
            IPlayer playerTest0 = new User("testName0");
            IJudge playerTest1 = new User("testName1");
            IPlayer playerTest2 = new User("testName2");
            IPlayer playerTest3 = new User("testName3");
            game.userList.Add((User)playerTest0);
            game.userList.Add((User)playerTest1);
            game.userList.Add((User)playerTest2);
            game.userList.Add((User)playerTest3);
            bool expected = false;
            
            Assert.AreEqual(expected, game.nextPlayer());

        }
    }
}