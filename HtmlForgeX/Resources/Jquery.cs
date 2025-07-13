namespace HtmlForgeX.Resources;

/// <summary>
/// Metadata description for the jQuery library.
/// </summary>
public class Jquery : Library {
    /// <summary>
    /// Initializes a new instance of the <see cref="Jquery"/> class.
    /// </summary>
    public Jquery() {
        Header = new LibraryLinks {
            JsLink = ["https://cdn.jsdelivr.net/npm/jquery@3.7.1/dist/jquery.min.js"],
            Js = ["jquery.min.js"]
        };
        Comment = "Jquery library";
        LicenseLink = "https://jquery.org/license/";
        License = "MIT";
        SourceCodes = "https://github.com/jquery/jquery";
    }
}
