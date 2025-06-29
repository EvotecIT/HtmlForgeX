namespace HtmlForgeX;

internal static class StringBuilderCache {
    [ThreadStatic]
    private static StringBuilder? _cachedInstance;

    public static StringBuilder Acquire() {
        var sb = _cachedInstance;
        if (sb == null) {
            return new StringBuilder();
        }
        _cachedInstance = null;
        sb.Clear();
        return sb;
    }

    public static string GetStringAndRelease(StringBuilder sb) {
        var result = sb.ToString();
        Release(sb);
        return result;
    }

    public static void Release(StringBuilder sb) {
        if (sb.Capacity <= 360) {
            _cachedInstance = sb;
        }
    }
}
