using System;
using Samples;

var generator = new MazeGenerator();
var maze = generator.Generate(new MazeGeneratorOptions()
{
    Height = 15,
    Width = 35
});

PrintMaze(maze);

void PrintMaze(string[,] maze)
{
    for (int y = 0; y < maze.GetLength(1); y++)
    {
        for (int x = 0; x < maze.GetLength(0); x++)
        {
            Console.Write(maze[x,y]);
        }
        Console.WriteLine();
    }
}