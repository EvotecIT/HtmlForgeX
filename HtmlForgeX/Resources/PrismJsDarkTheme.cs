namespace HtmlForgeX.Resources;

/// <summary>
/// PrismJS Dark theme library configuration
/// </summary>
public class PrismJsDarkTheme : Library
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PrismJsDarkTheme"/> class.
    /// </summary>
    public PrismJsDarkTheme()
    {
        Header = new LibraryLinks {
            CssLink = [
                "https://cdn.jsdelivr.net/npm/prismjs@1.29.0/themes/prism-dark.min.css"
            ],
            Css = [
                "prism-dark.min.css"
            ]
        };

        Comment = "PrismJS Dark Theme - Dark syntax highlighting theme";
        Website = "https://prismjs.com/";
        SourceCodes = "https://github.com/PrismJS/prism";
        LicenseLink = "https://github.com/PrismJS/prism/blob/master/LICENSE";
        License = "MIT License";
        Default = false;
        Email = false;
    }
}