using System;
using System.Text;

namespace GameOfLife
{
    public class Board
    {
        private readonly Cell[,] _cells;

        public Board()
        {
            const int height = 20;
            const int width = 20;
            _cells = new Cell[height, width];

            for (var row = 0; row < height; row++)
                for (var column = 0; column < width; column++)
                    _cells[row, column] = new Cell();
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
            _cells[9, 9].IsAlive = true;
            _cells[9, 10].IsAlive = true;
            _cells[9, 11].IsAlive = true;
        }

        private void SetToad()
        {
            _cells[9, 9].IsAlive = true;
            _cells[9, 10].IsAlive = true;
            _cells[9, 11].IsAlive = true;
            _cells[10, 8].IsAlive = true;
            _cells[10, 9].IsAlive = true;
            _cells[10, 10].IsAlive = true;
        }

        private void SetBeacon()
        {
            _cells[9, 8].IsAlive = true;
            _cells[9, 9].IsAlive = true;
            _cells[10, 8].IsAlive = true;
            _cells[10, 9].IsAlive = true;
            _cells[11, 10].IsAlive = true;
            _cells[11, 11].IsAlive = true;
            _cells[12, 10].IsAlive = true;
            _cells[12, 11].IsAlive = true;
        }

        private void SetPulsar()
        {
            _cells[4, 5].IsAlive = true;
            _cells[4, 6].IsAlive = true;
            _cells[4, 7].IsAlive = true;
            _cells[4, 11].IsAlive = true;
            _cells[4, 12].IsAlive = true;
            _cells[4, 13].IsAlive = true;
            _cells[6, 3].IsAlive = true;
            _cells[6, 8].IsAlive = true;
            _cells[6, 10].IsAlive = true;
            _cells[6, 15].IsAlive = true;
            _cells[7, 3].IsAlive = true;
            _cells[7, 8].IsAlive = true;
            _cells[7, 10].IsAlive = true;
            _cells[7, 15].IsAlive = true;
            _cells[8, 3].IsAlive = true;
            _cells[8, 8].IsAlive = true;
            _cells[8, 10].IsAlive = true;
            _cells[8, 15].IsAlive = true;
            _cells[9, 5].IsAlive = true;
            _cells[9, 6].IsAlive = true;
            _cells[9, 7].IsAlive = true;
            _cells[9, 11].IsAlive = true;
            _cells[9, 12].IsAlive = true;
            _cells[9, 13].IsAlive = true;
            _cells[11, 5].IsAlive = true;
            _cells[11, 6].IsAlive = true;
            _cells[11, 7].IsAlive = true;
            _cells[11, 11].IsAlive = true;
            _cells[11, 12].IsAlive = true;
            _cells[11, 13].IsAlive = true;
            _cells[12, 3].IsAlive = true;
            _cells[12, 8].IsAlive = true;
            _cells[12, 10].IsAlive = true;
            _cells[12, 15].IsAlive = true;
            _cells[13, 3].IsAlive = true;
            _cells[13, 8].IsAlive = true;
            _cells[13, 10].IsAlive = true;
            _cells[13, 15].IsAlive = true;
            _cells[14, 3].IsAlive = true;
            _cells[14, 8].IsAlive = true;
            _cells[14, 10].IsAlive = true;
            _cells[14, 15].IsAlive = true;
            _cells[16, 5].IsAlive = true;
            _cells[16, 6].IsAlive = true;
            _cells[16, 7].IsAlive = true;
            _cells[16, 11].IsAlive = true;
            _cells[16, 12].IsAlive = true;
            _cells[16, 13].IsAlive = true;
        }

        private void SetPentadecathlon()
        {
            _cells[8, 7].IsAlive = true;
            _cells[8, 12].IsAlive = true;
            _cells[9, 5].IsAlive = true;
            _cells[9, 6].IsAlive = true;
            _cells[9, 8].IsAlive = true;
            _cells[9, 9].IsAlive = true;
            _cells[9, 10].IsAlive = true;
            _cells[9, 11].IsAlive = true;
            _cells[9, 13].IsAlive = true;
            _cells[9, 14].IsAlive = true;
            _cells[10, 7].IsAlive = true;
            _cells[10, 12].IsAlive = true;
        }

        private void SetRandom()
        {
            var random = new Random();
            for (var row = 0; row < _cells.GetLength(0); row++)
                for (var column = 0; column < _cells.GetLength(1); column++)
                {
                    var randomValue = random.NextDouble();
                    if (randomValue <= .2)
                        _cells[row, column].IsAlive = true;
                }
        }

        public Board NextGeneration()
        {
            var nextBoard = new Board();

            for (var row = 0; row < _cells.GetLength(0); row++)
                for (var column = 0; column < _cells.GetLength(0); column++)
                    nextBoard._cells[row, column].IsAlive = GetNextState(row, column);

            return nextBoard;
        }

        private bool GetNextState(int row, int column)
        {
            var count = 0;
            var totalRows = _cells.GetLength(0);
            var totalColumns = _cells.GetLength(1);

            for (var i = row - 1; i <= row + 1; i++)
                for (var j = column - 1; j <= column + 1; j++)
                {
                    var rowIndex = (i + totalRows) % totalRows;
                    var columnIndex = (j + totalColumns) % totalColumns;

                    if (_cells[rowIndex, columnIndex].IsAlive)
                        count++;
                }

            if (count == 3)
                return true;
            return count == 4 && _cells[row, column].IsAlive;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            for (var row = 0; row < _cells.GetLength(0); row++)
            {
                for (var column = 0; column < _cells.GetLength(1); column++)
                {
                    var symbol = _cells[row, column].IsAlive ? 0 : 1;
                    stringBuilder.Append(symbol + " ");
                }
                stringBuilder.Append("\n");
            }

            return stringBuilder.ToString();
        }
    }
}