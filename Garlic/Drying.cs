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
    public partial class Drying : Form
    {
        public Drying()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(panelSearch.Height==0)
            {
                panelSearch.Height = panelSearch.Height + 90;
                return;
            }
            if(panelSearch.Height == 90)
            {
                panelSearch.Height = 0;
                return;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(button2.Text== "Додати в сушку")
            {
                panelEnterDate.Visible = true;
                TableConsignment.Visible = true;
                labelStart.Visible = true;
                dateTimePickerStart.Visible = true;

                labelWeight.Visible = false;
                textBoxWeight.Visible = false;
                labelEnd.Visible = false;
                dateTimePickerEnd.Visible = false;
                button2.Text = "Підтвердити";
            }
            else
            {
                panelEnterDate.Visible = false;
                TableConsignment.Visible = false;
                labelStart.Visible = false;
                dateTimePickerStart.Visible = false;
                button2.Text = "Додати в сушку";
                MessageBox.Show("Партія <none> відправлена на сушку");
            }
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(button3.Text== "Забрати з сушку")
            {
                panelEnterDate.Visible = true;
                TableConsignment.Visible = true;
                labelStart.Visible = false;
                dateTimePickerStart.Visible = false;
                labelWeight.Visible = true;
                textBoxWeight.Visible = true;
                labelEnd.Visible = true;
                dateTimePickerEnd.Visible = true;
                button3.Text = "Підтвердити";

            }
            else
            {
                labelWeight.Visible = false;
                textBoxWeight.Visible = false;
                labelEnd.Visible = false;
                dateTimePickerEnd.Visible = false;
                panelEnterDate.Visible = false;
                TableConsignment.Visible = false;
                button3.Text = "Забрати з сушку";
                MessageBox.Show("Партію <none> забрали з сушки");
            }
           

        }
    }
}
