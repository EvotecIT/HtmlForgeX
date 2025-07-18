using System.ComponentModel;

namespace HtmlForgeX;

/// <summary>
/// FontAwesome Solid icons (fas) - filled icon style
/// Contains the most commonly used solid FontAwesome icons
/// </summary>
public enum FontAwesomeSolid {
    // Navigation & Arrows
    /// <summary>
    /// Left-pointing arrow icon
    /// </summary>
    [Description("\uf060")]
    ArrowLeft,
    
    /// <summary>
    /// Right-pointing arrow icon
    /// </summary>
    [Description("\uf061")]
    ArrowRight,
    
    /// <summary>
    /// Upward-pointing arrow icon
    /// </summary>
    [Description("\uf062")]
    ArrowUp,
    
    /// <summary>
    /// Downward-pointing arrow icon
    /// </summary>
    [Description("\uf063")]
    ArrowDown,
    
    /// <summary>
    /// Left-pointing caret/triangle icon
    /// </summary>
    [Description("\uf0d9")]
    CaretLeft,
    
    /// <summary>
    /// Right-pointing caret/triangle icon
    /// </summary>
    [Description("\uf0da")]
    CaretRight,
    
    /// <summary>
    /// Downward-pointing caret/triangle icon
    /// </summary>
    [Description("\uf0d7")]
    CaretDown,
    
    /// <summary>
    /// Upward-pointing caret/triangle icon
    /// </summary>
    [Description("\uf0d8")]
    CaretUp,
    
    /// <summary>
    /// Left-pointing chevron icon
    /// </summary>
    [Description("\uf053")]
    ChevronLeft,
    
    /// <summary>
    /// Right-pointing chevron icon
    /// </summary>
    [Description("\uf054")]
    ChevronRight,
    
    /// <summary>
    /// Upward-pointing chevron icon
    /// </summary>
    [Description("\uf077")]
    ChevronUp,
    
    /// <summary>
    /// Downward-pointing chevron icon
    /// </summary>
    [Description("\uf078")]
    ChevronDown,
    
    // User & People
    /// <summary>
    /// Single user/person icon
    /// </summary>
    [Description("\uf007")]
    User,
    
    /// <summary>
    /// Multiple users/people icon
    /// </summary>
    [Description("\uf0c0")]
    Users,
    
    /// <summary>
    /// User icon enclosed in a circle
    /// </summary>
    [Description("\uf2bd")]
    UserCircle,
    
    /// <summary>
    /// Alternative user icon style
    /// </summary>
    [Description("\uf406")]
    UserAlt,
    
    /// <summary>
    /// User icon with checkmark
    /// </summary>
    [Description("\uf4ff")]
    UserCheck,
    
    /// <summary>
    /// User icon with clock/time indicator
    /// </summary>
    [Description("\uf506")]
    UserClock,
    
    /// <summary>
    /// User icon with settings/cog
    /// </summary>
    [Description("\uf507")]
    UserCog,
    
    /// <summary>
    /// User icon with edit/pencil indicator
    /// </summary>
    [Description("\uf508")]
    UserEdit,
    
    /// <summary>
    /// User icon with friends/social connection
    /// </summary>
    [Description("\uf509")]
    UserFriends,
    
    /// <summary>
    /// User icon with plus/add indicator
    /// </summary>
    [Description("\uf234")]
    UserPlus,
    
    /// <summary>
    /// User icon with minus/remove indicator
    /// </summary>
    [Description("\uf235")]
    UserMinus,
    
    /// <summary>
    /// User icon with X/delete indicator
    /// </summary>
    [Description("\uf2c0")]
    UserTimes,
    
    /// <summary>
    /// User icon with graduation cap
    /// </summary>
    [Description("\uf500")]
    UserGraduate,
    
    /// <summary>
    /// User icon representing medical doctor
    /// </summary>
    [Description("\uf0f0")]
    UserMd,
    
    /// <summary>
    /// User icon with ninja/masked appearance
    /// </summary>
    [Description("\uf501")]
    UserNinja,
    
