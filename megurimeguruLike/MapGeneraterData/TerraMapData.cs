using CreateMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace megurimeguruLike.MapParameter
{
    public static class TerraMapData
    {
        ///<summary>
        /// 各気候ごとのパラメータ値を設定する
        /// TerraMapDataクラスの中に格納しているがなんかもっといい方法がある気もする
        /// 
        /// Set parameters for each climate
        /// stored in the TrerraMapDataClass,but I'm sure there's a better way
        ///</summary>
        public static MapData DeepSea
        {

            set { }
            get
            {
                MapData deepSea = new MapData();
                deepSea.ParameterDensity = 0.4;
                deepSea.ID = 1;
                deepSea.Name = "DeepSea";
                deepSea.ImageCollor = new Rgba32(0, 70, 100);
                return deepSea;
            }
        }
        public static MapData Sea
        {
            set { }
            get
            {
                MapData sea = new MapData();
                sea.ParameterDensity = 0.5;
                sea.ID = 2;
                sea.Name = "Sea";
                sea.ImageCollor = new Rgba32(0, 100, 150);
                return sea;
            }
        }
        public static MapData FordSea
        {
            set { }
            get
            {
                MapData fordSea = new MapData();
                fordSea.ParameterDensity = 0.6;
                fordSea.ID = 3;
                fordSea.Name = "FordSea";
                fordSea.ImageCollor = new Rgba32(90, 170, 250);
                return fordSea;
            }
        }
        public static MapData Beach
        {
            set
            {
            }
            get
            {
                MapData beach = new MapData();
                beach.ParameterDensity = 0.7;
                beach.ID = 4;
                beach.Name = "Beach";
                beach.ImageCollor = new Rgba32(255, 255, 180);
                return beach;
            }
        }
        public static MapData Plane
        {
            set
            {
            }
            get
            {
                MapData plane = new MapData();
                plane.ParameterDensity = 0.75;
                plane.ID = 5;
                plane.Name = "Plane";
                plane.ImageCollor = new Rgba32(60, 160, 100);
                return plane;
            }
        }
        public static MapData Plateau
        {
            set { }
            get
            {
                MapData plateau = new MapData();
                plateau.ParameterDensity = 0.9;
                plateau.ID = 6;
                plateau.Name = "Plateau";
                plateau.ImageCollor = new Rgba32(120, 160, 140);
                return plateau;
            }
        }
        public static MapData Mountain
        {
            set { }
            get
            {
                MapData mountain = new MapData();
                mountain.ParameterDensity = 0.95;
                mountain.ID = 7;
                mountain.Name = "Mountain";
                mountain.ImageCollor = new Rgba32(110, 130, 120);
                return mountain;
            }
        }

    }
}
