using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GameOfLife.Test
{
    internal class BoardTest
    {


        [Test]
        public void CreateBoard()
        {
            var board = new Board();

            for (int row = 0; row < board.Cells.GetLength(0); row++)
            {
                for (int column = 0; column < board.Cells.GetLength(1); column++)
                {
                    Assert.AreEqual(false, board.Cells[row, column].IsAlive);
                }
            }

        }

        [Test]
        public void SetBlinkerPattern()
        {
            var board = new Board();
            board.SetPattern(Pattern.Blinker);

            Assert.True(board.Cells[9, 9].IsAlive);
            Assert.True(board.Cells[9, 10].IsAlive);
            Assert.True(board.Cells[9, 11].IsAlive);
        }

        [Test]
        public void SetToadPattern()
        {
            var board = new Board();
            board.SetPattern(Pattern.Toad);

            Assert.True(board.Cells[9, 9].IsAlive);
            Assert.True(board.Cells[9, 10].IsAlive);
            Assert.True(board.Cells[9, 11].IsAlive);
            Assert.True(board.Cells[10, 8].IsAlive);
            Assert.True(board.Cells[10, 9].IsAlive);
            Assert.True(board.Cells[10, 10].IsAlive);
            
        }

        [Test]
        public void SetBeaconPattern()
        {
            var board = new Board();
            board.SetPattern(Pattern.Beacon);

            Assert.True(board.Cells[9, 8].IsAlive);
            Assert.True(board.Cells[9, 9].IsAlive);
            Assert.True(board.Cells[10, 8].IsAlive);
            Assert.True(board.Cells[10, 9].IsAlive);
            Assert.True(board.Cells[11, 10].IsAlive);
            Assert.True(board.Cells[11, 11].IsAlive);
            Assert.True(board.Cells[12, 10].IsAlive);
            Assert.True(board.Cells[12, 11].IsAlive);

        }

        [Test]
        public void SetPulsarPattern()
        {
            var board = new Board();
            board.SetPattern(Pattern.Pulsar);

            Assert.True(board.Cells[4, 5].IsAlive);
            Assert.True(board.Cells[4, 6].IsAlive);
            Assert.True(board.Cells[4, 7].IsAlive);
            Assert.True(board.Cells[4, 11].IsAlive);
            Assert.True(board.Cells[4, 12].IsAlive);
            Assert.True(board.Cells[4, 13].IsAlive);
            Assert.True(board.Cells[6, 3].IsAlive);
            Assert.True(board.Cells[6, 8].IsAlive);
            Assert.True(board.Cells[6, 10].IsAlive);
            Assert.True(board.Cells[6, 15].IsAlive);
            Assert.True(board.Cells[7, 3].IsAlive);
            Assert.True(board.Cells[7, 8].IsAlive);
            Assert.True(board.Cells[7, 10].IsAlive);
            Assert.True(board.Cells[7, 15].IsAlive);
            Assert.True(board.Cells[8, 3].IsAlive);
            Assert.True(board.Cells[8, 8].IsAlive);
            Assert.True(board.Cells[8, 10].IsAlive);
            Assert.True(board.Cells[8, 15].IsAlive);
            Assert.True(board.Cells[9, 5].IsAlive);
            Assert.True(board.Cells[9, 6].IsAlive);
            Assert.True(board.Cells[9, 7].IsAlive);
            Assert.True(board.Cells[9, 11].IsAlive);
            Assert.True(board.Cells[9, 12].IsAlive);
            Assert.True(board.Cells[9, 13].IsAlive);
            Assert.True(board.Cells[11, 5].IsAlive);
            Assert.True(board.Cells[11, 6].IsAlive);
            Assert.True(board.Cells[11, 7].IsAlive);
            Assert.True(board.Cells[11, 11].IsAlive);
            Assert.True(board.Cells[11, 12].IsAlive);
            Assert.True(board.Cells[11, 13].IsAlive);
            Assert.True(board.Cells[12, 3].IsAlive);
            Assert.True(board.Cells[12, 8].IsAlive);
            Assert.True(board.Cells[12, 10].IsAlive);
            Assert.True(board.Cells[12, 15].IsAlive);
            Assert.True(board.Cells[13, 3].IsAlive);
            Assert.True(board.Cells[13, 8].IsAlive);
            Assert.True(board.Cells[13, 10].IsAlive);
            Assert.True(board.Cells[13, 15].IsAlive);
            Assert.True(board.Cells[14, 3].IsAlive);
            Assert.True(board.Cells[14, 8].IsAlive);
            Assert.True(board.Cells[14, 10].IsAlive);
            Assert.True(board.Cells[14, 15].IsAlive);
            Assert.True(board.Cells[16, 5].IsAlive);
            Assert.True(board.Cells[16, 6].IsAlive);
            Assert.True(board.Cells[16, 7].IsAlive);
            Assert.True(board.Cells[16, 11].IsAlive);
            Assert.True(board.Cells[16, 12].IsAlive);
            Assert.True(board.Cells[16, 13].IsAlive);  
        }

        [Test]
        public void SetPentadecathlonTest()
        {
            Board board = new Board();
            board.SetPattern(Pattern.Pentadecathlon);

            Assert.True(board.Cells[8, 7].IsAlive);
            Assert.True(board.Cells[8, 12].IsAlive);
            Assert.True(board.Cells[9, 5].IsAlive);
            Assert.True(board.Cells[9, 6].IsAlive);
            Assert.True(board.Cells[9, 8].IsAlive);
            Assert.True(board.Cells[9, 9].IsAlive);
            Assert.True(board.Cells[9, 10].IsAlive);
            Assert.True(board.Cells[9, 11].IsAlive);
            Assert.True(board.Cells[9, 13].IsAlive);
            Assert.True(board.Cells[9, 14].IsAlive);
            Assert.True(board.Cells[10, 7].IsAlive);
            Assert.True(board.Cells[10, 12].IsAlive);
        }
    }
}
