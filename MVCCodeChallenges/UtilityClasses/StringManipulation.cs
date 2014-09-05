
namespace MVCCodeChallenges.UtilityClasses
{
    public static class StringManipulation
    {
        public static string ConvertNewLinesToHtmlLineBreaksPreserveSpace(this string str)
        {
            return str.Replace("\r\n", "<br/>")
                    .Replace("\r", "<br/>")
                    .Replace("\n", "<br/>")
                    .Replace("  ", "&nbsp;");
        }
    }
}