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
    public partial class Refrigerator : Form
    {
        public Refrigerator()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (panelSearch.Height == 0)
            {
                panelSearch.Height = panelSearch.Height + 90;
                return;
            }
            if (panelSearch.Height == 90)
            {
                panelSearch.Height = 0;
                return;
            }
        }
    }
}
