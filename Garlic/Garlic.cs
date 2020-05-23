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
    public partial class Garlic : Form
    {
        public Garlic()
        {
            InitializeComponent();
        }

        private void Garlic_Load(object sender, EventArgs e)
        {
            Main.sQLFunction.LoadGarlic(dataGridView1);
        }
    }
}
