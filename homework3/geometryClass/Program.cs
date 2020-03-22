/* 
 * 1.编写面向对象程序实现长方形、正方形、三角形等形状的类。每个形状类都能计算面积、判断形状是否合法。 请尝试合理使用接口/抽象类、属性来实现。
 * 2.随机创建10个形状对象，计算这些对象的面积之和。 尝试使用简单工厂设计模式来创建对象。
 */
using System;

namespace GeometryShapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Factory fac = new Factory();

           for(int i = 0;i<10;i++)
            {
                Random r = new Random();
                int r1 = r.Next(1,4);
                Shape sh = fac.creatShape(r1);
                Console.WriteLine($"第{i+1}个图形是{sh.GetType().Name}，面积为{sh.Area}");
            }
            Console.ReadLine();
        }
    }
}
