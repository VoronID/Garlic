using Garlic.Model;
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
    public partial class Refrigerator : Form
    {
        public static RefrigeratorClass refrigeratorClass;
        Mapa Mapa = new Mapa("Refregerator");
        string codeNumber;
        public Refrigerator()
        {
            InitializeComponent();
            refrigeratorClass = new RefrigeratorClass();
         
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

        private void TableConsignment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Mapa.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            refrigeratorClass.DateOperation = Convert.ToDateTime(Convert.ToDateTime(dTPdata.Text).ToShortDateString());
            refrigeratorClass.CodeNumber = codeNumber;
            MessageBox.Show("Camera:" + refrigeratorClass.Camera + "\n" + "Column:" + refrigeratorClass.Column + "\n" + "Rows:" + refrigeratorClass.Rows + "\n" + "Storey:" + refrigeratorClass.Storey+"\n"+"Code:"+ refrigeratorClass.CodeNumber+"\n"+"Data:"+ refrigeratorClass.DateOperation);
            Main.sQLFunction.InsertInRefrigerator(refrigeratorClass.Camera, refrigeratorClass.Column, refrigeratorClass.Rows, refrigeratorClass.Storey, refrigeratorClass.DateOperation, refrigeratorClass.CodeNumber);
        }

        private void Refrigerator_Load(object sender, EventArgs e)
        {
            Main.sQLFunction.LoadNewConsignment(TableNewConsignment);
            Main.sQLFunction.SearchNumberNewConsignment(valueNumberConsignment, "storage");
         
        }

        private void TableNewConsignment_DoubleClick(object sender, EventArgs e)
        {
            codeNumber = this.TableNewConsignment.SelectedRows[0].Cells[0].Value.ToString();
            MessageBox.Show("Вибрано партію з кодом:" + codeNumber);
        
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if(panelSearch.Height == 0)
                panelSearch.Height = 80;
            else
                panelSearch.Height = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TableNewConsignment.Rows.Clear();
            Main.sQLFunction.SearchNewConsignment(TableNewConsignment, "storage", valueNumberConsignment.Text);
        }
    }
}
