namespace MazeSolverArduino
{
    public class Cell
    {
        public int distance;
        public bool leftWall;
        public bool rightWall;
        public bool upWall;
        public bool downWall;
        public bool isPath;
        public Cell(bool leftWall = false, bool upWall = false, bool rightWall = false, bool downWall = false, int distance = 0,bool isPath =false)
        { 
            this.leftWall = leftWall;
            this.rightWall = rightWall;
            this.upWall = upWall;
            this.downWall = downWall;
            this.isPath = isPath;
            this.distance = distance;
        }
        public bool [] wallArr()
        {
            bool[] arr = new bool[4];
            arr[0] = upWall;
            arr[1] = rightWall;
            arr[2] = downWall;
            arr[3] = leftWall;
            return arr;
        }
    }
}
