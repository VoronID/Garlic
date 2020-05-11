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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        List<string> nameButton = new List<string>() { "Часник", "      Приймання на склад", "Сушка", "   Калібрування", "   Нова партія", "    Холодильник", "       Контрольне зважування", "      Продаж та списання", "   Мапа" };
        /// <summary>
        /// Збільшення шрифту
        /// </summary>
        /// <param name="font"></param>
        void MagnificationFont(Button btn)
        {
            btn.Font = new Font("Century Gothic", 14F, FontStyle.Bold,
                     GraphicsUnit.Point, ((byte)(204)));
        }

        /// <summary>
        /// Зменшення шрифту
        /// </summary>
        /// <param name="btn"></param>
        void ReductionFont(Button btn)
        {
            btn.Font = new Font("Century Gothic", 12F, FontStyle.Regular,
                      GraphicsUnit.Point, ((byte)(204)));
        }
        private void DisableButton()
        {
            foreach(Control previousBtn in panelMenu.Controls)
            {
                if(previousBtn.GetType()==typeof(Button))
                {
                    previousBtn.Text="";
                }
            }
        }

        private void IncludeButton()
        {
            int count=8;
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.Text = nameButton[count];
                    count--;
                }
            }
        }

        private void btnGarlic_MouseEnter(object sender, EventArgs e)
        {
            MagnificationFont(btnGarlic);
        }

        private void btnGarlic_MouseLeave(object sender, EventArgs e)
        {
            ReductionFont(btnGarlic);
        }

        private void btnWarehouse_MouseEnter(object sender, EventArgs e)
        {
            btnWarehouse.Font = new Font("Century Gothic", 13F, FontStyle.Bold,
                       GraphicsUnit.Point, ((byte)(204)));
        }

        private void btnWarehouse_MouseLeave(object sender, EventArgs e)
        {
            ReductionFont(btnWarehouse);
        }

        private void btnDrying_MouseEnter(object sender, EventArgs e)
        {
            MagnificationFont(btnDrying);
        }

        private void btnDrying_MouseLeave(object sender, EventArgs e)
        {
            ReductionFont(btnDrying);
        }

        private void btnCaliber_MouseEnter(object sender, EventArgs e)
        {
            MagnificationFont(btnCaliber);
        }


        private void btnCaliber_MouseLeave(object sender, EventArgs e)
        {
            ReductionFont(btnCaliber);
        }

        private void btnNewConsignment_MouseEnter(object sender, EventArgs e)
        {
            MagnificationFont(btnNewConsignment);
        }

        private void btnNewConsignment_MouseLeave(object sender, EventArgs e)
        {
            ReductionFont(btnNewConsignment);
        }

        private void btnRefrigerator_MouseEnter(object sender, EventArgs e)
        {
            MagnificationFont(btnRefrigerator);
        }

        private void btnRefrigerator_MouseLeave(object sender, EventArgs e)
        {
            ReductionFont(btnRefrigerator);
        }

        private void btnWeighing_MouseEnter(object sender, EventArgs e)
        {
            btnWeighing.Font = new Font("Century Gothic", 12F, FontStyle.Bold,
                       GraphicsUnit.Point, ((byte)(204)));
        }

        private void btnWeighing_MouseLeave(object sender, EventArgs e)
        {
            ReductionFont(btnWeighing);
        }

     

        private void btnSelling_MouseEnter(object sender, EventArgs e)
        {
            btnSelling.Font = new Font("Century Gothic", 13F, FontStyle.Bold,
                       GraphicsUnit.Point, ((byte)(204)));
        }

        private void btnSelling_MouseLeave(object sender, EventArgs e)
        {
            ReductionFont(btnSelling);
        }

        private void btnMap_MouseEnter(object sender, EventArgs e)
        {
            MagnificationFont(btnMap);
        }

        private void btnMap_MouseLeave(object sender, EventArgs e)
        {
            ReductionFont(btnMap);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (panelMenu.Width==254)
            {
                pictureBoxLogo.Width = pictureBoxLogo.Width - 125;
                pictureBoxLogo.Height = pictureBoxLogo.Height - 28;
                pictureBoxLogo.Top = pictureBoxLogo.Top + 14;
                panelMenu.Width = panelMenu.Width - 199;
                DisableButton();
            }
            else
            {
                pictureBoxLogo.Width = pictureBoxLogo.Width + 125;
                pictureBoxLogo.Height = pictureBoxLogo.Height + 28;
                pictureBoxLogo.Top = pictureBoxLogo.Top - 14;
                panelMenu.Width = panelMenu.Width + 199;
                IncludeButton();
            }
            
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

        private void btnGarlic_Click(object sender, EventArgs e)
        {
            labelNavigation.Text = "ЧАСНИК";
        }

        private void btnWarehouse_Click(object sender, EventArgs e)
        {
            labelNavigation.Text = "ПРИЙМАННЯ НА СКЛАД";
            OpenlyFormInPanel(new Storage());
        }

        private void btnDrying_Click(object sender, EventArgs e)
        {
            labelNavigation.Text = "СУШКА";
            OpenlyFormInPanel(new Drying());
        }

        private void btnCaliber_Click(object sender, EventArgs e)
        {
            labelNavigation.Text = "КАЛІБРУВАННЯ";
        }

        private void btnNewConsignment_Click(object sender, EventArgs e)
        {
            labelNavigation.Text = "НОВА ПАРТІЯ";
        }

        private void btnRefrigerator_Click(object sender, EventArgs e)
        {
            labelNavigation.Text = "ХОЛОДИЛЬНИК";
        }

        private void btnWeighing_Click(object sender, EventArgs e)
        {
            labelNavigation.Text = "КОНТРОЛЬНЕ ЗВАЖУВАННЯ";
        }

        private void btnSelling_Click(object sender, EventArgs e)
        {
            labelNavigation.Text = "ПРОДАЖ ТА СПИСАННЯ";
        }

        private void btnMap_Click(object sender, EventArgs e)
        {
            labelNavigation.Text = "МАПА";
        }
    }
}
    