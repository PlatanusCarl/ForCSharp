using System;

namespace geometryClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle triangle = new Triangle(2,2,3);
            Rectangle rectangle = new Rectangle(3, 2);
            Circle circle = new Circle(3);
            Console.WriteLine(rectangle.GetArea());
            Console.ReadLine();
        }
    }
}
