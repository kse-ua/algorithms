namespace Kse.Algorithms.Samples
{
    using System;
    using System.Collections.Generic;

    public class MapGenerator
    {
        private const string Wall = "█";
        
        private const string Space = " ";

        private readonly MapGeneratorOptions options;

        private readonly Random random;

        private string[,] maze;

        public MapGenerator(MapGeneratorOptions options)
        {
            this.options = options;
            random = new Random((int)(options.Seed == -1? DateTime.UtcNow.Ticks : options.Seed));
        }

        public string[,] Generate()
        {
            maze = new string[options.Width, options.Height];
            if (options.Type == MapType.Maze)
            {
                return GenerateMaze();
            }
            else
            {
                return null;
            }
        }

        private string[,] GenerateMaze()
        {
            for (var x = 0; x < maze.GetLength(0); x++)
            {
                for (var y = 0; y < maze.GetLength(1); y++)
                {
                    maze[x, y] = (y % 2 == 1 || x % 2 == 1) ? Wall : Space;
                }
            }

            ExpandFrom(new Point(0, 0), new List<Point>());
            RemoveWalls(maze, options.Noise);
            return maze;

            void ExpandFrom(Point point, List<Point> visited)
            {
                visited.Add(point);
                var neighbours = GetNeighbours(point.Column, point.Row, maze).ToArray();
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
                maze[(a.Column + b.Column) / 2, (a.Row + b.Row) / 2] = " ";
            }

            void Shuffle(Random rng, Point[] array)
            {
                var n = array.Length;
                while (n > 1)
                {
                    var k = rng.Next(n--);
                    (array[n], array[k]) = (array[k], array[n]);
                }
            }
        }

        void RemoveWalls(string[,] maze, float chance)
        {
            for (var y = 0; y < maze.GetLength(1); y++)
            {
                for (var x = 0; x < maze.GetLength(0); x++)
                {
                    if (random.NextDouble() < chance && maze[x, y] == Wall)
                    {
                        maze[x, y] = " ";
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

}