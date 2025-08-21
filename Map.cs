using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Map
    {
        public char[,] map = new char[20,20];

        public void InitMap()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (i == 0 && j == 0)
                    {
                        map[i, j] = '+';
                        continue;
                    }
                    else if (i == 0 && j == 19)
                    {
                        map[i, j] = '+';
                        continue;
                    }
                    else if (i == 19 && j == 0)
                    {
                        map[i, j] = '+';
                        continue;
                    }
                    else if (i == 19 && j == 19)
                    {
                        map[i, j] = '+';
                        continue;
                    }

                    if (i == 0 || i == 19)
                    {
                        map[i, j] = '-';
                    }
                    else if (j == 0 || j == 19)
                    {
                        map[i, j] = '|';
                    }
                    else
                    {
                        map[i, j] = ' ';
                    }
                }
            }
        }

        public void ShowMap()
        {
            for(int i = 0; i < map.GetLength(0); i++)
            {
                for(int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write($"{map[i, j]}");
                }

                Console.WriteLine();
            }
        }
    }
}
