using System.Net.Http.Json;

namespace Nikcio.UHeadless.IntegrationTests;

public partial class ApiTests
{
    private const string _contentDescendantsByRouteSnapshotPath = $"{SnapshotConstants.BasePath}/ContentDescendantsByRoute";

    [Theory]
    [InlineData("test-1", "https://site-1.com", "/", null, 1, 2, "en-US", false, null, true)]
    [InlineData("test-2", "https://site-1.com", "/", "default", 1, 2, "en-US", false, null, true)]
    [InlineData("test-3", "https://site-1.com", "/", "does-not-exist", 1, 2, "en-US", false, null, true)]
    public async Task ContentDescendantsByRouteQuery_Snaps_Async(
        string testCase,
        string baseUrl,
        string route,
        string? contentType,
        int page,
        int pageSize,
        string? culture,
        bool? includePreview,
        string? segment,
        bool expectSuccess)
    {
        var snapshotProvider = new SnapshotProvider($"{_contentDescendantsByRouteSnapshotPath}/Snaps");
        HttpClient client = _factory.CreateClient();

        using var request = JsonContent.Create(new
        {
            query = ContentDescendantsByRouteQueries.GetItems,
            variables = new
            {
                baseUrl,
                route,
                contentType,
                page,
                pageSize,
                culture,
                includePreview,
                segment
            }
        });

        HttpResponseMessage response = await client.PostAsync("/graphql", request, TestContext.Current.CancellationToken).ConfigureAwait(true);

        string responseContent = await response.Content.ReadAsStringAsync(TestContext.Current.CancellationToken).ConfigureAwait(true);

        string snapshotName = $"ContentDescendantsByRoute_Snaps_{testCase}.snap";

        await snapshotProvider.AssertIsSnapshotEqualAsync(snapshotName, responseContent).ConfigureAwait(true);
        Assert.Equal(expectSuccess, response.IsSuccessStatusCode);
    }
}

public static class ContentDescendantsByRouteQueries
{
    public const string GetItems = """
        query ContentDescendantsByRouteQuery(
          $baseUrl: String!,
          $route: String!,
          $contentType: String,
          $page: Int!,
          $pageSize: Int!,
          $culture: String,
          $includePreview: Boolean,
          $fallbacks: [PropertyFallback!],
          $segment: String
        ) {
          contentDescendantsByRoute(
            route: $route,
            contentType: $contentType,
            page: $page,
            pageSize: $pageSize,
            inContext: {
              baseUrl: $baseUrl,
              culture: $culture,
              includePreview: $includePreview,
              fallbacks: $fallbacks,
              segment: $segment
            }
          ) {
            items {
              url(urlMode: ABSOLUTE)
              name
              id
              parent {
                url(urlMode: ABSOLUTE)
              }
              __typename
            }
            page
            pageSize
            totalItems
            hasNextPage
          }
        }
        """;
}
