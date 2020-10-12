using System;
using System.IO;
using System.Text.RegularExpressions;
using lab1.Core.Exceptions;
using lab1.Core.Types;

namespace lab1.Core
{
    public class IniParser
    {
        public Data TryParse(string filePath)
        {
            Data data = new Data();

            if (!File.Exists(filePath))
            {
                throw new FileNonExistentException();
            }


            if (Path.GetExtension(filePath) != ".INI" && Path.GetExtension(filePath) != ".ini")
            {
                throw new IncorrectFileExtensionException();
            }

            using (StreamReader sr = File.OpenText(filePath))
            {
                string s;
                int count = 0;

                Section currentSection = new Section("1");

                while ((s = sr.ReadLine()) != null)
                {
                    if(IsSectionHeader(s))
                    {
                        s = s.Replace("]", "").Replace("[", "");
                        if (count > 0)
                        {
                            data.Add(currentSection.GetName(), currentSection);
                        }
                        currentSection = new Section(s);
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
                    }

                }
                if (count > 0)
                {
                    data.Add(currentSection.GetName(), currentSection);
                }
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
            return Regex.IsMatch(test, @"^\s+$");
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
