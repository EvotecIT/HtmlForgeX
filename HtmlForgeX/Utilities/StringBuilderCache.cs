namespace HtmlForgeX;

internal static class StringBuilderCache {
    [ThreadStatic]
    private static StringBuilder? _cachedInstance;

    internal const int DefaultCapacity = 256;
    internal const int MaxBuilderSize = 4096;

    public static StringBuilder Acquire() {
        var sb = _cachedInstance;
        if (sb == null) {
            return new StringBuilder(DefaultCapacity);
        }
        _cachedInstance = null;
        sb.Clear();
        if (sb.Capacity < DefaultCapacity) {
            sb.EnsureCapacity(DefaultCapacity);
        }
        return sb;
    }

    public static string GetStringAndRelease(StringBuilder sb) {
        var result = sb.ToString();
        Release(sb);
        return result;
    }

    public static void Release(StringBuilder sb) {
        if (sb.Capacity <= MaxBuilderSize) {
            _cachedInstance = sb;
        }
    }
}