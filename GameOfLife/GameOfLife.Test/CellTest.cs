using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GameOfLife.Test
{
    class CellTest
    {
        [Test]
        public void CreateCell()
        {
            var deadCell = new Cell(false);
            var aliveCell = new Cell(true);

            Assert.AreEqual(true, aliveCell.IsAlive);
            Assert.AreEqual(false, deadCell.IsAlive);
            Assert.AreEqual(false, new Cell().IsAlive);
        }

        [Test]
        public void SwitchCellState()
        {
            var cell = new Cell(false);

            cell.SwitchState();
            Assert.AreEqual(true, cell.IsAlive);

            cell.SwitchState();
            Assert.AreEqual(false, cell.IsAlive);
        }
    }
}
