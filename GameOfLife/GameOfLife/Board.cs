using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Board
    {
        private Cell[,] cells;

        public Board(int height, int width)
        {
            if (height < 20 || width < 20) 
            {
                throw new ArgumentOutOfRangeException($"The board must be at least 20x20! Height was {height} and Width was {width}");
            }

            
        }

    }
}