    /// <summary>
    /// User icon with secret/spy appearance
    /// </summary>
    [Description("\uf21b")]
    UserSecret,
    
    /// <summary>
    /// User icon with shield/protection
    /// </summary>
    [Description("\uf504")]
    UserShield,
    
    /// <summary>
    /// User icon with slash/blocked indicator
    /// </summary>
    [Description("\uf505")]
    UserSlash,
    
    /// <summary>
    /// User icon with tag/label
    /// </summary>
    [Description("\uf4fc")]
    UserTag,
    
    /// <summary>
    /// User icon wearing business tie
    /// </summary>
    [Description("\uf502")]
    UserTie,
    
    // Actions & Controls
    /// <summary>
    /// Checkmark/tick icon
    /// </summary>
    [Description("\uf00c")]
    Check,
    
    /// <summary>
    /// Close/cancel X icon
    /// </summary>
    [Description("\uf00d")]
    Times,
    
    /// <summary>
    /// Plus/add icon
    /// </summary>
    [Description("\uf067")]
    Plus,
    
    /// <summary>
    /// Minus/subtract icon
    /// </summary>
    [Description("\uf068")]
    Minus,
    
    /// <summary>
    /// Plus/add icon in a circle
    /// </summary>
    [Description("\uf055")]
    PlusCircle,
    
    /// <summary>
    /// Minus/subtract icon in a circle
    /// </summary>
    [Description("\uf056")]
    MinusCircle,
    
    /// <summary>
    /// Checkmark/tick icon in a circle
    /// </summary>
    [Description("\uf058")]
    CheckCircle,
    
    /// <summary>
    /// X/close icon in a circle
    /// </summary>
    [Description("\uf057")]
    TimesCircle,
    
    /// <summary>
    /// Checkmark/tick icon in a square
    /// </summary>
    [Description("\uf05d")]
    CheckSquare,
    
    /// <summary>
    /// Minus/subtract icon in a square
    /// </summary>
    [Description("\uf14a")]
    MinusSquare,
    
    /// <summary>
    /// Plus/add icon in a square
    /// </summary>
    [Description("\uf0fe")]
    PlusSquare,
    
    /// <summary>
    /// X/close icon in a square
    /// </summary>
    [Description("\uf146")]
    TimesSquare,
    
    // Status & Info
    /// <summary>
    /// Information icon in a circle
    /// </summary>
    [Description("\uf059")]
    InfoCircle,
    
    /// <summary>
    /// Information icon
    /// </summary>
    [Description("\uf05a")]
    Info,
    
    /// <summary>
    /// Exclamation/warning icon in a circle
    /// </summary>
    [Description("\uf06a")]
    ExclamationCircle,
    
    /// <summary>
    /// Exclamation/warning icon in a triangle
    /// </summary>
    [Description("\uf071")]
    ExclamationTriangle,
    
    /// <summary>
    /// Question mark icon
    /// </summary>
    [Description("\uf128")]
    Question,
    
    /// <summary>
    /// Question mark icon in a circle
    /// </summary>
    [Description("\uf129")]
    QuestionCircle,
    
    // Files & Folders
    /// <summary>
    /// Generic file/document icon
    /// </summary>
    [Description("\uf15b")]
    File,
    
    /// <summary>
    /// Alternative file/document icon with text lines
    /// </summary>
    [Description("\uf15c")]
    FileAlt,
    
    /// <summary>
    /// Archive/compressed file icon
    /// </summary>
    [Description("\uf1c6")]
    FileArchive,
    
    /// <summary>
    /// Audio/sound file icon
    /// </summary>
    [Description("\uf1c7")]
    FileAudio,
    
    /// <summary>
    /// Code/programming file icon
    /// </summary>
    [Description("\uf1c9")]
    FileCode,
    
    /// <summary>
    /// Excel spreadsheet file icon
    /// </summary>
    [Description("\uf1c3")]
    FileExcel,
    
    /// <summary>
    /// Image/picture file icon
    /// </summary>
    [Description("\uf1c5")]
    FileImage,
    
