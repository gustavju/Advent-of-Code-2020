using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2020.Days
{
    public class Day09 : BaseDay
    {
        long numberToCheck = 0;
        private bool isValid(IEnumerable<long> slice, long numberToCheck)
        {
            foreach (var outer in slice)
            {
                foreach (var inner in slice)
                {
                    if (outer != inner && outer + inner == numberToCheck)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public override string PartOne(string input)
        {
            var ints = input.Split(Environment.NewLine).Select(e => Int64.Parse(e)).ToList();
            for (int i = 0; i < ints.Count(); i++)
            {
                numberToCheck = ints[25 + i];
                var slice = ints.Skip(i).Take(25);
                if (!isValid(slice, numberToCheck))
                {
                    break;
                }
            }
            return numberToCheck.ToString();
        }

        public override string PartTwo(string input)
        {
            var xs = input.Split(Environment.NewLine).Select(e => Int64.Parse(e)).ToList();
            long res = 0;

            for (int i = 0; i < xs.Count() && res == 0; i++)
            {
                for (int j = 2; j < xs.Count() - i && res == 0; j++)
                {
                    var slice = xs.Skip(i).Take(j);

                    if (slice.Any(e => e > numberToCheck))
                    {
                        break;
                    }

                    if (slice.Sum() == numberToCheck)
                    {
                        res = slice.Min() + slice.Max();
                    }
                }
            }
            return res.ToString();
        }
    }
}