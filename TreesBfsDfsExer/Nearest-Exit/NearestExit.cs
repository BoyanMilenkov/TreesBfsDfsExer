using Nearest_Exit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NearestExit
{
    static int width = 9;
    static int height = 7;
    static char[,] labyrinth;
    static char VisitedCell = 's';

    public static void Main()
    {
        ReadLabyrinth();
        string shortPath = FindShortestPathToExit();
        if(shortPath == null)
        {
            Console.WriteLine("No exit!");
        }
        else if(shortPath == "")
        {
            Console.WriteLine("Start is at the exit.");
        }
        else
        {
            Console.WriteLine("Shortest exit: " + shortPath);
        }
    }

    static string FindShortestPathToExit()
    {
        var queue = new Queue<Point>();
        var startPosition = FindStartPosition();

        if(startPosition == null)
        {
            return null;
        }

        queue.Enqueue(startPosition);
        while(queue.Count > 0)
        {
            var currCell = queue.Dequeue();
            if (IsExit(currCell))
            {
                return TracePathBack(currCell);
            }
            TryDirection(queue, currCell, "U", 0, -1);
            TryDirection(queue, currCell, "R", +1, 0);
            TryDirection(queue, currCell, "D", 0, +1);
            TryDirection(queue, currCell, "L", -1, 0);
        }
        return null;
    }

    static string TracePathBack(Point currentCell)
    {
        var path = new StringBuilder();
        while(currentCell.PreviousPoint != null)
        {
            path.Append(currentCell.Direction);
            currentCell = currentCell.PreviousPoint;
        }
        var pathReversed = new StringBuilder(path.Length);
        for(int i = path.Length - 1; i >= 0; i--)
        {
            pathReversed.Append(path[i]);
        }
        return pathReversed.ToString();
    }

    static void TryDirection(Queue<Point> queue, Point currentCell, string direction, int deltaX, int deltaY)
    {
        int newX = currentCell.X + deltaX;
        int newY = currentCell.Y + deltaY;
        if(newX >= 0 && newX < width && newY >= 0 && newY < height && labyrinth[newY, newX] == '-')
        {
            labyrinth[newY, newX] = VisitedCell;
            var nextCell = new Point()
            {
                X = newX,
                Y = newY,
                Direction = direction,
                PreviousPoint = currentCell
            };
            queue.Enqueue(nextCell);
        }
    }

    static bool IsExit(Point currentCell)
    {
        bool isOnBorderX = currentCell.X == 0 || currentCell.X == width - 1;
        bool isOnBorderY = currentCell.Y == 0 || currentCell.Y == height - 1;
        return isOnBorderX || isOnBorderY;
    }

    static Point FindStartPosition()
    {
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                if(labyrinth[y, x] == VisitedCell)
                {
                    return new Point() { X = x, Y = y };
                }
            }
        }
        return null;
    }
    static void ReadLabyrinth()
    {
        width = int.Parse(Console.ReadLine());
        height = int.Parse(Console.ReadLine());
        labyrinth = new char[height, width];
        for(int row = 0; row < height; row++)
        {
            string currentRow = Console.ReadLine()!;
            for (int col = 0; col < width; col++)
            {
                labyrinth[row, col] = currentRow[col];

                if (currentRow[col] == 's')
                {
                    startPoint.X = col;
                    startPoint.Y = row;
                }
            }
        }
    }
}
