/*using NUnit.Framework;
using Library;

namespace Library.Test
{
    public class TestGame
    {
        TypeOfGameOptions typeOfGameOptions;
        Game game;
        User testPlayer;
        User testJudge;
        BlackCard black;
        Round testRound;
        long id;
        Configuration configuration;

        [SetUp]
        public void Setup()
        {
            testPlayer = new User("testPlayer", id);
            testJudge = new User("testJudge", id);
            black = new BlackCardText(1);
            testRound = new Round(testJudge);
            typeOfGameOptions=TypeOfGameOptions.IncompletTextAndFreeAnswer;
            game = new Game(configuration);
            
            game.AddUserToUserList(testJudge);
            game.AddUserToUserList(testPlayer);
            
            game.Add(testRound);
            game.NextPositionPlayer = 1;
        }
        
        [Test]
        public void FirstPlayerMustReturnTrue()
        {
            Assert.True(game.ToNextPlayer());            
        }

        [Test]
        public void FirstPlayerMustReturnFalse()
        {
            game.GetCurrentPlayer();
            Assert.False(game.ToNextPlayer());
        }

        [Test]
        public void GetCurrentPlayer()
        {
            User testPlayer = new User("testPlayer", id);           
            User user=game.GetCurrentPlayer();
            Assert.AreEqual(testPlayer, user);
        }
    }
}*/