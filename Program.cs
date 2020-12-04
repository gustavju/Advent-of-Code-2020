using System;
using System.Diagnostics;

namespace AoC2020
{
    class Program
    {
        static void Main(string[] args)
        {
            string day;
            if ((args?.Length) != 0)
            {
                day = args[0];
            }
            else
            {
                day = DateTime.Now.ToString("dd");
            }

            var input = System.IO.File.ReadAllText($"./Inputs/Day{day}.txt");

            BaseDay dayClass = Activator.CreateInstance(Type.GetType($"AoC2020.Days.Day{day}")) as BaseDay;

            Stopwatch sw = Stopwatch.StartNew();
            var partOneResult = dayClass.PartOne(input);
            sw.Stop();
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Result 1: {partOneResult}, Time taken: {sw.ElapsedMilliseconds}ms");
            Console.WriteLine("--------------------------------");

            sw = Stopwatch.StartNew();
            var partTwoResult = dayClass.PartTwo(input);
            sw.Stop();
            Console.WriteLine($"Result 2: {partTwoResult}, Time taken: {sw.ElapsedMilliseconds}ms");
            Console.WriteLine("--------------------------------");
        }
    }
}
