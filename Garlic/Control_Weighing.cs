using Garlic.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Garlic
{
    public partial class Control_Weighing : Form
    {
        string process = "";
        Main main = new Main();
        public static Control_WeighingClass control_Weighing = new Control_WeighingClass();
        List<double> weight = new List<double>();
        List<string> month = new List<string>();
      
        public Control_Weighing(Main _main)
        {
            InitializeComponent();
            main = _main;
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("uk-UA");
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("uk-UA");
            targetCulture = System.Threading.Thread.CurrentThread.CurrentCulture;
            //System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat = new NumberFormatInfo();
 

            //а здесь формирую культуру на основе текущей(русской) и устанавливаю десятичный разделитель
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo(Application.CurrentCulture.Name);
            culture.NumberFormat.CurrencyDecimalSeparator = ",";
            Application.CurrentCulture = culture;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //if (panelSearch.Height == 0)
            //{
            //    panelSearch.Height = panelSearch.Height + 90;
            //    return;
            //}
            //if (panelSearch.Height == 90)
            //{
            //    panelSearch.Height = 0;
            //    return;
            //}
        }

        string mymonth = DateTime.Now.ToString("MMM");
        
        DateTimeStyles styles = DateTimeStyles.None;
        CultureInfo culture = CultureInfo.CreateSpecificCulture("uk-UA");
        CultureInfo targetCulture;

        public void AddRecord()
        {
            if (process == "Add")
            {
                panelDate.Height = 103;
                panelButton.Height = 70;
                control_Weighing.StateWeight = Main.sQLFunction.LoadWeightNewConsignment(control_Weighing.CodeNumber);
                valueStateWeight.Text = control_Weighing.StateWeight.ToString();
            }
            if (process == "Search")
            {
                panelDate.Height = 70;
                panelButton.Height = 70;
             
              
                panelAdds.Width = 30;
                panelSearchs.Width = 30;
                panelSearchs.Enabled = false;
                panelAdds.Enabled = false;
                Main.sQLFunction.LoadDateAndWeightNewConsignment(control_Weighing.CodeNumber,ref weight, ref month);
                Graphs.month = month;
                Graphs.weight = weight;
                Graphs.codeNumber = control_Weighing.CodeNumber;
                OpenlyFormInPanel(new Graphs());
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

        private void panelAdds_Click(object sender, EventArgs e)
        {
            panelAdds.Width = 0;
            panelSearchs.Width = 0;
            panelDate.Height = 0;
            panelButton.Height = 0;
            process = "Add";
            OpenlyFormInPanel(new Mapa("Weight",this));
        }

        private void panelSearchs_Click(object sender, EventArgs e)
        {
            panelAdds.Width = 0;
            panelSearchs.Width = 0;
            panelDate.Height = 0;
            panelButton.Height = 0;
            process = "Search";
            OpenlyFormInPanel(new Mapa("Weight", this));
            panelDate.Visible = false;
            panelButton.Visible = false;
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

       

        private void button2_Click(object sender, EventArgs e)
        {
            control_Weighing.ActualWeight = Convert.ToDouble(valueActualWeight.Text);
            control_Weighing.Deviation = Convert.ToDouble(valueDeviation.Text);
            control_Weighing.dataOperation = Convert.ToDateTime(Convert.ToDateTime(dTPDate.Value.ToShortDateString()));
            Main.sQLFunction.InsertControlWeight(control_Weighing);
            valueActualWeight.Text = "";
            valueDeviation.Text = "";
            valueStateWeight.Text = "";


        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            main.btnWeighing_Click(this,null);
        }

        private void Control_Weighing_Load(object sender, EventArgs e)
        {
      
            valueStateWeight.Enabled = false;
        }

        private void valueActualWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44) // цифры, клавиша BackSpace и запятая
            {
                e.Handled = true;
            }
        }

        private void valueActualWeight_MouseLeave(object sender, EventArgs e)
        {
            if (valueActualWeight.Text != "")
            {
                if (Convert.ToInt32(valueActualWeight.Text) == 0)
                {
                    MessageBox.Show("Вага не може дорівнювати нулю");
                    valueActualWeight.Text = "";
                    valueDeviation.Text = "";
                }
                else
                {
                    if (Convert.ToDouble(valueActualWeight.Text) < Convert.ToDouble(valueStateWeight.Text))
                    {
                        valueDeviation.Text = Math.Round((Convert.ToDouble(valueStateWeight.Text) - Convert.ToDouble(valueActualWeight.Text)), 2).ToString();
                    }
                    else
                    {
                        valueActualWeight.Text = "";
                        valueDeviation.Text = "";
                        MessageBox.Show("Вага не може бути більшою за попередню");
                    }
                }
                
            }
        }
    }
}
