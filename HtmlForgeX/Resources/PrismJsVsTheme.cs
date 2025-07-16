namespace HtmlForgeX.Resources;

/// <summary>
/// PrismJS VS theme library configuration
/// </summary>
public class PrismJsVsTheme : Library
{
    public PrismJsVsTheme()
    {
        Header = new LibraryLinks {
            CssLink = [
                "https://cdn.jsdelivr.net/npm/prism-themes@1.9.0/themes/prism-vs.min.css"
            ],
            Css = [
                "prism-vs.min.css"
            ]
        };

        Comment = "PrismJS VS Theme - Visual Studio-style syntax highlighting";
        Website = "https://prismjs.com/";
        SourceCodes = "https://github.com/PrismJS/prism";
        LicenseLink = "https://github.com/PrismJS/prism/blob/master/LICENSE";
        License = "MIT License";
        Default = false;
        Email = false;
    }
}