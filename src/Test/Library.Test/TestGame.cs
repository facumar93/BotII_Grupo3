using NUnit.Framework;
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

        [SetUp]
        public void Setup()
        {


            testPlayer = new User("testPlayer");
            testJudge = new User("testJudge");
            black = new BlackCardText(1);
            testRound = new Round(testJudge,black);
            typeOfGameOptions=TypeOfGameOptions.IncompletTextAndFreeAnswer;
            game = new Game(typeOfGameOptions);
            
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
            User testPlayer = new User("testPlayer");           
            User user=game.GetCurrentPlayer();
            Assert.AreEqual(testPlayer, user);
        }
    }
}