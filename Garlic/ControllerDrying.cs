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
    public partial class ControllerDrying : Form
    {
        Main main = new Main();
        public ControllerDrying(Main _main)
        {
            main = _main;
            InitializeComponent();
        }
        DryingMobile DryingMobile;
        string Process = "";
        string CodeConsignment = "";
        double weight = 0.0;

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
            if (labelAdd.Text=="Додати")
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                labelAdd.Location = new Point(3, 223);
                labelSearch.Location = new Point(6, 223);
                labelSearch.Text = "Друга сушка";
                labelAdd.Text = "Мобільна сушка";
                return;
            }
            if(labelAdd.Text == "Мобільна сушка")
            {
                labelNameProcess.Text = "Мобільна сушка";
                panelAdds.Width = 0;
                panelSearchs.Width = 0;


            }
            
        }

        private void btnInsertConsignment_Click(object sender, EventArgs e)
        {
            if(btnInsertConsignment.Text=="Додати")
            {
                if(labelNameProcess.Text== "Мобільна сушка")
                {
                    TableConsignment.Rows.Clear();
                    Main.sQLFunction.LoadConsignmentInProcess(TableConsignment, "storage");
                    Process = "Add";
                    btnTake.Visible = false;
                    labelStart.Visible = true;
                    dtPStart.Visible = true;
                    TableConsignment.Visible = true;
                    btnInsertConsignment.Text = "Підтвердити";
                    return;
                }
                if(labelNameProcess.Text == "Друга сушка")
                {
                    Process = "Add";
                    TableConsignment.Rows.Clear();
                    Main.sQLFunction.LoadConsignmentInProcess(TableConsignment, "after mobile");
                    btnTake.Visible = false;
                    labelStart.Visible = true;
                    dtPStart.Visible = true;
                    TableConsignment.Visible = true;
                    btnInsertConsignment.Text = "Підтвердити";
                    return;
                }
                
               
            }
            if (btnInsertConsignment.Text == "Підтвердити")
            {
                if (labelNameProcess.Text == "Мобільна сушка")
                {
                    if (CodeConsignment == "")
                    {
                        Console.WriteLine("Не вибрано партію");
                    }
                    else
                    {
                        DryingMobile = new DryingMobile(Convert.ToDateTime(dtPStart.Value.ToShortDateString()), weight, CodeConsignment);
                        Main.sQLFunction.InsertInMobile(DryingMobile);
                        btnTake.Visible = true;
                        labelStart.Visible = false;
                        dtPStart.Visible = false;
                        TableConsignment.Visible = false;
                        btnInsertConsignment.Text = "Додати";
                        MessageBox.Show("Партію:" + CodeConsignment + ". Додано в мобільну сушку");
                    }
                }
                if (labelNameProcess.Text == "Друга сушка")
                {
                    if (CodeConsignment == "")
                    {
                        Console.WriteLine("Не вибрано партію");
                    }
                    else
                    {
                        Main.sQLFunction.InsertInDrying(CodeConsignment, Convert.ToDateTime(dtPStart.Value.ToShortDateString()));
                        btnTake.Visible = true;
                        labelStart.Visible = false;
                        dtPStart.Visible = false;
                        TableConsignment.Visible = false;
                        btnInsertConsignment.Text = "Додати";
                        MessageBox.Show("Партію:" + CodeConsignment + ". Додано в другу сушку");
                    }
                }
            }
           

        }

        private void TableConsignment_DoubleClick(object sender, EventArgs e)
        {
            if(Process=="Add")
            {
                weight = Convert.ToDouble(TableConsignment.SelectedRows[0].Cells[6].Value);
                CodeConsignment = TableConsignment.SelectedRows[0].Cells[0].Value.ToString();
                MessageBox.Show("Партію:" + CodeConsignment + ".Вибрано");
            }
            if(Process=="Take")
            {
                CodeConsignment = TableConsignment.SelectedRows[0].Cells[0].Value.ToString();
                MessageBox.Show("Партію:" + CodeConsignment + ".Вибрано");
            }

        }

        private void panelSearchs_Click(object sender, EventArgs e)
        {
            if (labelSearch.Text == "Переглянути")
            {
                Main.sQLFunction.LoadAllInformationDrying(TableDrying);
                labelNameProcess.Text = "Перегляд даних";
                TableDrying.Visible = true;
                panelAdds.Width = 0;
                panelSearchs.Width = 0;
                TableConsignment.Visible = false;
                panelDate.Visible = false;
                btnInsertConsignment.Visible = false;
                btnTake.Visible = false;
                pbReport.Visible = true;
                
            }
            if(labelSearch.Text == "Друга сушка")
            {
                labelNameProcess.Text = "Друга сушка";
                panelAdds.Width = 0;
                panelSearchs.Width = 0;
            }
            
        }

        private void btnTake_Click(object sender, EventArgs e)
        {
            if (labelNameProcess.Text == "Мобільна сушка")
            {
                if (btnTake.Text == "Забрати")
                {
                    TableConsignment.Rows.Clear();
                    Main.sQLFunction.LoadConsignmentInProcess(TableConsignment, "in mobile");
                    Process = "Take";
                    btnInsertConsignment.Visible = false;
                    labelEnd.Visible = true;
                    dtPEnd.Visible = true;
                    TableConsignment.Visible = true;
                    labelWeight.Visible = true;
                    WeightValue.Visible = true;
                    panelDate.Visible = true;
                    btnTake.Text = "Підтвердити";
                    return;
                }
                if(btnTake.Text == "Підтвердити")
                {
                    if (CodeConsignment == "")
                    {
                        Console.WriteLine("Не вибрано партію");
                    }
                    else
                    {
                        TableConsignment.Rows.Clear();
                        Main.sQLFunction.TakeConsignmentWithMobileDrying(CodeConsignment, Convert.ToDouble(WeightValue.Text), Convert.ToDateTime(dtPStart.Value.ToShortDateString()));
                        btnInsertConsignment.Visible = true;
                        labelEnd.Visible = false;
                        dtPEnd.Visible = false;
                        TableConsignment.Visible = false;
                        labelWeight.Visible = false;
                        WeightValue.Visible = false;
                        btnTake.Text = "Забрати";
                        MessageBox.Show("Партію:" + CodeConsignment + ". Забрано з мобільної сушки");
                    }
                }
            }

            if (labelNameProcess.Text == "Друга сушка")
            {
                if (btnTake.Text == "Забрати")
                {
                    TableConsignment.Rows.Clear();
                    Main.sQLFunction.LoadConsignmentInProcess(TableConsignment, "in drying");
                    btnInsertConsignment.Visible = false;
                    Process = "Take";

                    labelEnd.Visible = true;
                    dtPEnd.Visible = true;
                    TableConsignment.Visible = true;
                    labelWeight.Visible = true;
                    WeightValue.Visible = true;
                    panelDate.Visible = true;
                    btnTake.Text = "Підтвердити";
                    return;
                }
                if (btnTake.Text == "Підтвердити")
                {
                    if (CodeConsignment == "")
                    {
                        Console.WriteLine("Не вибрано партію");
                    }
                    else
                    {
                        Main.sQLFunction.TakeConsignmentWithDrying(CodeConsignment, Convert.ToDouble(WeightValue.Text), Convert.ToDateTime(dtPStart.Value.ToShortDateString()));
                        btnInsertConsignment.Visible = true;
                        labelEnd.Visible = false;
                        dtPEnd.Visible = false;
                        TableConsignment.Visible = false;
                        labelWeight.Visible = false;
                        WeightValue.Visible = false;
                        btnTake.Text = "Забрати";
                        MessageBox.Show("Партію:" + CodeConsignment + ". Забрано з другої сушки");
                    }
                }
            }
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            main.btnDrying_Click(this, null);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ReportViwer reportViwer = new ReportViwer("Drying");
            reportViwer.ShowDialog();
        }
    }
}
