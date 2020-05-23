using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garlic.Model
{
    public class Control_WeighingClass
    {
        private double actualWeight;
        private double deviation;
        private double stateWeight;
  
        public double StateWeight { get => stateWeight; set => stateWeight = value; }
        public double Deviation { get => deviation; set => deviation = value; }
        public double ActualWeight { get => actualWeight; set => actualWeight = value; }

        public string CodeNumber { get; set; }

        public DateTime dataOperation { get; set; }

        public string Month { get; set; }

        public Control_WeighingClass(double _actualWeight,
                         double _deviation,
                         double _stateWeight,
                         string _CodeNumber,
                         DateTime _dataOperation,
                         string _Month)
        {
            StateWeight = _stateWeight;
            Deviation = _deviation;
            ActualWeight = _actualWeight;
            CodeNumber = _CodeNumber;
            dataOperation = _dataOperation;
            Month = _Month;
        }
        public Control_WeighingClass()
        {

        }
    }
}
