using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garlic.Model
{
    public class Garlic
    {
        private string name;
        private string sort;
        /// <summary>
        /// Назва часнику
        /// </summary>
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// Сорт часнику
        /// </summary>
        public string Sort { get => sort; set => sort = value; }
        public Garlic(string _name,
                      string _sort)
        {
            name = _name;
            sort = _sort;
        }


    }
}
