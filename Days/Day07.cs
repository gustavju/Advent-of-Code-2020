using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2020.Days
{
    public class Day07 : BaseDay
    {
        Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
        public override string PartOne(string input)
        {
            dict = input.Replace("bags", "").Replace("bag", "").Replace(".", "").Split(Environment.NewLine)
            .Select(row => row.Split("contain")).ToDictionary(
                t => t.First().Trim(),
                t => t.Last().Split(",").Select(value => value.Trim()).ToList());

            var found = new HashSet<string>();
            var stack = new Stack<string>();
            stack.Push("shiny gold");
            while (stack.Count != 0)
            {
                var item = stack.Pop();
                if (!found.Contains(item))
                {
                    found.Add(item);
                    dict.Select(e => e).Where(e => e.Value.Any(v => v.Contains(item))).Select(o => o.Key).ToList().ForEach(f => stack.Push(f));
                }
            }

            return $"{found.Count - 1}";
        }

        public int getInnerBags(string name)
        {
            int total = 0;
            foreach (var inner in dict[name])
            {
                if (inner == "no other")
                {
                    return 1;
                }
                int amount = int.Parse(inner.Substring(0, 1));
                string next = inner.Substring(1).Trim();
                total += amount * getInnerBags(next);
            }
            return 1 + total;
        }

        public override string PartTwo(string input)
        {
            dict = dict = input.Replace("bags", "").Replace("bag", "").Replace(".", "").Split(Environment.NewLine)
            .Select(row => row.Split("contain")).ToDictionary(
                t => t.First().Trim(),
                t => t.Last().Split(",").Select(value => value.Trim()).ToList());

            return $"{getInnerBags("shiny gold") - 1}";
        }
    }
}