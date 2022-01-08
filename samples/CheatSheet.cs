using System;

// This is a little C# cheat sheet to start your journey with

// C# is s strongly typed language, this means every variable has predefined type and it can not be changed in runtime
// To introduce a variable, you need to write its type followed by variable name and value and end the line with ;

// In C# you will mainly work with next basic types:
// integers (4 bytes with negative values)
int i = 5;

// doubles  (8 bytes, ~15-17 digits of precision)
double d = 0.34123;

// floats (4 bytes, ~6-9 digits of precision). You need to add f to literal to mark it as a float,
// otherwise it would be considered as double
float f = 0.345f;

// strings, they are always double-quoted
string s = "Hello, C#";

// characters
char c = 'A';

// booleans
bool b = true;

// you can write var instead of type in case it is obvious to compiler to determine it
var some = false; //ok, it's a bool
var another = 13; //and this is integer
var variable = 0.143; // and this is double
var k; // this is an error - compiler can not determine type of the k, so var is not allowed

// C# does not have power operator **
var square = Math.Pow(3, 2); // 3**2

// To read a string from input:
var input = Console.ReadLine();

// To write to output:
Console.WriteLine(input);

// C# has single typed arrays with predefined size
var array = new int[5]; // empty array of ints, for 5 elements

// to initialize arrays with values:
var floatsArray = new float[]{0.1f, 0.2f};

//when type is obvious, you also can skip it
var doublesArray = new[] { 0.5, 0.6 };

// if-else pair:
if (i >= 10)
{
    // ...
}
else
{
    // ...
}

// to perform a loop using 'for' statement:
for (var j = 0; j < 10; j++)
{
    Console.WriteLine(j);
}

//every array has .Length property you can use to iterate over it
var numbers = new[] { 1, 2, 3, 4, 5 };
for (var j = 0; j < numbers.Length; j++)
{
    Console.WriteLine(array[j]);
}

// or you can iterate using foreach statement
foreach (var value in numbers)
{
    Console.WriteLine(value);
}

// list

//iterate

// to define a function, you need to specify it's returning type and types of every argument
int Double(int value)
{
    return value * 2;
}

// if function returns nothing, use void keyword
void Scream(string text)
{
    Console.WriteLine(text.ToUpper());
}

// just like in Python, you can return a tuple from a function. But please, don't overuse it
(int x, int y) GetCoordinates()
{
    return (1, 3);
}

var point = GetCoordinates();
Console.WriteLine(point.x);
Console.WriteLine(point.y);

// or simply
var (x, y) = GetCoordinates();
