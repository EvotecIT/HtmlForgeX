using HtmlForgeX.Resources;

namespace HtmlForgeX;

public class Library {
    public string Comment { get; set; }
    public LibraryLinks Header { get; set; }
    public LibraryLinks HeaderAlways { get; set; }
    public LibraryLinks Footer { get; set; }
    public LibraryLinks FooterAlways { get; set; }
    public LibraryLinks Body { get; set; }
    public string LicenseLink { get; set; }
    public string License { get; set; }
    public string SourceCodes { get; set; }
    public string Website { get; set; }
    public bool Default { get; set; }
    public bool Email { get; set; }
}

public class LibraryLinks {
    public List<string> CssLink { get; set; }
    public Dictionary<string, Dictionary<string, string>> CssInLine { get; set; }
    public List<Style> CssStyle { get; set; } = new List<Style>();
    public List<string> Css { get; set; }
    public List<string> JSLinkOriginal { get; set; }
    public List<string> JsLink { get; set; }
    public List<string> JS { get; set; }
}

public class LibrariesConverter {
    public static Library MapLibraryEnumToLibraryObject(Libraries libraries) {
        switch (libraries) {
            case Libraries.Bootstrap:
                return new Bootstrap();
            case Libraries.DataTables:
                return new DataTables();
            case Libraries.Tabler:
                return new Tabler();
            case Libraries.JQuery:
                return new Jquery();
            case Libraries.FancyTree:
                return new FancyTreeLibrary();
            case Libraries.ApexCharts:
                return new ApexChartsLibrary();
            case Libraries.VisNetwork:
                return new VisNetworkLibrary();
            case Libraries.EasyQRCode:
                return new EasyQRCode();
            default:
                throw new ArgumentException($"Unsupported library: {libraries}");
        }
        return null;
    }
}

public enum LibraryMode {
    Online,
    Offline,
    OfflineWithFiles
}

public enum TableType {
    None,
    BootstrapTable,
    DataTables,
    Tabler
}

public enum Libraries {
    None,
    Bootstrap,
    DataTables,
    Tabler,
    JQuery,
    FancyTree,
    ApexCharts,
    VisNetwork,
    EasyQRCode
}