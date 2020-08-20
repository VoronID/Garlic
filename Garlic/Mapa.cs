using Garlic.Controller;
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
        int countConsignment = 0;
        SellClass sell = new SellClass();
        WriteOffClass WriteOffClass = new WriteOffClass();
        Control_Weighing Control_Weighing;
        RefrigeratorClass refrigerator;
        WriteOff WriteOff;
        Button Buttons;
        Sell Sell;
        MapaClass mapaClass;
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
            mapaClass = new MapaClass(button3.Location.Y, button4.Location.Y, button5.Location.Y, button8.Location.Y, button9.Location.Y, button10.Location.Y, button11.Location.Y, button12.Location.Y, button13.Location.Y, button14.Location.Y, button15.Location.Y, button16.Location.Y, button17.Location.Y, button3.Location.X, button18.Location.X, button37.Location.X, button56.Location.X, button69.Location.X, button82.Location.X, button95.Location.X, button108.Location.X, button121.Location.X, button134.Location.X, button147.Location.X, button160.Location.X, button170.Location.X, button186.Location.X, button199.Location.X, button212.Location.X);
            LoadCountConsignment();
            valueConsignament.Text = countConsignment.ToString();
            this.KeyPreview = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Mapa_Load_KeyDown);
            Main.sQLFunction.SearchNumberNewConsignment(valueCodeConsignment, "in refrigerator");


        }
        private void Mapa_Load_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if(panelConsignment.Visible==true)
                {
                    panelConsignment.Visible = false;
                    StandartButton();

                }
            }
               
        }

        void LoadCountConsignment()
        {
            foreach (Control previousBtn in Controller.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    
                    previousBtn.Text = Main.sQLFunction.LoadCountConsignmentInCell(mapaClass.CalculationBox((Button)previousBtn)).ToString();
                    countConsignment = countConsignment+Convert.ToInt32(previousBtn.Text);
                }
               
            }
        }


        void StandartButton()
        {
            foreach (Control previousBtn in panelConsignment.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                   if(previousBtn.BackColor == Color.Coral)
                    {
                        previousBtn.BackColor = SystemColors.ActiveBorder;
                        if(Buttons!=null)
                        {
                            Buttons.BackColor = Color.FromArgb(0, 150, 136);
                        }
                    }
                }
            }
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

            refrigerator = mapaClass.CalculationBox(panel);
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

        public void panel_Click(object sender, EventArgs e)
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

        private void label46_Click(object sender, EventArgs e)
        {

        }

        private void valueCodeConsignment_Leave(object sender, EventArgs e)
        {
            if (valueCodeConsignment.Text == "")
            {
                valueCodeConsignment.Text = "Код партії";
            }
        }

        private void valueCodeConsignment_Enter(object sender, EventArgs e)
        {
            if (valueCodeConsignment.Text == "Код партії")
            {
                valueCodeConsignment.Text = "";
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if(valueCodeConsignment.Visible==false)
            {
                valueCodeConsignment.Visible = true;
                return;
            }
            else
            {
                if (valueCodeConsignment.Text != "Код партії" && valueCodeConsignment.Text != "")
                {
                    StandartButton();
                    if (Main.sQLFunction.CheckProcess(valueCodeConsignment.Text))
                    {
                        RefrigeratorClass refrigeratorSearch = Main.sQLFunction.SearchConsignment(valueCodeConsignment.Text);
                        Point point = mapaClass.SearchLocationConsignment(refrigeratorSearch.Rows, refrigeratorSearch.Column, refrigeratorSearch.Camera);
                        ClickButton(point, refrigeratorSearch.Storey);
                        valueCodeConsignment.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Не знайдено партію");
                        valueCodeConsignment.Text = "";
                    }
                }
            }
        }

        void ClickButton(Point point,int storage)
        {
            Button button; 
            foreach (Control previousBtn in Controller.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                   
                    if (previousBtn.Location.X== point.X&& previousBtn.Location.Y == point.Y)
                    {
                        button = (Button)previousBtn;
                        Buttons = (Button)previousBtn;
                        previousBtn.BackColor = Color.Coral;
                        button.Click += new EventHandler(this.panel_Click);
                        button.PerformClick();
                    }
                   
                }
            }
            switch(storage)
            {
                case 1: { btnConsignment1.BackColor = Color.Coral; break; }
                case 2: { btnConsignment2.BackColor = Color.Coral; break; }
                case 3: { btnConsignment3.BackColor = Color.Coral; break; }
                case 4: { btnConsignment4.BackColor = Color.Coral; break; }
                case 5: { btnConsignment5.BackColor = Color.Coral; break; }
                case 6: { btnConsignment6.BackColor = Color.Coral; break; }
            }
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                MessageBox.Show("Права клавіша");
            }
        }
    }
}
