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
        public MapParameter[] TerraMapPrameter;
        public MapParameter TheVoid;


        public getTerraInfo()
        {
            this.TerraMapPrameter = new MapParameter[]
            {
            TerraMapData.DeepSea,
            TerraMapData.Sea,
            TerraMapData.FordSea,
            TerraMapData.Beach,
            TerraMapData.Plane,
            TerraMapData.Plateau,
            TerraMapData.Mountain
            };

            this.TheVoid = VoidMapData.TheVoid;
        }


        public MapInfo Terrainfo(double TerraNoise) //バイオームノイズと地形ノイズから地形情報を決定
        {
            MapInfo terraInfo = new MapInfo();
            terraInfo.TerraData = GetRangeforNoise(TerraMapPrameter, TerraNoise);
            terraInfo.Hight = (int)terraInfo.TerraData.ParameterDensity * 255;

            return terraInfo;
        }

        /*public TerraMapData GetTerraMapDataforTerraNoise
        {


        }
        public ClimateMapData GetClimateMapDataforClimateNoise
        {

        }*/

        public MapParameter GetRangeforNoise(MapParameter[] MapParameters, double Noise)
        //与えられたNoise(0~1を取る)がMapParameter[]配列のMapPrameter.PrameterDensityのどこの範囲に入るかを決定する
        {

            MapParameter mapParameter = MapParameters[0];
            for (var i = 0; i < MapParameters.Length; i++)
            {
                var param = MapParameters[i];

                if (Noise >= param.ParameterDensity)
                {
                    if (mapParameter.ParameterDensity < param.ParameterDensity)//PrameterDensity以下はその地形or気候
                    {
                        mapParameter = param;
                    }
                }
            }
            return mapParameter;
        }
    }
}
