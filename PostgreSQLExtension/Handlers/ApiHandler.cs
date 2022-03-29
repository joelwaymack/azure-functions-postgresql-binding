using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.PostgreSql;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PostgreSQLExtension.Generators;
using PostgreSQLExtension.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace PostgreSQLExtension.Handlers;

public static class ApiHandler
{
    [FunctionName("GetEmployees")]
    public static IActionResult GetEmployees(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "employees")] HttpRequest req,
        [PostgreSql(Query = "SELECT * FROM Employees", ConnectionStringSetting = "PostgresConnection")] IEnumerable<Employee> exports,
        ILogger log)
    {
        return new OkObjectResult(exports);
    }

    [FunctionName("CreateEmployees")]
    public async static Task<IActionResult> CreateEmployees(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "employees")] HttpRequest req,
        [PostgreSql(TableName = "Employees", ConnectionStringSetting = "PostgresConnection")] IAsyncCollector<Employee> employeeOutput,
        ILogger logger)
    {
        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var employees = JsonConvert.DeserializeObject<IList<Employee>>(requestBody);

        foreach (var employee in employees)
        {
            employee.Id = Guid.NewGuid();
            await employeeOutput.AddAsync(employee);
        }

        return new OkObjectResult($"{employees.Count} employees added.");
    }

    [FunctionName("CreateEmployeesTimer")]
    public async static Task CreateEmployeesTimer(
        [TimerTrigger("* */5 * * * *")] TimerInfo timer,
        [PostgreSql(TableName = "Employees", ConnectionStringSetting = "PostgresConnection")] IAsyncCollector<Employee> employeeOutput,
        ILogger logger)
    {
        var generator = new EmployeeGenerator();

        foreach (var employee in generator.Generate(10))
        {
            await employeeOutput.AddAsync(employee);
        }
    }

}
