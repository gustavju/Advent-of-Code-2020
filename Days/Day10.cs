using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2020.Days
{
    public class Day10 : BaseDay
    {
        public override string PartOne(string input)
        {
            var xs = input.Split(Environment.NewLine).Select(x => int.Parse(x));
            var a = xs.Append(0).Append(xs.Max() + 3).OrderBy(x => x).ToArray();
            int ones = 0;
            int three = 0;

            for (int i = 0; i < a.Length - 1; i++)
            {
                var diff = a[i + 1] - a[i];
                if (diff == 1) ones++;
                else if (diff == 3) three++;
            }

            return $"1's: {ones}, 3's: {three}, res = {ones * three}";
        }


        int[] numbers;
        Dictionary<int, long> memo = new Dictionary<int, long>();
        public long GetNext(int i)
        {
            if (i == numbers.Length - 1)
                return 1;
            if (memo.ContainsKey(i))
                return memo[i];

            long result = 0;
            for (int j = i + 1; j < numbers.Length; j++)
            {
                if (numbers[j] - numbers[i] <= 3)
                    result += GetNext(j);
            }
            memo.Add(i, result);
            return result;
        }

        public override string PartTwo(string input)
        {
            var xs = input.Split(Environment.NewLine).Select(x => int.Parse(x));
            numbers = xs.Append(0).Append(xs.Max() + 3).OrderBy(x => x).ToArray();
            return GetNext(0).ToString();
        }
    }
}