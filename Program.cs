using System;

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

            var partOneResult = dayClass.PartOne(input);
            var partTwoResult = dayClass.PartTwo(input);


            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Result 1: {partOneResult}");
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Result 2: {partTwoResult}");
            Console.WriteLine("--------------------------------");
        }
    }
}
