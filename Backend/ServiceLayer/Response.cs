using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

#nullable enable
namespace IntroSE.Kanban.Backend.ServiceLayer
{

    [Serializable]
    public sealed class Response<T>
    {
        [JsonInclude]
        public readonly bool operationState;

        [JsonInclude]
        public readonly T returnValue;

        [JsonConstructor]
        public Response(bool operationState, T returnValue)
        {
            this.operationState = operationState;
            this.returnValue = returnValue;
        }
    }
    

}
