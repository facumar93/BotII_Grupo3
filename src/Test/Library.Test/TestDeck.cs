using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Library.Test
{
    public class TestDeck
    {
        int lastCardWhite;
        White whiteCard1;
        White whiteCard2;
        Black blackCard1;
        Black blackCard2;
        Image imageCard1;
        Image imageCard2;

        [SetUp]
        public void Setup()
        {
            whiteCard1 = new White();
            whiteCard2 = new White();
            blackCard1 = new Black();
            blackCard2 = new Black();
            imageCard1 = new Image();
            imageCard2 = new Image();
        }

        [Test]
        public void NextCardWhite()
        {
            Deck deck = new Deck();
            deck.load(whiteCard1);
            deck.load(whiteCard2);
            deck.load(blackCard1);
            deck.load(blackCard2);
            deck.load(imageCard1);
            deck.load(imageCard2);
            lastCardWhite = -1;
            Assert.AreEqual(whiteCard1, deck.GetNextCardWhite());
        }
    }
}