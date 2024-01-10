using System;

class labaodindva
{
    static void Main()
    {
        int[ , ] matrix = {
{1, 2, 3, 0},
{0, 5, 0, 0},
{4, 5, 6, 7},
{5, 5, 0, 0},
{8, 9, 10, 11}
};
        static void Print(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++, Console.WriteLine())
                for (int j = 0; j < arr.GetLength(1); j++)
                    Console.Write(arr[i, j] + " ");
        }
        Print(matrix);
        // Пункт 1
        int columnsWithZero = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            bool hasZero = false;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, j] == 0)
                {
                    hasZero = true;
                    break;
                }
            }
            if (hasZero)
            {
                columnsWithZero++;
            }
        }
        Console.WriteLine("Количество столбцов, содержащих хотя бы один нулевой элемент: " + columnsWithZero);

        // Пункт 2
        int maxLength = 0;
        int maxRow = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int length = 1;
            for (int j = 1; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == matrix[i, j - 1])
                {
                    length++;
                }
                else
                {
                    length = 1;
                }
                if (length > maxLength)
                {
                    maxLength = length;
                    maxRow = i + 1;
                }
            }
        }
        Console.WriteLine("Номер строки с самой длинной серией одинаковых элементов: " + maxRow);
    }
}