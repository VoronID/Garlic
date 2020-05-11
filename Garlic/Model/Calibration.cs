using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garlic.Model
{
    public class Calibration
    {
        private DateTime dateOperation;
        /// <summary>
        /// Дата операції
        /// </summary>
        public DateTime DateOperation { get => dateOperation; set => dateOperation = value; }
    }
}
