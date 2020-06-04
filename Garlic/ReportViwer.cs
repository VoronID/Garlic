using Microsoft.Reporting.WinForms;
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
    public partial class ReportViwer : Form
    {
        string Form;
        DateTime From;
        DateTime To;
        public ReportViwer(DateTime From, DateTime To,string from)
        {
            InitializeComponent();
            this.From = From;
            this.To = To;
            Form = from;


        }

        public ReportViwer(string from)
        {
            InitializeComponent();
            Form = from;
        }

     

        void ShowReportDrying()
        {
            panel5.Height = 600;
            reportViewer3.Reset();
            DataTable dt = Main.sQLFunction.GetDataDrying();
            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            reportViewer3.LocalReport.DataSources.Add(rds);
            reportViewer3.LocalReport.ReportPath = "ReportDrying.rdlc";
            reportViewer3.LocalReport.Refresh();
        }

        void ShowReportWriteOff()
        {
            panel4.Width = panel4.Width+1193;
            reportViewer2.Reset();
            DataTable dt = Main.sQLFunction.GetDataWriteOff(From, To);
            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            reportViewer2.LocalReport.DataSources.Add(rds);
            reportViewer2.LocalReport.ReportPath = "ReportWriteOff.rdlc";
            ReportParameter[] rtpParams = new ReportParameter[]
            {
                new ReportParameter("fromDate",From.ToShortDateString()),
                new ReportParameter("toDate",To.ToShortDateString())

            };
            reportViewer2.LocalReport.SetParameters(rtpParams);
            reportViewer2.LocalReport.Refresh();
        }
        void ShowReportSell()
        {
            panel3.Width = panel3.Width + 1193;
            reportViewer1.Reset();
            DataTable dt = Main.sQLFunction.GetDataSell(From, To);
            ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.ReportPath = "ReportSell.rdlc";
            ReportParameter[] rtpParams = new ReportParameter[]
            {
                new ReportParameter("fromDate",From.ToShortDateString()),
                new ReportParameter("toDate",To.ToShortDateString())

            };
            reportViewer1.LocalReport.SetParameters(rtpParams);
            reportViewer1.LocalReport.Refresh();
        }
        private void ReportViwer_Load(object sender, EventArgs e)
        {
            if (Form == "Drying") 
            {
                ShowReportDrying();
            }
            if (Form == "Write") 
            {
                ShowReportWriteOff();
            }
            if (Form == "Sell")
            {
                ShowReportSell();
            }



            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
            this.reportViewer3.RefreshReport();
            this.reportViewer3.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
