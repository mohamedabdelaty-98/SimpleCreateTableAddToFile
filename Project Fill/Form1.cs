using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Fill
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void addcontrol(Control c)
        {
            c.Dock = DockStyle.Fill;
            panel3.Controls.Clear();
            panel3.Controls.Add(c);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 ff = new Form1();
            this.Hide();
            ff.ShowDialog(this);
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Us_Create c = new Us_Create();
            addcontrol(c);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Us_Add a = new Us_Add();
            addcontrol(a);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Us_Delete d = new Us_Delete();
            addcontrol(d);
        }
    }
}
