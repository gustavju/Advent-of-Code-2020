using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC2020.Days
{
    public class Day14 : BaseDay
    {
        private string applyBitMask(string mask, string bits, char ignored)
        {
            var bitArr = bits.PadLeft(mask.Length, '0').ToCharArray();
            for (int i = 0; i < mask.Length; i++)
            {
                if (mask[i] != ignored)
                    bitArr[i] = mask[i];
            }
            return new string(bitArr);
        }
        public override string PartOne(string input)
        {
            (string op, string value)[] codes = input.Split(Environment.NewLine).Select(code =>
            {
                string[] s = code.Split('=').Select(s => s.Trim()).ToArray();
                return (s[0], s[1]);
            }).ToArray();

            var memory = new Dictionary<string, long>();
            string mask = "";

            foreach (var code in codes)
            {
                if (code.op == "mask")
                {
                    mask = code.value;
                }
                else
                {
                    var memoryLocationStr = code.op.Replace("mem[", "").Replace("]", "");
                    string binaryValue = Convert.ToString(long.Parse(code.value), 2);
                    long maskedValue = Convert.ToInt64(applyBitMask(mask, binaryValue, 'X'), 2);
                    memory[memoryLocationStr] = maskedValue;
                }
            }
            return $"{memory.Values.Sum()}";
        }

        public override string PartTwo(string input)
        {
            (string op, string value)[] codes = input.Split(Environment.NewLine).Select(code =>
            {
                var s = code.Split(' ');
                return (s.First(), s.Last());
            }).ToArray();

            var memory = new Dictionary<string, long>();
            string mask = "";

            foreach (var code in codes)
            {
                if (code.op == "mask")
                {
                    mask = code.value;
                }
                else
                {
                    var memoryLocationStr = code.op.Replace("mem[", "").Replace("]", "");
                    var memLocation = long.Parse(memoryLocationStr);
                    var memBinary = Convert.ToString(memLocation, 2);
                    var maskedMem = applyBitMask(mask, memBinary, '0');

                    var queue = new Queue<string>();
                    queue.Enqueue(maskedMem);
                    var regex = new Regex(Regex.Escape("X"));
                    while (queue.Count() > 0)
                    {
                        var current = queue.Dequeue();
                        for (int i = 0; i < 2; i++)
                        {
                            var memMod = regex.Replace(current, i.ToString(), 1);
                            if (memMod.Contains('X'))
                                queue.Enqueue(memMod);
                            else
                                memory[memMod] = long.Parse(code.value);
                        }
                    }
                }
            }
            return $"{memory.Values.Sum()}";
        }
    }
}