using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.umbraco.models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace TestProject.NewModels
{
    public class TestModel : Test
    {
        public new string Text { get; }

        public TestModel(IPublishedContent content, IPublishedValueFallback publishedValueFallback) : base(content, publishedValueFallback)
        {
            Text = "HELLO";
        }
    }
}
