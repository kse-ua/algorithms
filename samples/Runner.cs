using Kse.Algorithms.Samples;

var generator = new MapGenerator(new MapGeneratorOptions()
{
    Height = 35,
    Width = 90,
    Noise = .3f
});

string[,] map = generator.Generate();
new MapPrinter().Print(map);
