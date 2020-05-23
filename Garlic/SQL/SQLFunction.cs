using Garlic.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Garlic.SQL
{
    //string timeSaved = control_Weighing.dataOperation.ToString("MMMM");
    //control_Weighing.Month = timeSaved.ToString();
    public class SQLFunction
    {
        SqlConnection conn;
        SqlConnectionStringBuilder connStringBuilder;
        static string DataSource = "";
        static string InitialCatalog = "";
        public SQLFunction()
        {
            OpenFile();
            ConnectTo();
        }
        public SqlConnection ConnectTo()
        {
            //Data Source=USER;Initial Catalog=User;Integrated Security=True
            connStringBuilder = new SqlConnectionStringBuilder();
            connStringBuilder.DataSource = DataSource;
            connStringBuilder.InitialCatalog = InitialCatalog;
            connStringBuilder.IntegratedSecurity = true;

            conn = new SqlConnection(connStringBuilder.ToString());
            return conn;

        }

        public void InsertNewConsignment(string NumberConsignment, string DateCreation, double WeightConsignment, int Caliber, string State, int CodeGarlic)
        {
            string sqlExpression = "sp_InsertNewConsignment";
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sqlExpression, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter numberConsignmentParam = new SqlParameter
                {
                    ParameterName = "@Code_New_Consignment",
                    Value = NumberConsignment
                };
                command.Parameters.Add(numberConsignmentParam);

                SqlParameter dateCollectionParam = new SqlParameter
                {
                    ParameterName = "@Date_Сreation",
                    Value = DateCreation
                };
                command.Parameters.Add(dateCollectionParam);

                SqlParameter dateReceivingParam = new SqlParameter
                {
                    ParameterName = "@Weight_New_Consignment",
                    Value = WeightConsignment
                };
                command.Parameters.Add(dateReceivingParam);

                SqlParameter areaParam = new SqlParameter
                {
                    ParameterName = "@Caliber",
                    Value = Caliber
                };
                command.Parameters.Add(areaParam);

                SqlParameter processParam = new SqlParameter
                {
                    ParameterName = "@State_Consignment",
                    Value = State
                };
                command.Parameters.Add(processParam);

                SqlParameter weightConsignmentParam = new SqlParameter
                {
                    ParameterName = "@FK_Garlic_NewConsignment",
                    Value = CodeGarlic
                };
                command.Parameters.Add(weightConsignmentParam);
                var result = command.ExecuteNonQuery();
                Console.WriteLine("Партiю:" + NumberConsignment + ".Додано.");

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }




        public void OpenFile()
        {
            string textFromFile = "";
            string text = "";
            string User = "";
            string InitialCatalogs = "";
          

                using (FileStream fstream = File.OpenRead("DBConnectionString.txt"))
                {
                    // преобразуем строку в байты
                    byte[] array = new byte[fstream.Length];
                    // считываем данные
                    fstream.Read(array, 0, array.Length);
                    // декодируем байты в строку
                    textFromFile = System.Text.Encoding.Default.GetString(array);
                    Console.WriteLine($"Текст из файла: {textFromFile}");
                }
                bool oneWords = false;
                bool twoWords = false;
                for (int i = textFromFile.Length - 1; i != 0; i--)
                {
                    if (textFromFile[i] != '=')
                    {
                        if (oneWords != true)
                        {
                            User += textFromFile[i];
                        }
                    }
                    else
                    {
                        oneWords = true;
                    }
                    if (textFromFile[i] == ';')
                    {
                        twoWords = true;
                        continue;
                    }
                    if (twoWords == true)
                    {
                        if (textFromFile[i] == '=')
                        {
                            twoWords = false;
                            break;
                        }
                        InitialCatalogs += textFromFile[i];
                    }
                }
           
        DataSource = new string(User.Reverse().ToArray());
            InitialCatalog = new string(InitialCatalogs.Reverse().ToArray());
            
            }

        public void LoadConsignment(DataGridView dataGridView)
        {
            conn.Open();
            string query = "SELECT* FROM Party_information";
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[7]);
                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = (Convert.ToDateTime(reader[3]).ToShortDateString()).ToString();
                data[data.Count - 1][4] = (Convert.ToDateTime(reader[4]).ToShortDateString()).ToString();
                data[data.Count - 1][5] = reader[5].ToString();
                data[data.Count - 1][6] = reader[6].ToString();
            }
            reader.Close();
            conn.Close();


            foreach (string[] s in data)
                dataGridView.Rows.Add(s);
        }

        public void UpdateCellConsignment(string codeConsignment,int Storey)
        {
            conn.Open();
            Storey = Storey - 1;
            try
            {
                string cmdText = "UPDATE dbo.Refrigerator SET Storey='" + Storey + "''where FK_Code_New_Consignment='" + codeConsignment + "';";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

        }

        public void RelocationRefrigerator(RefrigeratorClass refrigeratorClass)
        {
           // DeleteRefrigerator(refrigeratorClass);
            Dictionary<string, int> consignmentWhichAreAbove = new Dictionary<string, int>();
            //LoadCountConsignmentInCell(refrigeratorClass, ref consignmentWhichAreAbove);

            foreach (var pair in consignmentWhichAreAbove)
            {
                UpdateCellConsignment(pair.Key, pair.Value);
            }
               
            
           
            
        }

        public void DeleteRefrigerator(RefrigeratorClass refrigeratorClass)
        {
            string sqlExpression = "sp_ViewConsignmentProcess";
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sqlExpression, conn);

                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter numberConsignment = new SqlParameter
                {
                    ParameterName = "@NumberConsignment",
                    Value = refrigeratorClass.CodeNumber
                };
                command.Parameters.Add(numberConsignment);
                SqlParameter camera = new SqlParameter
                {
                    ParameterName = "@Camera",
                    Value = refrigeratorClass.Camera
                };
                command.Parameters.Add(camera);
                SqlParameter column = new SqlParameter
                {
                    ParameterName = "@Column_Box",
                    Value = refrigeratorClass.Column
                };
                command.Parameters.Add(column);
                SqlParameter rows = new SqlParameter
                {
                    ParameterName = "@Rows_Box",
                    Value = refrigeratorClass.Rows
                };
                command.Parameters.Add(rows);

                SqlParameter storey = new SqlParameter
                {
                    ParameterName = "@Storey",
                    Value = refrigeratorClass.Storey
                };
                command.Parameters.Add(storey);

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public void LoadConsignmentInProcess(DataGridView dataGridView,string Process)
        {
            
            string sqlExpression = "sp_ViewConsignmentProcess";
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sqlExpression, conn);
                
                command.CommandType = System.Data.CommandType.StoredProcedure;
          
                SqlParameter numberConsignmentParam = new SqlParameter
                {
                    ParameterName = "@Process",
                    Value = Process
                };
                command.Parameters.Add(numberConsignmentParam);
                SqlDataReader reader = command.ExecuteReader();
                List<string[]> data = new List<string[]>();
    
                while (reader.Read())
                {
                    data.Add(new string[7]);
                    data[data.Count - 1][0] = reader[0].ToString();
                    data[data.Count - 1][1] = reader[1].ToString();
                    data[data.Count - 1][2] = reader[2].ToString();
                    data[data.Count - 1][3] = (Convert.ToDateTime(reader[3]).ToShortDateString()).ToString();
                    data[data.Count - 1][4] = (Convert.ToDateTime(reader[4]).ToShortDateString()).ToString();
                    data[data.Count - 1][5] = reader[5].ToString();
                    data[data.Count - 1][6] = reader[6].ToString();
                }
                reader.Close();
                conn.Close();


                foreach (string[] s in data)
                    dataGridView.Rows.Add(s);

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        



        public void LoadConsignmentDrying(DataGridView dataGridView)
        {
            conn.Open();
            string query = "SELECT* FROM Party_information_Drying";
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[7]);
                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = (Convert.ToDateTime(reader[3]).ToShortDateString()).ToString();
                data[data.Count - 1][4] = (Convert.ToDateTime(reader[4]).ToShortDateString()).ToString();
                data[data.Count - 1][5] = reader[5].ToString();
                data[data.Count - 1][6] = reader[6].ToString();
            }
            reader.Close();
            conn.Close();


            foreach (string[] s in data)
                dataGridView.Rows.Add(s);
        }


        public void LoadNewConsignment(DataGridView dataGridView)
        {
            conn.Open();
            string query = "SELECT* FROM Party_information_New_Consignment";
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[6]);
                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = (Convert.ToDateTime(reader[1]).ToShortDateString()).ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
                data[data.Count - 1][5] = reader[5].ToString();
            }
            reader.Close();
            conn.Close();


            foreach (string[] s in data)
                dataGridView.Rows.Add(s);
        }
        public void LoadGarlic(DataGridView dataGridView)
        {
            conn.Open();
            string query = "SELECT Name_Garlic,Sort_Garlic FROM GARLIC";
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                data.Add(new string[2]);
                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
            }
            reader.Close();
            conn.Close();


            foreach (string[] s in data)
                dataGridView.Rows.Add(s);
        }
        /// <summary>
        /// Повератає код часнику
        /// </summary>
        /// <param name="garlic"></param>
        /// <returns></returns>
        public int GetGarlicCode(Garlics garlic)
        {
            int code=0;
            try
            {
                conn.Open();
                string cmdText = "Select Code_Garlic FROM GARLIC WHERE Name_Garlic='" + garlic.Name + "'AND Sort_Garlic = '"+garlic.Sort+"'";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    code = Convert.ToInt32(dr[0]);

                }
                return code;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public void InsertInDrying(string numberConsignment, DateTime start)
        {
            string sqlExpression = "sp_InsertInDrying";
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sqlExpression, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter dateStartDrying = new SqlParameter
                {
                    ParameterName = "@Date_Start_Drying",
                    Value = start
                };
                command.Parameters.Add(dateStartDrying);

                SqlParameter fkNumberConsignment = new SqlParameter
                {
                    ParameterName = "@FK_Number_Consignment",
                    Value = numberConsignment
                };
                command.Parameters.Add(fkNumberConsignment);
                var result = command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }


        public void TakeConsignmentWithDrying(string codeConsignment, double Weight, DateTime end)
        {
            string sqlExpression = "sp_UpdateDrying";
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sqlExpression, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter dateEndDrying = new SqlParameter
                {
                    ParameterName = "@Date_End_Mobile_Drying",
                    Value = end
                };
                command.Parameters.Add(dateEndDrying);

                SqlParameter weightConsignmentAfterDrying = new SqlParameter
                {
                    ParameterName = "@Weight_Consignment_After_Drying",
                    Value = Weight
                };
                command.Parameters.Add(weightConsignmentAfterDrying);

                SqlParameter fKNumberConsignment = new SqlParameter
                {
                    ParameterName = "@Number_Consignment",
                    Value = codeConsignment
                };
                command.Parameters.Add(fKNumberConsignment);
                var result = command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        //public void LoadConsignmentInCell(RefrigeratorClass refrigeratorClass, ref Dictionary<string, int> vs)
        //{
        //    try
        //    {
        //        conn.Open();

        //        string query = "Select FK_Code_New_Consignment,Storey FROM Refrigerator WHERE Camera = '" + refrigeratorClass.Camera + "' and Column_Box = '" + refrigeratorClass.Column + "'and Rows_Box = " + refrigeratorClass.Rows + " and Storey>'" + refrigeratorClass.Storey + "'";

        //        SqlCommand cmd = new SqlCommand(query, conn);
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        while (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                vs[reader.GetValue(0).ToString()] = Convert.ToInt32(reader.GetValue(1));
        //            }
        //            reader.NextResult();
        //        }
        //        reader.Close();

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    finally
        //    {
        //        if (conn != null)
        //        {
        //            conn.Close();
        //        }
        //    }
        //}


        public void LoadConsignmentInCell(RefrigeratorClass refrigeratorClass,ref List<string> vs)
        {
            try
            {
                conn.Open();
          
            string query = "Select FK_Code_New_Consignment,Storey FROM Refrigerator WHERE Camera = '" + refrigeratorClass.Camera+ "' and Column_Box = '"+ refrigeratorClass .Column + "'and Rows_Box = "+ refrigeratorClass.Rows + " and Storey>'"+ refrigeratorClass.Storey + "'";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
                while (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        vs.Add(reader.GetValue(0).ToString());
                    }
                    reader.NextResult();
                }
                reader.Close();
    
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        string translation(string mount)
        {
            switch(mount)
            {
                case "Январь": { mount= "Січень"; break; }
                case "Февраль": { mount= "Лютий"; break; }
                case "Март": { mount= "Березень"; break; }
                case "Апрель": { mount= "Квітень"; break; }
                case "Май": { mount= "Травень"; break; }
                case "Июнь": { mount= "Червень"; break; }
                case "Июль": { mount= "Липень"; break; }
                case "Август": { mount= "Серпень"; break; }
                case "Сентябрь": { mount= "Вересень"; break; }
                case "Октябрь": { mount= "Жовтень"; break; }
                case "Ноябрь": { mount= "Листопад"; break; }
                case "Декабрь": { mount= "Грудень"; break; }
            }
            return mount;
        }

        public void LoadDateAndWeightNewConsignment(string codeNumber,ref List<double> weight,ref List<string> mount)
        {
            List<Control_WeighingClass> control_WeighingClass = new List<Control_WeighingClass>();
            Control_WeighingClass control_Weighing = new Control_WeighingClass();
                try
            {
                conn.Open();
                int data = 0;
                string query = "Select Actual_Weight, Date_Operation_Weight From Control_Weighing Where FK_Code_New_Consignment ='" + codeNumber + "'";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                int i = 0;
                while (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        weight.Add(Convert.ToDouble(reader[0]));
                        mount.Add(translation(Convert.ToDateTime(reader[1]).ToString("MMMM")));

                    }
                    reader.NextResult();
                }

                reader.Close();

              
                  
              
       
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public void InsertControlWeight(Control_WeighingClass control_WeighingClass)
        {
            try
            {
                conn.Open();
                string sqlExpression = "sp_InsertControlWeight";
                SqlCommand command = new SqlCommand(sqlExpression, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter Actual_Weight = new SqlParameter
                {
                    ParameterName = "@Actual_Weight",
                    Value = control_WeighingClass.ActualWeight
                };
                command.Parameters.Add(Actual_Weight);

                SqlParameter Deviation = new SqlParameter
                {
                    ParameterName = "@Deviation",
                    Value = control_WeighingClass.Deviation
                };
                command.Parameters.Add(Deviation);

                SqlParameter Stage_Weight = new SqlParameter
                {
                    ParameterName = "@Stage_Weight",
                    Value = control_WeighingClass.StateWeight
                };
                command.Parameters.Add(Stage_Weight);

                SqlParameter Date_Operation_Weight = new SqlParameter
                {
                    ParameterName = "@Date_Operation_Weight",
                    Value = control_WeighingClass.dataOperation
                };
                command.Parameters.Add(Date_Operation_Weight);

                SqlParameter FK_Code_New_Consignment = new SqlParameter
                {
                    ParameterName = "@FK_Code_New_Consignment",
                    Value = control_WeighingClass.CodeNumber
                };
                command.Parameters.Add(FK_Code_New_Consignment);

                var result = command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public int LoadCountConsignmentInCell(RefrigeratorClass refrigeratorClass)
        {
         
            try
            {
                conn.Open();
                int data = 0;
                string query = "Select Count(FK_Code_New_Consignment) FROM Refrigerator WHERE Camera = '" + refrigeratorClass.Camera + "' and Column_Box = '" + refrigeratorClass.Column + "'and Rows_Box = " + refrigeratorClass.Rows + "";
                int i = 0;
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
               
                while (reader.HasRows)
                {
                 
                    while (reader.Read())
                    {
                        data=Convert.ToInt32(reader.GetValue(0));
                    }
                    reader.NextResult();
                }
                reader.Close();
               return data;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        public Model.NewConsignment SearchConsignment(Button button)
        {
            string sqlExpression = "sp_SearchNewConsignment";
            Model.NewConsignment newConsignment=new Model.NewConsignment();
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sqlExpression, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter NumberConsignment = new SqlParameter
                {
                    ParameterName = "@NumberConsignment",
                    Value = button.Text.ToString()
                };
                command.Parameters.Add(NumberConsignment);
               
                SqlDataReader reader = command.ExecuteReader();
              
                reader.Read();
                newConsignment.NumberConsignment = reader.GetValue(0).ToString();
                    newConsignment.DateCreation = Convert.ToDateTime(Convert.ToDateTime(reader.GetValue(1)).ToShortDateString());
                    newConsignment.Weight = Convert.ToDouble(reader[2]);
                    newConsignment.Caliber = Convert.ToInt32(reader[3]);
                    newConsignment.Garlic.Name = reader[4].ToString();
                    newConsignment.Garlic.Sort = reader[5].ToString();
             
                 
                    
                reader.Close();
             
                return newConsignment;



            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
          

            
        }

        public void InsertInRefrigerator(string camera, string column, int rows, int storey, DateTime date, string numberConsignment)
        {
            string sqlExpression = "sp_InsertInRefrigerator";
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sqlExpression, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter Camera = new SqlParameter
                {
                    ParameterName = "@Camera",
                    Value = camera
                };
                command.Parameters.Add(Camera);

                SqlParameter Column_Box = new SqlParameter
                {
                    ParameterName = "@Column_Box",
                    Value = column
                };
                command.Parameters.Add(Column_Box);

                SqlParameter Rows_Box = new SqlParameter
                {
                    ParameterName = "@Rows_Box",
                    Value = rows
                };
                command.Parameters.Add(Rows_Box);

                SqlParameter Storey = new SqlParameter
                {
                    ParameterName = "@Storey",
                    Value = storey
                };
                command.Parameters.Add(Storey);

                SqlParameter Date_Operation_Refrigerator = new SqlParameter
                {
                    ParameterName = "@Date_Operation_Refrigerator",
                    Value = date
                };
                command.Parameters.Add(Date_Operation_Refrigerator);

                SqlParameter FK_Code_New_Consignment = new SqlParameter
                {
                    ParameterName = "@FK_Code_New_Consignment",
                    Value = numberConsignment
                };
                command.Parameters.Add(FK_Code_New_Consignment);
                var result = command.ExecuteNonQuery();


            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public void InsertInCalibration(string numberConsignment,DateTime date)
        {
            string sqlExpression = "sp_InsertInCalibration";
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sqlExpression, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter dateCalibration = new SqlParameter
                {
                    ParameterName = "@Date_Calibration",
                    Value = date
                };
                command.Parameters.Add(dateCalibration);

                SqlParameter fKNumberConsignment = new SqlParameter
                {
                    ParameterName = "@FK_Number_Consignment",
                    Value = numberConsignment
                };
                command.Parameters.Add(fKNumberConsignment);
    
                var result = command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public void InsertInMobile(DryingMobile drying)
        {
            string sqlExpression = "sp_InsertInMobileDrying";
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sqlExpression, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter dateStartMobileDrying = new SqlParameter
                {
                    ParameterName = "@Date_Start_Mobile_Drying",
                    Value = drying.DateStart
                };
                command.Parameters.Add(dateStartMobileDrying);

                SqlParameter weightConsignmentInitial = new SqlParameter
                {
                    ParameterName = "@WeightConsignmentInitial",
                    Value = drying.Weight
                };
                command.Parameters.Add(weightConsignmentInitial);

                SqlParameter fKNumberConsignment = new SqlParameter
                {
                    ParameterName = "@FK_Number_Consignment",
                    Value = drying.CodeConsignment
                };
                command.Parameters.Add(fKNumberConsignment);
                var result = command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public double LoadWeightNewConsignment(string codeNumber)
        {
            double weight = 0.0;
            try
            {
                conn.Open();
                string query = "SELECT Weight_New_Consignment FROM New_Consignment Where Code_New_Consignment = '"+ codeNumber + "'";
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader reader = command.ExecuteReader();
                List<string[]> data = new List<string[]>();
                while (reader.Read())
                {
                    weight= Convert.ToDouble(reader.GetValue(0));
                }
                reader.Close();

                return weight;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        
           
        }

        public void LoadAllInformationDrying(DataGridView dataGridView)
        {
           
            try
            {
                conn.Open();
                string query = "SELECT* FROM Party_information_About_Drying";
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader reader = command.ExecuteReader();
                List<string[]> data = new List<string[]>();
                while (reader.Read())
                {
                    data.Add(new string[9]);
                    data[data.Count - 1][0] = reader[0].ToString();
                    data[data.Count - 1][1] = (Convert.ToDateTime(reader[1]).ToShortDateString()).ToString();
                    data[data.Count - 1][2] = reader[2].ToString();
                    data[data.Count - 1][3] = reader[3].ToString();
                    data[data.Count - 1][4] = reader[4].ToString();
                    data[data.Count - 1][5] = reader[5].ToString();
                    data[data.Count - 1][6] = reader[6].ToString();
                    data[data.Count - 1][7] = reader[7].ToString();
                    data[data.Count - 1][8] = reader[8].ToString();
                }
                reader.Close();
          
                foreach (string[] s in data)
                    dataGridView.Rows.Add(s);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public void TakeConsignmentWithMobileDrying(string codeConsignment,double Weight,DateTime end)
        {
            string sqlExpression = "sp_UpdateMobileDrying";
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sqlExpression, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter dateEndMobileDrying = new SqlParameter
                {
                    ParameterName = "@Date_End_Mobile_Drying",
                    Value = end
                };
                command.Parameters.Add(dateEndMobileDrying);

                SqlParameter weightConsignmentAfterMobileDrying = new SqlParameter
                {
                    ParameterName = "@Weight_Consignment_After_Mobile_Drying",
                    Value = Weight
                };
                command.Parameters.Add(weightConsignmentAfterMobileDrying);

                SqlParameter fKNumberConsignment = new SqlParameter
                {
                    ParameterName = "@Number_Consignment",
                    Value = codeConsignment
                };
                command.Parameters.Add(fKNumberConsignment);
                var result = command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        public void InsertConsignment(Consignment consignment)
            {
            string sqlExpression = "sp_InsertConsignment";
            try
                {
                conn.Open();
                SqlCommand command = new SqlCommand(sqlExpression, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter numberConsignmentParam = new SqlParameter
                {
                    ParameterName = "@Number_Consignment",
                    Value = consignment.NumberConsignment
                };
                command.Parameters.Add(numberConsignmentParam);

                SqlParameter dateCollectionParam = new SqlParameter
                {
                    ParameterName = "@Date_Collection",
                    Value = consignment.DateCollection
                };
                command.Parameters.Add(dateCollectionParam);

                SqlParameter dateReceivingParam = new SqlParameter
                {
                    ParameterName = "@Date_Receiving",
                    Value = consignment.DateReceiving
                };
                command.Parameters.Add(dateReceivingParam);

                SqlParameter areaParam = new SqlParameter
                {
                    ParameterName = "@Area",
                    Value = consignment.Area
                };
                command.Parameters.Add(areaParam);

                SqlParameter processParam = new SqlParameter
                {
                    ParameterName = "@Process",
                    Value = consignment.Process
                };
                command.Parameters.Add(processParam);

                SqlParameter weightConsignmentParam = new SqlParameter
                {
                    ParameterName = "@WeightConsignment",
                    Value = consignment.WeightConsignment
                };
                command.Parameters.Add(weightConsignmentParam);

                SqlParameter FKGarlicParam = new SqlParameter
                {
                    ParameterName = "@FK_Garlic",
                    Value = consignment.CodeGarlic
                };
                command.Parameters.Add(FKGarlicParam);
                var result = command.ExecuteNonQuery();
                MessageBox.Show("Партію:"+consignment.NumberConsignment+".Додано.");
                
            }
            catch (Exception)
                {

                    throw;
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
            }
        
    }
}
