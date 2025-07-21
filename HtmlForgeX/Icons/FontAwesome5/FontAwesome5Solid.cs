namespace HtmlForgeX;

/// <summary>
/// Font Awesome 5 Solid icons for use with VisNetwork and other components that require Font Awesome 5
/// </summary>
public enum FontAwesome5Solid {
    /// <summary>Server icon (fa-server)</summary>
    Server = 0xf233,
    /// <summary>Database icon (fa-database)</summary>
    Database = 0xf1c0,
    /// <summary>Users icon (fa-users)</summary>
    Users = 0xf0c0,
    /// <summary>Cloud icon (fa-cloud)</summary>
    Cloud = 0xf0c2,
    /// <summary>Lock icon (fa-lock)</summary>
    Lock = 0xf023,
    /// <summary>User icon (fa-user)</summary>
    User = 0xf007,
    /// <summary>Cog/Settings icon (fa-cog)</summary>
    Cog = 0xf013,
    /// <summary>Home icon (fa-home)</summary>
    Home = 0xf015,
    /// <summary>Chart Bar icon (fa-chart-bar)</summary>
    ChartBar = 0xf080,
    /// <summary>Envelope icon (fa-envelope)</summary>
    Envelope = 0xf0e0,
    /// <summary>Phone icon (fa-phone)</summary>
    Phone = 0xf095,
    /// <summary>Globe icon (fa-globe)</summary>
    Globe = 0xf0ac,
    /// <summary>Shield Alt icon (fa-shield-alt)</summary>
    ShieldAlt = 0xf3ed,
    /// <summary>Check icon (fa-check)</summary>
    Check = 0xf00c,
    /// <summary>Times/Close icon (fa-times)</summary>
    Times = 0xf00d
}

/// <summary>
/// Extension methods for FontAwesome5Solid icons
/// </summary>
public static class FontAwesome5SolidExtensions {
    /// <summary>
    /// Gets the Unicode character code for the icon
    /// </summary>
    public static string GetCode(this FontAwesome5Solid icon) {
        return char.ConvertFromUtf32((int)icon);
    }
}