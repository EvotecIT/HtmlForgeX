using HtmlForgeX.Resources;

namespace HtmlForgeX;

/// <summary>
/// Enumeration of available libraries that can be injected into generated
/// documents. The order of values controls the default load order when
/// rendering a page, so dependencies such as jQuery must appear first.
/// </summary>
public enum Libraries {
    /// <summary>No libraries.</summary>
    None,
    /// <summary>HtmlForgeX primary library.</summary>
    Primary,
    /// <summary>jQuery library.</summary>
    JQuery,
    /// <summary>Bootstrap framework.</summary>
    Bootstrap,
    /// <summary>DataTables plugin.</summary>
    DataTables,
    /// <summary>DataTables Buttons extension.</summary>
    DataTablesButtons,
    /// <summary>DataTables Responsive extension.</summary>
    DataTablesResponsive,
    /// <summary>DataTables FixedHeader extension.</summary>
    DataTablesFixedHeader,
    /// <summary>DataTables FixedColumns extension.</summary>
    DataTablesFixedColumns,
    /// <summary>DataTables RowGroup extension.</summary>
    DataTablesRowGroup,
    /// <summary>DataTables SearchBuilder extension.</summary>
    DataTablesSearchBuilder,
    /// <summary>DataTables SearchPanes extension.</summary>
    DataTablesSearchPanes,
    /// <summary>DataTables Select extension.</summary>
    DataTablesSelect,
    /// <summary>Tabler UI library.</summary>
    Tabler,
    /// <summary>Tabler icon set.</summary>
    TablerIcon,
    /// <summary>Tabler flag icons.</summary>
    TablerFlags,
    /// <summary>Tabler social icons.</summary>
    TablerSocials,
    /// <summary>Tabler payment icons.</summary>
    TablerPayments,
    /// <summary>Tabler themes.</summary>
    TablerThemes,
    /// <summary>FancyTree plugin.</summary>
    FancyTree,
    /// <summary>ApexCharts library.</summary>
    ApexCharts,
    /// <summary>Chart.js library.</summary>
    ChartJs,
    /// <summary>vis-network library.</summary>
    VisNetwork,
    /// <summary>vis-network loading bar extension.</summary>
    VisNetworkLoadingBar,
    /// <summary>EasyQRCode library.</summary>
    EasyQRCode,
    /// <summary>FullCalendar library.</summary>
    FullCalendar,
    /// <summary>Popper library.</summary>
    Popper,
    /// <summary>ScrollingText plugin.</summary>
    ScrollingText,
    /// <summary>Quill editor library.</summary>
    Quill,
    /// <summary>TomSelect component.</summary>
    TomSelect,
    /// <summary>IMask input masking library.</summary>
    IMask,
    /// <summary>PrismJS syntax highlighting library.</summary>
    PrismJs,
    /// <summary>PrismJS Dark theme.</summary>
    PrismJsDarkTheme,
    /// <summary>PrismJS Okaidia theme.</summary>
    PrismJsOkaidiaTheme,
    /// <summary>PrismJS GitHub theme.</summary>
    PrismJsGitHubTheme,
    /// <summary>PrismJS Tomorrow Night theme.</summary>
    PrismJsTomorrowNightTheme,
    /// <summary>PrismJS VS theme.</summary>
    PrismJsVsTheme,
    /// <summary>SmartTab jQuery plugin for responsive tabs.</summary>
    SmartTab,
    /// <summary>SmartWizard jQuery plugin for step wizards.</summary>
    SmartWizard,
    /// <summary>FontAwesome 6 Free icon library.</summary>
    FontAwesome6
}

/// <summary>
/// Represents metadata describing an external library or resource set.
/// </summary>
public class Library {
    /// <summary>Descriptive comment for the library.</summary>
    public string Comment { get; set; } = string.Empty;
    /// <summary>Resources that should be placed in the document head.</summary>
    public LibraryLinks Header { get; set; } = new LibraryLinks();
    /// <summary>Resources that should be placed at the end of the body.</summary>
    public LibraryLinks Footer { get; set; } = new LibraryLinks();
    /// <summary>Resources that should be placed inside the body.</summary>
    public LibraryLinks Body { get; set; } = new LibraryLinks();
    /// <summary>Link to the library license.</summary>
    public string LicenseLink { get; set; } = string.Empty;
    /// <summary>License text for the library.</summary>
    public string License { get; set; } = string.Empty;
    /// <summary>URL to the source code of the library.</summary>
    public string SourceCodes { get; set; } = string.Empty;
    /// <summary>Library web site.</summary>
    public string Website { get; set; } = string.Empty;
    /// <summary>Whether this library is enabled by default.</summary>
    public bool Default { get; set; } = false;
    /// <summary>Indicates the library is for email usage only.</summary>
    public bool Email { get; set; } = false;
}

