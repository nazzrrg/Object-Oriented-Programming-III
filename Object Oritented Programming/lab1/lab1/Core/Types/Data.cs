using System;
using System.Collections.Generic;
using lab1.Core.Exceptions;

namespace lab1.Core.Types
{
    public class Data
    {
        private readonly Dictionary<string, Section> _contents;

        public Data()
        {
            _contents = new Dictionary<string, Section>();
        }

        public void Add(string key_, Section section_)
        {
            if (!_contents.ContainsKey(key_))
            {
                _contents.Add(key_, section_);
            } else
            {
                throw new SectionDuplicationException($"Section {key_} already exists");
            }
        }

        public T Get<T>(string SectionName, string PropertyName)
        {
            if (_contents.ContainsKey(SectionName))
            {
                var result = _contents[SectionName].Get(PropertyName);
                
                try
                {
                    if (typeof(T).Equals(typeof(float)) || typeof(T).Equals(typeof(double)))
                    {
                        return (T)Convert.ChangeType(result, typeof(T), System.Globalization.CultureInfo.InvariantCulture);
                    }
                    return (T)Convert.ChangeType(result, typeof(T));
                }
                catch
                {
                    throw new ConversionErrorException("Conversion Error!");
                }
            } else
            {
                throw new IncorrectSectionException($"Section {SectionName} not exist!");
            }
        }

        public void Print()
        {
            foreach (KeyValuePair<string, Section> entry in _contents)
            {
                entry.Value.Print();
                Console.WriteLine();
            }
        }
    }
}
