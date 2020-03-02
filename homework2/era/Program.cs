/*
3.用“埃氏筛法”求2~ 100以内的素数。2~ 100以内的数，先去掉2的倍数，再去掉3的倍数，再
去掉4的倍数，以此类推...最后剩下的就是素数。
*/
using System;

namespace era
{
    class Program   
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入整数n：\n");
            int n;
            while(!int.TryParse(Console.ReadLine(),out n))
            {
                Console.WriteLine("输入有误，请重新输入");
            }
            bool[] tagArray = new bool[(int)System.Math.Sqrt(n)];

            for(int i = 2;i<tagArray.Length;i++)
            {
                if(!tagArray[i])
                {
                    Console.WriteLine(i);
                }
                for(int j =i+i;j<tagArray.Length;j+=i)
                {
                    tagArray[j] = true;
                }
            }

            Console.ReadKey();
        }
    }
}
