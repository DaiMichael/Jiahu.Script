namespace JiahuScriptRuntime.Utilities.Extensions
{
    public static class StringExtention
    {
        private const string SingleQuote = "\'";
        private const string DoubleQuote = "\"";

        public static string RemoveQuotes(this string quotedString)
        {
            if (quotedString.Length < 3)
            {
                return quotedString;
            }

            if (quotedString.StartsWith(DoubleQuote) || quotedString.StartsWith(SingleQuote))
            {
                quotedString = quotedString.Substring(1, quotedString.Length-1);
            }

            if (quotedString.EndsWith(DoubleQuote) || quotedString.EndsWith(SingleQuote))
            {
                quotedString = quotedString.Substring(0, quotedString.Length-1);
            }

            return quotedString;
        }

        public static bool HasQuotes(this string value)
        {
            return value.Contains(SingleQuote) || value.Contains(DoubleQuote);
        }
    }
}
