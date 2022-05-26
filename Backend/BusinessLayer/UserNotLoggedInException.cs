using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.BusinessLayer
{
    public class UserNotLoggedInException : SystemException
    {
        public UserNotLoggedInException() : base() { }
        public UserNotLoggedInException(string message) : base(message) { }
        public UserNotLoggedInException(string message, Exception innerException) : base(message, innerException) { }
    }
}
