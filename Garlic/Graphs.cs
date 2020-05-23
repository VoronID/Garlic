using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;

namespace Garlic
{
    public partial class Graphs : Form
    {
        public static List<double> weight = new List<double>();
        public static List<string> month = new List<string>();
        public static string codeNumber;
        public Graphs()
        {
            InitializeComponent();
            cartesianChart1.LegendLocation = LegendLocation.Top;
            cartesianChart1.DefaultLegend.Visibility = Visibility.Visible;

            cartesianChart1.Series = new LiveCharts.SeriesCollection
            {

                new LineSeries
                {
                    //Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 150, 136)),
                    // Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 150, 136)),
                    Title =codeNumber,
                    
                    //Values = new ChartValues<ObservablePoint>
                    //{
                    //    new ObservablePoint(7,500),
                    //     new ObservablePoint(8,490),
                    //      new ObservablePoint(9,480),
                        

                    //}
                    Values= new ChartValues<double>(weight)
                    ,
                    PointGeometrySize=15
                }
            };

            cartesianChart1.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                FontSize = 14,
                Title = "Місяці",
                Labels = month
            });
           
            cartesianChart1.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Вага",
                FontSize = 14,
            });

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
