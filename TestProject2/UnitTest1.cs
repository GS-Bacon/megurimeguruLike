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
        public void TestMethod1()
        {
            CreatePictures createPictures = new CreatePictures();
            createPictures.CreateImage();

        }

        [TestMethod]
        public void TestMethod2()
        {
            CreatePictures createPictures = new CreatePictures();
            double r = createPictures.grad(1, 0.22, 23, 0);
            TestContext.WriteLine(r.ToString());
        }

        [TestMethod]

        public void TestGetGrad()
        {
            CreatePictures createPictures = new CreatePictures();
            for (uint y = 0; y < 100; y++)
            {
                for (uint x = 0; x < 100; x++)
                {
                    double r = createPictures.GetGrad(111, x, y, 0);
                    TestContext.WriteLine(r.ToString());
                }
            }
        }
    }
}