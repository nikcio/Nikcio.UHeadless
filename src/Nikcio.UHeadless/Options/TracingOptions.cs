using HotChocolate.Execution.Instrumentation;
using HotChocolate.Execution.Options;

namespace Nikcio.UHeadless.Options
{
    /// <summary>
    /// Apollo tracing options
    /// </summary>
    public class TracingOptions
    {
        public TracingPreference TracingPreference { get; set; }
        public ITimestampProvider TimestampProvider { get; set; }
    }
}