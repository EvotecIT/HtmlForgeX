using HtmlForgeX.Resources;

namespace HtmlForgeX;

internal static class GlobalStorage {
    internal static LibraryMode LibraryMode { get; set; } = LibraryMode.Online;
    internal static HashSet<Libraries> Libraries { get; } = new HashSet<Libraries>();
    internal static List<string> Errors { get; } = new List<string>();


    internal static string GenerateRandomId(string preText) {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var random = new Random();
        var randomId = new string(Enumerable.Repeat(chars, 5)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        return $"{preText}-{randomId}";
    }
}