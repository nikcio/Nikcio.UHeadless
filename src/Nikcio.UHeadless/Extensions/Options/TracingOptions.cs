using HotChocolate.Execution.Instrumentation;
using HotChocolate.Execution.Options;

namespace Nikcio.UHeadless.Extensions.Options
{
    /// <summary>
    /// Apollo tracing options
    /// </summary>
    public class TracingOptions
    {
        /// <summary>
        /// TracingPreference
        /// </summary>
        public TracingPreference? TracingPreference { get; set; } = null;

        /// <summary>
        /// ITimestampProvider
        /// </summary>
        public ITimestampProvider? TimestampProvider { get; set; } = null;
    }
}