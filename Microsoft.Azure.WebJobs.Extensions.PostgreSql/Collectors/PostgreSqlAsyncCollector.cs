using Dapper;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Npgsql;
using System.Data;
using System.Text;

namespace Microsoft.Azure.WebJobs.Extensions.PostgreSql.Collectors
{
    internal class PostgreSqlAsyncCollector<T> : IAsyncCollector<T>
    {
        private readonly PostgreSqlAttribute attribute;
        private readonly ILogger logger;
        private readonly List<T> rows = new List<T>();
        private string insertQuery = string.Empty;

        public PostgreSqlAsyncCollector(PostgreSqlAttribute attribute, ILogger logger)
        {
            this.attribute = attribute;
            this.logger = logger;
        }

        public async Task AddAsync(T item, CancellationToken cancellationToken = default(CancellationToken))
        {
            rows.Add(item);
        }

        public async Task FlushAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (rows.Any())
            {
                if (string.IsNullOrEmpty(insertQuery)) SetInsertQuery(rows[0]);

                Console.WriteLine(insertQuery);
                await using var connection = new NpgsqlConnection(attribute.ConnectionStringSetting);
                var result = await connection.ExecuteAsync(insertQuery, rows.ToArray());
                Console.WriteLine($"{result} records inserted.");
            }
        }

        private void SetInsertQuery(T entity)
        {
            var query = new StringBuilder($"INSERT INTO {attribute.TableName} (");
            var parameterList = new StringBuilder(") VALUES (");

            var json = JObject.FromObject(entity);
            foreach (var property in json.Properties())
            {
                query.Append(property.Name);
                parameterList.Append($"@{property.Name}");

                if (property != json.Properties().Last())
                {
                    query.Append(", ");
                    parameterList.Append(", ");
                }
            }

            query.Append(parameterList.ToString());
            query.Append(")");
            insertQuery = query.ToString();
        }
    }
}
