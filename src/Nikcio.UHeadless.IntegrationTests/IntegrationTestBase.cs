using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Nikcio.UHeadless.IntegrationTests.TestProject;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Logging;
using StrawberryShake.Transport.Http;

namespace Nikcio.UHeadless.IntegrationTests;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public abstract class IntegrationTestBase
{
}
