using System;
using System.Collections.Generic;
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
            var lines = input.Split(Environment.NewLine);
            var items = lines[1].Split(',').ToArray();

            long time = 0;
            long increment = long.Parse(items[0]);
            for (int i = 1; i < items.Length; i++)
            {
                // if we have an x, just skip to increment i which updates offset
                if (items[i] == "x")
                {
                    continue;
                }
                long nextBus = long.Parse(items[i]);
                // Add the offset (i) to the time to check where nextBus need to be.
                while ((time + i) % nextBus != 0)
                {
                    // Jump in list to next place where found buses align
                    time += increment;
                }
                // Next align will be a multiple of all earlier found buses
                increment *= nextBus;
            }
            return time.ToString();
        }
    }
}