namespace HtmlForgeX.Extensions;

internal static class EnumerableExtensions
{
    public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T?> source) where T : class
    {
        return source.Where(item => item is not null)!;
    }
}
