using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC2020.Days
{
    public class Day05 : BaseDay
    {
        public int toSeatId(string s)
        {
            return Convert.ToInt32(s.Replace('F', '0').Replace('B', '1').Replace('L', '0').Replace('R', '1'), 2);
        }

        public override string PartOne(string input)
        {
            return $"{input.Split(Environment.NewLine).Select(s => toSeatId(s)).Max()}";
        }

        public override string PartTwo(string input)
        {
            var ids = input.Split(Environment.NewLine).Select(s => toSeatId(s)).ToList().OrderBy(i => i);
            return $"{Enumerable.Range(ids.First(), ids.Count()).Except(ids).First()}";
        }

        /* Less golfy version below  */

        public SortedSet<int> GetSeatIds(string input)
        {
            SortedSet<int> seatIds = new SortedSet<int>();
            var seatStrings = input.Split(Environment.NewLine);
            foreach (var seatString in seatStrings)
            {
                var row = BinarySeats(seatString.Substring(0, 7), 127, 0, 'F', 'B');
                var seat = BinarySeats(seatString.Substring(7, 3), 7, 0, 'L', 'R');
                seatIds.Add(row * 8 + seat);
            }
            return seatIds;
        }

        public int BinarySeats(string str, int high, int low, char up, char down)
        {
            foreach (var c in str)
            {
                int mid = (low + high) / 2;
                if (c == up) high = mid;
                else if (c == down) low = mid + 1;
            }
            return low;
        }

        public string AltPartOne(string input)
        {
            var highestSeatId = GetSeatIds(input).Last();
            return $"{highestSeatId}";
        }

        public string AltPartTwo(string input)
        {
            var seatIds = GetSeatIds(input);
            var missingSeat = Enumerable.Range(seatIds.First(), seatIds.Count).Except(seatIds).First();
            return $"{missingSeat}";
        }
    }
}