    /// <summary>
    /// PDF document file icon
    /// </summary>
    [Description("\uf1c8")]
    FilePdf,
    
    /// <summary>
    /// PowerPoint presentation file icon
    /// </summary>
    [Description("\uf1c4")]
    FilePowerpoint,
    
    /// <summary>
    /// Word document file icon
    /// </summary>
    [Description("\uf1c2")]
    FileWord,
    
    /// <summary>
    /// Folder/directory icon
    /// </summary>
    [Description("\uf07b")]
    Folder,
    
    /// <summary>
    /// Open folder/directory icon
    /// </summary>
    [Description("\uf07c")]
    FolderOpen,
    
    /// <summary>
    /// Folder with plus/add icon
    /// </summary>
    [Description("\uf65d")]
    FolderPlus,
    
    /// <summary>
    /// Folder with minus/remove icon
    /// </summary>
    [Description("\uf65e")]
    FolderMinus,
    
    // Communication
    /// <summary>
    /// Email/mail envelope icon
    /// </summary>
    [Description("\uf0e0")]
    Envelope,
    
    /// <summary>
    /// Open email/mail envelope icon
    /// </summary>
    [Description("\uf0e1")]
    EnvelopeOpen,
    
    /// <summary>
    /// Open email with text content icon
    /// </summary>
    [Description("\uf658")]
    EnvelopeOpenText,
    
    /// <summary>
    /// Email envelope icon in a square
    /// </summary>
    [Description("\uf2b6")]
    EnvelopeSquare,
    
    /// <summary>
    /// Telephone/phone icon
    /// </summary>
    [Description("\uf095")]
    Phone,
    
    /// <summary>
    /// Telephone icon in a square
    /// </summary>
    [Description("\uf098")]
    PhoneSquare,
    
    /// <summary>
    /// Alternative phone icon style
    /// </summary>
    [Description("\uf879")]
    PhoneAlt,
    
    /// <summary>
    /// Phone icon with slash/blocked
    /// </summary>
    [Description("\uf3cd")]
    PhoneSlash,
    
    /// <summary>
    /// Multiple comments/discussion icon
    /// </summary>
    [Description("\uf086")]
    Comments,
    
    /// <summary>
    /// Single comment/speech bubble icon
    /// </summary>
    [Description("\uf075")]
    Comment,
    
    /// <summary>
    /// Alternative comment bubble icon
    /// </summary>
    [Description("\uf0e5")]
    CommentAlt,
    
    /// <summary>
    /// Comment bubble with dots/typing indicator
    /// </summary>
    [Description("\uf27a")]
    CommentDots,
    
    /// <summary>
    /// Comment icon with slash/disabled
    /// </summary>
    [Description("\uf4ad")]
    CommentSlash,
    
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
    /// Mobile phone device icon
    /// </summary>
    [Description("\uf10b")]
    Mobile,
    
    /// <summary>
    /// Alternative mobile phone icon
    /// </summary>
    [Description("\uf3cd")]
    MobileAlt,
    
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
    /// Hard disk drive/storage icon
    /// </summary>
    [Description("\uf0a0")]
    Hdd,
    
    /// <summary>
    /// SD memory card icon
    /// </summary>
    [Description("\uf7c2")]
    SdCard,
    
    /// <summary>
    /// SIM card icon
    /// </summary>
    [Description("\uf8cc")]
    SimCard,
    
    // Business & Commerce
    /// <summary>
    /// Business briefcase icon
    /// </summary>
    [Description("\uf0b1")]
    Briefcase,
    
    /// <summary>
    /// Building/office icon
    /// </summary>
    [Description("\uf1ad")]
    Building,
    
    /// <summary>
    /// Building icon with regular/outlined style
    /// </summary>
    [Description("\uf84b")]
    BuildingRegular,
    
    /// <summary>
    /// Industrial/factory icon
    /// </summary>
    [Description("\uf275")]
    Industry,
    
    /// <summary>
    /// Store/shop icon
    /// </summary>
    [Description("\uf0d6")]
    Store,
    
