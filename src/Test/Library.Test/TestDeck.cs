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
        BlackCard blackCard2;
        Deck deck;

   

        [SetUp]
        public void Setup()
        {
            whiteCard1 = new White(1);
            blackCard2 = new BlackCard(2);
            whiteCard3 = new White(3);
            deck = new Deck();
            deck.load();

            
        }

        [Test]
        public void VerifyFirstWhiteCardInDeck()
        {
            Assert.AreEqual(whiteCard1, deck.GetNextCardWhite());
        }

        [Test]
        public void VerifyNextWhiteCardInDeck()
        {   
            deck.GetNextCardWhite();
            Assert.AreEqual(whiteCard3, deck.GetNextCardWhite());
        }
        
        //REVISAR POR QUE DA MAL
         [Test]
        public void VerifyFirstBlackCardInDeck()
        {   
            Assert.AreEqual(blackCard2, deck.GetNextCardBlack());
        }
    }
}

