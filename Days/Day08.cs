using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AoC2020.Days
{
    public class Day08 : BaseDay
    {
        enum OPCodes { acc, jmp, nop };
        class Instruction
        {
            public OPCodes Code { get; set; }
            public int Parameter { get; set; }
            public Instruction(string instructionStr)
            {
                var parts = instructionStr.Split(" ");
                Code = (OPCodes)Enum.Parse(typeof(OPCodes), parts[0]);
                Parameter = int.Parse(parts[1], new NumberFormatInfo() { NegativeSign = "-" });
            }
        }
        int acc = 0;
        bool runGameConsole(Instruction[] instructions)
        {
            acc = 0;
            var ranCodes = new HashSet<int>();
            var ops = instructions;
            for (int i = 0; i < ops.Count();)
            {
                if (ranCodes.Contains(i))
                {
                    return false;
                }
                ranCodes.Add(i);
                Instruction current = instructions[i];
                switch (current.Code)
                {
                    case OPCodes.acc:
                        acc += current.Parameter;
                        i++;
                        break;
                    case OPCodes.jmp:
                        i += current.Parameter;
                        break;
                    case OPCodes.nop:
                        i++;
                        break;
                }
            }
            return true;
        }

        public override string PartOne(string input)
        {
            var instructions = input.Split(Environment.NewLine).Select(line => new Instruction(line)).ToArray();
            bool terminated = runGameConsole(instructions);
            return acc.ToString();
        }

        public override string PartTwo(string input)
        {
            var instructions = input.Split(Environment.NewLine).Select(line => new Instruction(line)).ToArray();
            for (int i = 0; i < instructions.Length; i++)
            {
                if (instructions[i].Code == OPCodes.jmp)
                {
                    instructions[i].Code = OPCodes.nop;
                    bool terminated = runGameConsole(instructions);
                    if (terminated)
                    {
                        break;
                    }
                    instructions[i].Code = OPCodes.jmp;
                }
            }
            return acc.ToString();
        }
    }
}