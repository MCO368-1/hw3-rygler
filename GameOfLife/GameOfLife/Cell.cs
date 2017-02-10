using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public struct Cell
    {
        public bool IsAlive { get; private set; }

        public Cell(bool isAlive = false)
        {
            IsAlive = isAlive;
        }

        public void SwitchState()
        {
            IsAlive = !IsAlive;
        }
    }
}