    /// <summary>
    /// Shopping bag icon
    /// </summary>
    [Description("\uf290")]
    ShoppingBag,
    
    /// <summary>
    /// Shopping cart icon
    /// </summary>
    [Description("\uf07a")]
    ShoppingCart,
    
    /// <summary>
    /// Shopping basket icon
    /// </summary>
    [Description("\uf291")]
    ShoppingBasket,
    
    /// <summary>
    /// Shopping cart with plus/add icon
    /// </summary>
    [Description("\uf218")]
    CartPlus,
    
    /// <summary>
    /// Shopping cart with download arrow
    /// </summary>
    [Description("\uf217")]
    CartArrowDown,
    
    /// <summary>
    /// Cash register/point of sale icon
    /// </summary>
    [Description("\uf53d")]
    CashRegister,
    
    // Security
    /// <summary>
    /// Padlock/security lock icon
    /// </summary>
    [Description("\uf023")]
    Lock,
    
    /// <summary>
    /// Open padlock/unlocked icon
    /// </summary>
    [Description("\uf3c1")]
    LockOpen,
    
    /// <summary>
    /// Unlock/open lock icon
    /// </summary>
    [Description("\uf09c")]
    Unlock,
    
    /// <summary>
    /// Alternative unlock icon
    /// </summary>
    [Description("\uf13e")]
    UnlockAlt,
    
    /// <summary>
    /// Key/access icon
    /// </summary>
    [Description("\uf084")]
    Key,
    
    /// <summary>
    /// Shield/protection icon
    /// </summary>
    [Description("\uf132")]
    Shield,
    
    /// <summary>
    /// Alternative shield/protection icon
    /// </summary>
    [Description("\uf3ed")]
    ShieldAlt,
    
    /// <summary>
    /// User icon with lock/security
    /// </summary>
    [Description("\uf0eb")]
    UserLock,
    
    // Settings & Tools
    /// <summary>
    /// Settings/gear cog icon
    /// </summary>
    [Description("\uf013")]
    Cog,
    
    /// <summary>
    /// Multiple settings/gear cogs icon
    /// </summary>
    [Description("\uf085")]
    Cogs,
    
    /// <summary>
    /// Wrench/tool icon
    /// </summary>
    [Description("\uf0ad")]
    Wrench,
    
    /// <summary>
    /// Sliders/adjustment controls icon
    /// </summary>
    [Description("\uf1de")]
    Sliders,
    
    /// <summary>
    /// Tools/repair equipment icon
    /// </summary>
    [Description("\uf7d9")]
    Tools,
    
    /// <summary>
    /// Hammer/construction tool icon
    /// </summary>
    [Description("\uf6e3")]
    Hammer,
    
    /// <summary>
    /// Toolbox/tool storage icon
    /// </summary>
    [Description("\uf492")]
    Toolbox,
    
    // Charts & Analytics
    /// <summary>
    /// Bar chart/graph icon
    /// </summary>
    [Description("\uf080")]
    ChartBar,
    
    /// <summary>
    /// Line chart/graph icon
    /// </summary>
    [Description("\uf201")]
    ChartLine,
    
    /// <summary>
    /// Pie chart/graph icon
    /// </summary>
    [Description("\uf200")]
    ChartPie,
    
    /// <summary>
    /// Area chart/graph icon
    /// </summary>
    [Description("\uf1fe")]
    ChartArea,
    
    /// <summary>
    /// Tasks/checklist icon
    /// </summary>
    [Description("\uf0ae")]
    Tasks,
    
    /// <summary>
    /// Poll/survey icon
    /// </summary>
    [Description("\uf681")]
    Poll,
    
    /// <summary>
    /// Horizontal poll/survey icon
    /// </summary>
    [Description("\uf643")]
    PollH,
    
    // Search & Filter
    /// <summary>
    /// Search/magnifying glass icon
    /// </summary>
    [Description("\uf002")]
    Search,
    
    /// <summary>
    /// Search with plus/zoom in icon
    /// </summary>
    [Description("\uf00e")]
    SearchPlus,
    
