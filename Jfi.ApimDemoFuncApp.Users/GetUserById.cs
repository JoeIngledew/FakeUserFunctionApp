using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Jfi.ApimDemoFuncApp.Users;

using Generators;

public static class GetUserById
{
    [FunctionName("GetUserById")]
    public static async Task<IActionResult> RunAsync(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "users/{id:int}")] HttpRequest req, int id, ILogger log)
    {
        log.LogInformation("Called GetUserById: {id}", id);

        var user = UserGenerator.CreateUser();
        user.Id = id;

        return new OkObjectResult(user);
    }
}
