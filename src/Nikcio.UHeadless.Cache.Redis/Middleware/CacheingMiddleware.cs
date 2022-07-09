using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotChocolate.Execution.Processing;
using HotChocolate.Execution;
using HotChocolate.Fetching;
using HotChocolate.Language;
using HotChocolate.Resolvers;
using HotChocolate.Utilities;
using Microsoft.Extensions.Caching.Distributed;
using Nikcio.UHeadless.Cache.Extensions;
using HotChocolate.Types.Introspection;
using HotChocolate.Types;
using static HotChocolate.ErrorCodes;
using System.Text.Encodings.Web;
using HotChocolate.Execution.Serialization;

namespace Nikcio.UHeadless.Cache.Redis.Middleware {
    public class CacheingMiddleware {
        private readonly RequestDelegate _next;
        //private readonly IDistributedCache _distributedCache;

        public CacheingMiddleware(RequestDelegate next) {
            _next = next;
        }

        //public async Task InvokeAsync(IMiddlewareContext context, IDistributedCache distributedCache) {
        //    var cachedValue = await distributedCache.GetRecordAsync<object?>("CACHEVALUE0");
        //    if (cachedValue != null) {
        //        context.Result = cachedValue;
        //    } else {
        //        await _next(context);
        //        //await distributedCache.SetRecordAsync("CACHEVALUE0", context.Result, TimeSpan.FromSeconds(30), TimeSpan.FromSeconds(30));
        //    }
        //}

        public async ValueTask InvokeAsync(IRequestContext context, IDistributedCache distributedCache, JavaScriptEncoder? encoder = null) {

            var queryId =
                context.Request.QueryId ??
                context.DocumentId ??
                context.DocumentHash ??
                context.Request.QueryHash;

            if(queryId != null) {
                var cachedValue = await distributedCache.GetRecordAsync<QueryResult?>(queryId);
                if (cachedValue != null) {
                    context.Result = cachedValue;
                } else {
                    await _next(context).ConfigureAwait(false);

                    if (context.Result is not IQueryResult queryResult) {
                        // Result is potentially deferred or batched,
                        // we can not cache the entire query.

                        return;
                    }

                    if (context.Operation?.Definition.Operation != OperationType.Query) {
                        // Request is not a query, so we do not cache it.

                        return;
                    }

                    if (queryResult.Errors is { Count: > 0 }) {
                        // Result has unexpected errors, we do not want to cache it.

                        return;
                    }
                    if(context.Result is QueryResult result) {
                        await distributedCache.SetRecordAsync(queryId, result, TimeSpan.FromSeconds(30), TimeSpan.FromSeconds(30));
                    }
                    
                }
            } else {
                await _next(context).ConfigureAwait(false);
            }
        }
    }
}
