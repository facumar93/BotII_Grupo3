using NUnit.Framework;
using Library;

namespace Library.Test
{
    public class TestGame
    {
        TypeOfGameOptions typeOfGameOptions;

        Game game; //Esto hay que hacerlo?


        [SetUp]
        public void Setup()
        {


            User testPlayer = new User("testPlayer");
            User testJudge = new User("testJudge");
            Black black = new Black(1);
            Round testRound = new Round(testJudge,black);
            typeOfGameOptions=TypeOfGameOptions.IncompletTextAndFreeAnswer;
            game = new Game(typeOfGameOptions);
            
            game.AddUserToUserList(testJudge);
            game.AddUserToUserList(testPlayer);
           
            game.rounds.Add(testRound);
            game.NextPositionPlayer = 1;

        }
        
        [Test]
        public void FirstPlayerMustReturnTrue()
        {
            
            Assert.True(game.nextPlayer());
            
            
        
        }
        [Test]
        public void FirstPlayerMustReturnFalse()
        {
           
            game.GetCurrentPlayer();

            Assert.False(game.nextPlayer());
        
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