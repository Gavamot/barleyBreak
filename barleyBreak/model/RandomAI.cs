using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barleyBreak
{
    public class RandomAI : AI
    {
        public RandomAI(GameMap map) : base(map)
        {

        }

        protected override Cell GetCell()
        {
            var rnd = new Random(DateTime.Now.Millisecond);
            var EmptyCell = map.EmptyCell;
            int x = EmptyCell.X, y = EmptyCell.Y;

            int mult = rnd.Next(0, 2) == 0 ? 1 : -1;
            int dx = rnd.Next(0, 2) * mult;
            int dy = rnd.Next(0, 2) * mult;

            int newX = x + dx, newY = y + dy;

            if (newX < 0) newX = 0;
            if (newX >= map.size) newX = map.size - 1;
            if (newY < 0) newY = newY = 0;
            if (newY >= map.size) newY = map.size - 1;

            return map[newX, newY];
        }
    }
}
