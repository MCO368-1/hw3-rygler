namespace GameOfLife
{
    public class Cell
    {
        public Cell(bool isAlive = false)
        {
            IsAlive = isAlive;
        }

        public bool IsAlive { get; set; }
        
    }
}