    /// <summary>
    /// Search with minus/zoom out icon
    /// </summary>
    [Description("\uf010")]
    SearchMinus,
    
    /// <summary>
    /// Search with dollar/money icon
    /// </summary>
    [Description("\uf688")]
    SearchDollar,
    
    /// <summary>
    /// Search with location/map icon
    /// </summary>
    [Description("\uf689")]
    SearchLocation,
    
    /// <summary>
    /// Filter/funnel icon
    /// </summary>
    [Description("\uf0b0")]
    Filter,
    
    /// <summary>
    /// Sort/arrange icon
    /// </summary>
    [Description("\uf1de")]
    Sort,
    
    /// <summary>
    /// Sort ascending/up icon
    /// </summary>
    [Description("\uf160")]
    SortUp,
    
    /// <summary>
    /// Sort descending/down icon
    /// </summary>
    [Description("\uf161")]
    SortDown,
    
    // Media Controls
    /// <summary>
    /// Play/start media icon
    /// </summary>
    [Description("\uf04b")]
    Play,
    
    /// <summary>
    /// Pause media icon
    /// </summary>
    [Description("\uf04c")]
    Pause,
    
    /// <summary>
    /// Stop media icon
    /// </summary>
    [Description("\uf04d")]
    Stop,
    
    /// <summary>
    /// Forward/next media icon
    /// </summary>
    [Description("\uf04e")]
    Forward,
    
    /// <summary>
    /// Backward/previous media icon
    /// </summary>
    [Description("\uf049")]
    Backward,
    
    /// <summary>
    /// Fast forward media icon
    /// </summary>
    [Description("\uf050")]
    FastForward,
    
    /// <summary>
    /// Fast backward media icon
    /// </summary>
    [Description("\uf04a")]
    FastBackward,
    
    /// <summary>
    /// Step forward media icon
    /// </summary>
    [Description("\uf051")]
    StepForward,
    
    /// <summary>
    /// Step backward media icon
    /// </summary>
    [Description("\uf048")]
    StepBackward,
    
    // Time & Calendar
    /// <summary>
    /// Clock/time icon
    /// </summary>
    [Description("\uf017")]
    Clock,
    
    /// <summary>
    /// Calendar/date icon
    /// </summary>
    [Description("\uf073")]
    Calendar,
    
    /// <summary>
    /// Alternative calendar/date icon
    /// </summary>
    [Description("\uf133")]
    CalendarAlt,
    
    /// <summary>
    /// Calendar with checkmark icon
    /// </summary>
    [Description("\uf271")]
    CalendarCheck,
    
    /// <summary>
    /// Calendar with minus/remove icon
    /// </summary>
    [Description("\uf272")]
    CalendarMinus,
    
    /// <summary>
    /// Calendar with plus/add icon
    /// </summary>
    [Description("\uf274")]
    CalendarPlus,
    
    /// <summary>
    /// Calendar with X/delete icon
    /// </summary>
    [Description("\uf273")]
    CalendarTimes,
    
    /// <summary>
    /// Calendar single day view icon
    /// </summary>
    [Description("\uf783")]
    CalendarDay,
    
    /// <summary>
    /// Calendar weekly view icon
    /// </summary>
    [Description("\uf784")]
    CalendarWeek,
    
    // Location
    /// <summary>
    /// Alternative map marker/location pin icon
    /// </summary>
    [Description("\uf3c5")]
    MapMarkerAlt,
    
    /// <summary>
    /// Map marker/location pin icon
    /// </summary>
    [Description("\uf041")]
    MapMarker,
    
    /// <summary>
    /// Map pin/location marker icon
    /// </summary>
    [Description("\uf276")]
    MapPin,
    
    /// <summary>
    /// Map signs/directions icon
    /// </summary>
    [Description("\uf277")]
    MapSigns,
    
    /// <summary>
    /// Map/geographical chart icon
    /// </summary>
    [Description("\uf278")]
    Map,
    
    /// <summary>
    /// Map with marked locations icon
    /// </summary>
    [Description("\uf279")]
    MapMarked,
    
