using Dapper;
using Npgsql;

namespace Microsoft.Azure.WebJobs.Extensions.PostgreSql.Converters
{
    internal class PostgreSqlObjectConverter<T> : IAsyncConverter<PostgreSqlAttribute, T>
        where T : class
    {
        public async Task<T> ConvertAsync(PostgreSqlAttribute attribute, CancellationToken cancellationToken)
        {
            await using var connection = new NpgsqlConnection(attribute.ConnectionStringSetting);
            return (await connection.QueryAsync<T>(attribute.Query)).FirstOrDefault();
        }

    }
}
