using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroSE.Kanban.Backend.ServiceLayer
{
    public class Response
    {
        public readonly bool operationState;
        public readonly string message;

        public Response(bool operationState, string message)
        {
            this.operationState = operationState;
            this.message = message;
        }
        public string GenerateJson()
        {
            return JsonController.Generate(this);
        }
    }
    

}
