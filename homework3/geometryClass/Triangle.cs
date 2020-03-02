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
            tag = this.IsLegal();
        }
        public void Reset(int a, int b, int c)
        {
            L1 = a;
            L2 = b;
            L3 = c;
            tag = this.IsLegal();
        }
        public override double? GetArea()
        {
            if(tag == true)
            {
                float p = L1 + L2 + L3;
                area = Math.Sqrt(p * (p - L1) * (p - L2) * (p - L3));
                return area;
            }
            Console.WriteLine("三角形非法");
            return null;
        }
        public override bool IsLegal()
        {
            if (L1 < 0 || L2 < 0 || L3 < 0) return false;
            if (L1 + L2 > L3 && L1 + L3 > L2 && L2 + L3 > L1)return true;
            return false;
        }

        private int L1, L2, L3;
        private bool? tag = null;
    }
}
