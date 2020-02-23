using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true){  
                double num1=0,num2=0,result=0;
                string operater="";

                read(ref num1,ref num2,ref operater);

                calculate(num1,num2,operater,ref result);

                Console.WriteLine("运算结果：\n{0} {1} {2} = {3}",num1,operater,num2,result);
                                    
                Console.WriteLine("输入Q可退出");
                string key = Console.ReadLine();
                switch(key)
                {
                    case "q":
                    case "Q":
                        return;
                }
            }
        }

        static void read(ref double num1,ref double num2,ref string operater){
            Console.WriteLine("请输入第一个数:");
            string str1 = Console.ReadLine();
            num1 = toNum(str1);  

            Console.WriteLine("请输入运算符:");
            string ope = Console.ReadLine();
            operater = check(ope);
                    
            Console.WriteLine("请输入第二个数:");
            string str2 = Console.ReadLine();
            num2 = toNum(str2,operater);  
        }

        static double toNum(String rawstr){
            try
            {
                double num = Double.Parse(rawstr);
                return num;
            }
            catch (System.Exception)
            {
                Console.WriteLine("输入有误，请重新输入:\n>");
                String str = Console.ReadLine();
                return toNum(str);
            }   
        }

        static double toNum(string rawstr,string ope)
        {
            try
            {
                double num = Double.Parse(rawstr);
                int test = Int32.Parse(rawstr);
                int temp = 1/test;
                return num;
            }
            catch(DivideByZeroException){
                Console.WriteLine("0不能作为除数，请重新输入:\n>");
                String str = Console.ReadLine();
                return toNum(str,ope);
            }
            catch (System.Exception)
            {
                Console.WriteLine("输入有误，请重新输入:\n>");
                String str = Console.ReadLine();
                return toNum(str);
            }   
        }

        static string check(string operater)
        {
            string[] opeList = {"+","-","x","*","÷","/"};
            foreach (string ope in opeList)
            {
                if(operater == ope )
                    return operater;
            }
            Console.WriteLine("输入有误，请重新输入运算符:\n>");
            string str = Console.ReadLine();
            return check(str);
        }
        static void calculate(Double num1,Double num2, String operater, ref double result)
        {
            switch(operater)
            {
                case "+":
                    result = num1+num2;
                    break;

                case "-":
                    result = num1-num2;
                    break;

                case "÷":
                case "/":     
                    result = num1/num2;
                    break;

                case "x":
                case "*":
                    result = num1*num2;
                    break;
                default:
                    break;                    
            }
        }
    }
}
