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
            //lista = Archive.Read("/../ArchiveTestCards.csv");
            lista = Archive.Read("/Users/anakaprielian/Documents/UCU/2020/ProgramacionII/Proyecto/ultimo/BotII_Grupo3/BotII_Grupo3/src/Test/Library.Test/ArchiveTestCards.csv");
        }

        [Test]
        public void OpenAndReadArchiveCorrectlyFirstLine()
        {
            Assert.AreEqual("blackCardText;ba",lista[0]);
        }

        [Test]
        public void OpenAndReadArchiveCorrectlySecondLine()
        {
            Assert.AreEqual("blackCardText;bb",lista[1]);
        }

    }
}