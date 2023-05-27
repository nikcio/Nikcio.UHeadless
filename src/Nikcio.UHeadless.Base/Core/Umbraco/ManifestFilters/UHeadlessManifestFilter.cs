using System.Diagnostics;
using System.Reflection;
using Umbraco.Cms.Core.Manifest;

namespace Nikcio.UHeadless.Core.Umbraco.ManifestFilters;

internal class UHeadlessManifestFilter : IManifestFilter
{
    public void Filter(List<PackageManifest> manifests)
    {
        var assembly = Assembly.GetExecutingAssembly();
        manifests.Add(new PackageManifest
        {
            PackageName = "Nikcío.UHeadless",
            Version = assembly != null ? FileVersionInfo.GetVersionInfo(assembly.Location).ProductVersion?.ToString() ?? "Unknown" : "Unknown"
        });
    }
}