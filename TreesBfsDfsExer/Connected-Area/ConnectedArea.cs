using System;
using System.Collections.Generic;
using System.Linq;

internal class ConnectedArea
{
    public static char[,] matrix;
    public static Dictionary<int, List<int>> visited =
    new Dictionary<int, List<int>>();
    static void Main()
    {
        int rows = int.Parse(Console.ReadLine()!);
        int cols = int.Parse(Console.ReadLine()!);

        ReadMatrix(rows, cols);

        int maxSize = 0;
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                int areaSize = FindArea(row, col);
                maxSize = Math.Max(maxSize, areaSize);
            }
        }

        Console.WriteLine($"The largest connected area of the matrix is: {maxSize}");
    }

    static void ReadMatrix()
    {
        matrix = new char[rows, cols];

        for (int r = 0; r < rows; r++)
        {
            string newRow = Console.ReadLine();

            for (int c = 0; c < cols; c++)
            {
                matrix[r, c] = newRow[c];
            }
        }
    }

    private static int FindArea(int row, int col)
    {
        if (row >= matrix.GetLength(0) || row < 0 ||
                col >= matrix.GetLength(1) || col < 0)
        {
            return 0;
        }
        if (visited.Keys.Contains(row) && visited[row].Contains(col))
        {
            return 0;
        }
        if (matrix[row, col] != '1')
        {
            return 0;
        }

        if (!visited.Keys.Contains(row))
        {
            visited[row] = new List<int>();
        }

        visited[row].Add(col);

        var areaSize = 1;
        areaSize += FindArea(row + 1, col);
        areaSize += FindArea(row - 1, col);
        areaSize += FindArea(row, col + 1);
        areaSize += FindArea(row, col - 1);

        return areaSize;
    }

}
