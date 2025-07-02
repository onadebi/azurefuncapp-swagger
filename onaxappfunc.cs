using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.OpenApi.Models;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;


namespace OnaxFiles;

public class OnaxAppFunc
{
    private readonly ILogger<OnaxAppFunc> _logger;

    public OnaxAppFunc(ILogger<OnaxAppFunc> logger)
    {
        _logger = logger;
    }

    [Function("GetIntro")]
    [OpenApiOperation(operationId: "Run", tags: new[] { "hello" })]
    [OpenApiParameter(name: "GetIntro", In = ParameterLocation.Query, Required = false, Type = typeof(string), Description = "Your name")]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Description = "The greeting")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        return new OkObjectResult("Welcome to Azure Functions!");
    }
}
