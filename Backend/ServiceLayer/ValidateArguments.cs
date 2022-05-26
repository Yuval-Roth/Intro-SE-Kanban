using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.ServiceLayer
{
    internal class ValidateArguments
    {
        public static bool ValidateNotNull(object[] args)
        {
            foreach (object arg in args)
            {
                if (arg == null) return false;
            }
            return true;
        }
    }
}
