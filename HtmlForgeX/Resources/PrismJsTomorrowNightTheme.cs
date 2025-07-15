namespace HtmlForgeX.Resources;

/// <summary>
/// PrismJS Tomorrow Night theme library configuration
/// </summary>
public class PrismJsTomorrowNightTheme : Library
{
    public PrismJsTomorrowNightTheme()
    {
        Header = new LibraryLinks {
            CssLink = [
                "https://cdnjs.cloudflare.com/ajax/libs/prism/1.29.0/themes/prism-tomorrow-night.min.css"
            ]
        };

        Comment = "PrismJS Tomorrow Night Theme - Dark theme with subtle colors";
        Website = "https://prismjs.com/";
        SourceCodes = "https://github.com/PrismJS/prism";
        LicenseLink = "https://github.com/PrismJS/prism/blob/master/LICENSE";
        License = "MIT License";
        Default = false;
        Email = false;
    }
}