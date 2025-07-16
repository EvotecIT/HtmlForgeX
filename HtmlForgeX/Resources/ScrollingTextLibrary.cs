namespace HtmlForgeX.Resources;

/// <summary>
/// Library providing assets for the scrolling text component.
/// </summary>
public class ScrollingTextLibrary : Library {
    /// <summary>
    /// Initializes a new instance of the <see cref="ScrollingTextLibrary"/> class.
    /// </summary>
    public ScrollingTextLibrary() {
        Header = new LibraryLinks {
            CssLink = ["https://cdn.jsdelivr.net/gh/evotecit/cdn@0.0.27/CSS/sectionScrolling.min.css"],
            Css = ["sectionScrolling.min.css"],
            JsLink = ["https://cdn.jsdelivr.net/gh/evotecit/cdn@0.0.27/JS/sectionScrolling.min.js"],
            Js = ["sectionScrolling.min.js"]
        };
        Comment = "ScrollingText helper";
        LicenseLink = "https://www.bram.us/2020/01/10/smooth-scrolling-sticky-scrollspy-navigation/";
        License = "";
        SourceCodes = "https://www.bram.us/2020/01/10/smooth-scrolling-sticky-scrollspy-navigation/";
        Default = true;
        Email = false;
    }
}
