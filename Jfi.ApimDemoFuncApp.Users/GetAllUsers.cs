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

using System.Collections.Generic;
using Generators;
using Models;

public static class GetAllUsers
{
    [FunctionName("GetAllUsers")]
    public static async Task<IActionResult> RunAsync(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "users")] HttpRequest req, ILogger log)
    {
        log.LogInformation("Called GetAllUsers");

        List<User> users = UserGenerator.CreateUsers();

        return new OkObjectResult(users);
    }
}
