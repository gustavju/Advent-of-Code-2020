using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AoC2020.Days
{
    public class Day04 : BaseDay
    {
        IList PasswordFields = new List<string>() { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };
        // "cid" <- ignored
        IList eyeColors = new List<string>() { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };


        private List<Dictionary<string, string>> GetPassportDicts(string input)
        {
            var passports = new List<Dictionary<string, string>>();
            // Goofy whitespace today :(
            var ppStrings = input.Replace("\n\n", ",").Replace("\n", " ").Split(",");

            foreach (var ppString in ppStrings)
            {
                var ppEntryStrings = ppString.Split(" ");
                var passport = new Dictionary<string, string>();

                foreach (var ppEntryString in ppEntryStrings)
                {
                    var entry = ppEntryString.Split(":");
                    passport.Add(entry[0], entry[1]);
                }

                passports.Add(passport);
            }
            return passports;
        }
        public override string PartOne(string input)
        {
            var passports = GetPassportDicts(input);
            // all valid passports have 8 entries or 7 without cid
            int count = passports.Where(p => p.Keys.Count > 7 || p.Keys.Count == 7 && !p.ContainsKey("cid")).Count();

            return $"{count}";
        }

        /*
        byr (Birth Year) - four digits; at least 1920 and at most 2002.
        iyr (Issue Year) - four digits; at least 2010 and at most 2020.
        eyr (Expiration Year) - four digits; at least 2020 and at most 2030.
        hgt (Height) - a number followed by either cm or in:
        If cm, the number must be at least 150 and at most 193.
        If in, the number must be at least 59 and at most 76.
        hcl (Hair Color) - a # followed by exactly six characters 0-9 or a-f.
        ecl (Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
        pid (Passport ID) - a nine-digit number, including leading zeroes.
        cid (Country ID) - ignored, missing or not.
        */
        public override string PartTwo(string input)
        {
            var passports = GetPassportDicts(input);
            var passportsWithKeys = passports.Where(p => p.Keys.Count > 7 || p.Keys.Count == 7 && !p.ContainsKey("cid"));

            int count = 0;

            foreach (var p in passportsWithKeys)
            {
                int byr = ParseOrZero(p["byr"]);
                int iyr = ParseOrZero(p["iyr"]);
                int eyr = ParseOrZero(p["eyr"]);

                if (byr < 1920 || byr > 2002) continue;
                if (iyr < 2010 || iyr > 2020) continue;
                if (eyr < 2020 || eyr > 2030) continue;
                if (!ValidHgt(p["hgt"])) continue;
                if (!ValidHcl(p["hcl"])) continue;
                if (!ValidEcl(p["ecl"])) continue;
                if (!ValidPid(p["pid"])) continue;

                count++;
            }

            return $"{count}";
        }

        public bool ValidPid(string s)
        {
            return s.Length == 9 && s.All(c => Char.IsDigit(c));
        }

        public bool ValidEcl(string s)
        {
            return eyeColors.Contains(s);
        }

        public bool ValidHcl(string s)
        {
            return (s.Length == 7 || s[0] == '#') &&
                    s.Substring(1, s.Length - 1)
                        .All(c => (Char.IsDigit(c) || IsLetterBetweenAF(c)));
        }

        public static bool IsLetterBetweenAF(char c)
        {
            return (c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F');
        }

        public bool ValidHgt(string s)
        {
            string t = s.Substring(0, s.Length - 2);
            int i = ParseOrZero(t);
            return ((s.EndsWith("cm") && i >= 150 && i <= 193) ||
                (s.EndsWith("in") && i >= 59 && i <= 76));
        }

        public int ParseOrZero(string s)
        {
            try
            {
                return int.Parse(s);
            }
            catch
            {
                return 0;
            }
        }
    }
}