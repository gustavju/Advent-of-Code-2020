using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2020.Days
{
    public class Day11 : BaseDay
    {
        private (int cx, int cy)[] directions = { (-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 1), (1, -1), (1, 0), (1, 1) };
        public override string PartOne(string input)
        {
            var grid = input.Split(Environment.NewLine).Select(e => e.ToArray()).ToArray();
            bool instable = true;
            while (instable)
            {
                var copy = grid.Select(a => a.ToArray()).ToArray();
                instable = false;
                for (int i = 0; i < copy.Length; i++)
                {
                    for (int j = 0; j < copy[i].Length; j++)
                    {
                        if (copy[i][j] == '.')
                        {
                            continue;
                        }
                        int occupiedSeats = 0;
                        foreach (var (cx, cy) in directions)
                        {
                            int x = j + cx;
                            int y = i + cy;
                            if (y < 0 || x < 0 || y >= copy.Length || x >= copy[i].Length)
                            {
                                continue;
                            }
                            if (copy[y][x] == '#')
                            {
                                occupiedSeats++;
                            }
                        }
                        if (copy[i][j] == 'L' && occupiedSeats == 0)
                        {
                            grid[i][j] = '#';
                            instable = true;
                        }
                        else if (copy[i][j] == '#' && occupiedSeats >= 4)
                        {
                            grid[i][j] = 'L';
                            instable = true;
                        }
                    }
                }
            }
            return grid.Select(e => e.Count(t => t == '#')).Sum().ToString();
        }

        public override string PartTwo(string input)
        {
            var grid = input.Split(Environment.NewLine).Select(e => e.ToArray()).ToArray();
            bool instable = true;
            while (instable)
            {
                var copy = grid.Select(a => a.ToArray()).ToArray();
                instable = false;
                for (int i = 0; i < copy.Length; i++)
                {
                    for (int j = 0; j < copy[i].Length; j++)
                    {
                        if (copy[i][j] == '.')
                            continue;

                        int occupiedSeats = 0;
                        foreach (var (cx, cy) in directions)
                        {
                            for (int k = 1; ; k++)
                            {
                                int y = i + (cy * k);
                                int x = j + (cx * k);
                                if (y < 0 || x < 0 || y >= copy.Length || x >= copy[i].Length || copy[y][x] == 'L')
                                {
                                    break;
                                }
                                if (copy[y][x] == '#')
                                {
                                    occupiedSeats++;
                                    break;
                                }
                            }
                        }
                        if (copy[i][j] == 'L' && occupiedSeats == 0)
                        {
                            grid[i][j] = '#';
                            instable = true;
                        }
                        else if (copy[i][j] == '#' && occupiedSeats >= 5)
                        {
                            grid[i][j] = 'L';
                            instable = true;
                        }
                    }
                }
            }
            return grid.Select(e => e.Count(t => t == '#')).Sum().ToString();
        }
    }
}