using System;
using System.Collections.Generic;
using System.Text;

namespace GeometryShapes
{
    class Rectangle:Shape
    {
        public double Length { set; get; }
        public double Width { set; get; }

        public Rectangle(int a, int b)
        {
            Length = a;
            Width = b;
        }

        public override double? Area
        {
            get
            {
                if(this.IsLegal())
                {
                    return Length * Width;
                }
                Console.WriteLine("矩形非法");
                return null;
            }
        }
        public override bool IsLegal()
        {
            if (Length < 0 || Width < 0) return false;
            return true;
        }
    }
}
