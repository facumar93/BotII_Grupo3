using NUnit.Framework;
using Library;

namespace Library.Test
{
    public class TestConfig
    {
        Configuration configuration;

        int JudgeNum;
        int CountPlayer

        [SetUp]
        public void Setup()
        {
            JudgeNum { get; set; }  
            CountPlayer { get; set; }
            configuration = new Configuration("../../../ConfiguationTest.csv", "../../../ArchiveTestCards.csv");
        }
        
        [Test]
        public void NumberOfConfigurationListElementMustBeThree()
        {
            Configuration configurationTest = new Configuration("Configuration.csv");
            int excpected = 3;
            
            List[] list = configurationTest.Paraments();
            int result = 0;
            foreach(var elem in list)
            {
                result += 1;
            }
            Assert.AreEqual(result, excpected);
        }
    }
}
