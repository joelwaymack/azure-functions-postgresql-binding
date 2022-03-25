using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.PostgreSql;
using Microsoft.Azure.WebJobs.Hosting;

[assembly: WebJobsStartup(typeof(PostgreSQLExtension.Startup))]

namespace PostgreSQLExtension
{

    public class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.AddExtension<PostgreSqlConfigProvider>();
        }
    }
}
