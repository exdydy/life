using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{

    public partial class GameForm : Form
    {
        private Mygame gof;
        public GameForm(int setwidth = 40, int setheight = 40)
        {
            setwidth = Math.Max(10, setwidth);
            setheight = Math.Min(Math.Max(10, setheight),55);
            InitializeComponent();
            this.Width = setwidth * 10 + 135;
            this.Height = Math.Max(setheight * 10 + 39, 350);
            Field.Size = new Size(setwidth * 10, setheight * 10);
            Field.Image = new Bitmap(Field.Width, Field.Height);
            Setitemsproperties();
            gof = new Mygame(setwidth, setheight, 1000, Color.Black, Color.SkyBlue,Color.Ivory, Color.Black, Graphics.FromImage(Field.Image));
            GameTimer.Interval = gof.initialtime / TimeBar.Value;
            Drawgrid();
        }

        public void Setitemsproperties()
        {
            ButtonStart.Location = new Point(this.Width - 125, 10);
            ButtonPause.Location = new Point(this.Width - 125, 50);
            ButtonNext.Location = new Point(this.Width - 125, 90);
            ButtonEarly.Location = new Point(this.Width - 125, 130);
            ButtonClear.Location = new Point(this.Width - 125, 170);
            LabelSpeed.Location = new Point(this.Width - 120, 210);
            TimeBar.Location = new Point(this.Width - 125, 235);
            LabelAliveCount.Location = new Point(this.Width - 125, 265);
            AliveCountTextBox.Location = new Point(this.Width - 125, 285);
        }
        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e) => Application.Exit();

        private void TimeBar_ValueChanged(object sender, EventArgs e)
        {
            GameTimer.Interval = gof.initialtime / TimeBar.Value;
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (gof.gameison)
            {
                ShowNextGeneration();
                if (gof.legacy.Count() > 50) gof.legacy.Deletelast();
                AliveCountTextBox.Text = gof.currentgeneration.alivecount.ToString();
            }
    }

        private void Field_MouseUp(object sender, MouseEventArgs e)
        {
            if (gof.gameison || e.X > Field.Width - 1 || e.Y > Field.Height - 1 || e.X < 0 || e.Y < 0) return;
            switch (e.Button)
            {
                case MouseButtons.Left when gof.currentgeneration.cells[e.X / 10, e.Y / 10].isalive == 0:
                    gof.currentgeneration.cells[e.X / 10, e.Y / 10].isalive = 1;
                    gof.graph.FillRectangle(gof.paints.livecellbrush, e.X / 10 * 10 + 1, e.Y / 10 * 10 + 1, 7, 7);
                    Field.Refresh();
                    gof.currentgeneration.alivecount++;
                    AliveCountTextBox.Text = gof.currentgeneration.alivecount.ToString();
                    break;
                case MouseButtons.Right when gof.currentgeneration.cells[e.X / 10, e.Y / 10].isalive == 1:
                    gof.currentgeneration.cells[e.X / 10, e.Y / 10].isalive = 0;
                    gof.currentgeneration.cells[e.X / 10, e.Y / 10].wasalive = true;
                    gof.graph.FillRectangle(gof.paints.diedcellbrush, e.X / 10 * 10 + 1, e.Y / 10 * 10 + 1, 7, 7);
                    Field.Refresh();
                    gof.currentgeneration.alivecount--;
                    AliveCountTextBox.Text = gof.currentgeneration.alivecount.ToString();
                    break;
            }
        }

        private void Field_MouseMove(object sender, MouseEventArgs e)
        {
            if (gof.gameison || e.X > Field.Width - 1 || e.Y > Field.Height - 1 || e.X < 0 || e.Y < 0) return;
            switch (e.Button)
            {
                case MouseButtons.Left when gof.currentgeneration.cells[e.X / 10, e.Y / 10].isalive == 0:
                    gof.currentgeneration.cells[e.X / 10, e.Y / 10].isalive = 1;
                    gof.graph.FillRectangle(gof.paints.livecellbrush, e.X / 10 * 10 + 1, e.Y / 10 * 10 + 1, 7, 7);
                    Field.Refresh();
                    gof.currentgeneration.alivecount++;
                    AliveCountTextBox.Text = gof.currentgeneration.alivecount.ToString();
                    break;
                case MouseButtons.Right when gof.currentgeneration.cells[e.X / 10, e.Y / 10].isalive == 1:
                    gof.currentgeneration.cells[e.X / 10, e.Y / 10].isalive = 0;
                    gof.currentgeneration.cells[e.X / 10, e.Y / 10].wasalive = true;
                    gof.graph.FillRectangle(gof.paints.diedcellbrush, e.X / 10 * 10 + 1, e.Y / 10 * 10 + 1, 7, 7);
                    Field.Refresh();
                    gof.currentgeneration.alivecount--;
                    AliveCountTextBox.Text = gof.currentgeneration.alivecount.ToString();
                    break;
            }
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            ButtonStart.Enabled = false;
            ButtonNext.Enabled = false;
            ButtonPause.Enabled = true;
            ButtonEarly.Enabled = false;
            ButtonClear.Enabled = false;
            gof.gameison = true;
        }

        private void ButtonPause_Click(object sender, EventArgs e)
        {
            ButtonStart.Enabled = true;
            ButtonPause.Enabled = false;
            ButtonNext.Enabled = true;
            ButtonClear.Enabled = true;
            if (gof.legacy.Count() != 0)
                ButtonEarly.Enabled = true;
            gof.gameison = false;
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            ShowNextGeneration();
            ButtonEarly.Enabled = true;
            if (gof.legacy.Count() > 50) gof.legacy.Deletelast();
            AliveCountTextBox.Text = gof.currentgeneration.alivecount.ToString();
        }

        private void ButtonEarly_Click(object sender, EventArgs e)
        {
            gof.currentgeneration = gof.legacy.Pop();
            if (gof.legacy.Count() == 0)
                ButtonEarly.Enabled = false;
            Drawpreviousgeneration();
            AliveCountTextBox.Text = gof.currentgeneration.alivecount.ToString();
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            ButtonEarly.Enabled = false;
            gof.legacy.Clear();
            gof.killgeneration(gof.width, gof.height);
            AliveCountTextBox.Text = "0";
            Clearfield();
        }

       private void ShowNextGeneration()
        {
            gof.CreateNextGeneration(gof.width, gof.height);
            Drawnextgeneration();
        }

        public void Drawgrid()
        {
            for (var i = 1; i <= gof.width; i++)
            {
                gof.graph.DrawLine(gof.paints.gridpen, i * 10 - 1, 0, i * 10 - 1, Field.Height);
            }

            for (var i = 1; i <= gof.height; i++)
            {
                gof.graph.DrawLine(gof.paints.gridpen, 0, i * 10 - 1, Field.Width, i * 10 - 1);
            }
        }

        public void Drawnextgeneration()
        {
            for (var i = 0; i < gof.width; i++)
            for (var j = 0; j < gof.height; j++)
                if (gof.currentgeneration.cells[i, j].isalive == 1)
                    gof.graph.FillRectangle(gof.paints.livecellbrush, i * 10 + 1, j * 10 + 1, 7, 7);
                else if (gof.currentgeneration.cells[i, j].wasalive)
                    gof.graph.FillRectangle(gof.paints.diedcellbrush, i * 10 + 1, j * 10 + 1, 7, 7);
            Field.Refresh();
        }

        public void Drawpreviousgeneration()
        {
            for (var i = 0; i < gof.width; i++)
            for (var j = 0; j < gof.height; j++)
                if (gof.currentgeneration.cells[i, j].isalive == 1)
                    gof.graph.FillRectangle(gof.paints.livecellbrush, i * 10 + 1, j * 10 + 1, 7, 7);
                else if (gof.currentgeneration.cells[i, j].wasalive)
                    gof.graph.FillRectangle(gof.paints.diedcellbrush, i * 10 + 1, j * 10 + 1, 7, 7);
                else
                    gof.graph.FillRectangle(gof.paints.backgrouncolorbrush, i * 10 + 1, j * 10 + 1, 7, 7);
            Field.Refresh();
        }

        public void Clearfield()
        {
            for (var i = 0; i < gof.width; i++)
            for (var j = 0; j < gof.height; j++)
            {
                gof.graph.FillRectangle(gof.paints.backgrouncolorbrush, i * 10 + 1, j * 10 + 1, 7, 7);
            }
            Field.Refresh();
        }
    }

    public class Mygame
    {
        public Deq<Generation> legacy;
        public Generation currentgeneration;
        public bool gameison;
        public int width, height, initialtime;
        public Paints paints;
        public Graphics graph;

        public Mygame(int setwidth, int setheight, int i, Color l, Color d, Color b, Color g, Graphics gr)
        {
            width = setwidth;
            height = setheight;
            initialtime = i;
            legacy = new Deq<Generation>();
            currentgeneration = new Generation(width,height);
            paints = new Paints(l, d, b, g);
            graph = gr;
        }

        public class Paints
        {
            public SolidBrush livecellbrush;
            public SolidBrush diedcellbrush;
            public SolidBrush backgrouncolorbrush;
            public Pen gridpen;

            public Paints(Color l, Color d, Color b, Color g)
            {
                livecellbrush = new SolidBrush(l);
                diedcellbrush = new SolidBrush(d);
                backgrouncolorbrush = new SolidBrush(b);
                gridpen = new Pen(g);
            }
        }

        public class Generation
        {
            public int alivecount;
            public Cell[,] cells;

            public class Cell
            {
                public int isalive;
                public bool wasalive;
                public Cell()
                {
                    isalive = 0;
                    wasalive = false;
                }
            }
            public Generation(int width, int height)
            {
                cells = new Cell[width, height];
                for (var i = 0; i < width; i++)
                for (var j = 0; j < height; j++)
                    cells[i, j] = new Cell();
                alivecount = 0;
            }
            public int CountNeighbors(int i, int j, int width, int height)
            {
                return (cells[(i - 1 + width) % width, (j - 1 + height) % height].isalive + cells[(i - 1 + width) % width, j].isalive + cells[(i - 1 + width) % width, (j + 1) % height].isalive
                        + cells[i, (j - 1 + height) % height].isalive + cells[i, (j + 1) % height].isalive
                        + cells[(i + 1) % width, (j - 1 + height) % height].isalive + cells[(i + 1) % width, j].isalive + cells[(i + 1) % width, (j + 1) % height].isalive);
            }
        }
        public void CreateNextGeneration(int width, int height)
        {
            legacy.Push(currentgeneration);
            Generation lastgeneration = currentgeneration;
            currentgeneration = new Mygame.Generation(width, height);
                for (var i = 0; i < width; i++)
            for (var j = 0; j < height; j++)
            {
                int neighbors = lastgeneration.CountNeighbors(i, j, width, height);
                if (lastgeneration.cells[i, j].isalive == 0)
                    if (neighbors == 3)
                    {
                        currentgeneration.cells[i, j].isalive = 1;
                        currentgeneration.alivecount++;
                    }
                    else
                        currentgeneration.cells[i, j].wasalive = lastgeneration.cells[i, j].wasalive;
                else if (neighbors > 3 || neighbors < 2)
                {
                    currentgeneration.cells[i, j].isalive = 0;
                    currentgeneration.cells[i, j].wasalive = true;
                }
                else
                {
                    currentgeneration.cells[i, j].isalive = 1;
                    currentgeneration.alivecount++;
                }

            }
        }
        public void killgeneration(int width, int height)
        {
            for (var i = 0; i < width; i++)
            for (var j = 0; j < height; j++)
            {
                currentgeneration.cells[i, j].isalive = 0;
                currentgeneration.cells[i, j].wasalive = false;
            }
            currentgeneration.alivecount = 0;
        }
    }

    public class Deq<type>
    {
        private type[] array;

        public Deq()
        {
            array = new type[0];
        }
        public int Count() => array.Length;

        public void Push(type temp)
        {
            Array.Resize(ref array, array.Length + 1);
            array[array.Length - 1] = temp;
        }
        public type Pop()
        {
            type temp = array[array.Length - 1];
            Array.Resize(ref array, array.Length - 1);
            return temp;
        }
        public void Deletelast()
        {
            for (var i = 0; i < array.Length - 1; i++)
                array[i] = array[i + 1];
            Array.Resize(ref array, array.Length - 1);
        }
        public void Clear() => Array.Resize(ref array, 0);
    }

}
