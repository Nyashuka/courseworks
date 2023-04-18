using System;
using System.Drawing;
using System.Windows.Forms;

namespace MazeRenderWF
{ 
    public partial class Form1 : Form
    {
        private Maze _maze;
        private WithTimerRenderer _renderer;

        private Graphics _graphics;
        private Bitmap _bm;

        public Form1()
        {
            InitializeComponent();

            _bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            _graphics = Graphics.FromImage(_bm);
            _graphics.Clear(Color.White);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = "maze.txt";

            _maze = new Maze("*", ".", "S", path);

            _renderer = new WithTimerRenderer(_graphics, _maze);

            _renderer.ShowWalls();

            pictureBox1.Image = _bm;

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool endRenderPathes = _renderer.ShowPathLengths();           

            if (endRenderPathes)
            {
                pictureBox1.Image = null;
                _graphics.Clear(Color.White);
                _renderer.ShowWalls();
                _renderer.ShowShortestPath();
                pictureBox1.Image = _bm;
                timer1.Stop();
            }
            pictureBox1.Image = _bm;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            _graphics.Clear(Color.White);

        }

        
    }
}
