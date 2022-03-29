using Microsoft.Azure.WebJobs.Extensions.PostgreSql.Converters;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.PostgreSql;

[Extension("PosgreSql")]
public class PostgreSqlConfigProvider : IExtensionConfigProvider
{
    private readonly ILoggerFactory loggerFactory;

    public PostgreSqlConfigProvider(ILoggerFactory loggerFactory)
    {
        this.loggerFactory = loggerFactory;
    }


    public void Initialize(ExtensionConfigContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        var logger = loggerFactory.CreateLogger(LogCategories.Bindings);

        var rule = context.AddBindingRule<PostgreSqlAttribute>();
        rule.BindToInput<IEnumerable<OpenType>>(typeof(PostgreSqlEnumerableConverter<>), logger);
        rule.BindToCollector<OpenType>(typeof(PostgresSqlAsyncCollectorConverter<>), logger);
    }
}
