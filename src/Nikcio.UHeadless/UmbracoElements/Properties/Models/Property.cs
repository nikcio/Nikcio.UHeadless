using HotChocolate.Types;
using HotChocolate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nikcio.UHeadless.UmbracoElements.Properties.Commands;
using Umbraco.Cms.Core.Models.PublishedContent;
using Nikcio.UHeadless.UmbracoElements.Properties.Factories;
using Nikcio.UHeadless.UmbracoElements.Properties.EditorsValues.Fallback.Commands;
using System.Text.RegularExpressions;

namespace Nikcio.UHeadless.UmbracoElements.Properties.Models
{
    /// <inheritdoc/>
    [GraphQLDescription("Represents a property.")]
    public abstract class Property : IProperty
    {
        /// <inheritdoc/>
        protected Property(CreateProperty _)
        {
        }
    }
}
