using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garlic.Model
{
    public class SellClass
    {
        public DateTime DateOperation { get; set; }

        public double Price { get; set; }

        public double TotalPrice { get; set; }

        public string NumberConsignment { get; set; }

        public int CodeRefrigerator { get; set; }

        public double Weight { get; set; } 

        public SellClass(DateTime DateOperation,
                    double Price,
                    double TotalPrice,
                    string NumberConsignment,
                    int CodeRefrigerator)
        {
            this.DateOperation = DateOperation;
            this.Price = Price;
            this.TotalPrice = TotalPrice;
            this.NumberConsignment = NumberConsignment;
            this.CodeRefrigerator = CodeRefrigerator;
        }

        public SellClass()
        {

        }
    }
}
