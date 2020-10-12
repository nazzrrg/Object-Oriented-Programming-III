using System;
namespace lab1.Core.Exceptions
{
    public class ParseFailureException : Exception
    {
        public ParseFailureException(string msg) : base(msg)
        {
        }
    }
}
