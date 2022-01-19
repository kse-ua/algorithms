namespace Samples
{
    using System;
    using System.Collections.Generic;

    public class MapGenerator
    {
        private const string Wall = "█";

        private readonly MazeGeneratorOptions options;

        public MapGenerator(MazeGeneratorOptions options)
        {
            this.options = options;
        }

        public string[,] Generate()
        {
            var maze = new string[options.Width, options.Height];
            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    maze[x, y] = (y % 2 == 1 || x % 2 == 1) ? Wall : " ";
                }
            }

            var random = new Random();
            ExpandFrom(new Point(0,0), new HashSet<Point>());
            RemoveWalls(0f);
            return maze;

            void ExpandFrom(Point point, HashSet<Point> visited)
            {
                visited.Add(point);
                var neighbours = GetNeighbours(point.X, point.Y, maze).ToArray();
                Shuffle(random, neighbours);
                foreach (var neighbour in neighbours)
                {
                    if (visited.Contains(neighbour))
                    {
                        continue;
                    }
                    RemoveWallBetween(point, neighbour);
                    Console.WriteLine();
                    ExpandFrom(neighbour, visited);
                }
            }

            void RemoveWallBetween(Point a, Point b)
            {
                maze[(a.X + b.X) / 2, (a.Y + b.Y) / 2] = " ";
            }
            
            void Shuffle (Random rng, Point[] array)
            {
                var n = array.Length;
                while (n > 1) 
                {
                    int k = rng.Next(n--);
                    (array[n], array[k]) = (array[k], array[n]);
                }
            }
            
            void RemoveWalls(float chance)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    for (int x = 0; x < maze.GetLength(0); x++)
                    {
                        if (random.NextDouble() < chance && maze[x, y] == Wall)
                        {
                            maze[x, y] = " ";
                        }
                    }
                }
            }
        }


        private List<Point> GetNeighbours(int x, int y, string[,] maze)
        {
            var result = new List<Point>();
            TryAddWithOffset(2, 0);
            TryAddWithOffset(-2, 0);
            TryAddWithOffset(0, 2);
            TryAddWithOffset(0, -2);
            return result;

            void TryAddWithOffset(int offsetX, int offsetY)
            {
                var newX = x + offsetX;
                var newY = y + offsetY;
                if (newX >= 0 && newY >= 0 && newX < maze.GetLength(0) && newY < maze.GetLength(1))
                {
                    result.Add(new Point(newX, newY));
                }
            }
        }
    }

    public class MazeGeneratorOptions
    {
        public int Width { get; set; }
        
        public int Height { get; set; }
    }
}