using Microsoft.Azure.WebJobs.Description;
using System.Data;

namespace Microsoft.Azure.WebJobs.Extensions.PostgreSql;

[Binding]
[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
public class PostgreSqlAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SqlAttribute/>"/> class.
    /// </summary>
    /// <param name="commandText">The text of the command</param>
    public PostgreSqlAttribute(string commandText)
    {
        CommandText = commandText ?? throw new ArgumentNullException(nameof(commandText));
    }

    /// <summary>
    /// The name of the app setting where the PostgreSQL connection string is stored.
    /// </summary>
    [AppSetting]
    public string ConnectionStringSetting { get; set; }

    /// <summary>
    /// For an input binding, either a SQL query or stored procedure that will be run in the database referred to in the ConnectionString.
    /// For an output binding, the table name.
    /// </summary>
    [AutoResolve]
    public string CommandText { get; }

    /// <summary>
    /// Specifies whether <see cref="CommandText"/> refers to a stored procedure or SQL query string.
    /// Use <see cref="CommandType.StoredProcedure"/> for the former, <see cref="CommandType.Text"/> for the latter
    /// </summary>
    //public CommandType CommandType { get; set; }

    /// <summary>
    /// Specifies the parameters that will be used to execute the SQL query or stored procedure specified in <see cref="CommandText"/>.
    /// Must follow the format "@param1=param1,@param2=param2". For example, if your SQL query looks like
    /// "select * from Products where cost = @Cost and name = @Name", then Parameters must have the form "@Cost=100,@Name={Name}"
    /// If the value of a parameter should be null, use "null", as in @param1=null,@param2=param2".
    /// If the value of a parameter should be an empty string, do not add anything after the equals sign and before the comma,
    /// as in "@param1=,@param2=param2"
    /// Note that neither the parameter name nor the parameter value can have ',' or '='
    /// </summary>
    //[AutoResolve]
    //public string Parameters { get; set; }
}
