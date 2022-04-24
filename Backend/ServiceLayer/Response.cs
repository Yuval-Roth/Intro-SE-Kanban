using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace IntroSE.Kanban.Backend.ServiceLayer
{
    [Serializable]
    public sealed class Response
    {
        [JsonInclude]
        public readonly string? ErrorMessage;

        [JsonInclude]
        public readonly object? ReturnValue;

        public Response(string ErrorMessage)
        {
            this.ErrorMessage = ErrorMessage;
            ReturnValue = null;
        }

        public Response(object ReturnValue)
        {
            this.ReturnValue = ReturnValue;
            ErrorMessage = null;
        }

        [JsonConstructor]
        public Response(object? ReturnValue, string? ErrorMessage)
        {
            this.ReturnValue = ReturnValue;
            this.ErrorMessage = ErrorMessage;
        }
    }
    

}
