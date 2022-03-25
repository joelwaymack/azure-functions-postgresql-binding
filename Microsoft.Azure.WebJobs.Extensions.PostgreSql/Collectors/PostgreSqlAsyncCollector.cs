//using Npgsql;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Microsoft.Azure.WebJobs.Extensions.PostgreSql.Collectors
//{
//    internal class PostgreSqlAsyncCollector<T> : IAsyncCollector<T>
//    {
//        private readonly PostgreSqlAttribute attribute;
//        private readonly List<T> rows = new List<T>();

//        public PostgreSqlAsyncCollector(PostgreSqlAttribute attribute)
//        {
//            this.attribute = attribute;
//        }

//        public async Task AddAsync(T item, CancellationToken cancellationToken = default(CancellationToken))
//        {
//            await using var connection = new NpgsqlConnection(attribute.ConnectionStringSetting);
//            await connection.OpenAsync();

//            await using var command = new NpgsqlCommand(attribute.CommandText, connection);
//            var dataAdapter = new NpgsqlDataAdapter(command);
//            var dataTable = new DataTable();
//            dataAdapter.Fill(dataTable);
//            return JsonConvert.SerializeObject(dataTable);
//        }

//        public async Task FlushAsync(CancellationToken cancellationToken = default(CancellationToken))
//        {
//            // no-op
//            return;
//        }
//    }
//}
