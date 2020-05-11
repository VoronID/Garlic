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
            panelEnterDate.Visible = true;
            TableConsignment.Visible = true;
            labelStart.Visible = true;
            dateTimePickerStart.Visible = true;
            
            labelWeight.Visible = false;
            textBoxWeight.Visible = false;
            labelEnd.Visible = false;
            dateTimePickerEnd.Visible = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panelEnterDate.Visible = true;
            TableConsignment.Visible = true;
            labelStart.Visible = false;
            dateTimePickerStart.Visible = false;
            labelWeight.Visible = true;
            textBoxWeight.Visible = true;
            labelEnd.Visible = true;
            dateTimePickerEnd.Visible = true;

        }
    }
}
