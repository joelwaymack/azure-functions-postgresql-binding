using Microsoft.Azure.WebJobs.Extensions.PostgreSql.Converters;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Config;

namespace Microsoft.Azure.WebJobs.Extensions.PostgreSql;

[Extension("PosgreSql")]
public class PostgreSqlConfigProvider : IExtensionConfigProvider
{
    public void Initialize(ExtensionConfigContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }
        var rule = context.AddBindingRule<PostgreSqlAttribute>();
        rule.BindToInput<IEnumerable<OpenType>>(typeof(PostgreSqlEnumerableConverter<>));
        rule.BindToInput<OpenType>(typeof(PostgreSqlObjectConverter<>));
    }
}