/// <summary>
/// Holds links and resources associated with a library.
/// </summary>
public class LibraryLinks {
    /// <summary>
    /// Link to styles hosted on CDN
    /// </summary>
    /// <value>
    /// The CSS link.
    /// </value>
    public List<string> CssLink { get; set; } = new List<string>();
    /// <summary>
    /// Gets or sets the CSS in line using dictionary with key as the selector and value as the style.
    /// </summary>
    /// <value>
    /// The CSS in line.
    /// </value>
    public Dictionary<string, Dictionary<string, string>> CssInLine { get; set; } = new Dictionary<string, Dictionary<string, string>>();
    /// <summary>
    /// Gets or sets the CSS style using Style object.
    /// </summary>
    /// <value>
    /// The CSS style.
    /// </value>
    public List<Style> CssStyle { get; set; } = new List<Style>();
    /// <summary>
    /// File name of the CSS file that is embedded in the project.
    /// </summary>
    /// <value>
    /// The CSS.
    /// </value>
    public List<string> Css { get; set; } = new List<string>();
    //public List<string> JsLinkOriginal { get; set; } = new List<string>();
    /// <summary>Links to JavaScript files hosted on a CDN.</summary>
    public List<string> JsLink { get; set; } = new List<string>();
    /// <summary>Embedded JavaScript file names.</summary>
    public List<string> Js { get; set; } = new List<string>();
    /// <summary>Inline JavaScript blocks.</summary>
    public List<string> JsScript = new List<string>();

}

/// <summary>
/// Utility methods for translating <see cref="Libraries"/> enum values into library objects.
/// </summary>
public class LibrariesConverter {
    /// <summary>
    /// Converts a <see cref="Libraries"/> enum value into its corresponding library object.
    /// </summary>
    /// <param name="libraries">The library enumeration value.</param>
    /// <returns>The matching <see cref="Library"/> instance.</returns>
    public static Library MapLibraryEnumToLibraryObject(Libraries libraries) {
        switch (libraries) {
            case Libraries.Primary:
                return new Primary();
            case Libraries.Bootstrap:
                return new Bootstrap();
            case Libraries.DataTables:
                return new DataTables();
            case Libraries.DataTablesButtons:
                return new Resources.DataTablesButtons();
            case Libraries.DataTablesResponsive:
                return new Resources.DataTablesResponsive();
            case Libraries.DataTablesFixedHeader:
                return new Resources.DataTablesFixedHeader();
            case Libraries.DataTablesFixedColumns:
                return new Resources.DataTablesFixedColumns();
            case Libraries.DataTablesRowGroup:
                return new Resources.DataTablesRowGroup();
            case Libraries.DataTablesSearchBuilder:
                return new Resources.DataTablesSearchBuilder();
            case Libraries.DataTablesSearchPanes:
                return new Resources.DataTablesSearchPanes();
            case Libraries.DataTablesSelect:
                return new Resources.DataTablesSelect();
            case Libraries.Tabler:
                return new Tabler();
            case Libraries.TablerIcon:
                return new Resources.TablerIconLibrary();
            case Libraries.TablerFlags:
                return new Resources.TablerFlags();
            case Libraries.TablerSocials:
                return new Resources.TablerSocials();
            case Libraries.TablerPayments:
                return new Resources.TablerPayments();
            case Libraries.TablerThemes:
                return new Resources.TablerThemes();
            case Libraries.JQuery:
                return new Jquery();
            case Libraries.FancyTree:
                return new FancyTreeLibrary();
            case Libraries.ApexCharts:
                return new ApexChartsLibrary();
            case Libraries.ChartJs:
                return new Resources.ChartJsLibrary();
            case Libraries.VisNetwork:
                return new VisNetworkLibrary();
            case Libraries.VisNetworkLoadingBar:
                return new VisNetworkLoadingBarLibrary();
            case Libraries.EasyQRCode:
                return new EasyQRCode();
            case Libraries.FullCalendar:
                return new FullCalendarLibrary();
        case Libraries.Popper:
            return new PopperLibrary();
        case Libraries.ScrollingText:
            return new ScrollingTextLibrary();
        case Libraries.Quill:
            return new Resources.QuillLibrary();
        case Libraries.TomSelect:
            return new Resources.TomSelectLibrary();
        case Libraries.IMask:
            return new Resources.IMaskLibrary();
        case Libraries.PrismJs:
            return new Resources.PrismJsLibrary();
        case Libraries.PrismJsDarkTheme:
            return new Resources.PrismJsDarkTheme();
        case Libraries.PrismJsOkaidiaTheme:
            return new Resources.PrismJsOkaidiaTheme();
        case Libraries.PrismJsGitHubTheme:
            return new Resources.PrismJsGitHubTheme();
        case Libraries.PrismJsTomorrowNightTheme:
            return new Resources.PrismJsTomorrowNightTheme();
        case Libraries.PrismJsVsTheme:
            return new Resources.PrismJsVsTheme();
        case Libraries.SmartTab:
            return new Resources.SmartTabLibrary();
        case Libraries.SmartWizard:
            return new Resources.SmartWizardLibrary();
        case Libraries.FontAwesome6:
            return new Resources.FontAwesome6Library();
        default:
            throw new ArgumentException($"Unsupported library: {libraries}");
        }
    }
}
