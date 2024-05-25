using HtmlForgeX.Resources;

namespace HtmlForgeX;

public enum Libraries {
    None,
    Primary,
    Bootstrap,
    DataTables,
    Tabler,
    TablerIcon,
    JQuery,
    FancyTree,
    ApexCharts,
    VisNetwork,
    VisNetworkLoadingBar,
    EasyQRCode,
    FullCalendar,
    Popper
}

public class Library {
    public string Comment { get; set; } = "";
    public LibraryLinks Header { get; set; } = new LibraryLinks();
    public LibraryLinks Footer { get; set; } = new LibraryLinks();
    public LibraryLinks Body { get; set; } = new LibraryLinks();
    public string LicenseLink { get; set; } = "";
    public string License { get; set; } = "";
    public string SourceCodes { get; set; } = "";
    public string Website { get; set; } = "";
    public bool Default { get; set; } = false;
    public bool Email { get; set; } = false;
}

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
    public List<string> JsLink { get; set; } = new List<string>();
    public List<string> Js { get; set; } = new List<string>();
    public List<string> JsScript = new List<string>();

}

public class LibrariesConverter {
    public static Library MapLibraryEnumToLibraryObject(Libraries libraries) {
        switch (libraries) {
            case Libraries.Primary:
                return new Primary();
            case Libraries.Bootstrap:
                return new Bootstrap();
            case Libraries.DataTables:
                return new DataTables();
            case Libraries.Tabler:
                return new Tabler();
            case Libraries.TablerIcon:
                return new TablerIconLibrary();
            case Libraries.JQuery:
                return new Jquery();
            case Libraries.FancyTree:
                return new FancyTreeLibrary();
            case Libraries.ApexCharts:
                return new ApexChartsLibrary();
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
            default:
                throw new ArgumentException($"Unsupported library: {libraries}");
        }
    }
}