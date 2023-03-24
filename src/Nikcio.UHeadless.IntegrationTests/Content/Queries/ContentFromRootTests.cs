using System.Net;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Umbraco.Cms.Core.Services;

namespace Nikcio.UHeadless.IntegrationTests.Content.Queries;

[TestFixture]
public class ContentFromRootTests : IntegrationTestBase
{
    public partial class ContentAtRootData
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public partial class Data
    {
        [JsonProperty("contentAtRoot")]
        public ContentAtRoot ContentAtRoot { get; set; }
    }

    public partial class ContentAtRoot
    {
        [JsonProperty("nodes")]
        public Node[] Nodes { get; set; }
    }

    public partial class Node
    {
        [JsonProperty("id")]
        public long Id { get; set; }
    }

    [Test]
    public async Task General_GetContentFromRoot_Test()
    {
        var setup = new Setup();

        var query = 
        """"
        {
            "query": "{\n  contentAtRoot {\n    nodes {\n      name\n      creatorId\n      writerId\n      properties {\n        alias\n      }\n      itemType\n      level\n      parent {\n        name\n      }\n      redirect {\n        redirectUrl\n      }\n      sortOrder\n      templateId\n      url\n      urlSegment\n      absoluteUrl\n      children {\n        name\n        creatorId\n        writerId\n        properties {\n          alias\n        }\n        itemType\n        level\n        parent {\n          name\n        }\n        redirect {\n          redirectUrl\n        }\n        sortOrder\n        templateId\n        url\n        urlSegment\n        absoluteUrl\n      }\n    }\n  }\n}\n"
        }
        """";
        
        var expectedResult = 
        """"
        {"data":{"contentAtRoot":{"nodes":[{"name":"Site 1","creatorId":-1,"writerId":-1,"properties":[],"itemType":"CONTENT","level":1,"parent":null,"redirect":null,"sortOrder":0,"templateId":null,"url":"http://site-1.com/","urlSegment":"site-1","absoluteUrl":"http://site-1.com/","children":[{"name":"Homepage","creatorId":-1,"writerId":-1,"properties":[{"alias":"blockList"},{"alias":"checkboxList"},{"alias":"colorPicker"},{"alias":"contentPicker"},{"alias":"datePicker"},{"alias":"datePickerWithTime"},{"alias":"decimal"},{"alias":"dropdown"},{"alias":"emailAddress"},{"alias":"eyeDropperColorPicker"},{"alias":"article"},{"alias":"audio"},{"alias":"file"},{"alias":"svg"},{"alias":"video"},{"alias":"imageCropper"},{"alias":"markdown"},{"alias":"imageMediaPicker"},{"alias":"mediaPicker"},{"alias":"multipleImageMediaPicker"},{"alias":"multipleMediaPicker"},{"alias":"mediaPickerLegacy"},{"alias":"multipleMediaPickerLegacy"},{"alias":"memberGroupPicker"},{"alias":"memberPicker"},{"alias":"multinodeTreepicker"},{"alias":"multiUrlPicker"},{"alias":"numeric"},{"alias":"radiobox"},{"alias":"repeatableTextstrings"},{"alias":"richtext"},{"alias":"slider"},{"alias":"tags"},{"alias":"textarea"},{"alias":"textstring"},{"alias":"trueOrFalse"},{"alias":"userPicker"}],"itemType":"CONTENT","level":2,"parent":{"name":"Site 1"},"redirect":null,"sortOrder":0,"templateId":null,"url":"http://site-1.com/homepage/","urlSegment":"homepage","absoluteUrl":"http://site-1.com/homepage/"},{"name":"Page 1","creatorId":-1,"writerId":-1,"properties":[{"alias":"blockList"},{"alias":"checkboxList"},{"alias":"colorPicker"},{"alias":"contentPicker"},{"alias":"datePicker"},{"alias":"datePickerWithTime"},{"alias":"decimal"},{"alias":"dropdown"},{"alias":"emailAddress"},{"alias":"eyeDropperColorPicker"},{"alias":"article"},{"alias":"audio"},{"alias":"file"},{"alias":"svg"},{"alias":"video"},{"alias":"imageCropper"},{"alias":"markdown"},{"alias":"imageMediaPicker"},{"alias":"mediaPicker"},{"alias":"multipleImageMediaPicker"},{"alias":"multipleMediaPicker"},{"alias":"mediaPickerLegacy"},{"alias":"multipleMediaPickerLegacy"},{"alias":"memberGroupPicker"},{"alias":"memberPicker"},{"alias":"multinodeTreepicker"},{"alias":"multiUrlPicker"},{"alias":"numeric"},{"alias":"radiobox"},{"alias":"repeatableTextstrings"},{"alias":"richtext"},{"alias":"slider"},{"alias":"tags"},{"alias":"textarea"},{"alias":"textstring"},{"alias":"trueOrFalse"},{"alias":"userPicker"}],"itemType":"CONTENT","level":2,"parent":{"name":"Site 1"},"redirect":null,"sortOrder":1,"templateId":null,"url":"http://site-1.com/page-1/","urlSegment":"page-1","absoluteUrl":"http://site-1.com/page-1/"},{"name":"Page 2","creatorId":-1,"writerId":-1,"properties":[{"alias":"blockList"},{"alias":"checkboxList"},{"alias":"colorPicker"},{"alias":"contentPicker"},{"alias":"datePicker"},{"alias":"datePickerWithTime"},{"alias":"decimal"},{"alias":"dropdown"},{"alias":"emailAddress"},{"alias":"eyeDropperColorPicker"},{"alias":"article"},{"alias":"audio"},{"alias":"file"},{"alias":"svg"},{"alias":"video"},{"alias":"imageCropper"},{"alias":"markdown"},{"alias":"imageMediaPicker"},{"alias":"mediaPicker"},{"alias":"multipleImageMediaPicker"},{"alias":"multipleMediaPicker"},{"alias":"mediaPickerLegacy"},{"alias":"multipleMediaPickerLegacy"},{"alias":"memberGroupPicker"},{"alias":"memberPicker"},{"alias":"multinodeTreepicker"},{"alias":"multiUrlPicker"},{"alias":"numeric"},{"alias":"radiobox"},{"alias":"repeatableTextstrings"},{"alias":"richtext"},{"alias":"slider"},{"alias":"tags"},{"alias":"textarea"},{"alias":"textstring"},{"alias":"trueOrFalse"},{"alias":"userPicker"}],"itemType":"CONTENT","level":2,"parent":{"name":"Site 1"},"redirect":null,"sortOrder":2,"templateId":null,"url":"http://site-1.com/page-2/","urlSegment":"page-2","absoluteUrl":"http://site-1.com/page-2/"},{"name":"Collection of pages","creatorId":-1,"writerId":-1,"properties":[{"alias":"blockList"},{"alias":"checkboxList"},{"alias":"colorPicker"},{"alias":"contentPicker"},{"alias":"datePicker"},{"alias":"datePickerWithTime"},{"alias":"decimal"},{"alias":"dropdown"},{"alias":"emailAddress"},{"alias":"eyeDropperColorPicker"},{"alias":"article"},{"alias":"audio"},{"alias":"file"},{"alias":"svg"},{"alias":"video"},{"alias":"imageCropper"},{"alias":"markdown"},{"alias":"imageMediaPicker"},{"alias":"mediaPicker"},{"alias":"multipleImageMediaPicker"},{"alias":"multipleMediaPicker"},{"alias":"mediaPickerLegacy"},{"alias":"multipleMediaPickerLegacy"},{"alias":"memberGroupPicker"},{"alias":"memberPicker"},{"alias":"multinodeTreepicker"},{"alias":"multiUrlPicker"},{"alias":"numeric"},{"alias":"radiobox"},{"alias":"repeatableTextstrings"},{"alias":"richtext"},{"alias":"slider"},{"alias":"tags"},{"alias":"textarea"},{"alias":"textstring"},{"alias":"trueOrFalse"},{"alias":"userPicker"}],"itemType":"CONTENT","level":2,"parent":{"name":"Site 1"},"redirect":null,"sortOrder":3,"templateId":null,"url":"http://site-1.com/collection-of-pages/","urlSegment":"collection-of-pages","absoluteUrl":"http://site-1.com/collection-of-pages/"}]},{"name":"No domain site","creatorId":-1,"writerId":-1,"properties":[],"itemType":"CONTENT","level":1,"parent":null,"redirect":null,"sortOrder":1,"templateId":null,"url":"/no-domain-site/","urlSegment":"no-domain-site","absoluteUrl":"http://localhost/no-domain-site/","children":[{"name":"No domain homepage","creatorId":-1,"writerId":-1,"properties":[{"alias":"blockList"},{"alias":"checkboxList"},{"alias":"colorPicker"},{"alias":"contentPicker"},{"alias":"datePicker"},{"alias":"datePickerWithTime"},{"alias":"decimal"},{"alias":"dropdown"},{"alias":"emailAddress"},{"alias":"eyeDropperColorPicker"},{"alias":"article"},{"alias":"audio"},{"alias":"file"},{"alias":"svg"},{"alias":"video"},{"alias":"imageCropper"},{"alias":"markdown"},{"alias":"imageMediaPicker"},{"alias":"mediaPicker"},{"alias":"multipleImageMediaPicker"},{"alias":"multipleMediaPicker"},{"alias":"mediaPickerLegacy"},{"alias":"multipleMediaPickerLegacy"},{"alias":"memberGroupPicker"},{"alias":"memberPicker"},{"alias":"multinodeTreepicker"},{"alias":"multiUrlPicker"},{"alias":"numeric"},{"alias":"radiobox"},{"alias":"repeatableTextstrings"},{"alias":"richtext"},{"alias":"slider"},{"alias":"tags"},{"alias":"textarea"},{"alias":"textstring"},{"alias":"trueOrFalse"},{"alias":"userPicker"}],"itemType":"CONTENT","level":2,"parent":{"name":"No domain site"},"redirect":null,"sortOrder":0,"templateId":null,"url":"/no-domain-homepage/","urlSegment":"no-domain-homepage","absoluteUrl":"http://localhost/no-domain-homepage/"},{"name":"Page 1","creatorId":-1,"writerId":-1,"properties":[{"alias":"blockList"},{"alias":"checkboxList"},{"alias":"colorPicker"},{"alias":"contentPicker"},{"alias":"datePicker"},{"alias":"datePickerWithTime"},{"alias":"decimal"},{"alias":"dropdown"},{"alias":"emailAddress"},{"alias":"eyeDropperColorPicker"},{"alias":"article"},{"alias":"audio"},{"alias":"file"},{"alias":"svg"},{"alias":"video"},{"alias":"imageCropper"},{"alias":"markdown"},{"alias":"imageMediaPicker"},{"alias":"mediaPicker"},{"alias":"multipleImageMediaPicker"},{"alias":"multipleMediaPicker"},{"alias":"mediaPickerLegacy"},{"alias":"multipleMediaPickerLegacy"},{"alias":"memberGroupPicker"},{"alias":"memberPicker"},{"alias":"multinodeTreepicker"},{"alias":"multiUrlPicker"},{"alias":"numeric"},{"alias":"radiobox"},{"alias":"repeatableTextstrings"},{"alias":"richtext"},{"alias":"slider"},{"alias":"tags"},{"alias":"textarea"},{"alias":"textstring"},{"alias":"trueOrFalse"},{"alias":"userPicker"}],"itemType":"CONTENT","level":2,"parent":{"name":"No domain site"},"redirect":null,"sortOrder":1,"templateId":null,"url":"/page-1/","urlSegment":"page-1","absoluteUrl":"http://localhost/page-1/"},{"name":"Page 2","creatorId":-1,"writerId":-1,"properties":[{"alias":"blockList"},{"alias":"checkboxList"},{"alias":"colorPicker"},{"alias":"contentPicker"},{"alias":"datePicker"},{"alias":"datePickerWithTime"},{"alias":"decimal"},{"alias":"dropdown"},{"alias":"emailAddress"},{"alias":"eyeDropperColorPicker"},{"alias":"article"},{"alias":"audio"},{"alias":"file"},{"alias":"svg"},{"alias":"video"},{"alias":"imageCropper"},{"alias":"markdown"},{"alias":"imageMediaPicker"},{"alias":"mediaPicker"},{"alias":"multipleImageMediaPicker"},{"alias":"multipleMediaPicker"},{"alias":"mediaPickerLegacy"},{"alias":"multipleMediaPickerLegacy"},{"alias":"memberGroupPicker"},{"alias":"memberPicker"},{"alias":"multinodeTreepicker"},{"alias":"multiUrlPicker"},{"alias":"numeric"},{"alias":"radiobox"},{"alias":"repeatableTextstrings"},{"alias":"richtext"},{"alias":"slider"},{"alias":"tags"},{"alias":"textarea"},{"alias":"textstring"},{"alias":"trueOrFalse"},{"alias":"userPicker"}],"itemType":"CONTENT","level":2,"parent":{"name":"No domain site"},"redirect":null,"sortOrder":2,"templateId":null,"url":"/page-2/","urlSegment":"page-2","absoluteUrl":"http://localhost/page-2/"},{"name":"Page 3","creatorId":-1,"writerId":-1,"properties":[{"alias":"blockList"},{"alias":"checkboxList"},{"alias":"colorPicker"},{"alias":"contentPicker"},{"alias":"datePicker"},{"alias":"datePickerWithTime"},{"alias":"decimal"},{"alias":"dropdown"},{"alias":"emailAddress"},{"alias":"eyeDropperColorPicker"},{"alias":"article"},{"alias":"audio"},{"alias":"file"},{"alias":"svg"},{"alias":"video"},{"alias":"imageCropper"},{"alias":"markdown"},{"alias":"imageMediaPicker"},{"alias":"mediaPicker"},{"alias":"multipleImageMediaPicker"},{"alias":"multipleMediaPicker"},{"alias":"mediaPickerLegacy"},{"alias":"multipleMediaPickerLegacy"},{"alias":"memberGroupPicker"},{"alias":"memberPicker"},{"alias":"multinodeTreepicker"},{"alias":"multiUrlPicker"},{"alias":"numeric"},{"alias":"radiobox"},{"alias":"repeatableTextstrings"},{"alias":"richtext"},{"alias":"slider"},{"alias":"tags"},{"alias":"textarea"},{"alias":"textstring"},{"alias":"trueOrFalse"},{"alias":"userPicker"}],"itemType":"CONTENT","level":2,"parent":{"name":"No domain site"},"redirect":null,"sortOrder":3,"templateId":null,"url":"/page-3/","urlSegment":"page-3","absoluteUrl":"http://localhost/page-3/"}]},{"name":"Site 2","creatorId":-1,"writerId":-1,"properties":[],"itemType":"CONTENT","level":1,"parent":null,"redirect":null,"sortOrder":2,"templateId":null,"url":"http://site-2.dk/","urlSegment":"site-2","absoluteUrl":"http://site-2.dk/","children":[{"name":"Page 1","creatorId":-1,"writerId":-1,"properties":[{"alias":"blockList"},{"alias":"checkboxList"},{"alias":"colorPicker"},{"alias":"contentPicker"},{"alias":"datePicker"},{"alias":"datePickerWithTime"},{"alias":"decimal"},{"alias":"dropdown"},{"alias":"emailAddress"},{"alias":"eyeDropperColorPicker"},{"alias":"article"},{"alias":"audio"},{"alias":"file"},{"alias":"svg"},{"alias":"video"},{"alias":"imageCropper"},{"alias":"markdown"},{"alias":"imageMediaPicker"},{"alias":"mediaPicker"},{"alias":"multipleImageMediaPicker"},{"alias":"multipleMediaPicker"},{"alias":"mediaPickerLegacy"},{"alias":"multipleMediaPickerLegacy"},{"alias":"memberGroupPicker"},{"alias":"memberPicker"},{"alias":"multinodeTreepicker"},{"alias":"multiUrlPicker"},{"alias":"numeric"},{"alias":"radiobox"},{"alias":"repeatableTextstrings"},{"alias":"richtext"},{"alias":"slider"},{"alias":"tags"},{"alias":"textarea"},{"alias":"textstring"},{"alias":"trueOrFalse"},{"alias":"userPicker"}],"itemType":"CONTENT","level":2,"parent":{"name":"Site 2"},"redirect":null,"sortOrder":0,"templateId":null,"url":"http://site-2.dk/page-1/","urlSegment":"page-1","absoluteUrl":"http://site-2.dk/page-1/"}]}]}}}
        """"; 

        var response = await setup.GetQuery(query);

        Assert.That(response.ResponseMessage.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Response, Is.EqualTo(expectedResult));
    }

    [Test]
    public async Task GetContentFromRoot_Id_Test()
    {
        var setup = new Setup();

        var query =
        """"
        {
            "query" : "{ contentAtRoot { nodes { id }}}"
        }
        """";

        var response = await setup.GetQuery(query);

        Assert.That(response.ResponseMessage.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Response, Is.Not.Empty);
        Assert.That(response.TypedResponse<ContentAtRootData>().Data.ContentAtRoot.Nodes[0].Id, Is.GreaterThan(0));
    }
}