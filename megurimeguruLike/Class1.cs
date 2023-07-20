using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreateMap;

namespace megurimeguruLike
{
    public class getTerraInfo
    {
        public double TerraNoise;
        public double ClimateNoise;
        public getTerraInfo(double TerraNoise, double ClimateNoise)
        {
            this.TerraNoise = TerraNoise;
            this.ClimateNoise = ClimateNoise;
        }

        public TerraInfo Terrainfo() //バイオームノイズと地形ノイズから地形情報を決定
        {
            TerraInfo terraInfo;
            double a = TerraMapData.DeepSea.ParameterDensity;
            
            return terraInfo;
        }
    }
}
