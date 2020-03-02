using System;
using System.Collections.Generic;
using System.Text;

namespace geometryClass
{
    class Circle:Shape
    {
        public Circle(int a)
        {
            radius = a;
            tag = this.IsLegal();
        }
        public void Reset(int a)
        {
            radius = a;
            tag = this.IsLegal();
        }
        public override double? GetArea()
        {
            if (tag == true)
            {
                area = 3.14 * radius * radius;
                return area;
            }
            Console.WriteLine("圆形非法");
            return null;
        }
        public override bool IsLegal()
        {
            if (radius < 0) return false;
            return true;
        }

        private int radius;
        private bool? tag = null;
    }
}
