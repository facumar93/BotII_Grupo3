using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Library.Test
{
    public class TestUser
    {
        User user1;
        User user2;
        Card whiteCard1;
        Card blackCard;

        [SetUp]
        public void Setup()
        {
            user1 = new User("xx");
            user2 = new User("yy");
            whiteCard1 = new WhiteCard(1);
            blackCard = new BlackCardText(2);
        }

        [Test]
        public void AddOneCardToUserAndVerifyItWasAddedToCardsOfUser()
        {
            user1.AddCardToUser(whiteCard1);
            bool result = user1.EnumeratorCards().MoveNext();
            Assert.AreEqual(true, result);   
        }
    }
}