using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Library.Test
{
    public class TestDeck
    {
        

        [Test]
        public void GetNextCardWhite()
        {
            White expected = new White(1);
            Deck deck = new Deck();
            deck.load();
            Assert.AreEqual(expected, deck.GetNextCardWhite());
        }
    }
}