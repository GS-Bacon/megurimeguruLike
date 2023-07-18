using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CreateMap
{
    public struct NoiseParameter
    {
        public double Persistenc { get; set; }
        public int Octaves { get; set; }
        public int Seed { get; set; }
    }
    public struct TerraParameter
    {
        public double DeepSea { get; set; } = 0.7;
        public double Sea { get; set; } = 0.6;
        public double Beach { get; set; } = 0.04;

        public TerraParameter() { }
    }
}