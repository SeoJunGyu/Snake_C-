using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class SnakeBody
    {
        public int col;
        public int row;
        Vector2 dir = new Vector2(0f, 1f);
        ConsoleKeyInfo input = new ConsoleKeyInfo();

        public int bodyCount = 1;
        public (int, int)[] bodyArr = new (int, int)[50];
        public int index;

        public void InitBody(Map m)
        {
            Random rnd = new Random();
            col = rnd.Next(4, 10);
            row = rnd.Next(4, 10);

            m.map[col, row] = '0';
            bodyArr[0] = (col, row);
        }

        public void MoveBody(Map m)
        {
            for(int i = 0; i < bodyCount; i++)
            {
                m.map[bodyArr[i].Item1, bodyArr[i].Item2] = ' ';
                if (Console.KeyAvailable)
                {
                    input = Console.ReadKey(true);
                    switch (input.Key)
                    {
                        case ConsoleKey.RightArrow:
                            if (dir.X == 1)
                            {
                                dir.X = 1;
                                break;
                            }
                            if (dir.X == -1)
                            {
                                dir.X = -1;
                                break;
                            }

                            dir.X = 1;
                            dir.Y = 0;
                            break;
                        case ConsoleKey.LeftArrow:
                            if (dir.X == -1)
                            {
                                dir.X = -1;
                                break;
                            }
                            else if (dir.X == 1)
                            {
                                dir.X = 1;
                                break;
                            }

                            dir.X = -1;
                            dir.Y = 0;
                            break;
                        case ConsoleKey.UpArrow:
                            if (dir.Y == 1)
                            {
                                dir.Y = 1;
                                break;
                            }
                            else if (dir.Y == -1)
                            {
                                dir.Y = -1;
                                break;
                            }

                            dir.X = 0;
                            dir.Y = 1;
                            break;
                        case ConsoleKey.DownArrow:
                            if (dir.Y == -1)
                            {
                                dir.Y = -1;
                                break;
                            }
                            else if (dir.Y == 1)
                            {
                                dir.Y = 1;
                                break;
                            }

                            dir.X = 0;
                            dir.Y = -1;
                            break;
                    }
                }

                if (dir.X != 0)
                {
                    switch (dir.X)
                    {
                        case 1:
                            bodyArr[i].Item2++;
                            if(i == 0)
                            {
                                row++;
                            }
                            break;
                        case -1:
                            bodyArr[i].Item2--;
                            if (i == 0)
                            {
                                row--;
                            }
                            break;
                    }
                }
                else
                {
                    switch (dir.Y)
                    {
                        case 1:
                            bodyArr[i].Item1--;
                            if (i == 0)
                            {
                                col--;
                            }
                            break;
                        case -1:
                            bodyArr[i].Item1++;
                            if (i == 0)
                            {
                                col++;
                            }
                            break;
                    }
                }

                if (GameOver(m, i))
                {
                    index = i;
                    return;
                }

                m.map[bodyArr[i].Item1, bodyArr[i].Item2] = '0';
            }
            
        }

        public bool GameOver(Map m, int i)
        {
            if (m.map[bodyArr[i].Item1, bodyArr[i].Item2] == '-' || m.map[bodyArr[i].Item1, bodyArr[i].Item2] == '|')
            {
                return true;
            }

            return false;
        }

        public void AddBody(Map m)
        {
            bodyCount++;

            if (dir.X != 0)
            {
                switch (dir.X)
                {
                    case 1:
                        bodyArr[bodyCount].Item2 = bodyArr[bodyCount - 1].Item2 - 1;
                        break;
                    case -1:
                        bodyArr[bodyCount].Item2 = bodyArr[bodyCount - 1].Item2 + 1; ;
                        break;
                }
            }
            else
            {
                switch (dir.Y)
                {
                    case 1:
                        bodyArr[bodyCount].Item1 = bodyArr[bodyCount - 1].Item1 + 1; ;
                        break;
                    case -1:
                        bodyArr[bodyCount].Item1 = bodyArr[bodyCount - 1].Item1 - 1; ;
                        break;
                }
            }
        }

        public void BodyReset()
        {
            bodyArr = new (int, int)[50];
        }
    }
}
