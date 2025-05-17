﻿using OrangeParanoia.Services.Interfaces;

namespace OrangeParanoia.Services
{
    public class StarWarsService : IStarWarsService
    {
        public string JediNameClassic(string firstName, string lastName, string motherName, string birthCity)
        {
            var a = lastName.Length >= 3 ? lastName[..3] : lastName;
            var b = firstName.Length >= 2 ? firstName[..2] : firstName;
            var c = motherName.Length >= 2 ? motherName[..2] : motherName;
            var d = birthCity.Length >= 3 ? birthCity[..3] : birthCity;

            var first = (a + b).ToLowerInvariant();
            var second = (c + d).ToLowerInvariant();
            return $"{Capitalize(first)} {Capitalize(second)}";
        }

        public string JediNameRealForm(string firstName, string lastName, string motherName, string birthCity)
        {
            var a = firstName.Length >= 3 ? firstName[..3] : firstName;
            var b = lastName.Length >= 2 ? lastName[..2] : lastName;
            var c = motherName.Length >= 2 ? motherName[..2] : motherName;
            var d = birthCity.Length >= 3 ? birthCity[..3] : birthCity;

            var first = (a + b).ToLowerInvariant();
            var second = (c + d).ToLowerInvariant();
            return $"{Capitalize(first)} {Capitalize(second)}";
        }

        public string JediName2332(string firstName, string lastName, string motherName, string birthCity)
        {
            var a = firstName.Length >= 2 ? firstName[..2] : firstName;
            var b = lastName.Length >= 3 ? lastName[..3] : lastName;
            var c = motherName.Length >= 3 ? motherName[..3] : motherName;
            var d = birthCity.Length >= 2 ? birthCity[..2] : birthCity;

            var first = (a + b).ToLowerInvariant();
            var second = (c + d).ToLowerInvariant();
            return $"{Capitalize(first)} {Capitalize(second)}";
        }

        public string JediNameFromEnds(string firstName, string lastName, string motherName, string birthCity)
        {
            var a = firstName.Length >= 2 ? firstName[^2..] : firstName;
            var b = lastName.Length >= 3 ? lastName[^3..] : lastName;
            var c = motherName.Length >= 2 ? motherName[^2..] : motherName;
            var d = birthCity.Length >= 3 ? birthCity[^3..] : birthCity;

            var first = (a + b).ToLowerInvariant();
            var second = (c + d).ToLowerInvariant();
            return $"{Capitalize(first)} {Capitalize(second)}";
        }

        public string JediNameAstrology(string firstName, string lastName, string birthCity, string zodiacSign, string zodiacElement)
        {
            var a = !string.IsNullOrEmpty(zodiacSign) ? zodiacSign[..1] : string.Empty;
            var b = firstName.Length >= 2 ? firstName[..2] : firstName;
            var c = lastName.Length >= 2 ? lastName[..2] : lastName;
            var d = !string.IsNullOrEmpty(zodiacElement) ? zodiacElement[..1] : string.Empty;
            var e = birthCity.Length >= 3 ? birthCity[..3] : birthCity;

            var first = (a + b + c).ToLowerInvariant();
            var second = (d + e).ToLowerInvariant();
            return $"{Capitalize(first)} {Capitalize(second)}";
        }

        public string SithNameClassic(string petName, string streetName)
        {
            var first = (!string.IsNullOrEmpty(petName) ? petName : string.Empty).ToLowerInvariant();
            var second = (!string.IsNullOrEmpty(streetName) ? streetName : string.Empty).ToLowerInvariant();
            return $"{Capitalize(first)} {Capitalize(second)}";
        }

        public string SithNameMethod1(string realName, string emotion, string virtue)
        {
            var a = realName.Length >= 3 ? realName[..3] : realName;
            var b = emotion.Length >= 2 ? emotion[..2] : emotion;
            var c = virtue.Length >= 3 ? virtue[..3] : virtue;
            var d = realName.Length >= 2 ? realName[^2..] : realName;

            var first = (a + b).ToLowerInvariant();
            var second = (c + d).ToLowerInvariant();
            return $"{Capitalize(first)} {Capitalize(second)}";
        }

        public string SithNameMethod2(string ambition, string realName, string weakness, string parentName)
        {
            var a = ambition.Length >= 3 ? ambition[..3] : ambition;
            var b = realName.Length >= 3 ? realName[..3] : realName;
            var c = weakness.Length >= 3 ? weakness[..3] : weakness;
            var d = parentName.Length >= 2 ? parentName[^2..] : parentName;

            var first = (a + b).ToLowerInvariant();
            var second = (c + d).ToLowerInvariant();
            return $"{Capitalize(first)} {Capitalize(second)}";
        }

        public string SithNameMethod3(string realName, string emotion)
        {
            var a = !string.IsNullOrEmpty(realName) ? realName[..1] : string.Empty;
            var b = emotion.Length >= 3 ? emotion[^3..] : emotion;
            var c = !string.IsNullOrEmpty(emotion) ? emotion[..1] : string.Empty;
            var d = realName.Length >= 2 ? realName[1..] : string.Empty;

            var first = (a + b).ToLowerInvariant();
            var second = (c + d).ToLowerInvariant();
            return $"{Capitalize(first)} {Capitalize(second)}";
        }

        public string DroidNameAstromech(int birthMonth, int birthDay)
        {
            return $"R{birthMonth}-{birthDay}";
        }

        public string DroidNameProtocol(string firstName, int age)
        {
            if (string.IsNullOrWhiteSpace(firstName)) return string.Empty;
            var initial = char.ToUpperInvariant(firstName[0]);
            var series = age % 10;
            return $"{initial}-{series}PO";
        }

        public string DroidNameRandom(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
                return string.Empty;

            var rnd = new Random((firstName + lastName).GetHashCode());
            var number = rnd.Next(100, 1000);
            var i1 = char.ToUpperInvariant(firstName[0]);
            var i2 = char.ToUpperInvariant(lastName[0]);
            return $"{i1}{i2}-{number}";
        }

        public string DroidNameFullSerial(string seriesPrefix)
        {
            var guid = Guid.NewGuid().ToString("N").ToUpperInvariant();
            return $"{seriesPrefix}-{guid}";
        }

        public string DroidNameShortened(string seriesPrefix)
        {
            var full = DroidNameFullSerial(seriesPrefix);
            var parts = full.Split('-', 2);
            if (parts.Length == 2 && parts[1].Length >= 2)
            {
                var shortId = parts[1].Substring(0, 2);
                return $"{parts[0]}-{shortId}";
            }
            return full;
        }

        private static string Capitalize(string s)
        {
            return string.IsNullOrEmpty(s)
                ? string.Empty
                : char.ToUpperInvariant(s[0]) + s[1..];
        }
    }
}
