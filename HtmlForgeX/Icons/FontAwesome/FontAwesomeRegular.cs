using System.ComponentModel;

namespace HtmlForgeX;

/// <summary>
/// FontAwesome Regular icons (far) - outlined icon style
/// Contains commonly used regular/outlined FontAwesome icons
/// </summary>
public enum FontAwesomeRegular {
    // User & People
    /// <summary>
    /// Outlined single user/person icon
    /// </summary>
    [Description("\uf007")]
    User,
    
    /// <summary>
    /// User icon in a circle outline
    /// </summary>
    [Description("\uf2bd")]
    UserCircle,
    
    // Files
    /// <summary>
    /// Basic file/document outline icon
    /// </summary>
    [Description("\uf15b")]
    File,
    
    /// <summary>
    /// Alternative file/document with text lines outline
    /// </summary>
    [Description("\uf15c")]
    FileAlt,
    
    /// <summary>
    /// Archive/compressed file outline icon
    /// </summary>
    [Description("\uf1c6")]
    FileArchive,
    
    /// <summary>
    /// Audio/sound file outline icon
    /// </summary>
    [Description("\uf1c7")]
    FileAudio,
    
    /// <summary>
    /// Code/programming file outline icon
    /// </summary>
    [Description("\uf1c9")]
    FileCode,
    
    /// <summary>
    /// Excel spreadsheet file outline icon
    /// </summary>
    [Description("\uf1c3")]
    FileExcel,
    
    /// <summary>
    /// Image/picture file outline icon
    /// </summary>
    [Description("\uf1c5")]
    FileImage,
    
    /// <summary>
    /// PDF document file outline icon
    /// </summary>
    [Description("\uf1c8")]
    FilePdf,
    
    /// <summary>
    /// PowerPoint presentation file outline icon
    /// </summary>
    [Description("\uf1c4")]
    FilePowerpoint,
    
    /// <summary>
    /// Video file outline icon
    /// </summary>
    [Description("\uf1c1")]
    FileVideo,
    
    /// <summary>
    /// Word document file outline icon
    /// </summary>
    [Description("\uf1c2")]
    FileWord,
    
    /// <summary>
    /// Folder/directory outline icon
    /// </summary>
    [Description("\uf07b")]
    Folder,
    
    /// <summary>
    /// Open folder/directory outline icon
    /// </summary>
    [Description("\uf07c")]
    FolderOpen,
    
    // Communication
    /// <summary>
    /// Email/mail envelope outline icon
    /// </summary>
    [Description("\uf0e0")]
    Envelope,
    
    /// <summary>
    /// Open email/mail envelope outline icon
    /// </summary>
    [Description("\uf2b6")]
    EnvelopeOpen,
    
    /// <summary>
    /// Single comment/speech bubble outline icon
    /// </summary>
    [Description("\uf075")]
    Comment,
    
    /// <summary>
    /// Alternative comment bubble outline icon
    /// </summary>
    [Description("\uf27a")]
    CommentAlt,
    
    /// <summary>
    /// Comment bubble with dots outline icon
    /// </summary>
    [Description("\uf4ad")]
    CommentDots,
    
    /// <summary>
    /// Multiple comments/discussion outline icon
    /// </summary>
    [Description("\uf086")]
    Comments,
    
    // UI Elements
    /// <summary>
    /// Checkmark/tick icon in circle outline
    /// </summary>
    [Description("\uf058")]
    CheckCircle,
    
    /// <summary>
    /// X/close icon in circle outline
    /// </summary>
    [Description("\uf057")]
    TimesCircle,
    
    /// <summary>
    /// Question mark icon in circle outline
    /// </summary>
    [Description("\uf059")]
    QuestionCircle,
    
    /// <summary>
    /// Exclamation Circle icon
    /// </summary>
    [Description("\uf06a")]
    ExclamationCircle,
    
    /// <summary>
    /// Circle icon
    /// </summary>
    [Description("\uf111")]
    Circle,
    
    /// <summary>
    /// Dot Circle icon
    /// </summary>
    [Description("\uf192")]
    DotCircle,
    
    /// <summary>
    /// Square icon
    /// </summary>
    [Description("\uf0c8")]
    Square,
    
