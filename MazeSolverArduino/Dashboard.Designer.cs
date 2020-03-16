namespace MazeSolverArduino
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabSolver = new System.Windows.Forms.TabPage();
            this.btn_wall = new System.Windows.Forms.Button();
            this.mazeBox = new System.Windows.Forms.PictureBox();
            this.btn_arduino = new System.Windows.Forms.Button();
            this.btn_send = new System.Windows.Forms.Button();
            this.btn_goal = new System.Windows.Forms.Button();
            this.btn_erase = new System.Windows.Forms.Button();
            this.tabViewer = new System.Windows.Forms.TabPage();
            this.btn_sendList = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_select = new System.Windows.Forms.Button();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.mazeBox2 = new System.Windows.Forms.PictureBox();
            this.btn_back = new System.Windows.Forms.Button();
            this.btn_next = new System.Windows.Forms.Button();
            this.lblIndex = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabSolver.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mazeBox)).BeginInit();
            this.tabViewer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mazeBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabSolver);
            this.tabControl.Controls.Add(this.tabViewer);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(628, 554);
            this.tabControl.TabIndex = 7;
            // 
            // tabSolver
            // 
            this.tabSolver.Controls.Add(this.btn_wall);
            this.tabSolver.Controls.Add(this.mazeBox);
            this.tabSolver.Controls.Add(this.btn_arduino);
            this.tabSolver.Controls.Add(this.btn_send);
            this.tabSolver.Controls.Add(this.btn_goal);
            this.tabSolver.Controls.Add(this.btn_erase);
            this.tabSolver.Location = new System.Drawing.Point(4, 22);
            this.tabSolver.Name = "tabSolver";
            this.tabSolver.Padding = new System.Windows.Forms.Padding(3);
            this.tabSolver.Size = new System.Drawing.Size(620, 528);
            this.tabSolver.TabIndex = 0;
            this.tabSolver.Text = "Maze solver";
            this.tabSolver.UseVisualStyleBackColor = true;
            // 
            // btn_wall
            // 
            this.btn_wall.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_wall.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_wall.BackgroundImage")));
            this.btn_wall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_wall.Location = new System.Drawing.Point(512, 11);
            this.btn_wall.Name = "btn_wall";
            this.btn_wall.Size = new System.Drawing.Size(100, 100);
            this.btn_wall.TabIndex = 4;
            this.btn_wall.UseVisualStyleBackColor = true;
            this.btn_wall.Click += new System.EventHandler(this.btn_wall_Click);
            // 
            // mazeBox
            // 
            this.mazeBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mazeBox.Location = new System.Drawing.Point(6, 11);
            this.mazeBox.Name = "mazeBox";
            this.mazeBox.Size = new System.Drawing.Size(500, 500);
            this.mazeBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mazeBox.TabIndex = 0;
            this.mazeBox.TabStop = false;
            this.mazeBox.Click += new System.EventHandler(this.mazeBox_Click);
            // 
            // btn_arduino
            // 
            this.btn_arduino.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_arduino.BackgroundImage = global::MazeSolverArduino.Properties.Resources.mouse;
            this.btn_arduino.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_arduino.Location = new System.Drawing.Point(512, 117);
            this.btn_arduino.Name = "btn_arduino";
            this.btn_arduino.Size = new System.Drawing.Size(100, 100);
            this.btn_arduino.TabIndex = 3;
            this.btn_arduino.UseVisualStyleBackColor = true;
            this.btn_arduino.Click += new System.EventHandler(this.btn_arduino_Click);
            // 
            // btn_send
            // 
            this.btn_send.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_send.BackgroundImage = global::MazeSolverArduino.Properties.Resources.send;
            this.btn_send.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_send.Location = new System.Drawing.Point(512, 435);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(100, 76);
            this.btn_send.TabIndex = 5;
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // btn_goal
            // 
            this.btn_goal.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_goal.BackgroundImage = global::MazeSolverArduino.Properties.Resources.finish;
            this.btn_goal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_goal.Location = new System.Drawing.Point(512, 223);
            this.btn_goal.Name = "btn_goal";
            this.btn_goal.Size = new System.Drawing.Size(100, 100);
            this.btn_goal.TabIndex = 2;
            this.btn_goal.UseVisualStyleBackColor = true;
            this.btn_goal.Click += new System.EventHandler(this.btn_goal_Click);
            // 
            // btn_erase
            // 
            this.btn_erase.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_erase.BackgroundImage = global::MazeSolverArduino.Properties.Resources.eraser;
            this.btn_erase.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_erase.Location = new System.Drawing.Point(512, 329);
            this.btn_erase.Name = "btn_erase";
            this.btn_erase.Size = new System.Drawing.Size(100, 100);
            this.btn_erase.TabIndex = 1;
            this.btn_erase.UseVisualStyleBackColor = true;
            this.btn_erase.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabViewer
            // 
            this.tabViewer.Controls.Add(this.btn_sendList);
            this.tabViewer.Controls.Add(this.pictureBox1);
            this.tabViewer.Controls.Add(this.btn_select);
            this.tabViewer.Controls.Add(this.btn_refresh);
            this.tabViewer.Controls.Add(this.btn_delete);
            this.tabViewer.Controls.Add(this.mazeBox2);
            this.tabViewer.Controls.Add(this.btn_back);
            this.tabViewer.Controls.Add(this.btn_next);
            this.tabViewer.Controls.Add(this.lblIndex);
            this.tabViewer.Location = new System.Drawing.Point(4, 22);
            this.tabViewer.Name = "tabViewer";
            this.tabViewer.Padding = new System.Windows.Forms.Padding(3);
            this.tabViewer.Size = new System.Drawing.Size(620, 528);
            this.tabViewer.TabIndex = 1;
            this.tabViewer.Text = "View arduino";
            this.tabViewer.UseVisualStyleBackColor = true;
            this.tabViewer.Click += new System.EventHandler(this.tabViewer_Click);
            // 
            // btn_sendList
            // 
            this.btn_sendList.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_sendList.BackgroundImage = global::MazeSolverArduino.Properties.Resources.send;
            this.btn_sendList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_sendList.Location = new System.Drawing.Point(512, 336);
            this.btn_sendList.Name = "btn_sendList";
            this.btn_sendList.Size = new System.Drawing.Size(100, 76);
            this.btn_sendList.TabIndex = 9;
            this.btn_sendList.UseVisualStyleBackColor = true;
            this.btn_sendList.Click += new System.EventHandler(this.btn_sendList_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MazeSolverArduino.Properties.Resources.star;
            this.pictureBox1.Location = new System.Drawing.Point(524, 418);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(88, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // btn_select
            // 
            this.btn_select.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_select.BackgroundImage = global::MazeSolverArduino.Properties.Resources.check;
            this.btn_select.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_select.Location = new System.Drawing.Point(514, 124);
            this.btn_select.Name = "btn_select";
            this.btn_select.Size = new System.Drawing.Size(100, 100);
            this.btn_select.TabIndex = 7;
            this.btn_select.UseVisualStyleBackColor = true;
            this.btn_select.Click += new System.EventHandler(this.btn_select_Click);
            // 
            // btn_refresh
            // 
            this.btn_refresh.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_refresh.BackgroundImage = global::MazeSolverArduino.Properties.Resources.refresh;
            this.btn_refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_refresh.Location = new System.Drawing.Point(514, 18);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(100, 100);
            this.btn_refresh.TabIndex = 6;
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_delete.BackgroundImage = global::MazeSolverArduino.Properties.Resources.delete;
            this.btn_delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_delete.Location = new System.Drawing.Point(512, 230);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(100, 100);
            this.btn_delete.TabIndex = 5;
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // mazeBox2
            // 
            this.mazeBox2.Location = new System.Drawing.Point(7, 18);
            this.mazeBox2.Name = "mazeBox2";
            this.mazeBox2.Size = new System.Drawing.Size(501, 475);
            this.mazeBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mazeBox2.TabIndex = 3;
            this.mazeBox2.TabStop = false;
            // 
            // btn_back
            // 
            this.btn_back.Location = new System.Drawing.Point(250, 499);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(26, 23);
            this.btn_back.TabIndex = 2;
            this.btn_back.Text = "<-";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // btn_next
            // 
            this.btn_next.Location = new System.Drawing.Point(321, 499);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(26, 23);
            this.btn_next.TabIndex = 1;
            this.btn_next.Text = "->";
            this.btn_next.UseVisualStyleBackColor = true;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // lblIndex
            // 
            this.lblIndex.AutoSize = true;
            this.lblIndex.Location = new System.Drawing.Point(282, 504);
            this.lblIndex.Name = "lblIndex";
            this.lblIndex.Size = new System.Drawing.Size(33, 13);
            this.lblIndex.TabIndex = 0;
            this.lblIndex.Text = "1/ 45";
            this.lblIndex.Click += new System.EventHandler(this.lblIndex_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 578);
            this.Controls.Add(this.tabControl);
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.tabControl.ResumeLayout(false);
            this.tabSolver.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mazeBox)).EndInit();
            this.tabViewer.ResumeLayout(false);
            this.tabViewer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mazeBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox mazeBox;
        private System.Windows.Forms.Button btn_erase;
        private System.Windows.Forms.Button btn_goal;
        private System.Windows.Forms.Button btn_arduino;
        private System.Windows.Forms.Button btn_wall;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabSolver;
        private System.Windows.Forms.TabPage tabViewer;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.Label lblIndex;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.PictureBox mazeBox2;
        private System.Windows.Forms.Button btn_select;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_sendList;
    }
}

