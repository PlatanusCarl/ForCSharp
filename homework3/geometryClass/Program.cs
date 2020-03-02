﻿using System;

namespace GeometryShapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle triangle = new Triangle(3,4,5);
            Rectangle rectangle = new Rectangle(3, 2);
            Circle circle = new Circle(-1);
            Console.WriteLine("{0} {1} {2}",triangle.Area,rectangle.Area,circle.Area);
            Console.ReadLine();
        }
    }
}
