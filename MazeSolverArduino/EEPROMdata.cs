using System.Collections.Generic;
using System.IO.Ports;
using System.Windows.Forms;

namespace MazeSolverArduino
{
    public class EEPROMdata
    {
        public List<Maze> listOfMazes;
        private SerialPort currentPort;
        public int selectedMaze;
        public EEPROMdata()
        {
            listOfMazes = new List<Maze>();
        }
        #region Board

        #region Find Arduino
        private bool DetectArduino()
        {
            try
            {
                currentPort.Open();
                currentPort.Write("!");
                System.Threading.Thread.Sleep(500);
                string a = currentPort.ReadExisting();
                currentPort.Close();
                if (a.Contains("Detected"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        private void findPort()
        {
            currentPort = new SerialPort();
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                try
                {
                    currentPort = new SerialPort(port, 9600);
                    if (DetectArduino())
                    {
                        return;
                    }
                }
                catch
                { }
            }
        }
        #endregion

        #region Get data
        public void GetData()
        {
            if (DetectArduino())
            {
                currentPort.Open();
                currentPort.Write("#");
                System.Threading.Thread.Sleep(500);
                string a = currentPort.ReadExisting();
                currentPort.Close();
                int mazeNumber = a[0];
                string[] mazes = a.Split('!');
                listOfMazes = new List<Maze>();
                for (int i = 1; i <= mazeNumber; i++)
                {
                    string[] mazeSplit = mazes[i].Split('*');
                    int x = int.Parse(mazeSplit[0]);
                    int y = int.Parse(mazeSplit[1]);
                    string instructions = mazeSplit[2];
                    int xPlayer = int.Parse(mazeSplit[3]);
                    int yPlayer = int.Parse(mazeSplit[4]);
                    Maze maze = new Maze(x, y);
                    maze.Player.X = xPlayer;
                    maze.Player.Y = yPlayer;
                    listOfMazes.Add(maze);
                }
                selectedMaze = int.Parse(mazes[mazeNumber + 1]);
            }
            else
            {
                string a = "6!9*9*gggfggghg*8*8*0!20*15*gggtggghg*8*8*0!9*9*gggfggghg*8*8*0!20*15*gggtggghg*8*8*0!9*9*gggfggghg*8*8*0!20*15*gggtggghg*8*8*0!0";
                int mazeNumber = int.Parse(a[0].ToString());
                string[] mazes = a.Split('!');
                listOfMazes = new List<Maze>();
                for (int i = 1; i <= mazeNumber; i++)
                {
                    string[] mazeSplit = mazes[i].Split('*');
                    int x = int.Parse(mazeSplit[0]);
                    int y = int.Parse(mazeSplit[1]);
                    string instructions = mazeSplit[2];
                    int xPlayer = int.Parse(mazeSplit[3]);
                    int yPlayer = int.Parse(mazeSplit[4]);
                    Maze maze = new Maze(x, y);
                    maze.Player.X = xPlayer;
                    maze.instructions = instructions;
                    maze.Player.Y = yPlayer;
                    maze.direction = int.Parse(mazeSplit[5]);
                    maze.directionInitial = int.Parse(mazeSplit[5]);
                    listOfMazes.Add(maze);
                }
                MessageBox.Show(a);
            }
        }
        #endregion

        #region Send data
        public void SendData(string a)
        {
            if (DetectArduino())
            {
                currentPort.Open();
                string stringToSend = "@" + (listOfMazes.Count + 1) + "!";
                foreach (Maze mz in listOfMazes)
                {
                    stringToSend += mz.BuildInstructionsForSending() + "!";
                }
                stringToSend += a;
                stringToSend += "!" + selectedMaze;
                currentPort.Write(stringToSend);
            }
        }
        public void UpdateData()
        {
            if (DetectArduino())
            {
                currentPort.Open();
                string stringToSend = "@" + (listOfMazes.Count) + "!";
                foreach (Maze mz in listOfMazes)
                {
                    stringToSend += mz.BuildInstructionsForSending() + "!";
                }
                stringToSend += "!" + selectedMaze;
                currentPort.Write(stringToSend);
            }
        }
        #endregion

        #endregion
    }
}
