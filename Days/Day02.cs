using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2020.Days
{
    public class Day02 : BaseDay
    {
        public struct Policy
        {
            public char c { get; set; }
            public int start { get; set; }
            public int end { get; set; }
        }

        public Policy parsePolicy(string policyStr)
        {
            var parts = policyStr.Split(' ');
            var range = parts[0].Split('-').Select(int.Parse);
            var strChar = parts[1];

            return new Policy
            {
                c = strChar[0],
                start = range.ElementAt(0),
                end = range.ElementAt(1)
            };
        }

        public override string PartOne(string input)
        {
            int count = 0;
            var rows = input.Split(Environment.NewLine);

            foreach (var row in rows)
            {
                var parts = row.Split(':');
                var policy = parsePolicy(parts[0]);
                string password = parts[1];

                int freq = password.Count(pw => (pw == policy.c));

                if (freq >= policy.start && freq <= policy.end)
                {
                    count++;
                }
            }
            return $"{count}";
        }

        public override string PartTwo(string input)
        {
            int count = 0;
            var rows = input.Split(Environment.NewLine);

            foreach (var row in rows)
            {
                var parts = row.Split(':');
                var policy = parsePolicy(parts[0]);
                string password = parts[1].Trim();

                if (password[policy.start - 1] == policy.c ^ password[policy.end - 1] == policy.c)
                {
                    count++;
                }
            }
            return $"{count}";
        }
    }
}