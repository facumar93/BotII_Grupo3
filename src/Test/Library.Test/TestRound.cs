using System.Collections.Generic;
using NUnit.Framework;

namespace Library.Test
{
    public class TestRound
    {
        Game game;
        User player;
        User judge;
        BlackCardText black;
        Card white;
        Round round;
        Configuration configuration;
        List<Card> listWhiteCardsAnswer;
      
        
        
        [SetUp]
        public void Setup()
        {
            configuration = new Configuration("../../../ConfigurationTest.csv","../../../ArchiveTestCards.csv");
            game = new Game(configuration);
            round = new Round(judge, black);
            player = new User("xx", 1);
            judge = new User("yy", 2);
            black = new BlackCardText(10, "blackText1");
            round = new Round(judge, black);
            white = new WhiteCard(11, "whiteText1");
            listWhiteCardsAnswer = new List<Card>();
        }

        [Test]
        public void Increment1PointToUserWhenHisCardIsSelected()
        {
            game.AddUserToUserList(player);
            game.AddUserToUserList(judge);
            player.AddCardToUser(white);
            round.AddAnswer(white);
            game.Winner(white);
            int points = player.Points;
            Assert.AreEqual(1, points);
        }

        [Test]
        public void TestListOfAnswerCadsWithGetEnumerator()
        {
            round.AddAnswer(white);
            IEnumerator<Card> e = round.GetEnumeratorForListWhiteCardsAnswer();
            e.MoveNext();
            Assert.AreEqual(white, e.Current);
        }

        [Test]
        public void CardsFreeTurnsTrueAfterUsed()
        {
            round.AddAnswer(white);
            IEnumerator<Card> f = round.GetEnumeratorForListWhiteCardsAnswer();
            f.MoveNext();
            f.Current.Free = false;
            round.GiveBackCard();
            Assert.AreEqual(true, f.Current.Free);

            // white.Free = false;
            // round.GiveBackCard();
            // IEnumerator<Card> f = round.GetEnumeratorForListWhiteCardsAnswer();
            // f.MoveNext();
            // Assert.AreEqual(true, f.Current.Free);
            
        }
    }
}