    /// <summary>
    /// Check Square icon
    /// </summary>
    [Description("\uf14a")]
    CheckSquare,
    
    /// <summary>
    /// Square Full icon
    /// </summary>
    [Description("\uf096")]
    SquareFull,
    
    /// <summary>
    /// Minus Square icon
    /// </summary>
    [Description("\uf146")]
    MinusSquare,
    
    /// <summary>
    /// Plus Square icon
    /// </summary>
    [Description("\uf0fe")]
    PlusSquare,
    
    // Media
    /// <summary>
    /// Play Circle icon
    /// </summary>
    [Description("\uf144")]
    PlayCircle,
    
    /// <summary>
    /// Pause Circle icon
    /// </summary>
    [Description("\uf28b")]
    PauseCircle,
    
    /// <summary>
    /// Stop Circle icon
    /// </summary>
    [Description("\uf28d")]
    StopCircle,
    
    // Time
    /// <summary>
    /// Clock icon
    /// </summary>
    [Description("\uf017")]
    Clock,
    
    /// <summary>
    /// Calendar icon
    /// </summary>
    [Description("\uf073")]
    Calendar,
    
    /// <summary>
    /// Calendar Alt icon
    /// </summary>
    [Description("\uf133")]
    CalendarAlt,
    
    /// <summary>
    /// Calendar Check icon
    /// </summary>
    [Description("\uf271")]
    CalendarCheck,
    
    /// <summary>
    /// Calendar Minus icon
    /// </summary>
    [Description("\uf272")]
    CalendarMinus,
    
    /// <summary>
    /// Calendar Plus icon
    /// </summary>
    [Description("\uf274")]
    CalendarPlus,
    
    /// <summary>
    /// Calendar Times icon
    /// </summary>
    [Description("\uf273")]
    CalendarTimes,
    
    // Business
    /// <summary>
    /// Building icon
    /// </summary>
    [Description("\uf1ad")]
    Building,
    
    /// <summary>
    /// Copyright icon
    /// </summary>
    [Description("\uf24d")]
    Copyright,
    
    /// <summary>
    /// Registered icon
    /// </summary>
    [Description("\uf25d")]
    Registered,
    
    // Objects
    /// <summary>
    /// Bell icon
    /// </summary>
    [Description("\uf0f3")]
    Bell,
    
    /// <summary>
    /// Bell Slash icon
    /// </summary>
    [Description("\uf1f6")]
    BellSlash,
    
    /// <summary>
    /// Bookmark icon
    /// </summary>
    [Description("\uf02e")]
    Bookmark,
    
    /// <summary>
    /// Eye icon
    /// </summary>
    [Description("\uf06e")]
    Eye,
    
    /// <summary>
    /// Eye Slash icon
    /// </summary>
    [Description("\uf070")]
    EyeSlash,
    
    /// <summary>
    /// Heart icon
    /// </summary>
    [Description("\uf004")]
    Heart,
    
    /// <summary>
    /// Star icon
    /// </summary>
    [Description("\uf005")]
    Star,
    
    /// <summary>
    /// Star Half icon
    /// </summary>
    [Description("\uf089")]
    StarHalf,
    
    /// <summary>
    /// Frown icon
    /// </summary>
    [Description("\uf11a")]
    Frown,
    
    /// <summary>
    /// Frown Open icon
    /// </summary>
    [Description("\uf11c")]
    FrownOpen,
    
    /// <summary>
    /// Smile icon
    /// </summary>
    [Description("\uf118")]
    Smile,
    
    /// <summary>
    /// Smile Beam icon
    /// </summary>
    [Description("\uf4da")]
    SmileBeam,
    
    /// <summary>
    /// Meh icon
    /// </summary>
    [Description("\uf119")]
    Meh,
    
    /// <summary>
    /// Meh Blank icon
    /// </summary>
    [Description("\uf5a4")]
    MehBlank,
    
    /// <summary>
    /// Meh Rolling Eyes icon
    /// </summary>
    [Description("\uf5a5")]
    MehRollingEyes,
    
    /// <summary>
    /// Laugh icon
    /// </summary>
    [Description("\uf59a")]
    Laugh,
    
    /// <summary>
    /// Laugh Beam icon
    /// </summary>
    [Description("\uf599")]
    LaughBeam,
    
