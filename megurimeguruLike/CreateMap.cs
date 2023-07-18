﻿using System.Numerics;
using SixLabors.ImageSharp;
using System.Windows;
using SixLabors.ImageSharp.ColorSpaces;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace CreateMap
{
    public class CreateNoise
    {
        public void CreateMapImage(int ImageX = 200, int ImageY = 200, int StartX = 0, int StartY = 0, String SavePath = "..\\test.png")
        {
            //画像を生成
            var image = new Image<Rgba32>(ImageX, ImageY);

            //参考ブログ
            //https://zenn.dev/baroqueengine/books/a19140f2d9fc1a/viewer/95c334

            //海抜設定
            //後で構造体等にする
            double deepSea = 0.7;
            double sea = 0.6;
            double beach = 0.04;



            //ランダム生成ができるようになったらつかう
            //現状使用しない
            int seed = 1111;

            for (int y = 0; y < image.Width; y++)
            {
                for (int x = 0; x < image.Height; x++)
                {
                    image[x, y] = s_coloringMapforNoise(x, y, seed, true);
                }

            }

            image.Save(SavePath);
        }

        public Rgba32 s_coloringMapforNoise(int x, int y, int seed, bool mode = true)
        {

            //ノイズの濃淡によって色塗り
            TerraParameter terraParameter = new TerraParameter();
            float density = s_getTerraNoise(x, y, seed);
            if (mode)
            {
                switch (density)
                {
                    case float i when density > terraParameter.DeepSea:
                        return new Rgba32(0, 70, 100);

                    case float i when density > terraParameter.Sea && density <= terraParameter.DeepSea:
                        return new Rgba32(0, 100, 150);

                    case float i when density > terraParameter.Sea - terraParameter.Beach && density <= terraParameter.Sea:
                        return new Rgba32(225, 225, 175);

                    default:
                        return new Rgba32(60, 160, 100);

                }
            }
            else
            {
                //一色で見る用
                return new Rgba32(0, 0, density);
            }
        }

        public float s_getTerraNoise(int x, int y, int seed)
        {
            //ベース地形
            Task<float> baseDensity = Task<float>.Run(() =>
            {
                CreateNoise createNoise = new CreateNoise();
                return (float)createNoise.s_octavesNoise((double)x * 0.01, (double)y * 0.01, 0, 3, 1, 2, seed);
            });


            //海岸線の複雑性確保
            Task<float> coastlineDensity = Task<float>.Run(() =>
            {
                CreateNoise createNoise = new CreateNoise();
                return (float)createNoise.s_octavesNoise((double)x * 0.01, (double)y * 0.01, 0, 2, 20, 0.5, seed);
            });

            //ずらしてパターン性を消す
            Task<float> shiftDensity = Task<float>.Run(() =>
            {
                CreateNoise createNoise = new CreateNoise();
                return (float)createNoise.s_octavesNoise((double)(x + 256) * 0.02, (double)(y + 256) * 0.02, 0, 1, 1, 2, seed);
            });
            //海と陸をダイナミックにする
            Task<float> dynamicDensity = Task<float>.Run(() =>
            {
                CreateNoise createNoise = new CreateNoise();
                return (float)createNoise.s_octavesNoise((double)(x + 1000) * 0.001, (double)(y + 1000) * 0.001, 0, 1, 1, 2, seed);
            });

            Task[] tasks = new Task[] { baseDensity, coastlineDensity, shiftDensity, dynamicDensity };

            Task.WaitAll(tasks);
            float density = 0;
            density=baseDensity.Result;
            density *= coastlineDensity.Result;
            density *= shiftDensity.Result;
            density += dynamicDensity.Result;

            return density;
        }

        static Object lockobj = new Object();
        public double s_octavesNoise(double x, double y, double z, int Octaves, double Persistence, double frequency, int seed)//オクターブ付ノイズ
        {
            double total = 0;
            double amplitude = 10;
            double maxValue = 0;  // Used for normalizing result to 0.0 - 1.0
            CreateNoise createNoise = new CreateNoise();


            for (int i = 0; i < Octaves; i++)
            {
                total += createNoise.s_noise(x * frequency, y * frequency, z * frequency, seed) * amplitude;

                maxValue += amplitude;

                amplitude *= Persistence;
                frequency *= 2;

            }
            return total / maxValue;
        }

        //格子点固有ベクトル用インデックス ハードコーディング
        //オーバーフローしないようになってるっぽい
        public static readonly int[] permutation = new int[]
            {
            151, 160, 137, 91, 90, 15, 131, 13, 201, 95, 96, 53, 194, 233, 7, 225,
            140, 36, 103, 30, 69, 142, 8, 99, 37, 240, 21, 10, 23, 190, 6, 148,
            247, 120, 234, 75, 0, 26, 197, 62, 94, 252, 219, 203, 117, 35, 11, 32,
            57, 177, 33, 88, 237, 149, 56, 87, 174, 20, 125, 136, 171, 168, 68, 175,
            74, 165, 71, 134, 139, 48, 27, 166, 77, 146, 158, 231, 83, 111, 229, 122,
            60, 211, 133, 230, 220, 105, 92, 41, 55, 46, 245, 40, 244, 102, 143, 54,
            65, 25, 63, 161, 1, 216, 80, 73, 209, 76, 132, 187, 208, 89, 18, 169,
            200, 196, 135, 130, 116, 188, 159, 86, 164, 100, 109, 198, 173, 186, 3, 64,
            52, 217, 226, 250, 124, 123, 5, 202, 38, 147, 118, 126, 255, 82, 85, 212,
            207, 206, 59, 227, 47, 16, 58, 17, 182, 189, 28, 42, 223, 183, 170, 213,
            119, 248, 152, 2, 44, 154, 163, 70, 221, 153, 101, 155, 167, 43, 172, 9,
            129, 22, 39, 253, 19, 98, 108, 110, 79, 113, 224, 232, 178, 185, 112, 104,
            218, 246, 97, 228, 251, 34, 242, 193, 238, 210, 144, 12, 191, 179, 162, 241,
            81, 51, 145, 235, 249, 14, 239, 107, 49, 192, 214, 31, 181, 199, 106, 157,
            184, 84, 204, 176, 115, 121, 50, 45, 127, 4, 150, 254, 138, 236, 205, 93,
            222, 114, 67, 29, 24, 72, 243, 141, 128, 195, 78, 66, 215, 61, 156, 180
            };

        public int[] s_pconcat()
        {
            int[] p = new int[permutation.Length * 2];
            for (int x = 0; x < 512; x++)
            {
                p[x] = permutation[x % 256];
            }
            return p;
        }

        public double s_grad(int idex, double x, double y, double z = 0)
        {
            //格子点8つ分の固有ベクトルを求める
            //indexから最初の4ビットを取り出す
            int h = idex & 15;

            //indexの最上位ビット(MSB)が0であれば u=xとする そうでなければy
            double u = h < 8 ? x : y;

            double v;

            // 第1および第2ビットが0の場合、v = yとする
            if (h < 4)
            {
                v = y;
            }

            //最初と2番目の上位ビットが1の場合、v = xとする
            else if (h == 12 || h == 14)
            {
                v = x;
            }

            // 第1および第2上位ビットが等しくない場合（0/1、1/0）、v = zとする
            else
            {
                v = z;
            }
            // 最後の2ビットを使って、uとvが正か負かを判断する そしてそれらの加算を返す
            return ((h & 1) == 0 ? u : -u) + ((h & 2) == 0 ? v : -v);
        }

        public double s_noise(double x, double y, double z, int seed)
        {
            int[] p = s_pconcat();
            //与えられたxyzから格子点を求める
            //xyzを囲む整数座標の正方形
            //0~255までの範囲かつ負の範囲をとらない
            int xi = (int)x & 255;
            int yi = (int)y & 255;
            int zi = (int)z & 255;

            /* Console.WriteLine("xi: {0}", xi);
             Console.WriteLine("yi: {0}", yi);
             Console.WriteLine("zi: {0}", zi);
            */
            //xyz少数部を取り出す
            double xf = x - Math.Floor(x);
            double yf = y - Math.Floor(y);
            double zf = z - Math.Floor(z);

            int xa = (int)Math.Floor(x);
            int ya = (int)Math.Floor(y);
            int za = (int)Math.Floor(z);

            //取り出した小数部を滑らかにする
            double u = s_smootherStep(xf);
            double v = s_smootherStep(yf);
            double w = s_smootherStep(zf);

            //格子点の位置からpermutationの中のどれかの位置を取り出す
            //255以上にならないようにする
            int p000 = p[p[p[xi] + yi] + zi];
            int p010 = p[p[p[xi] + s_inc(yi)] + zi];
            int p001 = p[p[p[xi] + yi] + s_inc(zi)];
            int p011 = p[p[p[xi] + s_inc(yi)] + s_inc(zi)];
            int p100 = p[p[p[s_inc(xi)] + yi] + zi];
            int p110 = p[p[p[s_inc(xi)] + s_inc(yi)] + zi];
            int p101 = p[p[p[s_inc(xi)] + yi] + s_inc(zi)];
            int p111 = p[p[p[s_inc(xi)] + s_inc(yi)] + s_inc(zi)];

            double g000 = s_grad(p000, xf, yf, zf);
            double g100 = s_grad(p100, xf - 1, yf, zf);
            double g010 = s_grad(p010, xf, yf - 1, zf);
            double g001 = s_grad(p001, xf, yf, zf - 1);
            double g110 = s_grad(p110, xf - 1, yf - 1, zf);
            double g011 = s_grad(p011, xf, yf - 1, zf - 1);
            double g101 = s_grad(p101, xf - 1, yf, zf - 1);
            double g111 = s_grad(p111, xf - 1, yf - 1, zf - 1);

            double x0 = s_lerp(g000, g100, u);
            double x1 = s_lerp(g010, g110, u);
            double x2 = s_lerp(g001, g101, u);
            double x3 = s_lerp(g011, g111, u);
            double y0 = s_lerp(x0, x1, v);
            double y1 = s_lerp(x2, x3, v);
            double z0 = s_lerp(y0, y1, w);

            return (z0 + 1) / 2;

        }

        public int s_inc(int num) //numに+1した場合に256を超えたら0に戻す
        {
            return (num + 1) % permutation.Length;
        }

        public double s_smootherStep(double x) //小数点部をなめらかにするらしい
        {
            return x * x * x * (x * (x * 6 - 15) + 10);
        }

        public double s_lerp(double a, double b, double t)
        {
            return a + (b - a) * t;
        }
    }
}