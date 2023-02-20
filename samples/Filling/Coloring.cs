using System;
using System.Collections.Generic;
using Kse.Algorithms.Samples;

var graph = new string[,]
{
     { " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", " ", " ", " " },
     { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" },
     { " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", " ", " ", " " },
     { " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", " ", " ", " " },
     { " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", " ", " ", " " },
     { " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", " ", " ", " " },
     { " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", " ", " ", " " },
     { " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", " ", " ", " " },
     { " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", " ", " ", " " },
     { " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", " ", " ", " " },
     { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" },
     { " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", " ", " ", " " },
};

Print(graph);
PaintBFS(new Point(6, 5));

void PaintBFS(Point point)
{
     var visited = new List<Point>();
     var queue = new Queue<Point>();
     Visit(point);
     queue.Enqueue(point);
     while (queue.Count > 0)
     {
         var next = queue.Dequeue();
         Print(graph);
         var neighbours = GetNeighbours(next.Row, next.Column, graph);
         foreach (var neighbour in neighbours)
         {
             if (!visited.Contains(neighbour))
             {
                 Visit(neighbour);
                 queue.Enqueue(neighbour);
             }
         }
     }

     void Visit(Point point)
     {
         graph[point.Row, point.Column] = "1";
         visited.Add(point);
     }
}


void PaintDFS(Point point)
{
     var visited = new List<Point>();
     var stack = new Stack<Point>();
     stack.Push(point);
     while (stack.Count > 0)
     {
         var next = stack.Pop();
         if (visited.Contains(next))
         {
             continue;
         }

         Visit(next);
         Print(graph);
         var neighbours = GetNeighbours(next.Row, next.Column, graph);
         foreach (var neighbour in neighbours)
         {
             stack.Push(neighbour);
         }
     }

     void Visit(Point point)
     {
         graph[point.Row, point.Column] = "1";
         visited.Add(point);
     }
}

List<Point> GetNeighbours(int row, int column, string[,] maze)
{
     var result = new List<Point>();
     TryAddWithOffset(1, 0);
     TryAddWithOffset(-1, 0);
     TryAddWithOffset(0, 1);
     TryAddWithOffset(0, -1);
     return result;

     void TryAddWithOffset(int offsetRow, int offsetColumn)
     {
         var newX = row + offsetRow;
         var newY = column + offsetColumn;
         if (newX >= 0 && newY >= 0 && newX < maze.GetLength(0) && newY < maze.GetLength(1) && maze[newX, newY] != "#")
         {
             result.Add(new Point(newY, newX));
         }
     }
}

void Print(string[,] array)
{
     for (var row = 0; row < array.GetLength(0); row++)
     {
         for (var column = 0; column < array.GetLength(1); column++)
         {
             Console.Write(array[row, column]);
         }

         Console.WriteLine();
     }
     Console.WriteLine();
}