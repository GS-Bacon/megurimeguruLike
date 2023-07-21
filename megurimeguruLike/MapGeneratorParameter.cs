using System.Runtime.CompilerServices;

namespace CreateMap
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
        public MapParameter TerraData { get; set; } //地形
        public MapParameter ClimateData { get; set; }//気候帯
    }

    public struct ClimateMapData //ClimateNoise(0~1)から気候区分を設定
    {
        public MapParameter Polar { get; set; } //寒帯気候
        public MapParameter Subarctic { get; set; } //亜寒帯気候
    }

    public static class TerraMapData
    {
        public static MapParameter DeepSea
        {
            set { }
            get
            {
                MapParameter deepSea=new MapParameter();
                deepSea.ParameterDensity = 0.4;
                deepSea.ID = 1;
                deepSea.Name = "DeepSea";
                deepSea.ImageCollor = new Rgba32(0, 70, 100);
                return deepSea;
            }
        }
        public static MapParameter Sea
        {
            set { }
            get
            {
                MapParameter sea=new MapParameter();
                sea.ParameterDensity = 0.5;
                sea.ID = 2;
                sea.Name = "Sea";
                sea.ImageCollor = new Rgba32(0, 100, 150);
                return sea;
            }
        }
        public static MapParameter FordSea
        {
            set { }
            get
            {
                MapParameter fordSea=new MapParameter();
                fordSea.ParameterDensity = 0.6;
                fordSea.ID = 3;
                fordSea.Name = "FordSea";
                fordSea.ImageCollor = new Rgba32(90, 170, 250);
                return fordSea;
            }
        }
        public static MapParameter Beach
        {
            set
            {
            }
            get
            {
                MapParameter beach=new MapParameter();
                beach.ParameterDensity = 0.7;
                beach.ID = 4;
                beach.Name = "Beach";
                beach.ImageCollor = new Rgba32(255, 255, 180);
                return beach;
            }
        }
        public static MapParameter Plane
        {
            set
            {
            }
            get
            {
                MapParameter plane=new MapParameter();
                plane.ParameterDensity = 0.75;
                plane.ID = 5;
                plane.Name = "Plane";
                plane.ImageCollor = new Rgba32(60, 160, 100);
                return plane;
            }
        }
        public static MapParameter Plateau
        {
            set { }
            get
            {
                MapParameter plateau=new MapParameter();
                plateau.ParameterDensity = 0.9;
                plateau.ID = 6;
                plateau.Name = "Plateau";
                plateau.ImageCollor = new Rgba32(120, 160, 140);
                return plateau;
            }
        }
        public static MapParameter Mountain
        {
            set { }
            get
            {
                MapParameter mountain=new MapParameter();
                mountain.ParameterDensity = 0.95;
                mountain.ID = 7;
                mountain.Name = "Mountain";
                mountain.ImageCollor = new Rgba32(110, 130, 120);
                return mountain;
            }
        }

    }

    public class BiomeMapData
    { }

    public class VoidMapData
    {
        public static MapParameter TheVoid
        {
            set { }
            get
            {
                MapParameter theVoid=new MapParameter();
                theVoid.ParameterDensity = 0;
                theVoid.ID = 0;
                theVoid.Name = "TheVoid";
                theVoid.ImageCollor = new Rgba32(255, 255, 255);
                return theVoid;
            }
        }
    }
    public class MapParameter
    {
        public double ParameterDensity { get; set; }
        public int ID { get; set; }
        public string? Name { get; set; }
        public Rgba32 ImageCollor { get; set; }

    }
}