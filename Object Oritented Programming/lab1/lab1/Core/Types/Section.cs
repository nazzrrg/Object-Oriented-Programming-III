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
                throw new PropertyDuplicationException();
            }
        }

        public string Get(string key)
        {
            if (_sectionContents.ContainsKey(key))
            {
                return _sectionContents[key];
            } else
            {
                throw new IncorrectPropertyException();
            }
        }

        public string this[string key] =>
            _sectionContents.ContainsKey(key) ? _sectionContents[key] : throw new IncorrectPropertyException();

        public string GetName()
        {
            return _sectionName;
        }

        public void Print()
        {
            Console.WriteLine("[" + _sectionName + "]");
            foreach(KeyValuePair<string,string> pair in _sectionContents)
            {
                Console.WriteLine(pair.Key+"="+pair.Value);
            }
        }
    }
}
