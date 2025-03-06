using System;

class Program
{
    static bool IsToeplitzMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        // 遍历矩阵，检查每个元素是否与其左上对角线上的元素相同
        for (int i = 1; i < rows; i++)
        {
            for (int j = 1; j < cols; j++)
            {
                if (matrix[i, j] != matrix[i - 1, j - 1])
                {
                    return false;
                }
            }
        }
        return true;
    }

    static void Main()
    {
        int[,] matrix =
        {
            { 1, 2, 3, 4 },
            { 5, 1, 2, 3 },
            { 9, 5, 1, 2 }
        };

        Console.WriteLine(IsToeplitzMatrix(matrix)); // 输出 True
    }
}
