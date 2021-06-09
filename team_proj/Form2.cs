using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace team_proj
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
        }

        public Form2(string time)
        {
            InitializeComponent();
            Time = time;
            label3.Text = Time;
            this.FormBorderStyle = FormBorderStyle.None;
        }
        private string Time;

        private void Form2_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            this.BackColor = Color.White;
            this.TransparencyKey = Color.White;
            this.label1.BackColor = Color.LightSkyBlue;
            this.label2.BackColor = Color.LightSkyBlue;
            this.label3.BackColor = Color.LightSkyBlue;

            Graphics g = e.Graphics;
            Pen blackPen = new Pen(Color.Black, 3);
            SolidBrush lsbBr = new SolidBrush(Color.LightSkyBlue);
            
            Point[]Points =
            {
                new System.Drawing.Point(38, 12),
                new System.Drawing.Point(21, 38),
                new System.Drawing.Point(0, 38),
                new System.Drawing.Point(0, 120),
                new System.Drawing.Point(150, 120),
                new System.Drawing.Point(150, 38),
                new System.Drawing.Point(55, 38)
            };
            g.FillPolygon(lsbBr,Points);
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void more_Click(object sender, EventArgs e)
        {
            string name = label1.Text;
            string time = label3.Text;
            Form3 Fo = new Form3(name, time);
            Fo.Owner = this;
            Fo.Show();




        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
