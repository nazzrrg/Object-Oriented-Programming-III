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

        public T Get<T>(string sectionName, string propertyName)
        {
            if (_contents.ContainsKey(sectionName))
            {
                var result = _contents[sectionName].Get(propertyName);
                
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
                    throw new ConversionErrorException($"Conversion Error! Cannot convert {sectionName} {propertyName} of {result.GetType()} to {typeof(T)}");
                }
            } else
            {
                throw new IncorrectSectionException($"Section {sectionName} not exist!");
            }
        }

        override public string ToString()
        {
            string result="";
            foreach (KeyValuePair<string, Section> entry in _contents)
            {
                result += entry.Value.ToString() + '\n';
            }
            return result;
        }
    }
}
