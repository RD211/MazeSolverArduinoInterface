using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace MazeSolverArduino
{
    public class Maze
    {

        #region Variables
        public Cell[,] MazeMap;
        public int width;
        public int height;
        public Point Player;
        public Point Goal;
        public string instructions, instructionsLeft, instructionsRight;
        public int direction=0;
        public int directionInitial=0;
        private Point lastDoneCell;
        private string arrOfIntersections = "";
        int indexOfIntersections = 0;
        #endregion

        #region Constructor
        public Maze(int width,int height)
        {
            this.width = width;
            this.height = height;
            MazeMap = new Cell[width,height];
            for(int i = 0; i < height; i++) {
                for (int j = 0; j < width; j++)
                {
                    MazeMap[j,i] = new Cell();
                }
            }
            Player = new Point(width-1, height-1);
            Goal = new Point(0, 0);
            for (int i = 0; i < width; i++)
            {
                MazeMap[i, 0].upWall = true;
                MazeMap[i, height-1].downWall = true;
            }
            for (int i = 0; i < height; i++)
            {
                MazeMap[0, i].leftWall = true;
                MazeMap[width-1, i].rightWall = true;
            }
        }

        #endregion

        #region Find Way to end
        Point findWay(Point p)
        {
            Point minPoint = p;
            int c = 500;
            int call = 0;
            if (p.X != 0)
            {
                if (p.X - 1 >= 0 && p.X - 1 < width && MazeMap[p.X - 1, p.Y].distance < c && MazeMap[p.X - 1, p.Y].distance >= 0 && (!MazeMap[p.X, p.Y].leftWall))
                {
                    c = MazeMap[p.X - 1, p.Y].distance;
                    minPoint.X = p.X - 1;
                    minPoint.Y = p.Y;
                    call = 3;
                }
            }
            if (p.X != width - 1)
            {
                if (p.X + 1 >= 0 && p.X + 1 < width && MazeMap[p.X + 1, p.Y].distance < c && MazeMap[p.X + 1, p.Y].distance >= 0 && (!MazeMap[p.X, p.Y].rightWall))
                {
                    c = MazeMap[p.X + 1, p.Y].distance;
                    minPoint.X = p.X + 1;
                    minPoint.Y = p.Y;
                    call = 1;
                }
            }
            if (p.Y != 0)
            {
                if (p.X >= 0 && p.X < width && MazeMap[p.X, p.Y - 1].distance < c && MazeMap[p.X, p.Y - 1].distance >= 0 && (!MazeMap[p.X, p.Y].upWall))
                {
                    c = MazeMap[p.X, p.Y - 1].distance;
                    minPoint.X = p.X;
                    minPoint.Y = p.Y - 1;
                    call = 0;
                }
            }
            if (p.Y != height - 1)
            {
                if (p.X >= 0 && p.X < width && MazeMap[p.X, p.Y + 1].distance < c && MazeMap[p.X, p.Y + 1].distance >= 0 && (!MazeMap[p.X, p.Y].downWall))
                {
                    c = MazeMap[p.X, p.Y + 1].distance;
                    minPoint.X = p.X;
                    minPoint.Y = p.Y + 1;
                    call = 2;
                }
            }
            MazeMap[minPoint.X ,minPoint.Y].isPath = true;
            int num = 0;
            for (int i = 0; i < 4; i++) {
                if (MazeMap[p.X, p.Y].wallArr()[i])
                    num++;
            }
            string x = CalculateForDirection(call);
            if (!(num == 2 && MazeMap[p.X,p.Y].wallArr()[0]==MazeMap[p.X,p.Y].wallArr()[2]))
            {
                arrOfIntersections +=x;
                indexOfIntersections++;

            }
            instructions += x;


            return minPoint;
        }
        
        #endregion

        #region Calculate distances recursion
        List<Point> calculateDistanceForOne(List<Point> listPoint)
        {
            List<Point> returnList= new List<Point>();
            foreach (Point p in listPoint)
            {
                if (p.Y != 0)
                {
                    if (p.X >= 0 && p.X < width && p.Y - 1 >= 0 && p.Y - 1 < height && MazeMap[p.X, p.Y - 1].distance == 0 && (!MazeMap[p.X, p.Y].upWall) && !(p.X == Goal.X && p.Y - 1 == Goal.Y))
                    {
                        MazeMap[p.X, p.Y - 1].distance = MazeMap[p.X, p.Y].distance + 1;
                        returnList.Add(new Point(p.X, p.Y - 1));
                    }
                }
                if (p.X != 0)
                {
                    if (p.X - 1 >= 0 && p.X - 1 < width && p.Y >= 0 && p.Y < height && MazeMap[p.X - 1, p.Y].distance == 0 && (!MazeMap[p.X, p.Y].leftWall) && !(p.X - 1 == Goal.X && p.Y == Goal.Y))
                    {
                        MazeMap[p.X - 1, p.Y].distance = MazeMap[p.X, p.Y].distance + 1;
                        returnList.Add(new Point(p.X - 1, p.Y));
                    }
                }
                if (p.Y != height - 1)
                {
                    if (p.X >= 0 && p.X < width && p.Y + 1 >= 0 && p.Y + 1 < height && MazeMap[p.X, p.Y + 1].distance == 0 && (!MazeMap[p.X, p.Y].downWall) && !(p.X == Goal.X && p.Y + 1 == Goal.Y))
                    {
                        MazeMap[p.X, p.Y + 1].distance = MazeMap[p.X, p.Y].distance + 1;
                        returnList.Add(new Point(p.X, p.Y + 1));
                    }
                }
                if (p.X != width - 1)
                {
                    if (p.X + 1 >= 0 && p.X + 1 < width && p.Y >= 0 && p.Y < height && MazeMap[p.X + 1, p.Y].distance == 0 && (!MazeMap[p.X, p.Y].rightWall) && !(p.X + 1 == Goal.X && p.Y == Goal.Y))
                    {
                        MazeMap[p.X + 1, p.Y].distance = MazeMap[p.X, p.Y].distance + 1;
                        returnList.Add(new Point(p.X + 1, p.Y));
                    }
                }
            }
            return returnList;
        }
        #endregion

        #region Solve Maze
        public void solveMaze()
        {
            indexOfIntersections = 0;
            arrOfIntersections = "";
            direction = directionInitial;
            instructions = "";
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    MazeMap[i, j].distance = 0;
                    MazeMap[i, j].isPath = false;
                }
            }
            List<Point> goal = new List<Point>();
            goal.Add(Goal);
            while (goal.Count > 0)
            {
                goal = calculateDistanceForOne(goal);
            }
            Point ab = new Point(Player.X, Player.Y);
            int counter = 0;
            while (!(ab.X == Goal.X && ab.Y == Goal.Y))
            {
                ab = findWay(ab);
                counter++;
                if(counter == 1000)
                {
                    for(int i = 0; i < width; i++)
                    {
                        for(int j = 0; j < height; j++)
                        {
                            MazeMap[i, j].isPath = false;
                        }
                    }
                    break;
                }
            }
            string a = "";
            arrOfIntersections = arrOfIntersections.Replace("ghg", "->");
            arrOfIntersections = arrOfIntersections.Replace("gfg", "<-");
            arrOfIntersections = arrOfIntersections.Replace("g", "^");
            arrOfIntersections = arrOfIntersections.Replace("f", "-90");
            arrOfIntersections = arrOfIntersections.Replace("h", "+90");
            arrOfIntersections = arrOfIntersections.Replace("t", "90  90");
            arrOfIntersections = arrOfIntersections.Replace("->", "Right_turn ");
            arrOfIntersections = arrOfIntersections.Replace("<-", "Left_turn ");
            arrOfIntersections = arrOfIntersections.Replace("^", "Forward ");
            arrOfIntersections = arrOfIntersections.Replace("90", "90_deegres ");



            ///MessageBox.Show(arrOfIntersections);
        }
        public int SolveLeft()
        {
            instructionsLeft = "";
            direction = directionInitial;
            Point p = Player;
            int moves = 0;
            while (!(p.X == Goal.X && p.Y == Goal.Y))
            {
                if (!MazeMap[p.X, p.Y].wallArr()[(3 + direction) % 4])
                {
                    if (direction == 0)
                        direction = 3;
                    else
                        direction -= 1;
                    moves++;
                    instructionsLeft += 'f';
                }
                else if (!MazeMap[p.X, p.Y].wallArr()[(direction) % 4])
                {

                }
                else if (!MazeMap[p.X, p.Y].wallArr()[(direction+1) % 4])
                {
                    if (direction == 3)
                        direction = 0;
                    else
                        direction += 1;
                    moves++;
                    instructionsLeft += 'h';
                }
                else
                {
                    direction = (direction + 2) % 4;
                    instructionsLeft += 't';
                }
                switch (direction)
                {
                    case 0:
                        p.Y -= 1;
                        break;
                    case 1:
                        p.X += 1;
                        break;
                    case 2:
                        p.Y += 1;
                        break;
                    case 3:
                        p.X -= 1;
                        break;
                }
                instructionsLeft += 'g';
                moves++;
            }
            return moves;
        }
        private int SolveRight()
        {
            instructionsRight = "";
            direction = directionInitial;
            Point p = Player;
            int moves = 0;
            while (!(p.X == Goal.X && p.Y == Goal.Y))
            {
                if (!MazeMap[p.X, p.Y].wallArr()[(direction + 1) % 4])
                {
                    if (direction == 3)
                        direction = 0;
                    else
                        direction += 1;
                    moves++;
                    instructionsRight += 'h';
                }
                else if(!MazeMap[p.X, p.Y].wallArr()[(direction) % 4])
                {

                }
                else if (!MazeMap[p.X, p.Y].wallArr()[(3 + direction) % 4])
                {
                    if (direction == 0)
                        direction = 3;
                    else
                        direction -= 1;
                    moves++;
                    instructionsRight += 'f';
                }
                else
                {
                    direction = (direction + 2) % 4;
                    instructionsRight += 't';
                }
                switch (direction)
                {
                    case 0:
                        p.Y -= 1;
                        break;
                    case 1:
                        p.X += 1;
                        break;
                    case 2:
                        p.Y += 1;
                        break;
                    case 3:
                        p.X -= 1;
                        break;
                }
                moves++;
                instructionsRight += 'g';
            }
            return moves;
        }
        public bool SolveLeftRight()
        {
            MessageBox.Show(SolveLeft() + " " + SolveRight());
            return false;
        }
       
        private string testOverride(string mazeInstructions)
        {
            direction = directionInitial;
            Point p = Player;
            foreach (char c in mazeInstructions)
            {
                switch (c)
                {
                    case 'f':
                        direction = (Math.Abs(direction-1))%4;
                        break;
                    case 'g':
                        direction = (Math.Abs(direction - 1)) % 4;
                        break;
                    case 'h':

                        break;
                }
            }
            return "";
        }
        #endregion

        #region Update walls
        public void updateWalls()
        {
            for(int i = 0; i < height; i++)
            {
                for(int j = 0; j < width; j++)
                {
                    if (MazeMap[j, i].leftWall && j!=0)
                    {
                        MazeMap[j-1, i].rightWall = true;
                    }
                    if (MazeMap[j, i].rightWall && j != width-1)
                    {
                        MazeMap[j + 1, i].leftWall = true;
                    }
                    if (MazeMap[j, i].upWall && i != 0)
                    {
                        MazeMap[j, i - 1].downWall = true;
                    }
                    if (MazeMap[j, i].downWall && i != height-1)
                    {
                        MazeMap[j, i + 1].upWall = true;
                    }
                }
            }
        }
        #endregion

        #region Send to arduino

        public string BuildInstructionsForSending()
        {
            string mazeInfo = width + "*" + height + "*" + instructions + "*" + Player.X + "*" + Player.Y+"*"+directionInitial;
            return mazeInfo;
        }

        public void sendToBoard()
        {
            EEPROMdata dataSender = new EEPROMdata();
            dataSender.SendData(BuildInstructionsForSending());
        }
        #endregion

        #region Calculate Instructions

        private void updateDirection(int sender)
        {
            int added = sender + direction;

            if (added == 4)
                added = 0;
            else if (added == 5)
                added = 1;
            else if (added == -1)
                added = 3;
            else if(added ==-2)
                added = 2;

            direction = added;
        }
        private string CalculateForDirection(int command)
        {
            string sender="";
            int diff = (command - direction);
            if (diff == -3)
                diff = 1;
            if (diff == 3)
                diff = -1;
            updateDirection(diff);
            switch (diff)
            {
                case -2:
                    sender += 't';
                    break;
                case -1:
                    sender +=  'f';
                    break;
                case 0:
                    break;
                case 1:
                    sender += 'h';
                    break;
                case 2:
                    sender += 't';
                    break;
            }
            sender += 'g';
            return sender;
        }
        public void pathFromInstructions()
        {
            lastDoneCell = Player;
            foreach (char c in instructions)
            {
                int x=0;
                switch (c)
                {
                    case 't':
                        x = -2;
                        break;
                    case 'f':
                        x = -1;
                        break;
                }
                if (x != 0)
                {
                    int diff = x - direction;
                    updateDirection(diff);
                }
                else
                {
                    switch (direction)
                    {
                        case 0:
                            lastDoneCell.Y -= 1;
                            break;
                        case 1:
                            lastDoneCell.X += 1;
                            break;
                        case 2:
                            lastDoneCell.Y += 1;
                            break;
                        case 3:
                            lastDoneCell.X -= 1;
                            break;
                    }
                    MazeMap[lastDoneCell.X, lastDoneCell.Y].isPath = true;
                }

            }
            direction = directionInitial;
        }
    #endregion

    }
}