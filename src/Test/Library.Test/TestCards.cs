using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Library.Test
{
    public class TestCard
    {
        
        [Test]
        public void GetNextCardWhite()
        {
            WhiteCard expected = new WhiteCard(1);
            Deck deck = new Deck();
            deck.Load();
            Assert.AreEqual(expected, deck.GetNextCardWhite());
        }
    }
}