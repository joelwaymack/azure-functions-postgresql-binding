using Microsoft.Azure.WebJobs;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Extensions.PostgreSql.Converters
{
    internal class PostgreSqlObjectConverter<T> : PostgreSqlBaseConverter, IAsyncConverter<PostgreSqlAttribute, T>
        where T : class
    {
        public async Task<T> ConvertAsync(PostgreSqlAttribute attribute, CancellationToken cancellationToken)
        {
            var json = await ExecuteQueryAsync(attribute);
            return JsonConvert.DeserializeObject<T>(json);
        }

    }
}
