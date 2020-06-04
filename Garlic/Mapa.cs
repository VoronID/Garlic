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
    public partial class Mapa : Form
    {
        SellClass sell = new SellClass();
        WriteOffClass WriteOffClass = new WriteOffClass();
        Control_Weighing Control_Weighing;
        RefrigeratorClass refrigerator;
        WriteOff WriteOff;
        Sell Sell;
        List<string> numberConsignment = new List<string>(6);
        Model.NewConsignment NewConsignment = new Model.NewConsignment();
         string column;
         int rows;
         string storage;
        int storey;
        string Form = "";
        public Mapa(string form)
        {
            InitializeComponent();
            Form = form;
        }

        public Mapa(string form,Control_Weighing control_Weighing)
        {
            InitializeComponent();
            Control_Weighing = control_Weighing;
            Form = form;
        }

        public Mapa(string form,WriteOff writeOff)
        {
            InitializeComponent();
            WriteOff = writeOff;
            Form = form;
        }

        public Mapa(string form,Sell sell)
        {
            InitializeComponent();
            Sell = sell;
            Form = form;
        }
        private void Mapa_Load(object sender, EventArgs e)
        {
            LoadCountConsignment();
        }

        void LoadCountConsignment()
        {
   
            foreach (Control previousBtn in Controller.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    CalculationBox((Button)previousBtn);
                    previousBtn.Text = Main.sQLFunction.LoadCountConsignmentInCell(refrigerator).ToString();
                }
               
            }
        }
      

