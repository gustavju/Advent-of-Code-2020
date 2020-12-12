using System;
using System.Collections.Generic;

namespace AoC2020.Days
{
    public class Day12 : BaseDay
    {
        enum Actions
        {
            N, E, S, W, L, R, F
        };

        public override string PartOne(string input)
        {
            var instructions = input.Split(Environment.NewLine);
            // Dirs = 0:N, 1:E, 2:S, 3:W
            int direction = 1;
            //                           N,      E,      S,        W;           
            (int dx, int dy)[] dxdy = { (0, 1), (1, 0), (0, -1), (-1, 0) };

            (int x, int y) ship = (0, 0);

            foreach (var instruction in instructions)
            {
                var action = (Actions)Enum.Parse(typeof(Actions), instruction.Substring(0, 1));
                int n = int.Parse(instruction.Substring(1));

                switch (action)
                {
                    case Actions.N:
                        ship.y += n;
                        break;
                    case Actions.S:
                        ship.y -= n;
                        break;
                    case Actions.E:
                        ship.x += n;
                        break;
                    case Actions.W:
                        ship.x -= n;
                        break;
                    case Actions.F:
                        ship.x += dxdy[direction].dx * n;
                        ship.y += dxdy[direction].dy * n;
                        break;
                    case Actions.L:
                        direction = (direction + 3 * (n / 90)) % 4;
                        break;
                    case Actions.R:
                        direction = (direction + 1 * (n / 90)) % 4;
                        break;
                }
            }

            return $"{Math.Abs(ship.x) + Math.Abs(ship.y)}";
        }

        public override string PartTwo(string input)
        {
            var instructions = input.Split(Environment.NewLine);
            (int x, int y) ship = (0, 0);
            (int x, int y) waypoint = (10, 1);

            foreach (var instruction in instructions)
            {
                var action = (Actions)Enum.Parse(typeof(Actions), instruction.Substring(0, 1));
                int n = int.Parse(instruction.Substring(1));

                switch (action)
                {
                    case Actions.N:
                        waypoint.y += n;
                        break;
                    case Actions.S:
                        waypoint.y -= n;
                        break;
                    case Actions.E:
                        waypoint.x += n;
                        break;
                    case Actions.W:
                        waypoint.x -= n;
                        break;
                    case Actions.L:
                        for (int _ = 0; _ < n / 90; _++)
                            waypoint = (-waypoint.y, waypoint.x);
                        break;
                    case Actions.R:
                        for (int _ = 0; _ < n / 90; _++)
                            waypoint = (waypoint.y, -waypoint.x);
                        break;
                    case Actions.F:
                        ship.x += waypoint.x * n;
                        ship.y += waypoint.y * n;
                        break;
                }
            }

            return $"{Math.Abs(ship.x) + Math.Abs(ship.y)}";
        }
    }
}