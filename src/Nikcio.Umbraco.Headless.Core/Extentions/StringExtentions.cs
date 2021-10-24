namespace Nikcio.Umbraco.Headless.Core.Extentions
{
    public static class StringExtentions
    {
        public static string ToCamleCase(this string str)
        {
            if (string.IsNullOrEmpty(str) || char.IsLower(str, 0))
            {
                return str;
            }

            return char.ToLowerInvariant(str[0]) + str[1..];
        }
    }
}