    /// <summary>
    /// Alternative map with marked locations icon
    /// </summary>
    [Description("\uf57d")]
    MapMarkedAlt,
    
    /// <summary>
    /// Map location/position icon
    /// </summary>
    [Description("\uf59f")]
    MapLocation,
    
    /// <summary>
    /// Location arrow icon
    /// </summary>
    [Description("\uf124")]
    LocationArrow,
    
    /// <summary>
    /// Globe/world icon
    /// </summary>
    [Description("\uf0ac")]
    Globe,
    
    /// <summary>
    /// Globe showing Africa
    /// </summary>
    [Description("\uf57c")]
    GlobeAfrica,
    
    /// <summary>
    /// Globe showing the Americas
    /// </summary>
    [Description("\uf57d")]
    GlobeAmericas,
    
    /// <summary>
    /// Globe showing Asia
    /// </summary>
    [Description("\uf57e")]
    GlobeAsia,
    
    /// <summary>
    /// Globe showing Europe
    /// </summary>
    [Description("\uf7a2")]
    GlobeEurope,
    
    // Social & Sharing
    /// <summary>
    /// Generic share icon
    /// </summary>
    [Description("\uf1e0")]
    Share,
    
    /// <summary>
    /// Alternative share icon
    /// </summary>
    [Description("\uf14d")]
    ShareAlt,
    
    /// <summary>
    /// Share icon inside a square
    /// </summary>
    [Description("\uf045")]
    ShareSquare,
    
    /// <summary>
    /// Alternative share icon inside a square
    /// </summary>
    [Description("\uf1e1")]
    ShareAltSquare,
    
    /// <summary>
    /// Share to multiple nodes icon
    /// </summary>
    [Description("\uf064")]
    ShareNodes,
    
    // Nature & Weather
    /// <summary>
    /// Sun/daytime icon
    /// </summary>
    [Description("\uf185")]
    Sun,
    
    /// <summary>
    /// Moon/night icon
    /// </summary>
    [Description("\uf186")]
    Moon,
    
    /// <summary>
    /// Cloud computing/storage icon
    /// </summary>
    [Description("\uf0c2")]
    Cloud,
    
    /// <summary>
    /// Cloud with moon/nighttime weather icon
    /// </summary>
    [Description("\uf73d")]
    CloudMoon,
    
    /// <summary>
    /// Cloud with sun/partly cloudy weather icon
    /// </summary>
    [Description("\uf6c4")]
    CloudSun,
    
    /// <summary>
    /// Cloud with rain/rainy weather icon
    /// </summary>
    [Description("\uf73b")]
    CloudRain,
    
    /// <summary>
    /// Cloud with heavy rain/storm weather icon
    /// </summary>
    [Description("\uf740")]
    CloudShowersHeavy,
    
    /// <summary>
    /// Star/rating icon
    /// </summary>
    [Description("\uf005")]
    Star,
    
    /// <summary>
    /// Half star/partial rating icon
    /// </summary>
    [Description("\uf089")]
    StarHalf,
    
    /// <summary>
    /// Alternative half star/partial rating icon
    /// </summary>
    [Description("\uf621")]
    StarHalfAlt,
    
    // Miscellaneous
    /// <summary>
    /// Home/house icon
    /// </summary>
    [Description("\uf015")]
    Home,
    
    /// <summary>
    /// Bell/notification icon
    /// </summary>
    [Description("\uf0f3")]
    Bell,
    
    /// <summary>
    /// Bell with slash/muted notifications icon
    /// </summary>
    [Description("\uf1f6")]
    BellSlash,
    
    /// <summary>
    /// Book/reading icon
    /// </summary>
    [Description("\uf02d")]
    Book,
    
    /// <summary>
    /// Bookmark/save page icon
    /// </summary>
    [Description("\uf02e")]
    Bookmark,
    
    /// <summary>
    /// Copy/duplicate icon
    /// </summary>
    [Description("\uf0c5")]
    Copy,
    
    /// <summary>
    /// Save/disk icon
    /// </summary>
    [Description("\uf0c7")]
    Save,
    