    /// <summary>
    /// Laugh Squint icon
    /// </summary>
    [Description("\uf59b")]
    LaughSquint,
    
    /// <summary>
    /// Laugh Wink icon
    /// </summary>
    [Description("\uf59c")]
    LaughWink,
    
    // Charts
    /// <summary>
    /// Chart Bar icon
    /// </summary>
    [Description("\uf080")]
    ChartBar,
    
    // Hands
    /// <summary>
    /// Hand Lizard icon
    /// </summary>
    [Description("\uf256")]
    HandLizard,
    
    /// <summary>
    /// Hand Paper icon
    /// </summary>
    [Description("\uf259")]
    HandPaper,
    
    /// <summary>
    /// Hand Peace icon
    /// </summary>
    [Description("\uf25a")]
    HandPeace,
    
    /// <summary>
    /// Hand Pointer icon
    /// </summary>
    [Description("\uf25b")]
    HandPointer,
    
    /// <summary>
    /// Hand Rock icon
    /// </summary>
    [Description("\uf258")]
    HandRock,
    
    /// <summary>
    /// Hand Scissors icon
    /// </summary>
    [Description("\uf257")]
    HandScissors,
    
    /// <summary>
    /// Hand Spock icon
    /// </summary>
    [Description("\uf255")]
    HandSpock,
    
    /// <summary>
    /// Handshake icon
    /// </summary>
    [Description("\uf2b5")]
    Handshake,
    
    // Miscellaneous
    /// <summary>
    /// Newspaper icon
    /// </summary>
    [Description("\uf1ea")]
    Newspaper,
    
    /// <summary>
    /// Flag icon
    /// </summary>
    [Description("\uf024")]
    Flag,
    
    /// <summary>
    /// Copy icon
    /// </summary>
    [Description("\uf0c5")]
    Copy,
    
    /// <summary>
    /// Save icon
    /// </summary>
    [Description("\uf0c7")]
    Save,
    
    /// <summary>
    /// Edit icon
    /// </summary>
    [Description("\uf044")]
    Edit,
    
    /// <summary>
    /// Pen Alt icon
    /// </summary>
    [Description("\uf303")]
    PenAlt,
    
    /// <summary>
    /// Trash icon
    /// </summary>
    [Description("\uf1f8")]
    Trash,
    
    /// <summary>
    /// Trash Alt icon
    /// </summary>
    [Description("\uf2ed")]
    TrashAlt,
    
    /// <summary>
    /// Lightbulb icon
    /// </summary>
    [Description("\uf0eb")]
    Lightbulb,
    
    /// <summary>
    /// Trophy icon
    /// </summary>
    [Description("\uf091")]
    Trophy,
    
    /// <summary>
    /// Hdd icon
    /// </summary>
    [Description("\uf0a0")]
    Hdd,
    
    /// <summary>
    /// Plug icon
    /// </summary>
    [Description("\uf1e6")]
    Plug,
    
    /// <summary>
    /// Sliders H icon
    /// </summary>
    [Description("\uf1de")]
    SlidersH,
    
    /// <summary>
    /// Sun icon
    /// </summary>
    [Description("\uf21a")]
    Sun,
    
    /// <summary>
    /// Moon icon
    /// </summary>
    [Description("\uf186")]
    Moon,
    
    /// <summary>
    /// Snowflake icon
    /// </summary>
    [Description("\uf2cc")]
    Snowflake,
    
    /// <summary>
    /// Sun Alt icon
    /// </summary>
    [Description("\uf185")]
    SunAlt,
    
    /// <summary>
    /// Car Alt icon
    /// </summary>
    [Description("\uf1b9")]
    CarAlt,
    
    /// <summary>
    /// Paper Plane icon
    /// </summary>
    [Description("\uf1d8")]
    PaperPlane,
    
    /// <summary>
    /// Share icon
    /// </summary>
    [Description("\uf1e3")]
    Share,
    
    /// <summary>
    /// Share Alt icon
    /// </summary>
    [Description("\uf14d")]
    ShareAlt,
    
    /// <summary>
    /// Share Square icon
    /// </summary>
    [Description("\uf1e0")]
    ShareSquare,
    
    /// <summary>
    /// Share Alt Square icon
    /// </summary>
    [Description("\uf045")]
    ShareAltSquare,
    
