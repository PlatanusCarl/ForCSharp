/*
2.编程求一个整数数组的最大值、最小值、平均值和所有数组元素的和。

*/

using System;

namespace arrayope
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = {1,2,3,4,5,6,7,8,9,10};
            Console.WriteLine("{0} {1} {2} {3} ",max(array),mini(array),average(array),sum(array));

            Console.ReadKey();
        }
        static int max(int[] array)
        {
            int max = array[0];
            foreach(int i in array)
            {
                if(i > max)
                {
                    max = i;
                }
            }
            return max;
        }

        static int mini(int[] array)
        {
            int mini = array[0];
            foreach(int i in array)
            {
                if(i < mini)
                {
                    mini = i;
                }
            }
            return mini;
        }
        static int average(int[] array)
        {
            int average=array[0] ,count=0;
            foreach(int i  in array)
            {
                average += i;
                count++;
            }
            average /= count;
            return average;
        }

        static int sum(int[] array)
        {
            int sum = array[0];
            foreach(int i  in array)
            {
                sum += i;
            }
            return sum;
        }
    }
}
