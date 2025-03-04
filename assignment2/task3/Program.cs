using System;
using System.Reflection.Metadata;
class Program {

    static void Prime() //埃式筛法
    {
        int maxNum = 100;
        bool[] isPrime = new bool[maxNum + 1];

        // 初始化所有数为true，之后将非素数标记为false
        for (int i = 0; i <= maxNum; i++)
        {
            isPrime[i] = true;
        }
        isPrime[0] = isPrime[1] = false; // 0和1不是素数

        int sqrtMax = (int)Math.Sqrt(maxNum);
        for (int current = 2; current <= sqrtMax; current++)
        {
            if (isPrime[current])
            {
                // 标记current的所有倍数为非素数
                for (int multiple = current * current; multiple <= maxNum; multiple += current)
                {
                    isPrime[multiple] = false;
                }
            }
        }

        // 收集所有素数
        List<int> primes = new List<int>();
        for (int num = 2; num <= maxNum; num++)
        {
            if (isPrime[num])
            {
                primes.Add(num);
            }
        }

        // 输出结果
        Console.WriteLine("2~100以内的素数：");
        Console.WriteLine(string.Join(", ", primes));
    }
    static void Main() 
    {
        Prime();
    }
}
