using System;
using System.Collections.Generic;
using lab1.Core.Exceptions;

namespace lab1.Core.Types
{
    public class Section
    {
        private readonly Dictionary<string, string> _sectionContents;
        private readonly string _sectionName;

        public Section(string name_)
        {
            _sectionName = name_;
            _sectionContents = new Dictionary<string, string>();
        }

        public void Add(string key_, string value_)
        {
            if (!_sectionContents.ContainsKey(key_))
            {
                _sectionContents.Add(key_, value_);
            } else
            {
                throw new PropertyDuplicationException($"Property {key_} already exists");
            }
        }

        public string Get(string key)
        {
            if (_sectionContents.ContainsKey(key))
            {
                return _sectionContents[key];
            } else
            {
                throw new IncorrectPropertyException($"Key {key} does not exist");
            }
        }

        public string this[string key] =>
            _sectionContents.ContainsKey(key) ? _sectionContents[key] : throw new IncorrectPropertyException($"Key {key} does not exist");

        public string GetName()
        {
            return _sectionName;
        }

        override public string ToString()// TODO ToString
        {
            string result = $"[{_sectionName}]\n";
            foreach(KeyValuePair<string,string> pair in _sectionContents)
            {
                result += $"{pair.Key}={pair.Value}\n";
            }
            return result;
        }
    }
}
