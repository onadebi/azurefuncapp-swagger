using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnaxFiles;

public class onaxappfunc
{
    private readonly ILogger<onaxappfunc> _logger;

    public onaxappfunc(ILogger<onaxappfunc> logger)
    {
        _logger = logger;
    }

    [Function("onaxappfunc")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        return new OkObjectResult("Welcome to Azure Functions!");
    }
}
