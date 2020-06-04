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
    public partial class WriteOff : Form
    {
        Main Main;
        public WriteOff(Main main)
        {
            InitializeComponent();
            Main = main;
        }
        public static RefrigeratorClass refrigeratorClass = new RefrigeratorClass();
        public static Model.NewConsignment NewConsignment;
        public static WriteOffClass WriteOffClass = new WriteOffClass();
        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            labelAdd.Font = new Font("Century Gothic", 40F, FontStyle.Regular,
              GraphicsUnit.Point, ((byte)(204)));
            panelAdds.BackColor = Color.FromArgb(253, 251, 253);
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            labelAdd.Font = new Font("Century Gothic", 36F, FontStyle.Regular,
             GraphicsUnit.Point, ((byte)(204)));
            panelAdds.BackColor = SystemColors.Control;
        }

        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            labelSearch.Font = new Font("Century Gothic", 40F, FontStyle.Regular,
              GraphicsUnit.Point, ((byte)(204)));
            panelSearchs.BackColor = Color.FromArgb(253, 251, 253);
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            labelSearch.Font = new Font("Century Gothic", 36F, FontStyle.Regular,
             GraphicsUnit.Point, ((byte)(204)));
            panelSearchs.BackColor = SystemColors.Control;
        }

        private void panelAdds_Click(object sender, EventArgs e)
        {
            panelAdds.Width = 0;
            panelSearchs.Width = 0;
            panelButton.Height = 0;
            panelData.Height = 0;
            OpenlyFormInPanel(new Mapa("Write-Off", this));
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
            panelButton.Height = 70;
            panelData.Height = 574;
            valueNumberConsignment.Text = NewConsignment.NumberConsignment;
            valueDate.Text = NewConsignment.DateCreation.ToShortDateString();
            valueCaliber.Text = NewConsignment.Caliber.ToString();
            valueWeight.Text = NewConsignment.Weight.ToString();
            valueSort.Text = NewConsignment.Garlic.Name;
            valueType.Text = NewConsignment.Garlic.Sort;
        }
        private void panelSearchs_Click(object sender, EventArgs e)
        {
            panelAdds.Width = 0;
            panelSearchs.Width = 0;
            panelData.Height = 50;
            panelButton.Height = 70;
            TableNewConsignment.Visible = true;
            Main.sQLFunction.LoadConsignmentWriteOff(TableNewConsignment);
            label7.Visible = true;
            label8.Visible = true;
            dTPFrom.Visible = true;
            dTPTo.Visible = true;
            pictureBox10.Visible = true;
            pictureBox9.Visible = true;




        }

        private void buttonButton_Click(object sender, EventArgs e)
        {
            WriteOffClass.DateOperation = Convert.ToDateTime(dTPDate.Value.ToShortDateString());
            Main.sQLFunction.InsertWriteOff(WriteOffClass);
            Main.sQLFunction.RelocationRefrigerator(refrigeratorClass);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            TableNewConsignment.Rows.Clear();
            Main.sQLFunction.SearchConsignmentWriteOffByDate(TableNewConsignment, Convert.ToDateTime(dTPFrom.Value.ToShortDateString()), Convert.ToDateTime(dTPTo.Value.ToShortDateString()));

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            ReportViwer reportViwer = new ReportViwer(Convert.ToDateTime(dTPFrom.Value.ToShortDateString()), Convert.ToDateTime(dTPTo.Value.ToShortDateString()), "Write");
            reportViwer.ShowDialog();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Main.button1_Click(this,null);
        }
    }
}
