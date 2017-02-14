using System;
using System.Text;

namespace GameOfLife
{
    public class Board
    {
        public Cell[,] Cells { get; }

        public Board()
        {
            const int height = 20;
            const int width = 20;
            Cells = new Cell[height, width];

            for (var row = 0; row < height; row++)
                for (var column = 0; column < width; column++)
                    Cells[row, column] = new Cell();
        }

        public Board SetPattern(Pattern pattern)
        {
            switch (pattern)
            {
                case Pattern.Blinker:
                    SetBlinker();
                    break;
                case Pattern.Toad:
                    SetToad();
                    break;
                case Pattern.Beacon:
                    SetBeacon();
                    break;
                case Pattern.Pulsar:
                    SetPulsar();
                    break;
                case Pattern.Pentadecathlon:
                    SetPentadecathlon();
                    break;
                case Pattern.Random:
                    SetRandom();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(pattern), pattern, null);
            }

            return this;
        }

        private void SetBlinker()
        {
            Cells[9, 9].IsAlive = true;
            Cells[9, 10].IsAlive = true;
            Cells[9, 11].IsAlive = true;
        }

        private void SetToad()
        {
            Cells[9, 9].IsAlive = true;
            Cells[9, 10].IsAlive = true;
            Cells[9, 11].IsAlive = true;
            Cells[10, 8].IsAlive = true;
            Cells[10, 9].IsAlive = true;
            Cells[10, 10].IsAlive = true;
        }

        private void SetBeacon()
        {
            Cells[9, 8].IsAlive = true;
            Cells[9, 9].IsAlive = true;
            Cells[10, 8].IsAlive = true;
            Cells[10, 9].IsAlive = true;
            Cells[11, 10].IsAlive = true;
            Cells[11, 11].IsAlive = true;
            Cells[12, 10].IsAlive = true;
            Cells[12, 11].IsAlive = true;
        }

        private void SetPulsar()
        {
            Cells[4, 5].IsAlive = true;
            Cells[4, 6].IsAlive = true;
            Cells[4, 7].IsAlive = true;
            Cells[4, 11].IsAlive = true;
            Cells[4, 12].IsAlive = true;
            Cells[4, 13].IsAlive = true;
            Cells[6, 3].IsAlive = true;
            Cells[6, 8].IsAlive = true;
            Cells[6, 10].IsAlive = true;
            Cells[6, 15].IsAlive = true;
            Cells[7, 3].IsAlive = true;
            Cells[7, 8].IsAlive = true;
            Cells[7, 10].IsAlive = true;
            Cells[7, 15].IsAlive = true;
            Cells[8, 3].IsAlive = true;
            Cells[8, 8].IsAlive = true;
            Cells[8, 10].IsAlive = true;
            Cells[8, 15].IsAlive = true;
            Cells[9, 5].IsAlive = true;
            Cells[9, 6].IsAlive = true;
            Cells[9, 7].IsAlive = true;
            Cells[9, 11].IsAlive = true;
            Cells[9, 12].IsAlive = true;
            Cells[9, 13].IsAlive = true;
            Cells[11, 5].IsAlive = true;
            Cells[11, 6].IsAlive = true;
            Cells[11, 7].IsAlive = true;
            Cells[11, 11].IsAlive = true;
            Cells[11, 12].IsAlive = true;
            Cells[11, 13].IsAlive = true;
            Cells[12, 3].IsAlive = true;
            Cells[12, 8].IsAlive = true;
            Cells[12, 10].IsAlive = true;
            Cells[12, 15].IsAlive = true;
            Cells[13, 3].IsAlive = true;
            Cells[13, 8].IsAlive = true;
            Cells[13, 10].IsAlive = true;
            Cells[13, 15].IsAlive = true;
            Cells[14, 3].IsAlive = true;
            Cells[14, 8].IsAlive = true;
            Cells[14, 10].IsAlive = true;
            Cells[14, 15].IsAlive = true;
            Cells[16, 5].IsAlive = true;
            Cells[16, 6].IsAlive = true;
            Cells[16, 7].IsAlive = true;
            Cells[16, 11].IsAlive = true;
            Cells[16, 12].IsAlive = true;
            Cells[16, 13].IsAlive = true;
        }

        private void SetPentadecathlon()
        {
            Cells[8, 7].IsAlive = true;
            Cells[8, 12].IsAlive = true;
            Cells[9, 5].IsAlive = true;
            Cells[9, 6].IsAlive = true;
            Cells[9, 8].IsAlive = true;
            Cells[9, 9].IsAlive = true;
            Cells[9, 10].IsAlive = true;
            Cells[9, 11].IsAlive = true;
            Cells[9, 13].IsAlive = true;
            Cells[9, 14].IsAlive = true;
            Cells[10, 7].IsAlive = true;
            Cells[10, 12].IsAlive = true;
        }

        private void SetRandom()
        {
            var random = new Random();
            for (var row = 0; row < Cells.GetLength(0); row++)
                for (var column = 0; column < Cells.GetLength(1); column++)
                {
                    var randomValue = random.NextDouble();
                    if (randomValue <= .2)
                        Cells[row, column].IsAlive = true;
                }
        }

        public Board NextGeneration()
        {
            var nextBoard = new Board();

            for (var row = 0; row < Cells.GetLength(0); row++)
                for (var column = 0; column < Cells.GetLength(0); column++)
                    nextBoard.Cells[row, column].IsAlive = GetNextState(row, column);

            return nextBoard;
        }

        private bool GetNextState(int row, int column)
        {
            var count = 0;
            var totalRows = Cells.GetLength(0);
            var totalColumns = Cells.GetLength(1);

            for (var i = row - 1; i <= row + 1; i++)
                for (var j = column - 1; j <= column + 1; j++)
                {
                    var rowIndex = (i + totalRows) % totalRows;
                    var columnIndex = (j + totalColumns) % totalColumns;

                    if (Cells[rowIndex, columnIndex].IsAlive)
                        count++;
                }

            if (count == 3)
                return true;
            return count == 4 && Cells[row, column].IsAlive;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            for (var row = 0; row < Cells.GetLength(0); row++)
            {
                for (var column = 0; column < Cells.GetLength(1); column++)
                {
                    var symbol = Cells[row, column].IsAlive ? 0 : 1;
                    stringBuilder.Append(symbol + " ");
                }
                stringBuilder.Append("\n");
            }

            return stringBuilder.ToString();
        }
    }
}