using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal static class Feed
    {
        public static int col;
        public static int row;
        public static void MakeFeed(Map m)
        {
            Random rnd = new Random();
            do
            {
                col = rnd.Next(1, 19);
                row = rnd.Next(1, 19);
            }
            while (m.map[col, row] != ' ');

            m.map[col, row] = '*';
        }
    }
}
