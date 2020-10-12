using System;
namespace lab1.Core.Exceptions
{
    public class IncorrectFileExtensionException : Exception
    {
        public IncorrectFileExtensionException(string msg) : base(msg)
        {
        }
    }
}
