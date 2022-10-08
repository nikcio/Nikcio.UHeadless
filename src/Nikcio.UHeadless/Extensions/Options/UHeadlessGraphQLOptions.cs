using HotChocolate.Execution.Configuration;
using Nikcio.UHeadless.Base.Properties.Models;

namespace Nikcio.UHeadless.Extensions.Options;

/// <summary>
/// Options for UHeadless GraphQL
/// </summary>
public class UHeadlessGraphQLOptions
{
    /// <summary>
    /// 
    /// </summary>
    public virtual bool UseSecurity { get; set; }

    /// <summary>
    /// Should the schema builder throw an exception when a schema error occurs. (true = yes, false = no)
    /// </summary>
    public virtual bool ThrowOnSchemaError { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public virtual Func<IRequestExecutorBuilder, IRequestExecutorBuilder>? GraphQLExtensions { get; set; }

    /// <summary>
    /// A collection of all the type implementing <see cref="PropertyValue"/>
    /// </summary>
    /// <remarks>
    /// This will be filled automaticly
    /// </remarks>
    public virtual List<Type> PropertyValueTypes { get; set; } = new();
}
