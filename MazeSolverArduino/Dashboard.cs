using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace MazeSolverArduino
{
    public partial class Dashboard : Form
    {
        private static Maze maze;
        private static EEPROMdata data;
        new int Width;
        new int Height;
        bool erase=false;
        bool goal = false;
        bool arduino = false;
        int indexSelected = 0;
        public Dashboard()
        {
            Width = 50;
            Height = 50;
            data = new EEPROMdata();
            data.GetData();
            InitializeComponent();
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.KeyPreview = true;
            this.DragDrop += new DragEventHandler(Form1_DragDrop);
            this.KeyDown += new KeyEventHandler(Form_KeyDown);
        }
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.NullValueHandling = NullValueHandling.Ignore;
                SaveFileDialog dialog = new SaveFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(dialog.FileName))
                    using (JsonWriter writer = new JsonTextWriter(sw))
                    {
                        serializer.Serialize(writer, maze);
                    }
                }
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Left && this.tabControl.SelectedIndex==1)
            {
                btn_back.PerformClick();
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Right && this.tabControl.SelectedIndex == 1)
            {
                btn_next.PerformClick();
                e.SuppressKeyPress = true;
            }
        }
        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            maze = JsonConvert.DeserializeObject<Maze>(File.ReadAllText(files[0]));
            Width = maze.width;
            Height = maze.height;
            maze.solveMaze();
            drawMaze(mazeBox,maze,Width,Height);
        }

        private void drawMaze(PictureBox c, Maze m,int width,int height)
        {
            
            Bitmap bmp = new Bitmap(width * 100, height * 100);
            Graphics g = Graphics.FromImage(bmp);
            Pen pn = new Pen(Color.Black);
            Brush brsh = Brushes.Black;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    pn.Width = 2;
                    pn.Color = Color.Gray;
                    g.DrawLine(pn, j * 100 + 20, i * 100, j * 100 + 20, i * 100 + 100);
                    g.DrawLine(pn, j * 100, i * 100 + 20, j * 100 + 100, i * 100 + 20);
                    g.DrawLine(pn, j * 100 + 80, i * 100, j * 100 + 80, i * 100 + 100);
                    g.DrawLine(pn, j * 100, i * 100 + 80, j * 100 + 100, i * 100 + 80);
                    pn.Color = Color.Black;
                    pn.Width = 3;
                    g.DrawLine(pn, j * 100, i * 100, j * 100 + 100, i * 100);
                    g.DrawLine(pn, j * 100, i * 100, j * 100, i * 100 + 100);
                    if (m.Goal.X == j && m.Goal.Y == i)
                    {
                        g.FillRectangle(Brushes.Orange, j * 100, i * 100, 100, 100);
                    }
                    else if (m.Player.X == j && m.Player.Y == i)
                    {
                        //g.DrawImage(MazeSolverArduino.Properties.Resources.mouse, j * 100 + 20, i * 100 + 20, 60, 60);
                        g.FillRectangle(Brushes.Blue, j * 100, i * 100, 100, 100);
                        Point[] arrP = { new Point(j * 100 + 50, i * 100), new Point(j * 100 + 20, i * 100 + 20), new Point(j * 100 + 80, i * 100 + 20) };
                        switch (m.directionInitial) {
                            case 0:
                                arrP[0] = new Point(j * 100 + 50, i * 100+20);
                                arrP[1] = new Point(j * 100 + 30, i * 100 + 40);
                                arrP[2] = new Point(j * 100 + 70, i * 100 + 40);
                                break;
                            case 1:
                                arrP[0] = new Point(j * 100 + 80, i * 100 + 50);
                                arrP[1] = new Point(j * 100 + 60, i * 100 + 30);
                                arrP[2] = new Point(j * 100 + 60, i * 100 + 70);
                                break;
                            case 2:
                                arrP[0] = new Point(j * 100 + 50, i * 100 + 80);
                                arrP[1] = new Point(j * 100 + 30, i * 100 + 60);
                                arrP[2] = new Point(j * 100 + 70, i * 100 + 60);
                                break;
                            case 3:
                                arrP[0] = new Point(j * 100+20, i * 100 + 50);
                                arrP[1] = new Point(j * 100 + 40, i * 100 + 30);
                                arrP[2] = new Point(j * 100 + 40, i * 100 + 70);
                                break;
                        }
                        g.FillPolygon(Brushes.Purple, arrP);
                    }
                    else if (m.MazeMap[j, i].isPath)
                    {
                        g.FillRectangle(Brushes.Purple, j * 100, i * 100, 100, 100);
                    }
                    else
                         g.FillRectangle(new SolidBrush(Color.FromArgb(0,(int)(m.MazeMap[j,i].distance*2.6), (int)(255 - m.MazeMap[j, i].distance * 2.6))), j * 100, i * 100, 100, 100);

                    g.DrawString(m.MazeMap[j, i].distance.ToString(), new Font(FontFamily.GenericSerif, 20, FontStyle.Bold), Brushes.Gray, j * 100 + 20, i * 100 + 20);
                }
            }
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (m.MazeMap[j, i].leftWall)
                    {
                        g.FillRectangle(brsh, j * 100 - 20, i * 100-20, 40, 140);
                    }
                    if (m.MazeMap[j, i].rightWall)
                    {
                        g.FillRectangle(brsh, j * 100 + 80, i * 100-20, 40, 140);
                    }
                    if (m.MazeMap[j, i].upWall)
                    {
                        g.FillRectangle(brsh, j * 100 - 20, i * 100, 140, 20);
                    }
                    if (m.MazeMap[j, i].downWall)
                    {
                        g.FillRectangle(brsh, j * 100 -20, i * 100 + 80, 140, 20);
                    }
                }
            } 
            g.DrawLine(pn, width * 100, 0, width*100, height*100);
            g.DrawLine(pn, 0, height * 100, width * 100, height * 100);

            c.Image = bmp;
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {
            maze = new Maze(Width, Height);
            data.listOfMazes[indexSelected].pathFromInstructions();
            drawMaze(mazeBox2, data.listOfMazes[indexSelected], data.listOfMazes[indexSelected].width, data.listOfMazes[indexSelected].height);
            lblIndex.Text = indexSelected + 1 + "/ " + data.listOfMazes.Count;
            if (indexSelected == data.selectedMaze)
                pictureBox1.Show();
            else
                pictureBox1.Hide();
            drawMaze(mazeBox,maze,Width,Height);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            erase = true;
            goal = false;
            arduino = false;
        }

        private void mazeBox_Click(object sender, EventArgs e)
        {
            
            MouseEventArgs me = (MouseEventArgs)e;
            Point coords = me.Location;
           // coords.X = coords.X * (width / (mazeBox.Width/width/20));
            //coords.Y = (coords.Y * (height / (mazeBox.Height / height / 20)));
           coords.Y = coords.Y * 100/(mazeBox.Height/Height);
            coords.X= coords.X * 100 / (mazeBox.Width / Width);
            int i = (coords.X - (coords.X % 100)) / 100;
            int j = (coords.Y - (coords.Y% 100)) / 100;
            int xRest = coords.X % 100;
            int yRest = coords.Y % 100;
            if (goal)
            {
                maze.Goal = new Point(i, j);
            }
            else if (arduino)
            {
                maze.Player = new Point(i,j);
            }
            else
            {
                if (xRest >= 20 && xRest <= 80)
                {
                    if (yRest <= 20)
                    {
                        if (erase)
                        {
                            maze.MazeMap[i, j].upWall = false;
                            if (j > 0)
                            {
                                maze.MazeMap[i, j - 1].downWall = false;
                            }
                        }
                        else
                        {
                            maze.MazeMap[i, j].upWall = true;
                        }
                    }
                    else if (yRest >= 80)
                    {
                        if (erase)
                        {
                            maze.MazeMap[i, j].downWall = false;
                            if (j < Height - 1)
                            {
                                maze.MazeMap[i, j + 1].upWall = false;
                            }
                        }
                        else
                        {
                            if (j < Height - 1)
                            {
                                maze.MazeMap[i, j].downWall = true;
                            }
                        }
                    }
                }
                if (yRest >= 20 && yRest <= 80)
                {
                    if (xRest <= 20)
                    {
                        if (erase)
                        {
                            maze.MazeMap[i, j].leftWall = false;
                            if (i > 0)
                            {
                                maze.MazeMap[i - 1, j].rightWall = false;
                            }
                        }
                        else
                        {
                            if (i < Width - 1)
                            {
                                maze.MazeMap[i, j].leftWall = true;
                            }
                        }
                    }
                    else if (xRest >= 80)
                    {
                        if (erase)
                        {
                            maze.MazeMap[i, j].rightWall = false;
                            if (i < Width - 1)
                            {
                                maze.MazeMap[i + 1, j].leftWall = false;
                            }
                        }
                        else
                        {
                            maze.MazeMap[i, j].rightWall = true;
                        }
                    }
                }
            }
            maze.updateWalls();
            maze.solveMaze();
            drawMaze(mazeBox,maze,Width,Height);
            
        }

        private void btn_arduino_Click(object sender, EventArgs e)
        {
            erase = false;
            goal = false;
            arduino = true;
            
            maze.directionInitial = (maze.directionInitial+1)%4;
            maze.direction = maze.directionInitial;
            maze.solveMaze();
            drawMaze(mazeBox,maze,Width,Height);
}

        private void btn_wall_Click(object sender, EventArgs e)
        {
            erase = false;
            goal = false;
            arduino = false;
        }

        private void btn_goal_Click(object sender, EventArgs e)
        {
            erase = false;
            arduino = false;
            goal = true;
        }
        private string fixInstructions(string mazeInstructions)
        {
            for (int i = 0; i < mazeInstructions.Length; i++)
            {
                int index = -1;
                int sizeOfCut = -1;

                //Find 180 turn
                for (int j = 0; j < mazeInstructions.Length; j++)
                {
                    if (mazeInstructions[j] == 't')
                    {
                        index = j;
                        break;
                    }
                }
                //Return if no 180 turn was found
                if (index == -1)
                    return mazeInstructions;

                //Finds respective turns for 180
                for (int j = index; j < mazeInstructions.Length; j++)
                {
                    if (mazeInstructions[j] == 'h' || mazeInstructions[j] == 'f' || mazeInstructions[index - (j - index)] == 'h' || mazeInstructions[index - (j - index)] == 'f')
                    {
                        sizeOfCut = j - index;
                        break;
                    }
                }
                //Takes threw the cases
                string a = mazeInstructions[index - sizeOfCut].ToString() + mazeInstructions[index + sizeOfCut];
                if (a[0] =='f'&& a[1] == 'f')
                {
                    a = "";
                }
                if (a[0] == 'h' && a[1] == 'h')
                {
                    a = "";
                }
                switch (a)
                {
                    case "fh":
                        a = "t";
                        break;
                    case "hf":
                        a = "t";
                        break;
                    case "fg":
                        a = "hg";
                        break;
                    case "hg":
                        a = "fg";
                        break;
                    case "gf":
                        a = "gh";
                        break;
                    case "gh":
                        a = "gf";
                        break;
                }
                mazeInstructions = mazeInstructions.Remove(index - sizeOfCut, sizeOfCut * 2 + 1);
                mazeInstructions = mazeInstructions.Insert(index - sizeOfCut, a);
            }
            return mazeInstructions;
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            MessageBox.Show(maze.SolveLeftRight().ToString());
            string output = "";
            string mazeInstructions = maze.instructionsLeft;
            for(int i = 0; i <mazeInstructions.Length; i++)
            {
                switch (mazeInstructions[i])
                {
                    case 'f':
                        output += " LEFT";
                        break;
                    case 'g':
                        output += " FORWARD";
                        break;
                    case 'h':
                        output += " RIGHT";
                        break;
                    case 't':
                        output += " 180";
                        break;
                }
            }
            MessageBox.Show(output+"   "+mazeInstructions.Length);

            ////////////////////////////////////////////////////////

            MessageBox.Show("fixed");
           // maze.instructionsRight = maze.instructionsRight.Replace('g', ' ');
            mazeInstructions = fixInstructions(maze.instructionsLeft);
            output = "";
            for (int i = 0; i < mazeInstructions.Length; i++)
            {
                switch (mazeInstructions[i])
                {
                    case 'f':
                        output += " LEFT";
                        break;
                    case 'g':
                        output += " FORWARD";
                        break;
                    case 'h':
                        output += " RIGHT";
                        break;
                    case 't':
                        output += " 180";
                        break;
                }
            }

            MessageBox.Show(output+" length:"+mazeInstructions.Length+" desired length:" +maze.instructions.Length);
            maze.sendToBoard();
        }

        private void lblIndex_Click(object sender, EventArgs e)
        {

        }

        private void tabViewer_Click(object sender, EventArgs e)
        {

        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            data.listOfMazes[indexSelected].pathFromInstructions();
            drawMaze(mazeBox2, data.listOfMazes[indexSelected],data.listOfMazes[indexSelected].width,data.listOfMazes[indexSelected].height);
            lblIndex.Text = indexSelected+1 + "/ " + data.listOfMazes.Count;
            if (indexSelected == data.selectedMaze)
                pictureBox1.Show();
            else
                pictureBox1.Hide();
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if (indexSelected < data.listOfMazes.Count-1)
            {
                indexSelected++;
                data.listOfMazes[indexSelected].pathFromInstructions();
                drawMaze(mazeBox2, data.listOfMazes[indexSelected], data.listOfMazes[indexSelected].width, data.listOfMazes[indexSelected].height);
                lblIndex.Text = indexSelected + 1 + "/ " + data.listOfMazes.Count;
                if (indexSelected == data.selectedMaze)
                    pictureBox1.Show();
                else
                    pictureBox1.Hide();
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            if (indexSelected > 0)
            {
                indexSelected--;
                data.listOfMazes[indexSelected].pathFromInstructions();
                drawMaze(mazeBox2, data.listOfMazes[indexSelected], data.listOfMazes[indexSelected].width, data.listOfMazes[indexSelected].height);
                lblIndex.Text = indexSelected + 1 + "/ " + data.listOfMazes.Count;
                if (indexSelected == data.selectedMaze)
                    pictureBox1.Show();
                else
                    pictureBox1.Hide();
            }
        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            data.selectedMaze = indexSelected;
            data.listOfMazes[indexSelected].pathFromInstructions();
            drawMaze(mazeBox2, data.listOfMazes[indexSelected], data.listOfMazes[indexSelected].width, data.listOfMazes[indexSelected].height);
            lblIndex.Text = indexSelected + 1 + "/ " + data.listOfMazes.Count;
            if (indexSelected == data.selectedMaze)
                pictureBox1.Show();
            else
                pictureBox1.Hide();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if(data.listOfMazes.Count == 1)
            {
                return;
            }
            data.listOfMazes.RemoveAt(indexSelected);
                data.selectedMaze = data.listOfMazes.Count-1;
            if (indexSelected != 0)
            {
                indexSelected--;
            }

            data.listOfMazes[indexSelected].pathFromInstructions();
            drawMaze(mazeBox2, data.listOfMazes[indexSelected], data.listOfMazes[indexSelected].width, data.listOfMazes[indexSelected].height);
            lblIndex.Text = indexSelected + 1 + "/ " + data.listOfMazes.Count;
            if (indexSelected == data.selectedMaze)
                pictureBox1.Show();
            else
                pictureBox1.Hide();
        }

        private void btn_sendList_Click(object sender, EventArgs e)
        {
            data.UpdateData();
        }
    }
}
