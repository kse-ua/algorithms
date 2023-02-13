namespace Kse.Algorithms.Samples
{
    public class MapGeneratorOptions
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public MapType Type { get; set; } = MapType.Maze; 

        public float Noise { get; set; }

        public int Seed { get; set; } = -1;
        
        public bool AddTraffic { get; set; }
        
        public int TrafficSeed { get; set; }
    }
    
    
    public enum MapType
    {
        Maze,
        Grid
    }
}