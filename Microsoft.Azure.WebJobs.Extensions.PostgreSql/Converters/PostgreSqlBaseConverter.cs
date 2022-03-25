using Newtonsoft.Json;
using Npgsql;
using System.Data;

namespace Microsoft.Azure.WebJobs.Extensions.PostgreSql.Converters
{
    internal class PostgreSqlBaseConverter
    {
        protected async Task<string> ExecuteQueryAsync(PostgreSqlAttribute attribute)
        {
            await using var connection = new NpgsqlConnection(attribute.ConnectionStringSetting);
            await connection.OpenAsync();

            await using var command = new NpgsqlCommand(attribute.CommandText, connection);
            var dataAdapter = new NpgsqlDataAdapter(command);
            var dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            return JsonConvert.SerializeObject(dataTable);
        }
    }
}
