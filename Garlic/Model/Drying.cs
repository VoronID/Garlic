using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garlic.Model
{
    public class Drying
    {
        private DateTime dateStart;
        private DateTime dateEnd;
        /// <summary>
        /// Дата початку сушки
        /// </summary>
        public DateTime DateStart { get => dateStart; set => dateStart = value; }
        /// <summary>
        /// Дата кінця сушки
        /// </summary>
        public DateTime DateEnd { get => dateEnd; set => dateEnd = value; }

        public Drying(DateTime _dateStart,DateTime _dateEnd)
        {
            dateStart = _dateStart;
            dateEnd = _dateEnd;
        }
    }
}
