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
    public partial class Sell : Form
    {
        Main Main = new Main();
        public static RefrigeratorClass refrigeratorClass = new RefrigeratorClass();
        public static SellClass SellClass = new SellClass();
        public static string numberCode;
        public static int codeRefrigerator;
        public Sell(Main main)
        {
            InitializeComponent();
            Main = main;
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

        private void panelAdds_MouseEnter(object sender, EventArgs e)
        {
            labelAdd.Font = new Font("Century Gothic", 40F, FontStyle.Regular,
              GraphicsUnit.Point, ((byte)(204)));
            panelAdds.BackColor = Color.FromArgb(253, 251, 253);
        }

        private void panelAdds_MouseLeave(object sender, EventArgs e)
        {
            labelAdd.Font = new Font("Century Gothic", 36F, FontStyle.Regular,
              GraphicsUnit.Point, ((byte)(204)));
              panelAdds.BackColor = SystemColors.Control;
        }

        private void panelSearchs_MouseEnter(object sender, EventArgs e)
        {
            labelSearch.Font = new Font("Century Gothic", 40F, FontStyle.Regular,
              GraphicsUnit.Point, ((byte)(204)));
            panelSearchs.BackColor = Color.FromArgb(253, 251, 253);
        }

        private void panelSearchs_MouseLeave(object sender, EventArgs e)
        {
            labelSearch.Font = new Font("Century Gothic", 36F, FontStyle.Regular,
              GraphicsUnit.Point, ((byte)(204)));
            panelSearchs.BackColor = SystemColors.Control;
        }
        public void OpenlyFormInPanel(object Formhijo)
        {
            if (this.panelContent.Controls.Count > 0)
                this.panelContent.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContent.Controls.Add(fh);
            this.panelContent.Tag = fh;
            fh.Show();
        }


        public void AddInterface()
        {
            panelDate.Height = 570;
            panelButton.Height = 70;
            valueNumberConsignment.Text = SellClass.NumberConsignment;
            valueWeight.Text = SellClass.Weight.ToString();
        }
        private void panelAdds_Click(object sender, EventArgs e)
        {
            panelAdds.Width = 0;
            panelSearchs.Width = 0;
            panelDate.Height = 0;
            panelButton.Height = 0;
            OpenlyFormInPanel(new Mapa("Sell", this));
           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Main.btnSelling_Click(this,null);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            SellClass sell = new SellClass(Convert.ToDateTime(Convert.ToDateTime(dTPDate.Value.ToShortDateString())), Convert.ToDouble(valuePrice.Text), Convert.ToDouble(ValueTotalPrice.Text), SellClass.NumberConsignment, SellClass.CodeRefrigerator);
            Main.sQLFunction.InsertSell(sell);
            Main.sQLFunction.RelocationRefrigerator(refrigeratorClass);
          
    

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void valuePrice_MouseLeave(object sender, EventArgs e)
        {
            if(valuePrice.Text!="")
            {
                ValueTotalPrice.Text = Math.Round((Convert.ToDouble(valuePrice.Text) * Convert.ToDouble(valueWeight.Text)), 2).ToString();
            }
        }

        private void panelSearchs_Click(object sender, EventArgs e)
        {
            panelAdds.Width = 0;
            panelSearchs.Width = 0;
            panelDate.Height = 50;
            panelButton.Height = 70;
            TableNewConsignment.Visible = true;
            Main.sQLFunction.LoadConsignmentSell(TableNewConsignment);
            label6.Visible = true;
            dTPFrom.Visible = true;
            label7.Visible = true;
            dTPTo.Visible = true;
            pictureBox5.Visible = true;
            pictureBox4.Visible = true;





        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ReportViwer reportViwer = new ReportViwer(Convert.ToDateTime(dTPFrom.Value.ToShortDateString()), Convert.ToDateTime(dTPTo.Value.ToShortDateString()),"Sell");
            reportViwer.ShowDialog();
        }

        private void dateTimePicker2_MouseLeave(object sender, EventArgs e)
        {
             }

        private void dateTimePicker1_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            TableNewConsignment.Rows.Clear();
            Main.sQLFunction.SearchConsignmentSellBtDate(TableNewConsignment, Convert.ToDateTime(dTPFrom.Value.ToShortDateString()), Convert.ToDateTime(dTPTo.Value.ToShortDateString()));
           
        }
    }
}
