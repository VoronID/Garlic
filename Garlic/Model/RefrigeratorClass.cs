using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garlic.Model
{
    public class RefrigeratorClass
    {
        public string Camera { get; set; }
        public string Column { get; set; }
        public int Rows { get; set; }
        public int Storey { get; set; }
        public string CodeNumber { get; set; }

        public DateTime DateOperation { get; set; }


        public void Print()
        {
            Console.WriteLine("Camera:"+Camera+"\n"+"Column:"+Column+"\n"+"Rows:"+Rows+"\n"+"Storey:"+Storey);
        }

        public RefrigeratorClass(string codeNumber,
                            string camera,
                            string column,
                            int rows,
                            int storey)
        {
            CodeNumber = codeNumber;
            Camera = camera;
            Column = column;
            Rows = rows;
            Storey = storey;
        }

        public RefrigeratorClass(string camera,
                            string column,
                            int rows,
                            int storey)
        {
            Camera = camera;
            Column = column;
            Rows = rows;
            Storey = storey;
        }
        public RefrigeratorClass()
        {

        }

        public RefrigeratorClass(string camera,
                           string column,
                           int rows
                        )
        {
            Camera = camera;
            Column = column;
            Rows = rows;
          
        }
    }
}
