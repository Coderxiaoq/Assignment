using System;
class Program {
    static void Main() {
        Console.Write("请输入一个整数:");
        int num = Convert.ToInt32(Console.ReadLine());
        int i = 2;
        while (num != 1) {
            if (num % i != 0)
            {
                i++;
            }
            else {
                num /= i;
                Console.WriteLine(i);
                i = 2;
            }
        }
    }
}