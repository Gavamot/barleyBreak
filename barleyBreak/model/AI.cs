using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace barleyBreak
{
    public abstract class AI
    {
        protected readonly GameMap map;
       
        public AI(GameMap map)
        {
            this.map = map;
        }

        protected bool needPlay = false;
        private Task process; 

        public void Start()
        {
            needPlay = true;
            process = Task.Run(() =>
            {
                while (needPlay && !map.IsWinner())
                {
                    Cell cell = GetCell();
                    if (map.Swap(cell))
                    {
                        Thread.Sleep(GetStepTime());
                    }
                }
            });  
        }

        public void Stop()
        {
            needPlay = false;
        }

        public const int MIN_STEP_TIME = 400;
        public const int MAX_STEP_TIME = 1500;

        protected int GetStepTime()
        {
            return new Random(DateTime.Now.Millisecond).Next(MIN_STEP_TIME, MAX_STEP_TIME);
        }

        protected abstract Cell GetCell();
    }
}
