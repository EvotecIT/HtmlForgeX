namespace HtmlForgeX;

public class Library {
    public LibraryMode Mode { get; set; }
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
    public List<string> Css { get; set; }
    public List<string> JSLinkOriginal { get; set; }
    public List<string> JsLink { get; set; }
    public List<string> JS { get; set; }
}

public enum LibraryMode {
    Online,
    Offline,
    OfflineWithFiles
}

public enum Libraries {
    None,
    Bootstrap,
    DataTables,
    Tabler
}