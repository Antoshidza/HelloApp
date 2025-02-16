using System;

namespace Source.Core.App
{
    public class AppException : Exception
    {
        public AppException(string msg) : base(msg)
        {
        }
    }
}