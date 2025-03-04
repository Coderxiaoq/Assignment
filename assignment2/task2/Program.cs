using System;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
class Program {
    static void Main() {
        
        Console.WriteLine("请输入数组元素（用空格或逗号分隔）：");
        string input = Console.ReadLine();

        // 分割字符串为数组
        string[] parts = input.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

        // 转换为整数数组
        int[] numbers = new int[parts.Length];
        for (int i = 0; i < parts.Length; i++)
        {
            numbers[i] = int.Parse(parts[i]);
        }

        Array.Sort(numbers);
        Console.WriteLine("min:" + numbers[0]);
        int len = numbers.Length;
        Console.WriteLine("max:" + numbers[len - 1]);
        int sum = 0;
        for (int i = 0; i < len; i++) {
            sum += numbers[i];
        }
        Console.WriteLine("sum:" + sum);
        Console.WriteLine("average:" + sum / len);
    }

}