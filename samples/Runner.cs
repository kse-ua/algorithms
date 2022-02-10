using System;
using Kse.Algorithms.Samples;

var heap = new Heap();
heap.Add(5);
heap.Add(3);
heap.Add(7);
heap.Add(10);
heap.Add(15);
heap.Add(2);
heap.Add(8);
heap.Add(11);

Console.WriteLine(heap.PopMax());
Console.WriteLine(heap.PopMax());
Console.WriteLine(heap.PopMax());
Console.WriteLine(heap.PopMax());
Console.WriteLine(heap.PopMax());
Console.WriteLine(heap.PopMax());
Console.WriteLine(heap.PopMax());
Console.WriteLine(heap.PopMax());

var elements = new []{4, 1, 22, 7, 8, 15, 345, 19, 0, 3, 2, 14, 53};
Sortings.HeapSort(elements);


Console.WriteLine();