using CreateMap;

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
            createPictures.CreateImage(200,200);

        }

    }
}