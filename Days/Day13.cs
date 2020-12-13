using System;
using System.Linq;

namespace AoC2020.Days
{
    public class Day13 : BaseDay
    {
        public override string PartOne(string input)
        {
            var lines = input.Split(Environment.NewLine);
            int departureTime = int.Parse(lines[0]);
            var buses = lines[1].Split(',').Where(s => s != "x").Select(int.Parse);

            (int bus, int waitTime) best = (0, int.MaxValue);
            foreach (var bus in buses)
            {
                int time = departureTime;
                while (time % bus != 0)
                {
                    time++;
                }
                int wait = time - departureTime;
                if (best.waitTime > wait)
                    best = (bus, wait);
            }

            return $"{best.waitTime * best.bus}";
        }

        public override string PartTwo(string input)
        {
            return $"Too much number theory for a sunday morning! 🥺";
        }
    }
}