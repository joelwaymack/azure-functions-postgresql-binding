using Dapper;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace Microsoft.Azure.WebJobs.Extensions.PostgreSql.Converters;

internal class PostgreSqlEnumerableConverter<T> : IAsyncConverter<PostgreSqlAttribute, IEnumerable<T>>
    where T : class
{
    private ILogger logger;

    public PostgreSqlEnumerableConverter(ILogger logger)
    {
        this.logger = logger;
    }

    public async Task<IEnumerable<T>> ConvertAsync(PostgreSqlAttribute attribute, CancellationToken cancellationToken)
    {
        await using var connection = new NpgsqlConnection(attribute.ConnectionStringSetting);
        return await connection.QueryAsync<T>(attribute.Query);
    }
}
