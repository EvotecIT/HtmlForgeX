using System.ComponentModel;

namespace HtmlForgeX;

/// <summary>
/// FontAwesome Solid icons (fas) - filled icon style
/// Contains the most commonly used solid FontAwesome icons
/// </summary>
public enum FontAwesomeSolid {
    // Navigation & Arrows
    [Description("\uf060")]
    ArrowLeft,
    
    [Description("\uf061")]
    ArrowRight,
    
    [Description("\uf062")]
    ArrowUp,
    
    [Description("\uf063")]
    ArrowDown,
    
    [Description("\uf0d9")]
    CaretLeft,
    
    [Description("\uf0da")]
    CaretRight,
    
    [Description("\uf0d7")]
    CaretDown,
    
    [Description("\uf0d8")]
    CaretUp,
    
    [Description("\uf053")]
    ChevronLeft,
    
    [Description("\uf054")]
    ChevronRight,
    
    [Description("\uf077")]
    ChevronUp,
    
    [Description("\uf078")]
    ChevronDown,
    
    // User & People
    [Description("\uf007")]
    User,
    
    [Description("\uf0c0")]
    Users,
    
    [Description("\uf2bd")]
    UserCircle,
    
    [Description("\uf406")]
    UserAlt,
    
    [Description("\uf4ff")]
    UserCheck,
    
    [Description("\uf506")]
    UserClock,
    
    [Description("\uf507")]
    UserCog,
    
    [Description("\uf508")]
    UserEdit,
    
    [Description("\uf509")]
    UserFriends,
    
    [Description("\uf234")]
    UserPlus,
    
    [Description("\uf235")]
    UserMinus,
    
    [Description("\uf2c0")]
    UserTimes,
    
    [Description("\uf500")]
    UserGraduate,
    
    [Description("\uf0f0")]
    UserMd,
    
    [Description("\uf501")]
    UserNinja,
    
    [Description("\uf21b")]
    UserSecret,
    
    [Description("\uf504")]
    UserShield,
    
    [Description("\uf505")]
    UserSlash,
    
    [Description("\uf4fc")]
    UserTag,
    
    [Description("\uf502")]
    UserTie,
    
    // Actions & Controls
    [Description("\uf00c")]
    Check,
    
    [Description("\uf00d")]
    Times,
    
    [Description("\uf067")]
    Plus,
    
    [Description("\uf068")]
    Minus,
    
    [Description("\uf055")]
    PlusCircle,
    
    [Description("\uf056")]
    MinusCircle,
    
    [Description("\uf058")]
    CheckCircle,
    
    [Description("\uf057")]
    TimesCircle,
    
    [Description("\uf05d")]
    CheckSquare,
    
    [Description("\uf14a")]
    MinusSquare,
    
    [Description("\uf0fe")]
    PlusSquare,
    
    [Description("\uf146")]
    TimesSquare,
    
    // Status & Info
    [Description("\uf059")]
    InfoCircle,
    
    [Description("\uf05a")]
    Info,
    
    [Description("\uf06a")]
    ExclamationCircle,
    
    [Description("\uf071")]
    ExclamationTriangle,
    
    [Description("\uf128")]
    Question,
    
    [Description("\uf129")]
    QuestionCircle,
    
    // Files & Folders
    [Description("\uf15b")]
    File,
    
    [Description("\uf15c")]
    FileAlt,
    
    [Description("\uf1c6")]
    FileArchive,
    
    [Description("\uf1c7")]
    FileAudio,
    
    [Description("\uf1c9")]
    FileCode,
    
    [Description("\uf1c3")]
    FileExcel,
    
    [Description("\uf1c5")]
    FileImage,
    
    [Description("\uf1c8")]
    FilePdf,
    
    [Description("\uf1c4")]
    FilePowerpoint,
    
    [Description("\uf1c2")]
    FileWord,
    
    [Description("\uf07b")]
    Folder,
    
    [Description("\uf07c")]
    FolderOpen,
    
    [Description("\uf65d")]
    FolderPlus,
    
    [Description("\uf65e")]
    FolderMinus,
    
    // Communication
    [Description("\uf0e0")]
    Envelope,
    
    [Description("\uf0e1")]
    EnvelopeOpen,
    
    [Description("\uf658")]
    EnvelopeOpenText,
    
    [Description("\uf2b6")]
    EnvelopeSquare,
    
    [Description("\uf095")]
    Phone,
    
    [Description("\uf098")]
    PhoneSquare,
    
    [Description("\uf879")]
    PhoneAlt,
    
    [Description("\uf3cd")]
    PhoneSlash,
    
    [Description("\uf086")]
    Comments,
    
    [Description("\uf075")]
    Comment,
    
    [Description("\uf0e5")]
    CommentAlt,
    
    [Description("\uf27a")]
    CommentDots,
    
    [Description("\uf4ad")]
    CommentSlash,
    
    // Technology & Devices
    [Description("\uf108")]
    Desktop,
    
    [Description("\uf109")]
    Laptop,
    
    [Description("\uf10a")]
    Tablet,
    
