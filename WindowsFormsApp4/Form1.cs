using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 aform = new Form2();
            aform.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form4 aForm = new Form4();
            aForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 aForm = new Form5();
            aForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
