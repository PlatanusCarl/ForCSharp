using System;
using System.Collections.Generic;
using System.Text;

namespace geometryClass
{
    class Rectangle:Shape
    {
        private int height,width;
        private bool? tag = null;
        public Rectangle(int a, int b)
        {
            height = a;
            width = b;
            tag = this.IsLegal();
        }
        public void Reset(int a, int b)
        {
            height = a;
            width = b;
            tag = this.IsLegal();
        }
        public override double? GetArea()
        {
            if (tag == true)
            {
                area = height * width;
                return area;
            }
            Console.WriteLine("矩形非法");
            return null;
        }
        public override bool IsLegal()
        {
            if (height < 0 || width < 0) return false;
            return true;
        }
    }
}
