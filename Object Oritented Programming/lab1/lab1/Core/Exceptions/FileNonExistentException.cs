using System;
namespace lab1.Core.Exceptions
{
    public class FileNonExistentException : Exception
    {
        public FileNonExistentException(string msg) : base(msg)
        {
        }
    }
}
