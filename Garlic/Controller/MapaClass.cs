using Garlic.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Garlic.Controller
{
    public class MapaClass
    {
        static Rows rows;
        static Column column;
        string columns;
        int row;
        string storage;
        List<int> rowsSearch;
        List<int> columnSearch;
            public MapaClass(int One,
             int Two,
             int Three,
             int Four,
             int Five,
             int Six,
             int Seven,
             int Eight,
             int Nine,
             int Ten,
             int Eleven,
             int Twelve,
             int Thirteen,
             int K1_A,
               int K1_B,
               int K1_C,
               int K1_D,
               int K1_E,
               int K1_F,
               int K1_G,
               int K1_H,
               int K2_A,
               int K2_B,
               int K2_C,
               int K2_D,
               int K2_E,
               int K2_F,
               int K2_G,
               int K2_H)
        {
            rows = new Rows(One,
             Two,
             Three,
             Four,
             Five,
             Six,
             Seven,
             Eight,
             Nine,
             Ten,
             Eleven,
             Twelve,
             Thirteen);
            column = new Column(K1_A,
               K1_B,
               K1_C,
               K1_D,
               K1_E,
               K1_F,
               K1_G,
               K1_H,
               K2_A,
               K2_B,
               K2_C,
               K2_D,
               K2_E,
               K2_F,
               K2_G,
               K2_H);
            rowsSearch = new List<int>() { rows.One, rows.Two, rows.Three, rows.Four, rows.Five, rows.Six, rows.Seven, rows.Eight, rows.Nine, rows.Ten, rows.Eleven, rows.Twelve, rows.Thirteen };
            columnSearch = new List<int>() { column.K1_A, column.K1_B, column.K1_C, column.K1_D, column.K1_E, column.K1_F, column.K1_G, column.K1_H, column.K2_A, column.K2_B, column.K2_C, column.K2_D, column.K2_E, column.K2_F, column.K2_G, column.K2_H };

        }


        public RefrigeratorClass CalculationBox(Button panel)
        {
            if (column.K1_A == panel.Location.X) { columns = "A"; storage = "K1"; }
            if (column.K1_B == panel.Location.X) { columns = "B"; storage = "K1"; }
            if (column.K1_C == panel.Location.X) { columns = "C"; storage = "K1"; }
            if (column.K1_D == panel.Location.X) { columns = "D"; storage = "K1"; }
            if (column.K1_E == panel.Location.X) { columns = "E"; storage = "K1"; }
            if (column.K1_F == panel.Location.X) { columns = "F"; storage = "K1"; }
            if (column.K1_G == panel.Location.X) { columns = "G"; storage = "K1"; }
            if (column.K1_H == panel.Location.X) { columns = "H"; storage = "K1"; }

            if (column.K2_A == panel.Location.X) { columns = "A"; storage = "K2"; }
            if (column.K2_B == panel.Location.X) { columns = "B"; storage = "K2"; }
            if (column.K2_C == panel.Location.X) { columns = "C"; storage = "K2"; }
            if (column.K2_D == panel.Location.X) { columns = "D"; storage = "K2"; }
            if (column.K2_E == panel.Location.X) { columns = "E"; storage = "K2"; }
            if (column.K2_F == panel.Location.X) { columns = "F"; storage = "K2"; }
            if (column.K2_G == panel.Location.X) { columns = "G"; storage = "K2"; }
            if (column.K2_H == panel.Location.X) { columns = "H"; storage = "K2"; }

            if (rows.One == panel.Location.Y) { row = 1; }
            if (rows.Two == panel.Location.Y) { row = 2; }
            if (rows.Three == panel.Location.Y) { row = 3; }
            if (rows.Four == panel.Location.Y) { row = 4; }
            if (rows.Five == panel.Location.Y) { row = 5; }
            if (rows.Six == panel.Location.Y) { row = 6; }
            if (rows.Seven == panel.Location.Y) { row = 7; }
            if (rows.Eight == panel.Location.Y) { row = 8; }
            if (rows.Nine == panel.Location.Y) { row = 9; }
            if (rows.Ten == panel.Location.Y) { row = 10; }
            if (rows.Eleven == panel.Location.Y) { row = 11; }
            if (rows.Twelve == panel.Location.Y) { row = 12; }
            if (rows.Thirteen == panel.Location.Y) { row = 13; }

            return new RefrigeratorClass(storage.ToString(), columns, row);
        }

        public Point SearchLocationConsignment(int rows,string columns,string camera)
        {
            Point point = new Point();
            point.Y = rowsSearch[rows-1];

            if(camera=="K1")
            {
                if (columns == "A") { point.X = column.K1_A; }
                if (columns == "B") { point.X = column.K1_B; }
                if (columns == "C") { point.X = column.K1_C; }
                if (columns == "D") { point.X = column.K1_D; }
                if (columns == "E") { point.X = column.K1_E; }
                if (columns == "F") { point.X = column.K1_F; }
                if (columns == "G") { point.X = column.K1_G; }
                if (columns == "H") { point.X = column.K1_H; }
            }
            if(camera=="K2")
            {
                if (columns == "A") { point.X = column.K2_A; }
                if (columns == "B") { point.X = column.K2_B; }
                if (columns == "C") { point.X = column.K2_C; }
                if (columns == "D") { point.X = column.K2_D; }
                if (columns == "E") { point.X = column.K2_E; }
                if (columns == "F") { point.X = column.K2_F; }
                if (columns == "G") { point.X = column.K2_G; }
                if (columns == "H") { point.X = column.K2_H; }
            }

            
            return point;
        }

    }
}
