using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barleyBreak
{
    public class Cell
    {
        public readonly GameMap map;
        
        public Cell(int x, int y, int value, GameMap map)
        {
            SetPosition(x, y);
            Value = value;
            this.map = map;
        }

        public void Move()
        {

            map.Swap(this);
        }

        public void SetPosition(int x, int y)
        {
            X = x;
            Y = y;
            if(onPositionChanged != null)
                onPositionChanged.Invoke(X,Y);
        }

        private Action<int,int> onPositionChanged;

        public void AddPositionChangedListner(Action<int, int> act)
        {
            onPositionChanged += act;
        }

        public void RemovePositionChangedListner(Action<int, int> act)
        {
            if (onPositionChanged != null)
                onPositionChanged -= act;
        }

        public readonly int Value = 0;
        public const int EMPTY_VALUE = 0;

        public bool IsEmpty
        {
            get { return Value <= EMPTY_VALUE; }
        }

        public int X { get; private set; }

        public int Y { get; private set; }
    }
}
