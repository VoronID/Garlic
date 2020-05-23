using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garlic.Model
{
    public class DryingInformation
    {
        public string NumberConsignment { get; set; }
        public DateTime DateCollection { get; set; }
        public string Sort { get; set; }

        public string TypeGarlic { get; set; }

        public double Area { get; set; }

        public double InitialWeight { get; set; }

        public double WeightAfterMobile { get; set; }

        public double WeightAfterTwo { get; set; }

        public double Difference { get; set; }

        public DryingInformation(string NumberConsignment,
                                 DateTime DateCollection,
                                 string Sort,
                                 string TypeGarlic,
                                 double Area,
                                 double InitialWeight,
                                 double WeightAfterMobile,
                                 double WeightAfterTwo,
                                 double Difference)
        {
            this.NumberConsignment = NumberConsignment;
                this.DateCollection = DateCollection;
                this.Sort = Sort;
            this.TypeGarlic = TypeGarlic;
            this.Area = Area;
            this.InitialWeight = InitialWeight;
            this.WeightAfterMobile = WeightAfterMobile;
            this.WeightAfterTwo = WeightAfterTwo;
            this.Difference = Difference;
        }

    }
}
