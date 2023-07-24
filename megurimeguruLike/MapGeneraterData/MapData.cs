using System.Runtime.CompilerServices;

namespace megurimeguruLike.MapParameter
{
    public struct NoiseParameter
    {
        public double Persistenc { get; set; }
        public int Octaves { get; set; }
        public int Seed { get; set; }
    }

    public struct MapInfo
    {
        public int Hight { get; set; } //地形高さ
        public BiomeMapData BiomeData { get; set; } //バイオーム
        public double Temperature { get; set; } //地形温度
        public MapData TerraData { get; set; } //地形
        public MapData ClimateData { get; set; }//気候帯
    }

    public struct ClimateMapData //ClimateNoise(0~1)から気候区分を設定
    {
        public MapData Polar //寒帯気候
        {
            set { }
            get
            {
                MapData polar = new MapData();
                polar.ParameterDensity = 0.9;
                polar.ID = 0;
                polar.Name = "Polar";
                return polar;
            }
        }
        public MapData Subarctic
        {
            set { }
            get
            {
                MapData subarctic = new MapData();
                subarctic.ParameterDensity = 0.7;
                subarctic.ID = 1;
                subarctic.Name = "Subarctic";
                return subarctic;
            }
        }
        //亜寒帯気候

        public MapData Temperate
        {
            set { }
            get
            {
                MapData temperate = new MapData();
                temperate.ParameterDensity = 0.6;
                temperate.ID = 2;
                temperate.Name = "Temperate";
                return temperate;
            }
        }

        public MapData Tropical
        {
            set { }
            get
            {
                MapData tropical = new MapData();
                tropical.ParameterDensity = 0.3;
                tropical.ID = 3;
                tropical.Name = "Tropical";
                return tropical;
            }
        }

        public MapData Arid { set { } get { } }
    }

    public class BiomeMapData
    { }

    public class VoidMapData
    {
        public static MapData TheVoid
        {
            set { }
            get
            {
                MapData theVoid = new MapData();
                theVoid.ParameterDensity = 0;
                theVoid.ID = 0;
                theVoid.Name = "TheVoid";
                theVoid.ImageCollor = new Rgba32(255, 255, 255);
                return theVoid;
            }
        }
    }
    public class MapData
    {
        public double ParameterDensity { get; set; }
        public int ID { get; set; }
        public string? Name { get; set; }
        public Rgba32 ImageCollor { get; set; }

    }
}