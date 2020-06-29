using System;
using System.Collections.Generic;
using NUnit.Framework;
using Library;

namespace Library.Test
{
    public class TestDeck
    {
        Deck deck;

        [SetUp]
        public void Setup()
        {
            deck = new Deck();
            deck.Load("/Users/anakaprielian/Documents/UCU/2020/ProgramacionII/Proyecto/ultimo/BotII_Grupo3/BotII_Grupo3/src/Test/Library.Test/ArchiveTestCards.csv");
        }

        [Test]
        public void VeryfyIdOfFirstWhiteCardInArchiveUsignLoadMethod()
        {
            Assert.AreEqual(10, deck.GetNextCardWhite().Id);
        }

        [Test]
        public void VerifyTextOfFirstCardWhiteUsingLoad()
        {
            Assert.AreEqual("wa", deck.GetNextCardWhite().Text);
        }

        [Test]
        public void VerifySecondCardUsingGetNextCardWhite()
        {
            deck.GetNextCardWhite();
            Assert.AreEqual("wb", deck.GetNextCardWhite().Text);
        }







    }
}



/*using System;
using System.Collections.Generic;
using NUnit.Framework;
using Library;



namespace Library.Test
{
    public class TestDeck
    {
        WhiteCard whiteCard1;
        WhiteCard  whiteCard3; 
        BlackCard blackCard2;

        BlackCardImage blackImage;
        Deck deck;

   

        [SetUp]
        public void Setup()
        {
            whiteCard1 = new WhiteCard(1);
            blackCard2 = new BlackCardText(2);
            whiteCard3 = new WhiteCard(3);
            blackImage= new BlackCardImage(7);
            deck = new Deck();
            deck.Load();
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
        
     
         [Test]
        public void VerifyFirstBlackCardTextInDeck()
        {   
            TypeOfGameOptions tipo = TypeOfGameOptions.IncompletTextAndAnswerText;
            Assert.AreEqual(blackCard2, deck.GetNextCardBlack(tipo));
        }

         [Test]
        public void VerifyFirstBlackCardImageInDeck()
        {   
            TypeOfGameOptions tipo = TypeOfGameOptions.ImageAndFreeAnswer;
            Assert.AreEqual(blackImage, deck.GetNextCardBlack(tipo));
        }
    }
}*/

