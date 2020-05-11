using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garlic.Model
{
    public class NewConsignment
    {
        private double weight;
        private double caliber;
        /// <summary>
        /// Вага партії
        /// </summary>
        public double Weight { get => weight; set => weight = value; }
        /// <summary>
        /// Калібр партії
        /// </summary>
        public double Caliber { get => caliber; set => caliber = value; }

        public NewConsignment(double _weight,
                       double _caliber)
        {
            weight = _weight;
            caliber = _caliber;
        }
    }
}
