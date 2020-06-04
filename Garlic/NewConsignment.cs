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
    public partial class NewConsignment : Form
    {
        Main main = new Main();
        Garlics Garlic = new Garlics();
        public NewConsignment(Main _main)
        {
            InitializeComponent();
            main = _main;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main.sQLFunction.InsertNewConsignment(valueNumber.Text, DateTime.Now.ToShortDateString(), Convert.ToDouble(valueWeight.Text),Convert.ToInt32(valueCaliber.Text), "storage", Garlic.CodeGarlic);
            MessageBox.Show("Партію "+ valueNumber.Text + " внесено");
        }

        private void NewConsignment_Load(object sender, EventArgs e)
        {
            Main.sQLFunction.LoadNewConsignment(TableNewConsignment);
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
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

        private void panelAdds_Click(object sender, EventArgs e)
        {
            panelAdds.Width = 31;
            panelSearchs.Width = 31;
            panelAdds.Enabled = false;
            panelSearchs.Enabled = false;
            TableGarlic.Visible = true;
            Main.sQLFunction.LoadGarlic(TableGarlic);
        }

        private void panelSearchs_Click(object sender, EventArgs e)
        {
            panelAdds.Width = 31;
            panelSearchs.Width = 31;
            panelAdds.Enabled = false;
            panelSearchs.Enabled = false;
            panelData.Height = 0;
            TableNewConsignment.Visible = true;
            btnInsert.Visible = false;
            Main.sQLFunction.LoadNewConsignment(TableNewConsignment);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            main.btnNewConsignment_Click(this,null);
        }

        private void TableGarlic_DoubleClick(object sender, EventArgs e)
        {
            Garlic = new Garlics(this.TableGarlic.SelectedRows[0].Cells[0].Value.ToString(), this.TableGarlic.SelectedRows[0].Cells[1].Value.ToString());
            MessageBox.Show("Вибрано часник з назвою '" + Garlic.Name + "' та типом '" + Garlic.Sort + "'");
            Garlic.CodeGarlic = Main.sQLFunction.GetGarlicCode(Garlic);
        }
    }
}
