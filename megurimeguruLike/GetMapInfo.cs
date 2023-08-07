using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using megurimeguruLike.MapParameter;

namespace megurimeguruLike
{
    public class getTerraInfo
    {
        public MapData[] TerraMapPrameter;
        public MapData TheVoid;


        public getTerraInfo()
        {
            //地形情報として使うMapDataを設定
            this.TerraMapPrameter = new MapData[]
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

        public MapData GetRangeforNoise(MapData[] MapDatas, double Noise)
        ///<summary>
        ///与えられたNoise(0~1を取る)がMapData[]配列のMapPrameter.PrameterDensityのどこの範囲に入るかを決定する
        ///</summary>
        ///<param name="MapDatas">使用するマップパラメータ群</param>
        ///<param name="Noise">その場所のノイズの数値</param>
        {

            MapData mapParameter = TheVoid;
            MapData minParameter = MapDatas[0];
            for (var i = 0; i < MapDatas.Length; i++)
            {
                var param = MapDatas[i];
                minParameter = (param.ParameterDensity < minParameter.ParameterDensity) ? param : minParameter;
                if (Noise >= param.ParameterDensity)
                {
                    if (mapParameter.ParameterDensity < param.ParameterDensity)//PrameterDensity以下はその地形or気候
                    {
                        mapParameter = param;
                    }
                }
            }
            mapParameter = (mapParameter == TheVoid) ? minParameter : mapParameter;//一番低い部分を一番低いパラメータで埋める
            return mapParameter;
        }
    }
}
