using System;
namespace lab1.Core.Exceptions
{
    public class IncorrectSectionException : Exception
    {
        public IncorrectSectionException(string msg) : base(msg)
        {
        }
    }
}
