using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Garlic
{
    public partial class Calibration : Form
    {
        public Calibration()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Відправити партію")
            {
                button2.Text = "Підтвердити";
                TableConsignment.Visible = true;
            }  
            else
            {
                button2.Text = "Відправити партію";
                TableConsignment.Visible = false;
                MessageBox.Show("Партія <none> відправлена на калібровку");
            }
              
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (panelSearch.Height == 0)
            {
                panelSearch.Height = panelSearch.Height + 90;
                return;
            }
            if (panelSearch.Height == 90)
            {
                panelSearch.Height = 0;
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelSearch_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
