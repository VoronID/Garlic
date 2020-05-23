using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garlic.Model
{
    public class DryingMobile
    {
        private DateTime dateStart;
        private DateTime dateEnd;
        private double weight;
        private string codeConsignment;
        /// <summary>
        /// Дата початку сушки
        /// </summary>
        public DateTime DateStart { get => dateStart; set => dateStart = value; }
        /// <summary>
        /// Дата кінця сушки
        /// </summary>
        public DateTime DateEnd { get => dateEnd; set => dateEnd = value; }

        public double Weight { get => weight; set => weight = value; }

        public string CodeConsignment { get => codeConsignment; set => codeConsignment = value; }

        public DryingMobile(DateTime _dateStart,double _weight, string _codeConsignment)
        {
            DateStart = _dateStart;
            Weight = _weight;
            CodeConsignment = _codeConsignment;

        }
    }
}
