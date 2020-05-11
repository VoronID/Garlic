using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garlic.SQL
{
    public class SQLFunction
    {
        SqlConnection conn;
        SqlConnectionStringBuilder connStringBuilder;
        public SqlConnection ConnectTo()
        {
            //Data Source=USER;Initial Catalog=User;Integrated Security=True
            connStringBuilder = new SqlConnectionStringBuilder();
            connStringBuilder.DataSource = "USER";
            connStringBuilder.InitialCatalog = "User";
            connStringBuilder.IntegratedSecurity = true;

            conn = new SqlConnection(connStringBuilder.ToString());
            return conn;
        }
    }
}
