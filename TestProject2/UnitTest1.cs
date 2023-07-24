using CreateMap;
using megurimeguruLike;
using megurimeguruLike.MapParameter;
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
            createPictures.createMapImage(200, 200,2000,1000);

        }

        [TestMethod]
        public void Test2()
        {
            getTerraInfo gti = new getTerraInfo();
            //gti.TerraNoise = 0.1;
            MapData a = gti.GetRangeforNoise(gti.TerraMapPrameter, 0.1);
            Console.WriteLine(a.Name);

        }
    }
}