using System.Text.RegularExpressions;

namespace HtmlForgeX;

internal static class HtmlSanitizer {
    private static readonly Regex ScriptTagRegex = new("<script.*?>.*?</script>", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);

    public static string Sanitize(string? html) {
        if (string.IsNullOrEmpty(html)) {
            return string.Empty;
        }

        return ScriptTagRegex.Replace(html, string.Empty);
    }
}