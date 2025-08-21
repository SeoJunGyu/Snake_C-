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
        //public (int, int)[] bodyArr = new (int, int)[50];
        public LinkedList<(int col, int row)> body = new LinkedList<(int col, int row)>();
        public int index;

        public void InitBody(Map m)
        {
            Random rnd = new Random();
            col = rnd.Next(4, 10);
            row = rnd.Next(4, 10);

            body.Clear();
            m.map[col, row] = '0';
            body.AddFirst((col, row));
        }

        public void MoveBody(Map m)
        {
            if (Console.KeyAvailable)
            {
                input = Console.ReadKey(true);
                Vector2 beforeVec = dir;
                dir = input.Key switch
                {
                    ConsoleKey.RightArrow => new Vector2(1, 0),
                    ConsoleKey.LeftArrow => new Vector2(-1, 0),
                    ConsoleKey.UpArrow => new Vector2(0, -1),
                    ConsoleKey.DownArrow => new Vector2(0, 1),
                };
                // 길이가 2 이상일 때 정반대 전환 금지
                if (!(body.Count > 1 && beforeVec.X == dir.X && beforeVec.Y == dir.Y))
                {
                    return;
                }
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
