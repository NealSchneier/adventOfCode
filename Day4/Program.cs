using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = System.IO.File.ReadAllText("Day4/input.txt");
            var passports = text.Split(Environment.NewLine + Environment.NewLine);
            Part1(passports);
            Part2(passports);
        }
        private static void Part2(string[] passports)
        {
            var count = 0;
            foreach (var passport in passports)
            {
                var items = Regex.Split(passport, @"[\s \r\n]+");
                var currentPassport = new Passport();
                foreach (var item in items)
                {
                    if (item.Contains("byr:"))
                    {
                        var year = int.Parse(item.Split(":")[1]);
                        if(year >= 1920 && year <= 2002)
                        {
                            currentPassport.birthYear = year;
                        }
                    }
                    if (item.Contains("iyr:"))
                    {
                        var year = int.Parse(item.Split(":")[1]);
                        if(year >= 2010 && year <= 2020)
                        {
                            currentPassport.issueYear = year;
                        }
                    }
                    if (item.Contains("eyr:"))
                    {
                        var year = int.Parse(item.Split(":")[1]);
                        if(year >= 2020 && year <= 2030)
                        {
                            currentPassport.expirationYear = year;
                        }
                    }
                    if (item.Contains("hgt:"))
                    {
                        var values = item.Split(":")[1];
                        if (values.Contains("cm"))
                        {
                            var cmValue = int.Parse(values.Split("cm")[0]);
                            if (cmValue >=150 && cmValue <= 193)
                            {
                                currentPassport.height = values;
                            }
                        } else if (values.Contains("in"))
                        {
                            var cmValue = int.Parse(values.Split("in")[0]);
                            if (cmValue >=59 && cmValue <= 76)
                            {
                                currentPassport.height = values;
                            }
                        }
                    }
                    if (item.Contains("hcl:"))
                    {
                        var reg = new Regex("^#([a-fA-F0-9]{6}|[a-fA-F0-9]{3})$");
                        var match = reg.Match(item.Split(":")[1]);
                        if (match.Success)
                        {
                            currentPassport.hairColor = item.Split(":")[1];
                        }
                    }
                    if (item.Contains("ecl:"))
                    {
                        var colors = new List<string> {"amb", "blu", "brn", "gry", "grn", "hzl", "oth"};
                        if (colors.Contains(item.Split(":")[1]))
                        {
                            currentPassport.eyeColor = item.Split(":")[1];
                        }
                        
                    }
                    if (item.Contains("pid:"))
                    {
                        var value  = item.Split(":")[1];
                        int intValue;
                        var output = int.TryParse(value, out intValue);
                        if (value.Length == 9 && output)
                        {
                            currentPassport.passportId = value;
                        }
                        
                    }
                    if (item.Contains("cid:"))
                    {
                        currentPassport.countryId = int.Parse(item.Split(":")[1]);
                    }
                }
                if (currentPassport.IsValid())
                {
                    count += 1;
                }
            }
            Console.WriteLine("part 2 " + count);
        }

        private static void Part1(string[] passports)
        {
            var count = 0;
            foreach (var passport in passports)
            {
                var items = Regex.Split(passport, @"[\s \r\n]+");
                var currentPassport = new Passport();
                foreach (var item in items)
                {
                    if (item.Contains("byr:"))
                    {
                        currentPassport.birthYear = int.Parse(item.Split(":")[1]);
                    }
                    if (item.Contains("iyr:"))
                    {
                        currentPassport.issueYear = int.Parse(item.Split(":")[1]);
                    }
                    if (item.Contains("eyr:"))
                    {
                        currentPassport.expirationYear = int.Parse(item.Split(":")[1]);
                    }
                    if (item.Contains("hgt:"))
                    {
                        currentPassport.height = item.Split(":")[1];
                    }
                    if (item.Contains("hcl:"))
                    {
                        currentPassport.hairColor = item.Split(":")[1];
                    }
                    if (item.Contains("ecl:"))
                    {
                        currentPassport.eyeColor = item.Split(":")[1];
                    }
                    if (item.Contains("pid:"))
                    {
                        currentPassport.passportId = item.Split(":")[1];
                    }
                    if (item.Contains("cid:"))
                    {
                        currentPassport.countryId = int.Parse(item.Split(":")[1]);
                    }
                }
                if (currentPassport.IsValid())
                {
                    count += 1;
                }
            }
            Console.WriteLine("part 1 " + count);
        }
    }
}
