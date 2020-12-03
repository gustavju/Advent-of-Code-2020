using System;
using System.Collections.Generic;

namespace AoC2020.Days
{
    public class Day03 : BaseDay
    {
        public string[] parseInput(string input)
        {
            return input.Split(Environment.NewLine);
        }

        public int getTreesForAngle(string[] map, int xv, int yv)
        {
            int rowLength = map[0].Length;
            int trees = 0;
            int posX = 0;
            int posY = 0;

            while (posY < map.Length - 1)
            {
                posX += xv;
                posX = posX % rowLength;
                posY += yv;

                if (map[posY][posX] == '#')
                {
                    trees++;
                }
            }

            return trees;
        }

        public override string PartOne(string input)
        {
            var map = parseInput(input);
            return $"{getTreesForAngle(map, 3, 1)}";
        }

        public override string PartTwo(string input)
        {
            Int64 res = 0;
            var map = parseInput(input);
            var list = new List<int>() {
                1, 1,
                3, 1,
                5, 1,
                7, 1,
                1, 2
            };
            for (int i = 0; i < list.Count; i += 2)
            {
                var trees = getTreesForAngle(map, list[i], list[i + 1]);
                if (res == 0)
                    res += trees;
                else
                    res *= trees;
            }
            return $"{res}";
        }
    }
}