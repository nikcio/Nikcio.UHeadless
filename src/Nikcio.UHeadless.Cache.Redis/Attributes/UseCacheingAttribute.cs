using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using Microsoft.Extensions.Logging;
using Nikcio.UHeadless.Cache.Redis.Middleware;

namespace Nikcio.UHeadless.Cache.Redis.Attributes
{
    public class UseCacheingAttribute : ObjectFieldDescriptorAttribute {
        public UseCacheingAttribute([CallerLineNumber] int order = 0) {
            Order = order;
        }

        public override void OnConfigure(IDescriptorContext context, IObjectFieldDescriptor descriptor, MemberInfo member) {
            descriptor.Use<CacheingMiddleware>();
        }
    }
}
