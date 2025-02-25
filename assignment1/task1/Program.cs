using System;
class Program
{
    static void Main()
    {
        Console.Write("请输入第一个数字：");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("请输入运算符（+、-、*、/）：");
        string op = Console.ReadLine();

        Console.Write("请输入第二个数字：");
        double num2 = Convert.ToDouble(Console.ReadLine());

        double result = 0;
        switch (op)
        {
            case "+":
                result = num1 + num2;
                break;
            case "-":
                result = num1 - num2;
                break;
            case "*":
                result = num1 * num2;
                break;
            case "/":
                if (num2 == 0)
                    Console.WriteLine("错误：除数不能为零！");
                else
                    result = num1 / num2;
                break;
            default:
                Console.WriteLine("无效运算符！");
                return;
        }

        Console.WriteLine($"计算结果：{result}");
    }
}