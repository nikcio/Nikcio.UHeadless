using System;

namespace Nikcio.Umbraco.Headless.Core.Attributes
{

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public sealed class JsonIgnoreProperty : Attribute
    {
        public JsonIgnoreProperty(string propertyName)
        {
            PropertyName = propertyName;
        }

        public string PropertyName { get; }
    }
}
