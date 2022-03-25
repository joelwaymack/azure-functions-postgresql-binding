using Microsoft.Azure.WebJobs;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Extensions.PostgreSql.Converters;

internal class PostgreSqlEnumerableConverter<T> : PostgreSqlBaseConverter, IAsyncConverter<PostgreSqlAttribute, IEnumerable<T>>
    where T : class
{
    public async Task<IEnumerable<T>> ConvertAsync(PostgreSqlAttribute attribute, CancellationToken cancellationToken)
    {
        var json = await ExecuteQueryAsync(attribute);
        return JsonConvert.DeserializeObject<IEnumerable<T>>(json);
    }
}
