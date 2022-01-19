using System;
using Samples;

var generator = new MapGenerator(new MazeGeneratorOptions()
{
    Height = 35,
    Width = 90
});
var maze = generator.Generate();

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