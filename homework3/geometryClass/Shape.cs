﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GeometryShapes
{
    abstract class Shape
    {
        public abstract double? Area { get; }
        public abstract bool IsLegal();

    }
}
