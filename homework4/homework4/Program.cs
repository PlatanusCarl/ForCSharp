using System;
using System.Collections.Generic;
namespace homework4
{
    public class Clock
    {
        private DateTime time;
        public DateTime Time
        {
            set
            {
                time = value;
                OnTimeChanged();
            }
            get
            {
                return time;
            }
            
        }
        public DateTime AlarmTime{set;get;}

        public delegate void TimeChangeHandler();

        public event TimeChangeHandler TimeChanged;
        protected virtual void OnTimeChanged()
        {
            if (TimeChanged != null && AlarmTime == Time)
            {
                TimeChanged();
                TimeChanged = null;
            }
            else
            {
                Console.Write("Tick ");
            }
        }
    }

    public class Alarmer
    {
        public void printf()
        {
            Console.WriteLine("Alarm!");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
        /*
        1、为示例中的泛型链表类添加类似于List<T>类的ForEach(Action<T> action)方法。通过调用这个方法打印链表元素，求最大值、最小值和求和（使用lambda表达式实现）。
        */
            List<int> numList = new List<int>();
            String str = null;
            while (str != "Q")
            {
                try
                {
                    str = Console.ReadLine();
                    numList.Add(Int32.Parse(str));
                }
                catch
                {
                    continue;
                }
            }

            numList.ForEach(num => Console.WriteLine(num));

            int max = numList[0];
            numList.ForEach(num => max = num > max ? num : max);
            Console.WriteLine($"max: {max}");

            int min = numList[0];
            numList.ForEach(num => min = num < min ? num : min);
            Console.WriteLine($"min: {min}");

            int sum = 0;
            numList.ForEach(num => sum += num);
            Console.WriteLine($"sum: {sum}");

            Console.ReadLine();

            /*
             * 2、使用事件机制，模拟实现一个闹钟功能。闹钟可以有嘀嗒（Tick）事件和响铃（Alarm）两个事件。在闹钟走时时或者响铃时，在控制台显示提示信息。
            */
            Clock clock = new Clock(); 
            Alarmer alarmer = new Alarmer(); 
            clock.TimeChanged += new Clock.TimeChangeHandler(alarmer.printf);
            
            DateTime aim = new DateTime(2020, 3, 9, 16, 45, 00);
            clock.AlarmTime = aim;

            while(true)
            {
                clock.Time = DateTime.Now;
            }

        }

    }
}
