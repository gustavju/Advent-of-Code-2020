using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2020.Days
{
    public class Day15 : BaseDay
    {

        public int spokenAtRound(string input, int round)
        {
            var startingNumbers = input.Split(",").Select(int.Parse).ToList();
            var spokenIndex = new Dictionary<int, int>();

            for (int i = 0; i < startingNumbers.Count - 1; i++)
            {
                spokenIndex[startingNumbers[i]] = i;
            }

            int lastSpoken = startingNumbers.Last();
            for (int i = startingNumbers.Count; i < round; i++)
            {
                var lastSpokenIndex = spokenIndex.ContainsKey(lastSpoken) ? spokenIndex[lastSpoken] : -1;
                spokenIndex[lastSpoken] = i - 1;
                var next = 0;
                if (lastSpokenIndex != -1)
                {
                    next = i - 1 - lastSpokenIndex;
                }
                lastSpoken = next;
            }
            return lastSpoken;
        }
        public override string PartOne(string input)
        {
            int result = spokenAtRound(input, 2020);
            return result.ToString();
        }

        public override string PartTwo(string input)
        {
            int result = spokenAtRound(input, 30000000);
            return result.ToString();
        }
    }
}