    /// <summary>
    /// Object Group icon
    /// </summary>
    [Description("\uf247")]
    ObjectGroup,
    
    /// <summary>
    /// Object Ungroup icon
    /// </summary>
    [Description("\uf248")]
    ObjectUngroup,
    
    /// <summary>
    /// Id Badge icon
    /// </summary>
    [Description("\uf2c1")]
    IdBadge,
    
    /// <summary>
    /// Id Card icon
    /// </summary>
    [Description("\uf2c2")]
    IdCard,
    
    /// <summary>
    /// Address Book icon
    /// </summary>
    [Description("\uf2f5")]
    AddressBook,
    
    /// <summary>
    /// Address Card icon
    /// </summary>
    [Description("\uf2bb")]
    AddressCard,
    
    /// <summary>
    /// Flask icon
    /// </summary>
    [Description("\uf0c3")]
    Flask,
    
    /// <summary>
    /// Fire icon
    /// </summary>
    [Description("\uf06d")]
    Fire,
    
    /// <summary>
    /// Paw icon
    /// </summary>
    [Description("\uf1b0")]
    Paw,
    
    /// <summary>
    /// Bug icon
    /// </summary>
    [Description("\uf188")]
    Bug,
    
    /// <summary>
    /// Money icon
    /// </summary>
    [Description("\uf0f0")]
    Money,
    
    /// <summary>
    /// Gem icon
    /// </summary>
    [Description("\uf2a0")]
    Gem,
    
    /// <summary>
    /// Hashtag icon
    /// </summary>
    [Description("\uf292")]
    Hashtag,
    
    /// <summary>
    /// Anchor icon
    /// </summary>
    [Description("\uf13d")]
    Anchor,
    
    /// <summary>
    /// Bed icon
    /// </summary>
    [Description("\uf293")]
    Bed,
    
    /// <summary>
    /// Beer icon
    /// </summary>
    [Description("\uf294")]
    Beer,
    
    /// <summary>
    /// Beaker icon
    /// </summary>
    [Description("\uf0fc")]
    Beaker,
    
    /// <summary>
    /// Bicycle icon
    /// </summary>
    [Description("\uf295")]
    Bicycle,
    
    /// <summary>
    /// Coffee icon
    /// </summary>
    [Description("\uf0f4")]
    Coffee,
    
    /// <summary>
    /// Plane icon
    /// </summary>
    [Description("\uf072")]
    Plane,
    
    /// <summary>
    /// Taxi icon
    /// </summary>
    [Description("\uf1ba")]
    Taxi,
    
    /// <summary>
    /// Train icon
    /// </summary>
    [Description("\uf238")]
    Train,
    
    /// <summary>
    /// Ship icon
    /// </summary>
    [Description("\uf13a")]
    Ship,
    
    /// <summary>
    /// Space Shuttle icon
    /// </summary>
    [Description("\uf197")]
    SpaceShuttle,
    
    /// <summary>
    /// Truck icon
    /// </summary>
    [Description("\uf0d1")]
    Truck,
    
    /// <summary>
    /// Truck Moving icon
    /// </summary>
    [Description("\uf1b8")]
    TruckMoving,
    
    /// <summary>
    /// Motorcycle icon
    /// </summary>
    [Description("\uf21c")]
    Motorcycle,
    
    /// <summary>
    /// Bus icon
    /// </summary>
    [Description("\uf245")]
    Bus,
    
    /// <summary>
    /// Dumpster icon
    /// </summary>
    [Description("\uf540")]
    Dumpster,
    
    /// <summary>
    /// Dumpster Fire icon
    /// </summary>
    [Description("\uf541")]
    DumpsterFire,
    
    /// <summary>
    /// Tractor icon
    /// </summary>
    [Description("\uf52f")]
    Tractor,
    
    /// <summary>
    /// Road icon
    /// </summary>
    [Description("\uf018")]
    Road
}

/// <summary>
/// Extension methods for FontAwesomeRegular enum
/// </summary>
public static class FontAwesomeRegularExtensions {
    /// <summary>
    /// Gets the Unicode character code for the FontAwesome regular icon
    /// </summary>
    public static string GetCode(this FontAwesomeRegular icon) {
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