    [Description("\uf10b")]
    Mobile,
    
    [Description("\uf3cd")]
    MobileAlt,
    
    [Description("\uf233")]
    Server,
    
    [Description("\uf1c0")]
    Database,
    
    [Description("\uf0a0")]
    Hdd,
    
    [Description("\uf7c2")]
    SdCard,
    
    [Description("\uf8cc")]
    SimCard,
    
    // Business & Commerce
    [Description("\uf0b1")]
    Briefcase,
    
    [Description("\uf1ad")]
    Building,
    
    [Description("\uf84b")]
    BuildingRegular,
    
    [Description("\uf275")]
    Industry,
    
    [Description("\uf0d6")]
    Store,
    
    [Description("\uf290")]
    ShoppingBag,
    
    [Description("\uf07a")]
    ShoppingCart,
    
    [Description("\uf291")]
    ShoppingBasket,
    
    [Description("\uf218")]
    CartPlus,
    
    [Description("\uf217")]
    CartArrowDown,
    
    [Description("\uf53d")]
    CashRegister,
    
    // Security
    [Description("\uf023")]
    Lock,
    
    [Description("\uf3c1")]
    LockOpen,
    
    [Description("\uf09c")]
    Unlock,
    
    [Description("\uf13e")]
    UnlockAlt,
    
    [Description("\uf084")]
    Key,
    
    [Description("\uf132")]
    Shield,
    
    [Description("\uf3ed")]
    ShieldAlt,
    
    [Description("\uf0eb")]
    UserLock,
    
    // Settings & Tools
    [Description("\uf013")]
    Cog,
    
    [Description("\uf085")]
    Cogs,
    
    [Description("\uf0ad")]
    Wrench,
    
    [Description("\uf1de")]
    Sliders,
    
    [Description("\uf7d9")]
    Tools,
    
    [Description("\uf6e3")]
    Hammer,
    
    [Description("\uf492")]
    Toolbox,
    
    // Charts & Analytics
    [Description("\uf080")]
    ChartBar,
    
    [Description("\uf201")]
    ChartLine,
    
    [Description("\uf200")]
    ChartPie,
    
    [Description("\uf1fe")]
    ChartArea,
    
    [Description("\uf0ae")]
    Tasks,
    
    [Description("\uf681")]
    Poll,
    
    [Description("\uf643")]
    PollH,
    
    // Search & Filter
    [Description("\uf002")]
    Search,
    
    [Description("\uf00e")]
    SearchPlus,
    
    [Description("\uf010")]
    SearchMinus,
    
    [Description("\uf688")]
    SearchDollar,
    
    [Description("\uf689")]
    SearchLocation,
    
    [Description("\uf0b0")]
    Filter,
    
    [Description("\uf1de")]
    Sort,
    
    [Description("\uf160")]
    SortUp,
    
    [Description("\uf161")]
    SortDown,
    
    // Media Controls
    [Description("\uf04b")]
    Play,
    
    [Description("\uf04c")]
    Pause,
    
    [Description("\uf04d")]
    Stop,
    
    [Description("\uf04e")]
    Forward,
    
    [Description("\uf049")]
    Backward,
    
    [Description("\uf050")]
    FastForward,
    
    [Description("\uf04a")]
    FastBackward,
    
    [Description("\uf051")]
    StepForward,
    
    [Description("\uf048")]
    StepBackward,
    
    // Time & Calendar
    [Description("\uf017")]
    Clock,
    
    [Description("\uf073")]
    Calendar,
    
    [Description("\uf133")]
    CalendarAlt,
    
    [Description("\uf271")]
    CalendarCheck,
    
    [Description("\uf272")]
    CalendarMinus,
    
    [Description("\uf274")]
    CalendarPlus,
    
    [Description("\uf273")]
    CalendarTimes,
    
    [Description("\uf783")]
    CalendarDay,
    
    [Description("\uf784")]
    CalendarWeek,
    
    // Location
    [Description("\uf3c5")]
    MapMarkerAlt,
    
    [Description("\uf041")]
    MapMarker,
    
    [Description("\uf276")]
    MapPin,
    
    [Description("\uf277")]
    MapSigns,
    
    [Description("\uf278")]
    Map,
    
    [Description("\uf279")]
    MapMarked,
    
    [Description("\uf57d")]
    MapMarkedAlt,
    
    [Description("\uf59f")]
    MapLocation,
    
    [Description("\uf124")]
    LocationArrow,
    
    [Description("\uf0ac")]
    Globe,
    
    [Description("\uf57c")]
    GlobeAfrica,
    
    [Description("\uf57d")]
    GlobeAmericas,
    
    [Description("\uf57e")]
    GlobeAsia,
    
    [Description("\uf7a2")]
    GlobeEurope,
    
    // Social & Sharing
    [Description("\uf1e0")]
    Share,
    
    [Description("\uf14d")]
    ShareAlt,
    
    [Description("\uf045")]
    ShareSquare,
    
    [Description("\uf1e1")]
    ShareAltSquare,
    
    [Description("\uf064")]
    ShareNodes,
    
