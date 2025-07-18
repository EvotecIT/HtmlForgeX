using System.ComponentModel;

namespace HtmlForgeX;

/// <summary>
/// FontAwesome icon enum for easy icon selection in VisNetwork components.
/// Contains commonly used FontAwesome icons with their Unicode values.
/// </summary>
public enum FontAwesome {
    // Server & Infrastructure
    [Description("\uf233")]
    Server,

    [Description("\uf1c0")]
    Database,

    [Description("\uf0c2")]
    Cloud,

    [Description("\uf0e8")]
    Sitemap,

    [Description("\uf1ad")]
    Building,

    [Description("\uf1fe")]
    Hdd,

    // Users & People
    [Description("\uf007")]
    User,

    [Description("\uf0c0")]
    Users,

    [Description("\uf2bd")]
    UserCircle,

    [Description("\uf508")]
    UserTie,

    [Description("\uf2c0")]
    UserTimes,

    [Description("\uf234")]
    UserPlus,

    // Security & Lock
    [Description("\uf023")]
    Lock,

    [Description("\uf09c")]
    Unlock,

    [Description("\uf132")]
    Shield,

    [Description("\uf2f6")]
    ShieldAlt,

    [Description("\uf084")]
    Key,

    [Description("\uf21b")]
    UserSecret,

    // Network & Connectivity
    [Description("\uf0e3")]
    Wifi,

    [Description("\uf1eb")]
    Wifi3,

    [Description("\uf1e6")]
    Plug,

    [Description("\uf124")]
    Globe,

    [Description("\uf0ac")]
    Network,

    [Description("\uf362")]
    Ethernet,

    // Technology & Devices
    [Description("\uf108")]
    Desktop,

    [Description("\uf109")]
    Laptop,

    [Description("\uf10a")]
    Tablet,

    [Description("\uf10b")]
    Mobile,

    [Description("\uf110")]
    Phone,

    [Description("\uf095")]
    PhoneSquare,

    // Storage & Files
    [Description("\uf07b")]
    Folder,

    [Description("\uf07c")]
    FolderOpen,

    [Description("\uf15b")]
    File,

    [Description("\uf1c6")]
    FileO,

    [Description("\uf0c5")]
    Copy,

    [Description("\uf019")]
    Download,

    // System & Settings
    [Description("\uf013")]
    Gear,

    [Description("\uf085")]
    Cogs,

    [Description("\uf1de")]
    Sliders,

    [Description("\uf0c9")]
    Menu,

    [Description("\uf141")]
    EllipsisH,

    [Description("\uf142")]
    EllipsisV,

    // Navigation & Arrows
    [Description("\uf0d9")]
    CaretLeft,

    [Description("\uf0da")]
    CaretRight,

    [Description("\uf0d8")]
    CaretUp,

    [Description("\uf0d7")]
    CaretDown,

    [Description("\uf060")]
    ArrowLeft,

    [Description("\uf061")]
    ArrowRight,

    [Description("\uf062")]
    ArrowUp,

    [Description("\uf063")]
    ArrowDown,

    // Communication
    [Description("\uf0e0")]
    Email,

    [Description("\uf086")]
    Comment,

    [Description("\uf085")]
    Comments,

    [Description("\uf1d8")]
    Message,

    [Description("\uf095")]
    PhoneAlt,

    [Description("\uf1d9")]
    PhoneVolume,

    // Status & Indicators
    [Description("\uf058")]
    CheckCircle,

    [Description("\uf057")]
    TimesCircle,

    [Description("\uf071")]
    Warning,

    [Description("\uf06a")]
    Info,

    [Description("\uf192")]
    Question,

    [Description("\uf05a")]
    InfoCircle,

    // Business & Commerce
    [Description("\uf0f2")]
    Money,

    [Description("\uf24e")]
    Briefcase,

    [Description("\uf1ad")]
    Office,

    [Description("\uf0e6")]
    Industry,

    [Description("\uf219")]
    Calendar,

    [Description("\uf1ec")]
    Clock,

    // Analytics & Charts
    [Description("\uf080")]
    BarChart,

    [Description("\uf201")]
    LineChart,

    [Description("\uf200")]
    PieChart,

    [Description("\uf1fe")]
    AreaChart,

    [Description("\uf0e4")]
    Dashboard,

    [Description("\uf24d")]
    TrendingUp,

    // Search & Discovery
    [Description("\uf002")]
    Search,

    [Description("\uf00e")]
    SearchPlus,

    [Description("\uf010")]
    SearchMinus,

    [Description("\uf1e5")]
    Binoculars,

    [Description("\uf06e")]
    Eye,

    [Description("\uf070")]
    EyeSlash,

    // Actions & Controls
    [Description("\uf04b")]
    Play,

    [Description("\uf04c")]
    Pause,

    [Description("\uf04d")]
    Stop,

    [Description("\uf021")]
    Refresh,

    [Description("\uf067")]
    Plus,

    [Description("\uf068")]
    Minus,

    // Location & Maps
    [Description("\uf041")]
    MapMarker,

    [Description("\uf5a0")]
    MapPin,

    [Description("\uf279")]
    Map,

    [Description("\uf0ac")]
    Globe2,

    [Description("\uf1b9")]
    Location,

    [Description("\uf124")]
    LocationArrow
}

/// <summary>
/// Extension methods for FontAwesome enum to get icon codes and descriptions.
/// </summary>
public static class FontAwesomeExtensions {
    /// <summary>
    /// Gets the Unicode character code for the FontAwesome icon.
    /// </summary>
    /// <param name="icon">The FontAwesome icon enum value</param>
    /// <returns>The Unicode string representation of the icon</returns>
    public static string GetCode(this FontAwesome icon) {
        var field = icon.GetType().GetField(icon.ToString());
        if (field != null) {
            var attribute = (DescriptionAttribute?)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
            if (attribute != null) {
                return attribute.Description;
            }
        }
        return string.Empty;
    }

    /// <summary>
    /// Gets the name of the FontAwesome icon as a string.
    /// </summary>
    /// <param name="icon">The FontAwesome icon enum value</param>
    /// <returns>The name of the icon</returns>
    public static string GetName(this FontAwesome icon) {
        return icon.ToString();
    }
}