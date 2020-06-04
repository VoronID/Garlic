using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garlic.Model
{
    public class WriteOffClass
    {
        public DateTime DateOperation { get; set; }
        public string NumberConsignment { get; set; }

        public int CodeRefrigerator { get; set; }

       public WriteOffClass()
        {

        }
       public WriteOffClass(DateTime DateOperation, string NumberConsignment, int CodeRefrigerator)
        {
            this.DateOperation = DateOperation;
            this.NumberConsignment = NumberConsignment;
            this.CodeRefrigerator = CodeRefrigerator;
        }
    }
}