    // Nature & Weather
    [Description("\uf185")]
    Sun,
    
    [Description("\uf186")]
    Moon,
    
    [Description("\uf0c2")]
    Cloud,
    
    [Description("\uf73d")]
    CloudMoon,
    
    [Description("\uf6c4")]
    CloudSun,
    
    [Description("\uf73b")]
    CloudRain,
    
    [Description("\uf740")]
    CloudShowersHeavy,
    
    [Description("\uf005")]
    Star,
    
    [Description("\uf089")]
    StarHalf,
    
    [Description("\uf621")]
    StarHalfAlt,
    
    // Miscellaneous
    [Description("\uf015")]
    Home,
    
    [Description("\uf0f3")]
    Bell,
    
    [Description("\uf1f6")]
    BellSlash,
    
    [Description("\uf02d")]
    Book,
    
    [Description("\uf02e")]
    Bookmark,
    
    [Description("\uf0c5")]
    Copy,
    
    [Description("\uf0c7")]
    Save,
    
    [Description("\uf0c4")]
    Cut,
    
    [Description("\uf0ea")]
    Paste,
    
    [Description("\uf044")]
    Edit,
    
    [Description("\uf040")]
    Pencil,
    
    [Description("\uf303")]
    PencilAlt,
    
    [Description("\uf14b")]
    PencilSquare,
    
    [Description("\uf1f8")]
    Trash,
    
    [Description("\uf2ed")]
    TrashAlt,
    
    [Description("\uf014")]
    TrashCan,
    
    [Description("\uf019")]
    Download,
    
    [Description("\uf093")]
    Upload,
    
    [Description("\uf021")]
    Sync,
    
    [Description("\uf2f1")]
    SyncAlt,
    
    [Description("\uf01e")]
    Redo,
    
    [Description("\uf0e2")]
    Undo,
    
    [Description("\uf074")]
    Random,
    
    [Description("\uf11c")]
    Code,
    
    [Description("\uf121")]
    CodeBranch,
    
    [Description("\uf126")]
    CodeFork,
    
    [Description("\uf0e8")]
    Sitemap,
    
    [Description("\uf024")]
    Flag,
    
    [Description("\uf11e")]
    FlagCheckered,
    
    [Description("\uf0c3")]
    Flask,
    
    [Description("\uf0eb")]
    Lightbulb,
    
    [Description("\uf06e")]
    Eye,
    
    [Description("\uf070")]
    EyeSlash,
    
    [Description("\uf1e5")]
    Binoculars,
    
    [Description("\uf25a")]
    HandPointRight,
    
    [Description("\uf25b")]
    HandPointLeft,
    
    [Description("\uf25c")]
    HandPointUp,
    
    [Description("\uf25d")]
    HandPointDown,
    
    [Description("\uf4c0")]
    HandHolding,
    
    [Description("\uf4c2")]
    HandHoldingHeart,
    
    [Description("\uf4b8")]
    HandHoldingUsd,
    
    [Description("\uf0a6")]
    HandPeace,
    
    [Description("\uf25e")]
    HandPointer,
    
    [Description("\uf258")]
    HandRock,
    
    [Description("\uf259")]
    HandPaper,
    
    [Description("\uf256")]
    HandScissors,
    
    [Description("\uf257")]
    HandLizard,
    
    [Description("\uf255")]
    HandSpock,
    
    [Description("\uf2b5")]
    Handshake,
    
    [Description("\uf4c4")]
    HandshakeAltSlash,
    
    [Description("\uf0a7")]
    HandStop,
    
    [Description("\uf0c9")]
    Bars,
    
    [Description("\uf142")]
    EllipsisH,
    
    [Description("\uf141")]
    EllipsisV,
    
    [Description("\uf0ca")]
    ListUl,
    
    [Description("\uf0cb")]
    ListOl,
    
    [Description("\uf0ce")]
    Table,
    
    [Description("\uf0db")]
    Columns,
    
    [Description("\uf160")]
    SortAlphaDown,
    
    [Description("\uf15d")]
    SortAlphaUp,
    
    [Description("\uf161")]
    SortAmountDown,
    
    [Description("\uf884")]
    SortAmountDownAlt,
    
    [Description("\uf885")]
    SortAmountUp,
    
    [Description("\uf886")]
    SortAmountUpAlt,
    
    [Description("\uf162")]
    SortNumericDown,
    
    [Description("\uf887")]
    SortNumericDownAlt,
    
    [Description("\uf163")]
    SortNumericUp,
    
    [Description("\uf888")]
    SortNumericUpAlt
}

/// <summary>
/// Extension methods for FontAwesomeSolid enum
/// </summary>
public static class FontAwesomeSolidExtensions {
    /// <summary>
    /// Gets the Unicode character code for the FontAwesome solid icon
    /// </summary>
    public static string GetCode(this FontAwesomeSolid icon) {
        var field = icon.GetType().GetField(icon.ToString());
        if (field != null) {
            var attribute = (DescriptionAttribute?)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
            if (attribute != null) {
                return attribute.Description;
            }
        }
        return string.Empty;
    }
}