    /// <summary>
    /// Cut/scissors icon
    /// </summary>
    [Description("\uf0c4")]
    Cut,
    
    /// <summary>
    /// Paste/clipboard icon
    /// </summary>
    [Description("\uf0ea")]
    Paste,
    
    /// <summary>
    /// Edit/pencil icon
    /// </summary>
    [Description("\uf044")]
    Edit,
    
    /// <summary>
    /// Classic pencil icon
    /// </summary>
    [Description("\uf040")]
    Pencil,
    
    /// <summary>
    /// Alternative pencil icon
    /// </summary>
    [Description("\uf303")]
    PencilAlt,
    
    /// <summary>
    /// Pencil icon inside a square
    /// </summary>
    [Description("\uf14b")]
    PencilSquare,
    
    /// <summary>
    /// Trash/delete icon
    /// </summary>
    [Description("\uf1f8")]
    Trash,
    
    /// <summary>
    /// Alternative trash icon
    /// </summary>
    [Description("\uf2ed")]
    TrashAlt,
    
    /// <summary>
    /// Trash can icon
    /// </summary>
    [Description("\uf014")]
    TrashCan,
    
    /// <summary>
    /// Download arrow icon
    /// </summary>
    [Description("\uf019")]
    Download,
    
    /// <summary>
    /// Upload arrow icon
    /// </summary>
    [Description("\uf093")]
    Upload,
    
    /// <summary>
    /// Synchronize/refresh icon
    /// </summary>
    [Description("\uf021")]
    Sync,
    
    /// <summary>
    /// Alternative synchronize icon
    /// </summary>
    [Description("\uf2f1")]
    SyncAlt,
    
    /// <summary>
    /// Redo/forward icon
    /// </summary>
    [Description("\uf01e")]
    Redo,
    
    /// <summary>
    /// Undo/back icon
    /// </summary>
    [Description("\uf0e2")]
    Undo,
    
    /// <summary>
    /// Random/shuffle icon
    /// </summary>
    [Description("\uf074")]
    Random,
    
    /// <summary>
    /// Code brackets icon
    /// </summary>
    [Description("\uf11c")]
    Code,
    
    /// <summary>
    /// Code branch icon
    /// </summary>
    [Description("\uf121")]
    CodeBranch,
    
    /// <summary>
    /// Code fork icon
    /// </summary>
    [Description("\uf126")]
    CodeFork,
    
    /// <summary>
    /// Sitemap/structure icon
    /// </summary>
    [Description("\uf0e8")]
    Sitemap,
    
    /// <summary>
    /// Flag icon
    /// </summary>
    [Description("\uf024")]
    Flag,
    
    /// <summary>
    /// Checkered flag icon
    /// </summary>
    [Description("\uf11e")]
    FlagCheckered,
    
    /// <summary>
    /// Laboratory flask icon
    /// </summary>
    [Description("\uf0c3")]
    Flask,
    
    /// <summary>
    /// Lightbulb/idea icon
    /// </summary>
    [Description("\uf0eb")]
    Lightbulb,
    
    /// <summary>
    /// Eye/view icon
    /// </summary>
    [Description("\uf06e")]
    Eye,
    
    /// <summary>
    /// Slashed eye/hidden icon
    /// </summary>
    [Description("\uf070")]
    EyeSlash,
    
    /// <summary>
    /// Binoculars/vision icon
    /// </summary>
    [Description("\uf1e5")]
    Binoculars,
    
    /// <summary>
    /// Right pointing hand icon
    /// </summary>
    [Description("\uf25a")]
    HandPointRight,
    
    /// <summary>
    /// Left pointing hand icon
    /// </summary>
    [Description("\uf25b")]
    HandPointLeft,
    
    /// <summary>
    /// Upward pointing hand icon
    /// </summary>
    [Description("\uf25c")]
    HandPointUp,
    
    /// <summary>
    /// Downward pointing hand icon
    /// </summary>
    [Description("\uf25d")]
    HandPointDown,
    
