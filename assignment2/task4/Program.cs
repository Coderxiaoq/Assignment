using System;

public class ToeplitzMatrixChecker
{
    // 检查矩阵是否为托普利茨矩阵
    public static bool IsToeplitzMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows - 1; i++) // 无需检查最后一行
        {
            for (int j = 0; j < cols - 1; j++) // 无需检查最后一列
            {
                if (matrix[i, j] != matrix[i + 1, j + 1])
                {
                    return false;
                }
            }
        }
        return true;
    }
}

public class Program
{
    public static void Main()
    {
        // 示例矩阵
        int[,] matrix = {
            { 1, 2, 3, 4 },
            { 5, 1, 2, 5 },
            { 9, 5, 1, 2 }
        };

        bool result = ToeplitzMatrixChecker.IsToeplitzMatrix(matrix);
        Console.WriteLine("示例矩阵是否为托普利茨矩阵？ " + result);
    }
}