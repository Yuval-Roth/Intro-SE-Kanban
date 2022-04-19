using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.BusinessLayer
{
    public class IlligalArgumentException : SystemException
    {
        public IlligalArgumentException() : base() { }

        public IlligalArgumentException(string message) : base(message) { }

        public IlligalArgumentException(String message, Exception innerException) : base(message, innerException) { }
    }
}
