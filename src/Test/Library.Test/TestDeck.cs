using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Library.Test
{
    public class TestDeck
    {
        int lastCardWhite;
   

        [SetUp]
        public void Setup()
        {
          
        }

        [Test]
        public void NextCardWhite()
        {
            Deck deck = new Deck();
            deck.load();
            Assert.AreEqual("white0", Convert.ToString(deck.GetNextCardWhite()));
        }
    }
}