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
    public partial class Storage : Form
    {
        static Garlics garlics;
        public Storage()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

      

        private void Storage_Load(object sender, EventArgs e)
        {
            Main.sQLFunction.LoadGarlic(TableGarlic);
            Main.sQLFunction.LoadConsignment(TableConsignment);

        }

        private void btnInsertConsignment_Click(object sender, EventArgs e)
        {
            if (garlics==null)
                MessageBox.Show("Не вибраний часник!");
            else
            {
                Consignment consignment = new Consignment(NumberConsignmentValue.Text, Convert.ToDateTime(dateTimePickerDateCollection.Value.ToShortDateString()), Convert.ToDateTime(dateTimePickerDateReceiving.Value.ToShortDateString()), Convert.ToDouble(AreaValue.Text), "storage", Convert.ToDouble(WeightConsignmentValue.Text), garlics.CodeGarlic);
                Main.sQLFunction.InsertConsignment(consignment);
                NumberConsignmentValue.Text = "";
                AreaValue.Text = "";
                WeightConsignmentValue.Text = "";
            }

        }

        private void TableGarlic_DoubleClick(object sender, EventArgs e)
        {
            garlics = new Garlics(this.TableGarlic.SelectedRows[0].Cells[0].Value.ToString(), this.TableGarlic.SelectedRows[0].Cells[1].Value.ToString());
            MessageBox.Show("Вибрано часник з назвою '"+garlics.Name+"' та типом '"+garlics.Sort+"'");
            garlics.CodeGarlic=Main.sQLFunction.GetGarlicCode(garlics);
        }

        private void NumberConsignmentValue_Validating(object sender, CancelEventArgs e)
        {
            if(NumberConsignmentValue.Text == string.Empty)
            {
                MessageBox.Show("Не введено номер партії");
            }
        }

        private void AreaValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }

        }

        private void panelAdds_MouseEnter(object sender, EventArgs e)
        {
            labelAdd.Font = new Font("Century Gothic", 40F, FontStyle.Regular,
                  GraphicsUnit.Point, ((byte)(204)));
          panelAdds.BackColor=Color.FromArgb(253, 251, 253);
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
            panelAdds.Width = 0;
            panelSearchs.Width = 0;
            panelAdd.Visible = true;
            btnInsertConsignment.Visible = true;
            pictureBoxClose.Visible = true;

        }

        private void panelSearchs_Click(object sender, EventArgs e)
        {
            panelAdds.Width = 0;
            panelSearchs.Width = 0;
            panelRevision.Visible = true;
            pictureBoxClose.Visible = true;
        }

        private void panelAdds_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            panelAdds.Width = 513;
            panelSearchs.Width = 513;
            panelAdd.Visible = false;
            btnInsertConsignment.Visible = false;
            panelRevision.Visible = false;
            pictureBoxClose.Visible = false;
        }

        private void AreaValue_Leave(object sender, EventArgs e)
        {
            
        }

        private void WeightConsignmentValue_Leave(object sender, EventArgs e)
        {
            
        }

        private void WeightConsignmentValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void AreaValue_MouseLeave(object sender, EventArgs e)
        {
            if (AreaValue.Text != "")
            {
                if (Convert.ToDouble(AreaValue.Text) == 0)
                {
                    MessageBox.Show("Площа не може дорівнювати нулю");
                    AreaValue.Text = "";
                }

            }
        }

        private void WeightConsignmentValue_MouseLeave(object sender, EventArgs e)
        {
            if (WeightConsignmentValue.Text != "")
            {
                if (Convert.ToDouble(WeightConsignmentValue.Text) == 0)
                {
                    MessageBox.Show("Вага не може дорівнювати нулю");
                    WeightConsignmentValue.Text = "";
                }

            }
        }
    }
}
