namespace Kse.Algorithms.Samples
{
    public class MapGeneratorOptions
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public MapType Type { get; set; } = MapType.Maze; 

        public float Noise { get; set; }

        public int Seed { get; set; } = -1;
    }
    
    
    public enum MapType
    {
        Maze,
        Grid
    }
}