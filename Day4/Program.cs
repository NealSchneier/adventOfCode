using System;
using System.Text.RegularExpressions;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = System.IO.File.ReadAllText("Day4/input.txt");
            var passports = text.Split(Environment.NewLine + Environment.NewLine);
            var count = 0;
            foreach(var passport in passports)
            {
                var items = Regex.Split(passport, @"[\s \r\n]+");
                var currentPassport = new Passport();
                foreach(var item in items)
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
            Console.WriteLine(count);
        }
    }
}
