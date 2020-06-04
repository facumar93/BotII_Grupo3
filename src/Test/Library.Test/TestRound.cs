using NUnit.Framework;

namespace Library.Test
{
    public class TestRound
    {
        TypeOfGameOptions typeOfGameOptions;
        Game game;
        User player;
        User judge;
        BlackCard black;
        White white;
        Round round;
        
        
        [SetUp]
        public void Setup()
        {
            player = new User("xx");
            judge = new User("yy");
            black = new BlackCard(1);
            white = new White(2);
            player.AddCardToUser(white);
            round = new Round(judge, black);
            typeOfGameOptions=TypeOfGameOptions.IncompletTextAndFreeAnswer;
            game = new Game(typeOfGameOptions);
            game.AddUserToUserList(player);
            game.AddUserToUserList(judge);
        }

        [Test]
        public void Test1()
        {
            round.AddAnswer(white);
            game.Winner(white);
            int points = player.Points;
            Assert.AreEqual(1, points);

        }
    }
}
