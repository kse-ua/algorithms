using System.Collections.Generic;
using Kse.Algorithms.Samples;

var generator = new MapGenerator(new MapGeneratorOptions()
{
    Height = 35,
    Width = 90,
    Noise = .1f,
    AddTraffic = true,
    TrafficSeed = 1234
});

string[,] map = generator.Generate();
new MapPrinter().Print(map);
