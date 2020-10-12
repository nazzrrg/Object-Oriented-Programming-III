using System;
namespace lab1.Core.Exceptions
{
    public class FileReadException : Exception
    {
        public FileReadException(string msg) : base(msg)
        {
        }
    }
}
