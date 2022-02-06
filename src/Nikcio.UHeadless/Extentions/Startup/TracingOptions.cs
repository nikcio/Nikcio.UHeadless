using HotChocolate.Execution.Instrumentation;
using HotChocolate.Execution.Options;

namespace Nikcio.UHeadless.Extentions.Startup
{
    public class TracingOptions
    {
        public TracingPreference TracingPreference { get; set; }
        public ITimestampProvider TimestampProvider { get; set; }
    }
}