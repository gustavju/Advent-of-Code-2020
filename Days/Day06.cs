using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2020.Days
{
    public class Day06 : BaseDay
    {
        public override string PartOne(string input)
        {
            var groups = input.Replace("\n\n", ",").Replace("\n", " ").Split(",");

            var count = groups.Select(group => group)
                .Select(s => s.ToCharArray().Distinct().Where(c => !Char.IsWhiteSpace(c)))
                .Sum(g => g.Count());

            return $"{count}";
        }

        public override string PartTwo(string input)
        {
            var groups = input.Replace("\n\n", ",").Replace("\n", " ").Split(",");

            var count = groups.Select(group => group.Split(" ")
                .Select(person => person.ToCharArray())
                .Aggregate<IEnumerable<char>>(
                    (current, next) => current.Intersect(next)).ToList())
                .Sum(x => x.Count);

            return $"{count}";
        }
    }
}