using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace IntroSE.Kanban.Backend.ServiceLayer
{
    public class Response
    {
        public readonly bool operationState;
        public readonly string message;

        [JsonConstructor]
        public Response(bool operationState, string message)
        {
            this.operationState = operationState;
            this.message = message;
        }
        public string ToJson()
        {
            return JsonController.Generate(this);
        }
        public static Response BuildFromJson(string json)
        {
            return JsonController.DeserializeResponse(json);
        }
    
    }
    

}
