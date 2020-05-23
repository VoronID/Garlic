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

        public string NumberConsignment { get; set; }

        public DateTime DateCreation { get; set; }

        public Garlics Garlic { get; set; }

        public NewConsignment(double _weight,
                       double _caliber)
        {
            weight = _weight;
            caliber = _caliber;
        }
        public NewConsignment()
        {
            Garlic = new Garlics();
        }
        public NewConsignment(string numberConsignment,DateTime dateCreation,double _weight,
                       double _caliber,Garlics garlics)
        {
            numberConsignment = NumberConsignment;
            DateCreation = dateCreation;
            weight = _weight;
            caliber = _caliber;
            Garlic = garlics;
        }
    }
}
