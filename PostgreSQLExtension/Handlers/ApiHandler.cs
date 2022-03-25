using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.PostgreSql;
using Microsoft.Extensions.Logging;
using PostgreSQLExtension.Models;
using System.Collections.Generic;

namespace PostgreSQLExtension.Handlers;

public static class ApiHandler
{
    [FunctionName("GetExports")]
    public static IActionResult GetExports(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "exports")] HttpRequest req,
        [PostgreSql("SELECT * FROM EmployeeExports", ConnectionStringSetting = "PostgresConnection")] IEnumerable<EmployeeExport> exports,
        ILogger log)
    {
        return new OkObjectResult(exports);
    }
}
