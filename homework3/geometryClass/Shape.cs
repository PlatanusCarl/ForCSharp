using System;
using System.Collections.Generic;
using System.Text;

namespace geometryClass
{
    abstract class Shape
    {
        public abstract double? Area { get; }
        public abstract bool IsLegal();

    }
}
