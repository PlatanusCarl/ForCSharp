using System;
using System.Collections.Generic;
using System.Text;

namespace geometryClass
{
    abstract class Shape
    {
        ~Shape() { }
        public abstract double? GetArea();
        public abstract bool IsLegal();
      //  public abstract void Reset();

        protected double? area;
    }
}
