using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garlic.Model
{
    public class Consignment
    {
        private string numberConsignment;
        private DateTime dateCollection;
        private DateTime dateReceiving;
        private double area;
        private string process;
        private double weightConsignment;

        /// <summary>
        /// Номер партії
        /// </summary>
        public string NumberConsignment { get => numberConsignment; set => numberConsignment = value; }
        /// <summary>
        /// Дата збирання
        /// </summary>
        public DateTime DateCollection { get => dateCollection; set => dateCollection = value; }
        /// <summary>
        /// Дата прийому партії
        /// </summary>
        public DateTime DateReceiving { get => dateReceiving; set => dateReceiving = value; }
        /// <summary>
        /// Площа поля
        /// </summary>
        public double Area { get => area; set => area = value; }
        /// <summary>
        /// Останій процес, якій пройшла партія
        /// </summary>
        public string Process { get => process; set => process = value; }
        /// <summary>
        /// Вага партії
        /// </summary>
        public double WeightConsignment { get => weightConsignment; set => weightConsignment = value; }
    }
}
