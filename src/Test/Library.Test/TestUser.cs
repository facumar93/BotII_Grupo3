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
        List<User> userList;


        [SetUp]
        public void Setup()
        {
            user1 = new User("xx");
            user2 = new User("yy");
            whiteCard1 = new White(1);
            blackCard = new BlackCard(2);
            userList = new List<User>();
            userList.Add(user1);
            userList.Add(user2);
        }

        [Test]
        public void AlAgregarUnaCartaAlUsuarioEstaSeAgregaASuListaDeCartas()
        {
            user1.addCardToUser(whiteCard1); //AddCard en mayuscula
            Assert.AreEqual(1,user1.Count());   
        }

        [Test]
        public void SeleccionCartaGanadoraUsuario1LeAumentaElPuntaje()
        {
            user1.addCardToUser(whiteCard1);
            user2.addCardToUser(blackCard);

        }
    }
}