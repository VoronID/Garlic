using Garlic.SQL;
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
    public partial class Authorization : Form
    {
        Main Main;
        public Authorization(Main main)
        {
            InitializeComponent();
            Main = main;


        }

       

        private void Authorization_Load(object sender, EventArgs e)
        {
 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLFunction sQLFunction = new SQLFunction();
            if (sQLFunction.CheckUser(Login.Text, Password.Text))
            {
                Main.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Користувача не знайдено");
                Login.Text = "";
                Password.Text = "";
            }
               
               
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            Main.Close();
        }

        private void Login_Enter(object sender, EventArgs e)
        {
            if (Login.Text == "КОРИСТУВАЧ")
            {
                Login.Text = "";
                Login.ForeColor = Color.Black;
            }
        }

        private void Login_Leave(object sender, EventArgs e)
        {
            if (Login.Text == "")
            {
                Login.Text = "КОРИСТУВАЧ";
                Login.ForeColor = Color.Black;
            }
        }

        private void Password_Enter(object sender, EventArgs e)
        {
            if (Password.Text == "ПАРОЛЬ")
            {
                Password.Text = "";
                Password.ForeColor = Color.Black;
            }
        }

        private void Password_Leave(object sender, EventArgs e)
        {
            if (Password.Text == "")
            {
                Password.Text = "ПАРОЛЬ";
                Password.ForeColor = Color.Black;
            }
        }
    }
}
