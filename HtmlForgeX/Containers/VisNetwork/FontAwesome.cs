using System.ComponentModel;

namespace HtmlForgeX;

/// <summary>
/// FontAwesome icon enum for easy icon selection in VisNetwork components.
/// Contains commonly used FontAwesome icons with their Unicode values.
/// </summary>
public enum FontAwesome {
    // Server & Infrastructure
    /// <summary>
    /// Server/host computer icon
    /// </summary>
    [Description("\uf233")]
    Server,

    /// <summary>
    /// Database/data storage icon
    /// </summary>
    [Description("\uf1c0")]
    Database,

    /// <summary>
    /// Cloud computing/storage icon
    /// </summary>
    [Description("\uf0c2")]
    Cloud,

    /// <summary>
    /// Sitemap/diagram icon
    /// </summary>
    [Description("\uf0e8")]
    Sitemap,

    /// <summary>
    /// Building or office icon
    /// </summary>
    [Description("\uf1ad")]
    Building,

    /// <summary>
    /// Hard disk drive icon
    /// </summary>
    [Description("\uf1fe")]
    Hdd,

    // Users & People
    /// <summary>
    /// Single user/person icon
    /// </summary>
    [Description("\uf007")]
    User,

    /// <summary>
    /// Multiple users/group icon
    /// </summary>
    [Description("\uf0c0")]
    Users,

    /// <summary>
    /// User profile circle icon
    /// </summary>
    [Description("\uf2bd")]
    UserCircle,

    /// <summary>
    /// User wearing a tie icon
    /// </summary>
    [Description("\uf508")]
    UserTie,

    /// <summary>
    /// Disabled user icon
    /// </summary>
    [Description("\uf2c0")]
    UserTimes,

    /// <summary>
    /// Add user icon
    /// </summary>
    [Description("\uf234")]
    UserPlus,

    // Security & Lock
    /// <summary>
    /// Padlock/security lock icon
    /// </summary>
    [Description("\uf023")]
    Lock,

    /// <summary>
    /// Unlocked padlock icon
    /// </summary>
    [Description("\uf09c")]
    Unlock,

    /// <summary>
    /// Shield icon
    /// </summary>
    [Description("\uf132")]
    Shield,

    /// <summary>
    /// Alternate shield icon
    /// </summary>
    [Description("\uf2f6")]
    ShieldAlt,

    /// <summary>
    /// Key icon
    /// </summary>
    [Description("\uf084")]
    Key,

    /// <summary>
    /// Secret agent/user icon
    /// </summary>
    [Description("\uf21b")]
    UserSecret,

    // Network & Connectivity
    /// <summary>
    /// Wi-Fi icon
    /// </summary>
    [Description("\uf0e3")]
    Wifi,

    /// <summary>
    /// Wi-Fi signal icon
    /// </summary>
    [Description("\uf1eb")]
    Wifi3,

    /// <summary>
    /// Electrical plug icon
    /// </summary>
    [Description("\uf1e6")]
    Plug,

    /// <summary>
    /// Globe/Internet icon
    /// </summary>
    [Description("\uf124")]
    Globe,

    /// <summary>
    /// Network icon
    /// </summary>
    [Description("\uf0ac")]
    Network,

    /// <summary>
    /// Ethernet port icon
    /// </summary>
    [Description("\uf362")]
    Ethernet,

    // Technology & Devices
    /// <summary>
    /// Desktop computer icon
    /// </summary>
    [Description("\uf108")]
    Desktop,

    /// <summary>
    /// Laptop computer icon
    /// </summary>
    [Description("\uf109")]
    Laptop,

    /// <summary>
    /// Tablet device icon
    /// </summary>
    [Description("\uf10a")]
    Tablet,

    /// <summary>
    /// Mobile phone icon
    /// </summary>
    [Description("\uf10b")]
    Mobile,

    /// <summary>
    /// Traditional phone icon
    /// </summary>
    [Description("\uf110")]
    Phone,

    /// <summary>
    /// Square phone icon
    /// </summary>
    [Description("\uf095")]
    PhoneSquare,

    // Storage & Files
    /// <summary>
    /// Folder icon
    /// </summary>
    [Description("\uf07b")]
    Folder,

    /// <summary>
    /// Open folder icon
    /// </summary>
    [Description("\uf07c")]
    FolderOpen,

    /// <summary>
    /// File icon
    /// </summary>
    [Description("\uf15b")]
    File,

    /// <summary>
    /// Blank file icon
    /// </summary>
    [Description("\uf1c6")]
    FileO,

    /// <summary>
    /// Copy icon
    /// </summary>
    [Description("\uf0c5")]
    Copy,

    /// <summary>
    /// Download icon
    /// </summary>
    [Description("\uf019")]
    Download,

    // System & Settings
    /// <summary>
    /// Gear/settings icon
    /// </summary>
    [Description("\uf013")]
    Gear,

    /// <summary>
    /// Multiple gears icon
    /// </summary>
    [Description("\uf085")]
    Cogs,

    /// <summary>
    /// Slider controls icon
    /// </summary>
    [Description("\uf1de")]
    Sliders,

    /// <summary>
    /// Menu bars icon
    /// </summary>
    [Description("\uf0c9")]
    Menu,

    /// <summary>
    /// Horizontal ellipsis icon
    /// </summary>
    [Description("\uf141")]
    EllipsisH,

    /// <summary>
    /// Vertical ellipsis icon
    /// </summary>
    [Description("\uf142")]
    EllipsisV,

    // Navigation & Arrows
    /// <summary>
    /// Left caret icon
    /// </summary>
    [Description("\uf0d9")]
    CaretLeft,

    /// <summary>
    /// Right caret icon
    /// </summary>
    [Description("\uf0da")]
    CaretRight,

