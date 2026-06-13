using System.Net.Http.Json;
using Nikcio.UHeadless.Defaults.Authorization;
using Nikcio.UHeadless.Defaults.ContentItems;

namespace Nikcio.UHeadless.IntegrationTests;

public partial class ApiAuthTests
{
    private const string _contentDescendantsByRouteSnapshotPath = $"{SnapshotConstants.AuthBasePath}/ContentDescendantsByRoute";

    [Theory]
    [InlineData("test-1", "https://site-1.com", "/", "default", 1, 2, "en-US", false, null, true, ContentDescendantsByRouteQuery.ClaimValue)]
    [InlineData("test-2", "https://site-1.com", "/", "default", 1, 2, "en-US", false, null, true, DefaultClaimValues.GlobalContentRead)]
    [InlineData("test-3", "https://site-1.com", "/", "default", 1, 2, "en-US", false, null, true, "Invalid")]
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
        bool expectSuccess,
        params string[] claims)
    {
        var snapshotProvider = new SnapshotProvider($"{_contentDescendantsByRouteSnapshotPath}/Snaps");
        HttpClient client = _factory.CreateClient();

        JwtToken token = await CreateTokenMutation_Async(client, new TokenClaim() { Name = DefaultClaims.UHeadlessScope, Value = claims }).ConfigureAwait(true);

        client.DefaultRequestHeaders.Add(token.Header, token.Prefix + token.Token);

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
