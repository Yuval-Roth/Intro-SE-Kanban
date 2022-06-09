using System;

namespace IntroSE.Kanban.Backend.BusinessLayer
{
    public class NoSuchElementException : SystemException
    {
        public NoSuchElementException() : base() { }
        public NoSuchElementException(string message) : base(message) { }
        public NoSuchElementException(string message, Exception innerException) : base(message, innerException) { }
    }
}
