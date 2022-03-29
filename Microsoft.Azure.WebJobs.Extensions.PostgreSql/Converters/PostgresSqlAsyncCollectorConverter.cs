using Microsoft.Azure.WebJobs.Extensions.PostgreSql.Collectors;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.PostgreSql.Converters
{
    internal class PostgresSqlAsyncCollectorConverter<T> : IAsyncConverter<PostgreSqlAttribute, IAsyncCollector<T>>
    {
        private readonly ILogger logger;

        public PostgresSqlAsyncCollectorConverter(ILogger logger)
        {
            this.logger = logger;
        }

        public async Task<IAsyncCollector<T>> ConvertAsync(PostgreSqlAttribute attribute, CancellationToken cancellationToken)
        {
            return new PostgreSqlAsyncCollector<T>(attribute, logger);
        }
    }
}
