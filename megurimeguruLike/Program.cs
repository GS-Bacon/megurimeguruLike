using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    class Program
    {

        static char[][] map = new char[][]
        {
            new char[5]{ '#','#','#','#','#' },
            new char[5]{ '#',' ',' ',' ','#' },
            new char[5]{ '#',' ','#',' ','#' },
            new char[5]{ '#','P','#','G','#' },
            new char[5]{ '#','#','#','#','#' },

        };

        static void DrawMap()
        {
            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    Console.Write(map[i][j]);
                }
                Console.Write(System.Environment.NewLine);
            }
        }

        static Pxy GetP()
        {
            Pxy pxy = new Pxy();
            for(int i = 0; i < map.Length;i++)
            {
                for(int j = 0; j< map[i].Length;j++)
                {
                    if (map[i][j] == 'P')
                    {
                        pxy.x = j;
                        pxy.y = i;
                    }
                }
            }
            return pxy;
        }

        static void Main()
        {
            DrawMap();
            string key = Console.ReadLine();
            DrawMap();
        }
    }
        class Pxy 
        {
            public int x;
            public int y;
        }
}