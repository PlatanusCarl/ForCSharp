using System;
using System.Collections.Generic;
using System.Text;

namespace geometryClass
{
    class Triangle : Shape
    {
        public Triangle(int a, int b, int c)
        {
            L1 = a;
            L2 = b;
            L3 = c;
        }
        public double L1 { set; get; }
        public double L2 { set; get; }
        public double L3 { set; get; }

        public override double? Area
        {
            get
            {
                if (this.IsLegal())
                {
                    return Math.Sqrt((L1 + L2 + L3) * (-L1 + L2 + L3) * (L1 - L2 + L3) * (L1 + L2 - L3) / 16);
                }
                Console.WriteLine("非法三角形！");
                return null;
            }
        }
        public override bool IsLegal()
        {
            if (L1 < 0 || L2 < 0 || L3 < 0) return false;
            if (L1 + L2 > L3 && L1 + L3 > L2 && L2 + L3 > L1) return true;
            return false;
        }

    }
}
