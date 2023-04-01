using Newtonsoft.Json;
using StrawberryShake;

namespace Nikcio.UHeadless.IntegrationTests.Extensions;

public static class StrawberryShakeExtensions {
    public static void EnsureNoErrors(this IReadOnlyList<IClientError> errors){
        if(errors.Any()){
            throw new Exception(JsonConvert.SerializeObject(errors));
        }
        
        Assert.That(errors, Is.Empty);
    }
}