using System;
using System.Text.Json.Serialization;

namespace IntroSE.Kanban.Backend.ServiceLayer
{
#nullable enable
[Serializable]
public class GradingResponse<T>
{
    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public readonly string? ErrorMessage;

    [JsonInclude]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public readonly T? ReturnValue;


    [JsonConstructor]
    public GradingResponse(string? ErrorMessage, T? ReturnValue)
    {
        this.ErrorMessage = ErrorMessage;
        this.ReturnValue = ReturnValue;
    }

    public GradingResponse(string json)
    {
        Response<T> response = JsonController.BuildFromJson<Response<T>>(json);
        if (response.operationState == true)
        {
            if (response.returnValue is string)
            {
                if (response.returnValue as string != "")
                    ReturnValue = response.returnValue;
            }
            else
            {
                ReturnValue = response.returnValue;
            }
        }
        else if (response.returnValue is string)
        {
            ErrorMessage = response.returnValue as string;
        }
        else
        {
            throw new NotSupportedException("Response.operationState is false and returnValue is not string");
        }
    }
        
}
}

