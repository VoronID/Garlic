using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garlic.Model
{
    public class Garlics
    {
        private string name;
        private string sort;
        private int codeGarlic;
        /// <summary>
        /// Назва часнику
        /// </summary>
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// Сорт часнику
        /// </summary>
        public string Sort { get => sort; set => sort = value; }

        public int CodeGarlic { get => codeGarlic; set => codeGarlic = value; }
        public Garlics(string _name,
                      string _sort
                    )
        {
            name = _name;
            sort = _sort;
           
        }
        public Garlics(string _name,
                     string _sort,
                     int _codeGarlic)
        {
            name = _name;
            sort = _sort;
            codeGarlic = _codeGarlic;
        }
        public Garlics()
        {

        }

    }
}
