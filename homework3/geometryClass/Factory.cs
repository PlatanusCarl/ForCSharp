using System;
using System.Collections.Generic;
using System.Text;

namespace GeometryShapes
{
    class Factory
    {
        public Shape creatShape(int typeNum)
        {
            Shape mshape = null;
            switch (typeNum)
            {
                case 1:
                    mshape = new Circle(randnum());
                    break;
                case 2:
                    mshape = new Rectangle(randnum(), randnum());
                    break;
                case 3:
                    mshape = new Triangle(randnum(), randnum(), randnum());
                    while (!mshape.IsLegal())
                        mshape = new Triangle(randnum(), randnum(), randnum());
                    break;
            }
            return mshape;
        }
        static private int randnum()
        {
            Random r = new Random();
            int r1 = r.Next(1,100);
            return r1;
        }
    }
}
