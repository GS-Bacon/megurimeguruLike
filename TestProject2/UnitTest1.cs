using CreateMap;
using test;

namespace TestProject2
{
    [TestClass]
    public class UnitTest1
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestMethod]
        public void CreateMapTest()
        {
            CreateNoise createPictures = new CreateNoise();
            createPictures.CreateMapImage(2000,2000);

        }

        [TestMethod]
        public void Ptest()
        {
            PlTest atest = new PlTest();
            atest.B();
        }
    }
}