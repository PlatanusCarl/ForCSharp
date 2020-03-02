using System;
using System.Collections.Generic;
using System.Text;

namespace geometryClass
{
    class Circle:Shape
    {
        public Circle(double a)
        {
            Radius = a;
        }
        public double Radius { set; get; }
        public override double? Area
        {
            get
            {
                if(this.IsLegal())
                    return 3.14 * Radius * Radius;
                Console.WriteLine("非法圆形！");
                return null;
            }
        }
        public override bool IsLegal()
        {
            if (Radius < 0) return false;
            return true;
        }
    }
}
