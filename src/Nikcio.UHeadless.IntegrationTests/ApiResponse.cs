using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Nikcio.UHeadless.IntegrationTests;

public class ApiResponse
{
    public HttpResponseMessage ResponseMessage { get; }

    public string Response { get; }

    public ApiResponse(HttpResponseMessage responseMessage, string response)
    {
        ResponseMessage = responseMessage;
        Response = response;
    }

    public JObject JObjectResponse()
    {
        return JObject.Parse(Response);
    }

    public TType TypedResponse<TType>()
    {
        return JsonConvert.DeserializeObject<TType>(Response) ?? throw new InvalidOperationException("Unable to convert response to type.");
    }
}
