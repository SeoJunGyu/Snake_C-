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

        public (int c, int r) nextHead;

        public void InitBody(Map m)
        {
            Random rnd = new Random();
            col = rnd.Next(4, 10);
            row = rnd.Next(4, 10);

            body.Clear();
            m.map[col, row] = '0';
            body.AddFirst((col, row));

            nextHead = (col, row);
        }

        public void MoveBody(Map m)
        {
            var head = body.First.Value;

            if (Console.KeyAvailable)
            {
                input = Console.ReadKey(true);
                switch(input.Key)
                {
                    case ConsoleKey.RightArrow:
                        if(dir.X != -1)
                        {
                            dir = new Vector2(1, 0);
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (dir.X != 1)
                        {
                            dir = new Vector2(-1, 0);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (dir.Y != 1)
                        {
                            dir = new Vector2(0, -1);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (dir.Y != -1)
                        {
                            dir = new Vector2(0, 1);
                        }
                        break;
                }
            }

            nextHead = (head.col + (int)dir.Y, head.row + (int)dir.X);
        }

        public bool GameOver(Map m)
        {
            if (nextHead.c <= 0 || nextHead.c >= 19 || nextHead.r <= 0 || nextHead.r >= 19)
            {
                return true;
            }

            var tail = body.Last.Value;
            char cell = m.map[nextHead.c, nextHead.r];
            bool willGrow = (cell == '*');

            if(cell == '0')
            {
                bool isTailCell = (nextHead.c == tail.col && nextHead.r == tail.row);
                if(!(isTailCell && !willGrow))
                {
                    return true;
                }
            }

            body.AddFirst((nextHead.c, nextHead.r));
            m.map[nextHead.c, nextHead.r] = '0';
            col = nextHead.c;
            row = nextHead.r;

            if(!willGrow)
            {
                var oldTail = body.Last.Value;
                body.RemoveLast();
                m.map[oldTail.col, oldTail.row] = ' ';
            }

            return false;
        }

        
    }
}
