using System;
using System.IO;
using System.Text.RegularExpressions;
using lab1.Core.Exceptions;
using lab1.Core.Types;

namespace lab1.Core
{
    public class IniParser
    {
        public Data Parse(string[] strings)
        {
            Data data = new Data();

            Section currentSection = new Section("1");

            int count = 0;

            foreach (string s in strings)
            {
                if (IsSectionHeader(s))
                {
                    if (count > 0)
                    {
                        data.Add(currentSection.GetName(), currentSection);
                    }
                    currentSection = new Section(s.Replace("]", "").Replace("[", ""));
                    count++;
                    continue;
                }

                if (IsCommentLine(s) || IsBlankLine(s)) continue;

                var strArr = s.Split("=;".ToCharArray(), 3, StringSplitOptions.RemoveEmptyEntries);

                if (strArr.Length > 1)
                {
                    strArr[0] = strArr[0].Trim();
                    strArr[1] = strArr[1].Trim();
                    if (IsFieldName(strArr[0]) && IsValidValue(strArr[1]))
                    {
                        currentSection.Add(strArr[0], strArr[1]);
                    }
                    continue;
                }

                throw new ParseFailureException($"Error while parsing. Invalid line: {s}");
            }

            if (count > 0)
            {
                data.Add(currentSection.GetName(), currentSection);
            }
            return data;
        }

        private static bool IsSectionHeader(string test)
        {
            return Regex.IsMatch(test, @"\[[A-Za-z0-9_]+\]");
        }

        private static bool IsFieldName(string test)
        {
            return Regex.IsMatch(test, @"[A-Za-z0-9_]");
        }

        private static bool IsBlankLine(string test)
        {
            return Regex.IsMatch(test, @"^\s*$");
        }

        private static bool IsCommentLine(string test)
        {
            return Regex.IsMatch(test, @"^\s*;.*$");
        }

        private static bool IsValidValue(string test)
        {
            return Regex.IsMatch(test, @"[^\s;=]+");
        }
    }
}