    /// <summary>
    /// Open hand holding object icon
    /// </summary>
    [Description("\uf4c0")]
    HandHolding,
    
    /// <summary>
    /// Hand holding a heart icon
    /// </summary>
    [Description("\uf4c2")]
    HandHoldingHeart,
    
    /// <summary>
    /// Hand holding dollar sign icon
    /// </summary>
    [Description("\uf4b8")]
    HandHoldingUsd,
    
    /// <summary>
    /// Peace hand gesture icon
    /// </summary>
    [Description("\uf0a6")]
    HandPeace,
    
    /// <summary>
    /// Hand pointer/cursor icon
    /// </summary>
    [Description("\uf25e")]
    HandPointer,
    
    /// <summary>
    /// Rock/paper/scissors hand in rock pose
    /// </summary>
    [Description("\uf258")]
    HandRock,
    
    /// <summary>
    /// Paper hand gesture icon
    /// </summary>
    [Description("\uf259")]
    HandPaper,
    
    /// <summary>
    /// Scissors hand gesture icon
    /// </summary>
    [Description("\uf256")]
    HandScissors,
    
    /// <summary>
    /// Lizard hand gesture icon
    /// </summary>
    [Description("\uf257")]
    HandLizard,
    
    /// <summary>
    /// Vulcan salute hand gesture icon
    /// </summary>
    [Description("\uf255")]
    HandSpock,
    
    /// <summary>
    /// Handshake greeting icon
    /// </summary>
    [Description("\uf2b5")]
    Handshake,
    
    /// <summary>
    /// Handshake with slash icon
    /// </summary>
    [Description("\uf4c4")]
    HandshakeAltSlash,
    
    /// <summary>
    /// Raised hand stop icon
    /// </summary>
    [Description("\uf0a7")]
    HandStop,
    
    /// <summary>
    /// Bars/hamburger menu icon
    /// </summary>
    [Description("\uf0c9")]
    Bars,
    
    /// <summary>
    /// Horizontal ellipsis icon
    /// </summary>
    [Description("\uf142")]
    EllipsisH,
    
    /// <summary>
    /// Vertical ellipsis icon
    /// </summary>
    [Description("\uf141")]
    EllipsisV,
    
    /// <summary>
    /// Unordered list icon
    /// </summary>
    [Description("\uf0ca")]
    ListUl,
    
    /// <summary>
    /// Ordered list icon
    /// </summary>
    [Description("\uf0cb")]
    ListOl,
    
    /// <summary>
    /// Table/grid icon
    /// </summary>
    [Description("\uf0ce")]
    Table,
    
    /// <summary>
    /// Columns layout icon
    /// </summary>
    [Description("\uf0db")]
    Columns,
    
    /// <summary>
    /// Sort alphabetically descending icon
    /// </summary>
    [Description("\uf160")]
    SortAlphaDown,
    
    /// <summary>
    /// Sort alphabetically ascending icon
    /// </summary>
    [Description("\uf15d")]
    SortAlphaUp,
    
    /// <summary>
    /// Sort by amount descending icon
    /// </summary>
    [Description("\uf161")]
    SortAmountDown,
    
    /// <summary>
    /// Alternative sort by amount descending icon
    /// </summary>
    [Description("\uf884")]
    SortAmountDownAlt,
    
    /// <summary>
    /// Sort by amount ascending icon
    /// </summary>
    [Description("\uf885")]
    SortAmountUp,
    
    /// <summary>
    /// Alternative sort by amount ascending icon
    /// </summary>
    [Description("\uf886")]
    SortAmountUpAlt,
    
    /// <summary>
    /// Sort numerically descending icon
    /// </summary>
    [Description("\uf162")]
    SortNumericDown,
    
    /// <summary>
    /// Alternative sort numerically descending icon
    /// </summary>
    [Description("\uf887")]
    SortNumericDownAlt,
    
    /// <summary>
    /// Sort numerically ascending icon
    /// </summary>
    [Description("\uf163")]
    SortNumericUp,
    
    /// <summary>
    /// Alternative sort numerically ascending icon
    /// </summary>
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