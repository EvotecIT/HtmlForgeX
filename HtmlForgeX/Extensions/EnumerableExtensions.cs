namespace HtmlForgeX.Extensions;

internal static class EnumerableExtensions {
    public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T> source) {
        return source.Where(item => item is not null)!;
    }
}