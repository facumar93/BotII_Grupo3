using System;
using System.Collections.Generic;
using NUnit.Framework;
using Library;

namespace Library.Test
{
    public class TestArchive
    {
        List<string> lista;

        [SetUp]
        public void Setup()
        {
            lista = Archive.Read("../../../ArchiveTestCards.csv");
        }

        [Test]
        public void OpenAndReadArchiveCorrectlyFirstLine()
        {
            Assert.AreEqual("blackCardText;ba", lista[0]);
        }

        [Test]
        public void OpenAndReadArchiveCorrectlySecondLine()
        {
            Assert.AreEqual("blackCardText;bb", lista[1]);
        }



    }
}