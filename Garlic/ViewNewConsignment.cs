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
    public partial class ViewNewConsignment : Form
    {
        Model.NewConsignment newConsignment = new Model.NewConsignment();
        public ViewNewConsignment(Model.NewConsignment newConsignment)
        {
            InitializeComponent();
            this.newConsignment = newConsignment;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ViewNewConsignment_Load(object sender, EventArgs e)
        {
            valueNumberConsignment.Text = newConsignment.NumberConsignment;
            valueDate.Text = newConsignment.DateCreation.ToShortDateString();
            valueCaliber.Text = newConsignment.Caliber.ToString();
            valueWeight.Text = newConsignment.Weight.ToString();
            valueSort.Text = newConsignment.Garlic.Name;
            valueType.Text = newConsignment.Garlic.Sort;

        }
    }
}
