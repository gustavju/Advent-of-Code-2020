using System;
using System.Linq;

namespace AoC2020.Days
{
    public class Day01 : BaseDay
    {
        private int[] inputAsArr(string input)
        {
            var ints = input.Split(Environment.NewLine).Select(int.Parse).ToArray();
            return ints;
        }

        public override string PartOne(string input)
        {
            var ints = inputAsArr(input);
            for (int i = 0; i < ints.Length; i++)
            {
                int outer = ints[i];
                for (int j = 0; j < ints.Length; j++)
                {
                    int inner = ints[j];
                    if (outer + inner == 2020)
                    {
                        return $"{outer * inner}";
                    }
                }
            }
            return "No result";
        }
        public override string PartTwo(string input)
        {
            var ints = inputAsArr(input);
            for (int i = 0; i < ints.Length; i++)
            {
                int outer = ints[i];
                for (int j = 0; j < ints.Length; j++)
                {
                    int inner = ints[j];
                    int sum = outer + inner;
                    int needed = 2020 - sum;
                    if (ints.Where(i => i.Equals(needed)).FirstOrDefault() != 0)
                    {
                        return $"{outer * inner * needed}";
                    }
                }
            }
            return "No result";
        }
    }
}