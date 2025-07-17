namespace HtmlForgeX.Resources;

/// <summary>
/// PrismJS Okaidia theme library configuration
/// </summary>
public class PrismJsOkaidiaTheme : Library
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PrismJsOkaidiaTheme"/> class.
    /// </summary>
    public PrismJsOkaidiaTheme()
    {
        Header = new LibraryLinks {
            CssLink = [
                "https://cdn.jsdelivr.net/npm/prismjs@1.29.0/themes/prism-okaidia.min.css"
            ],
            Css = [
                "prism-okaidia.min.css"
            ]
        };

        Comment = "PrismJS Okaidia Theme - Dark theme with colorful syntax highlighting";
        Website = "https://prismjs.com/";
        SourceCodes = "https://github.com/PrismJS/prism";
        LicenseLink = "https://github.com/PrismJS/prism/blob/master/LICENSE";
        License = "MIT License";
        Default = false;
        Email = false;
    }
}