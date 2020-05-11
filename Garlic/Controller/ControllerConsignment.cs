using Garlic.Model;
using Garlic.SQL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garlic.Controller
{
    public class ControllerConsignment
    {
        SQLFunction sQLFunction = new SQLFunction();     
        public Consignment ConsignmentClass { get; set; }
      
        ControllerConsignment(Consignment _consignment)
        {
            ConsignmentClass = _consignment;
        }

        public void InsertConsignment()
        {

        }

        public void SearchConsignment()
        {
            //sQLFunction.ConnectTo();
            //string query = "SELECT * FROM dbo.Car";
            //SqlCommand command = new SqlCommand(query, sQLFunction.z);
            //SqlDataReader reader = command.ExecuteReader();
            //List<string[]> data = new List<string[]>();
            //while (reader.Read())
            //{
            //    data.Add(new string[11]);
            //    data[data.Count - 1][0] = reader[0].ToString();
            //    data[data.Count - 1][1] = reader[1].ToString();
            //    data[data.Count - 1][2] = reader[2].ToString();
            //    data[data.Count - 1][3] = reader[3].ToString();
            //    data[data.Count - 1][4] = (Convert.ToDateTime(reader[4]).ToShortDateString()).ToString();
            //    data[data.Count - 1][5] = reader[5].ToString();
            //    data[data.Count - 1][6] = reader[6].ToString();
            //    data[data.Count - 1][7] = reader[7].ToString();
            //    data[data.Count - 1][8] = reader[8].ToString();
            //    data[data.Count - 1][9] = reader[9].ToString();
            //    data[data.Count - 1][10] = reader[10].ToString();
            //}
            //reader.Close();

            //sQLFunction.ConnectTo().Close();
            ////foreach (string[] s in data)
            ////    dataGridView.Rows.Add(s);
        }
    }
}