void CalculationBox(Button panel)
        {

            if(panel.Location.X<432)
            {
                switch (panel.Location.X)
                {
                    case 58: { column = "A"; break; }
                    case 120: { column = "B"; break; }
                    case 166: { column = "C"; break; }
                    case 226: { column = "D"; break; }
                    case 272: { column = "E"; break; }
                    case 330: { column = "F"; break; }
                    case 376: { column = "G"; break; }
                    case 431: { column = "H"; break; }
                }
                storage = "K1";
            }
            else
            {
                switch (panel.Location.X)
                {
                    case 590: { column = "A"; break; }
                    case 652: { column = "B"; break; }
                    case 698: { column = "C"; break; }
                    case 758: { column = "D"; break; }
                    case 804: { column = "E"; break; }
                    case 862: { column = "F"; break; }
                    case 908: { column = "G"; break; }
                    case 963: { column = "H"; break; }
                }
                storage = "K2";
            }
            switch (panel.Location.Y)
            {
                case 121: { rows = 1; break; }
                case 157: { rows = 2; break; }
                case 193: { rows = 3; break; }
                case 229: { rows = 4; break; }
                case 265: { rows = 5; break; }
                case 301: { rows = 6; break; }
                case 337: { rows = 7; break; }
                case 373: { rows = 8; break; }
                case 409: { rows = 9; break; }
                case 445: { rows = 10; break; }
                case 481: { rows = 11; break; }
                case 517: { rows = 12; break; }
                case 553: { rows = 13; break; }
            }
            refrigerator = new RefrigeratorClass(storage, column, rows);
            //MessageBox.Show("Склад:"+storage+" Ряд:"+rows+" Колонка:"+column);

            //panelConsignment.Visible = true;
            //panelConsignment.Location = new Point(panel10.Location.X + panel10.Width + 1, panel10.Location.Y - 76);


        }



        void ClearButton()
        {
            foreach (Control previousBtn in panelConsignment.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.Text="Пусто";
                }
            }
        }
        void CalculationBoxs(Button panel)
        {

            if (panel.Location.X < 432)
            {
                switch (panel.Location.X)
                {
                    case 58: { column = "A"; break; }
                    case 120: { column = "B"; break; }
                    case 166: { column = "C"; break; }
                    case 226: { column = "D"; break; }
                    case 272: { column = "E"; break; }
                    case 330: { column = "F"; break; }
                    case 376: { column = "G"; break; }
                    case 431: { column = "H"; break; }
                }
                storage = "K1";
            }
            else
            {
                switch (panel.Location.X)
                {
                    case 590: { column = "A"; break; }
                    case 652: { column = "B"; break; }
                    case 698: { column = "C"; break; }
                    case 758: { column = "D"; break; }
                    case 804: { column = "E"; break; }
                    case 862: { column = "F"; break; }
                    case 908: { column = "G"; break; }
                    case 963: { column = "H"; break; }
                }
                storage = "K2";
            }
            switch (panel.Location.Y)
            {
                case 121: { rows = 1; break; }
                case 157: { rows = 2; break; }
                case 193: { rows = 3; break; }
                case 229: { rows = 4; break; }
                case 265: { rows = 5; break; }
                case 301: { rows = 6; break; }
                case 337: { rows = 7; break; }
                case 373: { rows = 8; break; }
                case 409: { rows = 9; break; }
                case 445: { rows = 10; break; }
                case 481: { rows = 11; break; }
                case 517: { rows = 12; break; }
                case 553: { rows = 13; break; }
            }
            refrigerator = new RefrigeratorClass(storage, column, rows);
          
            panelConsignment.Visible = true;
            if (panel.Location.X<590)
            {
                panelConsignment.Location = new Point(panel.Location.X + panel.Width + 1, panel.Location.Y - 76);
            }
            else
            {
                panelConsignment.Location = new Point(panel.Location.X- 179, panel.Location.Y - 76);
            }

        }

        void EnableButton()
        {
            foreach (Control previousBtn in panelConsignment.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    if(previousBtn.Text == "Пусто")
                    {
                        previousBtn.Enabled = false;
                    }
                    else
                    {
                        previousBtn.Enabled = true;
                    }
                }
            }
        }

        void EnableButtonRefrigerator()
        {
            btnConsignment1.BackColor = SystemColors.ActiveBorder;
            btnConsignment2.BackColor = SystemColors.ActiveBorder;
            btnConsignment3.BackColor = SystemColors.ActiveBorder;
            btnConsignment4.BackColor = SystemColors.ActiveBorder;
            btnConsignment5.BackColor = SystemColors.ActiveBorder;
            btnConsignment6.BackColor = SystemColors.ActiveBorder;
            if (btnConsignment1.Text=="Пусто")
            {
                btnConsignment1.Enabled = true;
                btnConsignment1.BackColor=Color.FromArgb(0, 150, 136);
                btnConsignment2.Enabled = false;
                btnConsignment3.Enabled = false;
                btnConsignment4.Enabled = false;
                btnConsignment5.Enabled = false;
                btnConsignment6.Enabled = false;
                return;
            }
            if (btnConsignment1.Text != "Пусто"&& btnConsignment2.Text == "Пусто")
            {
                btnConsignment1.Enabled = false;
                btnConsignment2.Enabled = true;
                btnConsignment2.BackColor = Color.FromArgb(0, 150, 136);
                btnConsignment3.Enabled = false;
                btnConsignment4.Enabled = false;
                btnConsignment5.Enabled = false;
                btnConsignment6.Enabled = false;
                return;
            }
            if (btnConsignment2.Text != "Пусто"&& btnConsignment3.Text == "Пусто")
            {
              


                btnConsignment1.Enabled = false;
                btnConsignment2.Enabled = false;
                btnConsignment3.Enabled = true;
                btnConsignment3.BackColor = Color.FromArgb(0, 150, 136);
                btnConsignment4.Enabled = false;
                btnConsignment5.Enabled = false;
                btnConsignment6.Enabled = false;
                return;
            }
            if (btnConsignment3.Text != "Пусто" && btnConsignment4.Text == "Пусто")
            {
                btnConsignment1.Enabled = false;
                btnConsignment2.Enabled = false;
                btnConsignment3.Enabled = false;
                btnConsignment4.Enabled = true;
                btnConsignment4.BackColor = Color.FromArgb(0, 150, 136);
                btnConsignment5.Enabled = false;
                btnConsignment6.Enabled = false;
                return;
            }
            if (btnConsignment4.Text != "Пусто" && btnConsignment5.Text == "Пусто")
            {
                btnConsignment1.Enabled = false;
                btnConsignment2.Enabled = false;
                btnConsignment3.Enabled = false;
                btnConsignment4.Enabled = false;
                btnConsignment5.Enabled = true;
                btnConsignment5.BackColor = Color.FromArgb(0, 150, 136);
                btnConsignment6.Enabled = false;
                return;
            }
            if (btnConsignment5.Text != "Пусто" && btnConsignment6.Text == "Пусто")
            {
                btnConsignment1.Enabled = false;
                btnConsignment2.Enabled = false;
                btnConsignment3.Enabled = false;
                btnConsignment4.Enabled = false;
                btnConsignment5.Enabled = false;
                btnConsignment6.Enabled = true;
                btnConsignment6.BackColor = Color.FromArgb(0, 150, 136);
                return;
            }
            if(btnConsignment6.Text == "Пусто")
            {
                btnConsignment1.Enabled = false;
                btnConsignment2.Enabled = false;
                btnConsignment3.Enabled = false;
                btnConsignment4.Enabled = false;
                btnConsignment5.Enabled = false;
                btnConsignment6.Enabled = false;
                return;
            }


        }

        private void panel_Click(object sender, EventArgs e)
        {

            int count;
            ClearButton();
            CalculationBoxs((Button)sender);
            Main.sQLFunction.LoadConsignmentInCell(refrigerator, ref numberConsignment);
            switch(numberConsignment.Count)
            {
                case 0: {; break; }
                case 1: {btnConsignment1.Text= numberConsignment[0]; break; }
                case 2: { btnConsignment1.Text = numberConsignment[0];
                        btnConsignment2.Text = numberConsignment[1];  break; }
                case 3: { btnConsignment1.Text = numberConsignment[0];
                        btnConsignment2.Text = numberConsignment[1];
                        btnConsignment3.Text = numberConsignment[2]; break; }
                case 4: { btnConsignment1.Text = numberConsignment[0];
                        btnConsignment2.Text = numberConsignment[1];
                        btnConsignment3.Text = numberConsignment[2];
                        btnConsignment4.Text = numberConsignment[3]; break; }
                case 5: { btnConsignment1.Text = numberConsignment[0];
                        btnConsignment2.Text = numberConsignment[1];
                        btnConsignment3.Text = numberConsignment[2];
                        btnConsignment4.Text = numberConsignment[3];
                        btnConsignment5.Text = numberConsignment[4]; break; }
                case 6: { btnConsignment1.Text = numberConsignment[0];
                        btnConsignment2.Text = numberConsignment[1];
                        btnConsignment3.Text = numberConsignment[2];
                        btnConsignment4.Text = numberConsignment[3];
                        btnConsignment5.Text = numberConsignment[4];
                        btnConsignment6.Text = numberConsignment[5]; break; }
            }
            numberConsignment.Clear();
            if(Form=="Mapa")
            {
                EnableButton();
            }
            if(Form== "Refregerator")
            {
                EnableButtonRefrigerator();
            }
            if(Form=="Weight")
            {
                EnableButton();
            }
            if(Form=="Sell")
            {
                EnableButton();
            }
            if(Form=="Write-Off")
            {
                EnableButton();
            }
            
        }

        private void Contoller_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Controller_Paint(object sender, PaintEventArgs e)
        {

        }

        string GetNameButton(Button button)
        {
            return button.Name;
        }

        private void btnConsignment1_Click(object sender, EventArgs e)
        {
            if(Form=="Mapa")
            {
                ViewNewConsignment viewNewConsignment = new ViewNewConsignment(NewConsignment = Main.sQLFunction.SearchConsignment((Button)sender));
                viewNewConsignment.ShowDialog();
            }
            if(Form== "Refregerator")
            {
                switch(GetNameButton((Button)sender))
                {
                    case "btnConsignment1": { refrigerator.Storey = 1; break; }
                    case "btnConsignment2": { refrigerator.Storey = 2; break; }
                    case "btnConsignment3": { refrigerator.Storey = 3; break; }
                    case "btnConsignment4": { refrigerator.Storey = 4; break; }
                    case "btnConsignment5": { refrigerator.Storey = 5; break; }
                    case "btnConsignment6": { refrigerator.Storey = 6; break; }
                }
                 Refrigerator.refrigeratorClass = refrigerator;
                Close();
            }
            if(Form=="Weight")
            {
                switch (GetNameButton((Button)sender))
                {
                    case "btnConsignment1": { refrigerator.Storey = 1; refrigerator.CodeNumber = btnConsignment1.Text; break; }
                    case "btnConsignment2": { refrigerator.Storey = 2; refrigerator.CodeNumber = btnConsignment2.Text; break; }
                    case "btnConsignment3": { refrigerator.Storey = 3; refrigerator.CodeNumber = btnConsignment3.Text; break; }
                    case "btnConsignment4": { refrigerator.Storey = 4; refrigerator.CodeNumber = btnConsignment4.Text; break; }
                    case "btnConsignment5": { refrigerator.Storey = 5; refrigerator.CodeNumber = btnConsignment5.Text; break; }
                    case "btnConsignment6": { refrigerator.Storey = 6; refrigerator.CodeNumber = btnConsignment6.Text; break; }
                }
                
                MessageBox.Show("Camera:" + refrigerator.Camera + "\n" + "Column:" + refrigerator.Column + "\n" + "Rows:" + refrigerator.Rows + "\n" + "Storey:" + refrigerator.Storey + "\n" + "Code:" + refrigerator.CodeNumber);
                Control_Weighing.control_Weighing.CodeNumber = refrigerator.CodeNumber;
                Control_Weighing.AddRecord();
                Close();
            }
            if (Form == "Sell")
            {
                switch (GetNameButton((Button)sender))
                {
                    case "btnConsignment1": { refrigerator.Storey = 1; refrigerator.CodeNumber = btnConsignment1.Text; break; }
                    case "btnConsignment2": { refrigerator.Storey = 2; refrigerator.CodeNumber = btnConsignment2.Text; break; }
                    case "btnConsignment3": { refrigerator.Storey = 3; refrigerator.CodeNumber = btnConsignment3.Text; break; }
                    case "btnConsignment4": { refrigerator.Storey = 4; refrigerator.CodeNumber = btnConsignment4.Text; break; }
                    case "btnConsignment5": { refrigerator.Storey = 5; refrigerator.CodeNumber = btnConsignment5.Text; break; }
                    case "btnConsignment6": { refrigerator.Storey = 6; refrigerator.CodeNumber = btnConsignment6.Text; break; }
                }
                Main.sQLFunction.LoadDataConsignmentInCell(refrigerator,ref sell);
                Sell.SellClass = sell;
                Sell.refrigeratorClass = refrigerator;
                Sell.AddInterface();
            }
            if(Form == "Write-Off")
            {
                switch (GetNameButton((Button)sender))
                {
                    case "btnConsignment1": { refrigerator.Storey = 1; refrigerator.CodeNumber = btnConsignment1.Text; break; }
                    case "btnConsignment2": { refrigerator.Storey = 2; refrigerator.CodeNumber = btnConsignment2.Text; break; }
                    case "btnConsignment3": { refrigerator.Storey = 3; refrigerator.CodeNumber = btnConsignment3.Text; break; }
                    case "btnConsignment4": { refrigerator.Storey = 4; refrigerator.CodeNumber = btnConsignment4.Text; break; }
                    case "btnConsignment5": { refrigerator.Storey = 5; refrigerator.CodeNumber = btnConsignment5.Text; break; }
                    case "btnConsignment6": { refrigerator.Storey = 6; refrigerator.CodeNumber = btnConsignment6.Text; break; }
                }
                Main.sQLFunction.LoadDataConsignmentInCell(refrigerator, ref WriteOffClass);
                WriteOff.WriteOffClass = WriteOffClass;
                WriteOff.NewConsignment = Main.sQLFunction.SearchConsignment((Button)sender);
                WriteOff.refrigeratorClass = refrigerator;
                WriteOff.AddInterface();
            }


        }

        private void btnConsignment2_Click(object sender, EventArgs e)
        {

        }

        private void btnConsignment3_Click(object sender, EventArgs e)
        {

        }

        private void btnConsignment4_Click(object sender, EventArgs e)
        {

        }

        private void btnConsignment5_Click(object sender, EventArgs e)
        {

        }

        private void btnConsignment6_Click(object sender, EventArgs e)
        {

        }
    }
}
