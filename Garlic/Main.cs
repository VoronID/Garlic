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

        private void btnGarlic_MouseEnter(object sender, EventArgs e)
        {
            btnGarlic.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Bold,
                        System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        }

        private void btnGarlic_MouseLeave(object sender, EventArgs e)
        {
            btnGarlic.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular,
                       System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        }

       
    }
}
