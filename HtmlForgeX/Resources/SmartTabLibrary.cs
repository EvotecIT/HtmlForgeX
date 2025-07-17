namespace HtmlForgeX.Resources;

/// <summary>
/// Metadata description for the SmartTab jQuery plugin library.
/// SmartTab is a responsive jQuery plugin for creating tabbed interfaces.
/// </summary>
public class SmartTabLibrary : Library {
    /// <summary>
    /// Initializes a new instance of the <see cref="SmartTabLibrary"/> class.
    /// </summary>
    public SmartTabLibrary() {
        Header = new LibraryLinks {
            CssLink = ["https://cdn.jsdelivr.net/npm/jquery-smarttab@4.0.2/dist/css/smart_tab_all.min.css"],
            Css = ["smart_tab_all.min.css"],
            JsLink = ["https://cdn.jsdelivr.net/npm/jquery-smarttab@4.0.2/dist/js/jquery.smartTab.min.js"],
            Js = ["jquery.smartTab.min.js"]
        };
        Comment = "SmartTab jQuery plugin for responsive tabbed interfaces";
        LicenseLink = "https://github.com/techlab/jquery-smarttab/blob/master/LICENSE";
        License = "MIT";
        SourceCodes = "https://github.com/techlab/jquery-smarttab";
        Website = "https://smarttab.techlaboratory.net/";
    }
}