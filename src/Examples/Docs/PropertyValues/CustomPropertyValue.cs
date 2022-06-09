namespace Examples.Docs.PropertyValues {
    public class CustomPropertyValue : PropertyValue {

        public string Name { get; set; }

        public CustomPropertyValue(CreatePropertyValue createPropertyValue) : base(createPropertyValue) {
            Name = (string) createPropertyValue.Property.GetValue(createPropertyValue.Culture);
        }
    }
}
