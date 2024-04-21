namespace HtmlForgeX;

public enum HeaderLevelTag {
    H1,
    H2,
    H3,
    H4,
    H5,
    H6
}

public static class HeaderLevelTagExtensions {
    public static string EnumToString(this HeaderLevelTag tag) {
        return tag.ToString().ToLower();
    }
}