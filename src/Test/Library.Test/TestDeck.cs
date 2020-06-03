using System;
using System.Collections.Generic;
using NUnit.Framework;
using Library;



namespace Library.Test
{
    public class TestDeck
    {
        White whiteCard1;
        White whiteCard3;
        Black blackCard2;

   

        [SetUp]
        public void Setup()
        {
            whiteCard1 = new White(1);
            blackCard2 = new Black(2);
            whiteCard3 = new White(3);
            
        }

        [Test]
        public void VerifyNextCardWhiteIsFistIndexOfList()
        {
            Deck deck = new Deck();
            deck.load();
            Assert.AreEqual(whiteCard1, deck.GetNextCardWhite());
        }

        [Test]
        public void Verify2()
        {
            //White expected = new White(1);
            
            Deck deck = new Deck();
            deck.load();
            deck.GetNextCardWhite();
            Assert.AreEqual(whiteCard3, deck.GetNextCardWhite());
        }
    }
}

