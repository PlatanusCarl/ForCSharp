using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true){
                
                try
                {
                                  
                }
                catch (System.Exception)
                {
                    
                    throw;
                }
                Console.WriteLine("请输入第一个数:\n>");
                string str1 = Console.ReadLine();
                check(str1);
                Double num1 = Double.Parse(str1);  
               

                Console.WriteLine("请输入运算符:\n>");
                string str3 = Console.ReadLine();
                
                Console.WriteLine("请输入第二个数:\n>");
                string str2 = Console.ReadLine();
                Double num2 = Double.Parse(str2);

                double result =0;

                calculate(num1,num2,str3,ref result);

                Console.WriteLine("{0} {1} {2} = {3}",str1,str3,str2,result);

                Console.ReadKey();
            }
        }

        static bool check(String str){

            return true;
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
