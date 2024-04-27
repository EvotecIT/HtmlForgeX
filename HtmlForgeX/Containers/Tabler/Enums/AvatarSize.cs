namespace HtmlForgeX;

public enum AvatarSize {
    XS,
    SM,
    MD,
    LG,
    XL
}

public static class AvatarSizeExtensions {
    public static string EnumToString(this AvatarSize size) {
        return "avatar-" + size.ToString().ToLower();
    }
}
