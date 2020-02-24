/*
1.编写程序输出用户指定数据的所有素数因子。


*/
using System;

namespace arrayope
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入数据：\n");
            string str = Console.ReadLine();
            int num = check(str);
            find(num);
            Console.ReadKey();
        }

        static int check(string str)//可以写一个tryparse
        { 

            int num = 0;
            try
            {
                num = Int32.Parse(str);
            }
            catch (System.Exception)
            {
                Console.WriteLine("请重新输入：\n");
                str = Console.ReadLine();
                num = check(str);
            }
            if(num < 2)
            {
                Console.WriteLine("请重新输入：\n");
                str = Console.ReadLine();
                num = check(str);
            }
            return num;
        }

        static void find(int num)
        {
            for(int i = 2; i <= num; i++)
            {
                while(num%i == 0)
                {
                    Console.WriteLine(i);
                    num/=i;
                }
            }
                   
        }
    }
}
