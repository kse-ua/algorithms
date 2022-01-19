namespace Samples
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MazeGenerator
    {
        public string[,] Generate(MazeGeneratorOptions options)
        {
            var maze = new string[options.Width, options.Height];
            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {

                    maze[x, y] = (y % 2 == 1 || x % 2 == 1) ? "#" : " ";
                }
            }

            return maze;

            void ExpandFrom(int x, int y, HashSet<(int x, int y)> visited)
            {
                var neighbours = GetNeighbours(x, y, maze).Where(point => !visited.Contains(point));
            }
        }

        private List<(int x, int y)> GetNeighbours(int x, int y, string[,] maze)
        {
            var result = new List<(int x, int y)>();
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
                    result.Add((newX, newY));
                }
            }
        }
    }

    public class MazeGeneratorOptions
    {
        public int Width { get; set; }
        
        public int Height { get; set; }
    }

    public class Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        protected bool Equals(Point other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Point)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}