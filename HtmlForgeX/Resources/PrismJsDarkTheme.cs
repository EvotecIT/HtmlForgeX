namespace HtmlForgeX.Resources;

/// <summary>
/// PrismJS Dark theme library configuration
/// </summary>
public class PrismJsDarkTheme : Library
{
    public PrismJsDarkTheme()
    {
        Header = new LibraryLinks {
            CssLink = [
                "https://cdnjs.cloudflare.com/ajax/libs/prism/1.29.0/themes/prism-dark.min.css"
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