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
        string CodeConsignment;
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
                labelDate.Visible = true;
                dtPDate.Visible = true;
                panel1.Visible = true;

            }  
            else
            {
                if(CodeConsignment!=null)
                {
                    button2.Text = "Відправити партію";
                    TableConsignment.Visible = false;
                    panel1.Visible = false;
                    Main.sQLFunction.InsertInCalibration(CodeConsignment, Convert.ToDateTime(dtPDate.Value.ToShortDateString()));
                    MessageBox.Show("Партія:"+CodeConsignment+". Відправлена на калібровку");
                }
              
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

        private void Calibration_Load(object sender, EventArgs e)
        {
            Main.sQLFunction.LoadConsignmentInProcess(TableConsignment, "after drying");
        }

        private void TableConsignment_DoubleClick(object sender, EventArgs e)
        {
            CodeConsignment = TableConsignment.SelectedRows[0].Cells[0].Value.ToString();
            MessageBox.Show("Вибрано партію:" + CodeConsignment);
        }
    }
}
