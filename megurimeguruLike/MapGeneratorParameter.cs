using System.Runtime.CompilerServices;

namespace CreateMap
{
    public struct NoiseParameter
    {
        public double Persistenc { get; set; }
        public int Octaves { get; set; }
        public int Seed { get; set; }
    }
    public struct TerracollaringParameter
    {
        public double DeepSea { get; set; } = 0.7;
        public double Sea { get; set; } = 0.6;
        public double Beach { get; set; } = 0.04;

        public TerracollaringParameter() { }
    }

    public struct TerraInfo
    {
        public int Hight { get; set; } //地形高さ
        public BiomeMapData BiomeData { get; set; } //バイオーム
        public double Temperature { get; set; } //地形温度
        public TerraMapData TerraData { get; set; } //地形
        public ClimateMapParameter ClimateData { get; set; }//気候帯
    }

    public struct ClimateMapParameter //ClimateNoise(0~1)から気候区分を設定
    {
        public MapParameterValue Polar { get; set; } //寒帯気候
        public MapParameterValue Subarctic { get; set; } //亜寒帯気候
    }

    public static class TerraMapData
    {
        public static MapParameterValue DeepSea
        {
            private set { }
            get
            {
                DeepSea.ParameterDensity = 0.8;
                DeepSea.ID = 1;
                DeepSea.Name = "DeepSea";
                DeepSea.ImageCollor = new Rgba32(0, 70, 100);
                return DeepSea;
            }
        }

        public static MapParameterValue Sea
        {
            private set { }
            get {
                Sea.ParameterDensity = 0.7;
                DeepSea.ID = 1;
                DeepSea.Name = "Sea";
                DeepSea.ImageCollor = new Rgba32(0, 100, 150);
                return Sea;
                    }
        }
        public static MapParameterValue FordSea { get; set; }
        public static MapParameterValue Beach { get; set; }
        public static MapParameterValue Plane { get; set; }
        public static MapParameterValue Plateau { get; set; }
        public static MapParameterValue Mountain { get; set; }

    }

    public struct BiomeMapData
    { }

    public class MapParameterValue
    {
        public double ParameterDensity { get; set; }
        public int ID { get; set; }
        public string? Name { get; set; }
        public Rgba32 ImageCollor { get; set; }

    }
}