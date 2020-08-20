using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garlic.Controller
{
    public class Column
    {
        public int K1_A { get; set; }
        public int K1_B { get; set; }
        public int K1_C { get; set; }
        public int K1_D { get; set; }
        public int K1_E { get; set; }
        public int K1_F { get; set; }
        public int K1_G { get; set; }
        public int K1_H { get; set; }

        public int K2_A { get; set; }
        public int K2_B { get; set; }
        public int K2_C { get; set; }
        public int K2_D { get; set; }
        public int K2_E { get; set; }
        public int K2_F { get; set; }
        public int K2_G { get; set; }
        public int K2_H { get; set; }

        public Column(int K1_A,
               int K1_B,
               int K1_C,
               int K1_D,
               int K1_E,
               int K1_F,
               int K1_G,
               int K1_H,
               int K2_A,
               int K2_B,
               int K2_C,
               int K2_D,
               int K2_E,
               int K2_F,
               int K2_G,
               int K2_H)
        {
            this.K1_A = K1_A;
            this.K1_B = K1_B;
            this.K1_C = K1_C;
            this.K1_D = K1_D;
            this.K1_E = K1_E;
            this.K1_F = K1_F;
            this.K1_G = K1_G;
            this.K1_H = K1_H;
            this.K2_A = K2_A;
            this.K2_B = K2_B;
            this.K2_C = K2_C;
            this.K2_D = K2_D;
            this.K2_E = K2_E;
            this.K2_F = K2_F;
            this.K2_G = K2_G;
            this.K2_H = K2_H;
        }
    }
}
