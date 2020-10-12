using System;
namespace lab1.Core.Exceptions
{
    public class ConversionErrorException : Exception
    {
        public ConversionErrorException(string msg) : base(msg)
        {
        }
    }
}
