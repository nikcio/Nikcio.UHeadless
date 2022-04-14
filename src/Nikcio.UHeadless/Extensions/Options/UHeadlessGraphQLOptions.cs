﻿using HotChocolate.Execution.Configuration;
using System;

namespace Nikcio.UHeadless.Extensions.Options
{
    /// <summary>
    /// Options for UHeadless GraphQL
    /// </summary>
    public class UHeadlessGraphQLOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual bool UseSecurity { get; set; } = false;

        /// <summary>
        /// Should the schema builder throw an exception when a schema error occurs. (true = yes, false = no)
        /// </summary>
        public virtual bool ThrowOnSchemaError { get; set; } = false;

        /// <summary>
        /// 
        /// </summary>
        public virtual Func<IRequestExecutorBuilder, IRequestExecutorBuilder>? GraphQLExtensions { get; set; } = null;
    }
}
