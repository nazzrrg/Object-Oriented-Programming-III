using System;
namespace lab1.Core.Exceptions
{
    public class SectionDuplicationException : Exception
    {
        public SectionDuplicationException(string msg) : base(msg)
        {
        }
    }
}
