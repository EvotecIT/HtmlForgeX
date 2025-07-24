namespace HtmlForgeX.Resources;

/// <summary>
/// Provides links for Popper and Tooltip libraries. Popper is commonly used to
/// position dropdowns and tooltips within web applications.
/// </summary>
public class PopperLibrary : Library {
    /// <summary>
    /// Initializes a new instance of the <see cref="PopperLibrary"/> class.
    /// </summary>
    public PopperLibrary() {
        Header = new LibraryLinks {
            JsLink = [
                "https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js",
                "https://cdn.jsdelivr.net/npm/tooltip.js@1.3.3/dist/umd/tooltip.min.js"
            ],
            Js = ["popper.min.js", "tooltip.min.js"]
        };
        Comment = "Popper & Tooltip library";
        LicenseLink = "https://github.com/floating-ui/floating-ui/blob/master/LICENSE";
        License = "MIT";
        SourceCodes = "https://github.com/floating-ui/floating-ui/tree/v1.x";
    }
}