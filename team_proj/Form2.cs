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
            Graphics g = e.Graphics;
            Pen blackPen = new Pen(Color.Black, 3);
            SolidBrush lsbBr = new SolidBrush(Color.LightSkyBlue);
            
            Point[] points =
            {
                new Point(38, 12),
                new Point(21, 38),
                new Point(0, 38),
                new Point(0, 88),
                new Point(140, 88),
                new Point(140, 38),
                new Point(55, 38)
            };
            g.FillPolygon(lsbBr, points);
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void more_Click(object sender, EventArgs e)
        {
            if (this.label1.Text == "강남역")
                MessageBox.Show("강남역");
            if (this.label1.Text == "가산디지털단지역")
                MessageBox.Show("가산디지털단지");
        }
    }
}
