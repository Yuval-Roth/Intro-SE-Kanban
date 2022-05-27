using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.BusinessLayer
{
    public class ElementAlreadyExistsException : SystemException
    {
        public ElementAlreadyExistsException() : base() { }
        public ElementAlreadyExistsException(string message) : base(message) { }
        public ElementAlreadyExistsException(string message, Exception innerException) : base(message, innerException) { }
    }
}