    /// <summary>
    /// Up caret icon
    /// </summary>
    [Description("\uf0d8")]
    CaretUp,

    /// <summary>
    /// Down caret icon
    /// </summary>
    [Description("\uf0d7")]
    CaretDown,

    /// <summary>
    /// Arrow pointing left
    /// </summary>
    [Description("\uf060")]
    ArrowLeft,

    /// <summary>
    /// Arrow pointing right
    /// </summary>
    [Description("\uf061")]
    ArrowRight,

    /// <summary>
    /// Arrow pointing up
    /// </summary>
    [Description("\uf062")]
    ArrowUp,

    /// <summary>
    /// Arrow pointing down
    /// </summary>
    [Description("\uf063")]
    ArrowDown,

    // Communication
    /// <summary>
    /// Email/envelope icon
    /// </summary>
    [Description("\uf0e0")]
    Email,

    /// <summary>
    /// Single comment bubble icon
    /// </summary>
    [Description("\uf086")]
    Comment,

    /// <summary>
    /// Multiple comments icon
    /// </summary>
    [Description("\uf085")]
    Comments,

    /// <summary>
    /// Message bubble icon
    /// </summary>
    [Description("\uf1d8")]
    Message,

    /// <summary>
    /// Alternative phone icon
    /// </summary>
    [Description("\uf095")]
    PhoneAlt,

    /// <summary>
    /// Phone with volume icon
    /// </summary>
    [Description("\uf1d9")]
    PhoneVolume,

    // Status & Indicators
    /// <summary>
    /// Success check icon
    /// </summary>
    [Description("\uf058")]
    CheckCircle,

    /// <summary>
    /// Cancel/error icon
    /// </summary>
    [Description("\uf057")]
    TimesCircle,

    /// <summary>
    /// Warning/alert icon
    /// </summary>
    [Description("\uf071")]
    Warning,

    /// <summary>
    /// Information icon
    /// </summary>
    [Description("\uf06a")]
    Info,

    /// <summary>
    /// Question mark icon
    /// </summary>
    [Description("\uf192")]
    Question,

    /// <summary>
    /// Info circle icon
    /// </summary>
    [Description("\uf05a")]
    InfoCircle,

    // Business & Commerce
    /// <summary>
    /// Money/banknote icon
    /// </summary>
    [Description("\uf0f2")]
    Money,

    /// <summary>
    /// Briefcase icon
    /// </summary>
    [Description("\uf24e")]
    Briefcase,

    /// <summary>
    /// Office building icon
    /// </summary>
    [Description("\uf1ad")]
    Office,

    /// <summary>
    /// Factory/industry icon
    /// </summary>
    [Description("\uf0e6")]
    Industry,

    /// <summary>
    /// Calendar icon
    /// </summary>
    [Description("\uf219")]
    Calendar,

    /// <summary>
    /// Clock/time icon
    /// </summary>
    [Description("\uf1ec")]
    Clock,

    // Analytics & Charts
    /// <summary>
    /// Bar chart icon
    /// </summary>
    [Description("\uf080")]
    BarChart,

    /// <summary>
    /// Line chart icon
    /// </summary>
    [Description("\uf201")]
    LineChart,

    /// <summary>
    /// Pie chart icon
    /// </summary>
    [Description("\uf200")]
    PieChart,

    /// <summary>
    /// Area chart icon
    /// </summary>
    [Description("\uf1fe")]
    AreaChart,

    /// <summary>
    /// Dashboard icon
    /// </summary>
    [Description("\uf0e4")]
    Dashboard,

    /// <summary>
    /// Trending up icon
    /// </summary>
    [Description("\uf24d")]
    TrendingUp,

    // Search & Discovery
    /// <summary>
    /// Search icon
    /// </summary>
    [Description("\uf002")]
    Search,

    /// <summary>
    /// Zoom in icon
    /// </summary>
    [Description("\uf00e")]
    SearchPlus,

    /// <summary>
    /// Zoom out icon
    /// </summary>
    [Description("\uf010")]
    SearchMinus,

    /// <summary>
    /// Binoculars icon
    /// </summary>
    [Description("\uf1e5")]
    Binoculars,

    /// <summary>
    /// Eye view icon
    /// </summary>
    [Description("\uf06e")]
    Eye,

    /// <summary>
    /// Hidden eye icon
    /// </summary>
    [Description("\uf070")]
    EyeSlash,

    // Actions & Controls
    /// <summary>
    /// Play icon
    /// </summary>
    [Description("\uf04b")]
    Play,

    /// <summary>
    /// Pause icon
    /// </summary>
    [Description("\uf04c")]
    Pause,

    /// <summary>
    /// Stop icon
    /// </summary>
    [Description("\uf04d")]
    Stop,

    /// <summary>
    /// Refresh/reload icon
    /// </summary>
    [Description("\uf021")]
    Refresh,

    /// <summary>
    /// Plus/add icon
    /// </summary>
    [Description("\uf067")]
    Plus,

    /// <summary>
    /// Minus/remove icon
    /// </summary>
    [Description("\uf068")]
    Minus,

    // Location & Maps
    /// <summary>
    /// Map marker icon
    /// </summary>
    [Description("\uf041")]
    MapMarker,

    /// <summary>
    /// Map pin icon
    /// </summary>
    [Description("\uf5a0")]
    MapPin,

    /// <summary>
    /// Map icon
    /// </summary>
    [Description("\uf279")]
    Map,

    /// <summary>
    /// Globe icon variant
    /// </summary>
    [Description("\uf0ac")]
    Globe2,

    /// <summary>
    /// Location icon
    /// </summary>
    [Description("\uf1b9")]
    Location,

    /// <summary>
    /// Location arrow icon
    /// </summary>
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