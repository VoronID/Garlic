using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garlic.Model
{
    public class Control_Weighing
    {
        private double actualWeight;
        private double deviation;
        private double stateWeight;
        /// <summary>
        /// 
        /// </summary>
        public double StateWeight { get => stateWeight; set => stateWeight = value; }
        public double Deviation { get => deviation; set => deviation = value; }
        public double ActualWeight { get => actualWeight; set => actualWeight = value; }
    }
}
