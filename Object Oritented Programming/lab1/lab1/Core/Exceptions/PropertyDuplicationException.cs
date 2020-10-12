using System;
namespace lab1.Core.Exceptions
{
    public class PropertyDuplicationException : Exception
    {
        public PropertyDuplicationException(string msg) : base(msg)
        {

        }
    }
}
