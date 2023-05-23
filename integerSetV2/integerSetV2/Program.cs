// See https://aka.ms/new-console-template for more information
using integerSetV2;

Console.WriteLine("Hello, World!");

var test = new int[] { 10, 1, 16, 1, 2, 30, 30, 1, 16, 8 };
var arr = new IntergerSet(test);

var test2 = new int[] { 3, 9, 12, 150, 2, 30, 30, 1, 16, 8 };
var arr2 = new IntergerSet(test2);

var arr3 = arr.union(arr2);
Console.WriteLine(arr3.ToString());
Console.WriteLine($"Does Set Contains 3: {arr3.contains(3)}");
Console.WriteLine($"Does Set Contains 7: {arr3.contains(7)}");



Console.ReadKey();