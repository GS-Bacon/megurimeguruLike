using Xunit.Abstractions;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {

        [Fact]
        public void Test1()
        {
            MazeGame.Program mazeGame = new MazeGame.Program();
            mazeGame.BakeMap();
            char[][] map = mazeGame.MoveP("w");
            Assert.Equal(mazeGame.Map, map);
        }
        [Fact]
        public void Test2()
        {
            CreateMap.CreatePictures createMap = new CreateMap.CreatePictures();
            createMap.CreateImage();
        }


    }
}