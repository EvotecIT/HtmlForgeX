namespace HtmlForgeX.Resources;

/// <summary>
/// PrismJS GitHub theme library configuration
/// </summary>
public class PrismJsGitHubTheme : Library
{
    public PrismJsGitHubTheme()
    {
        Header = new LibraryLinks {
            CssLink = [
                "https://cdnjs.cloudflare.com/ajax/libs/prism/1.29.0/themes/prism-github.min.css"
            ]
        };

        Comment = "PrismJS GitHub Theme - GitHub-style syntax highlighting";
        Website = "https://prismjs.com/";
        SourceCodes = "https://github.com/PrismJS/prism";
        LicenseLink = "https://github.com/PrismJS/prism/blob/master/LICENSE";
        License = "MIT License";
        Default = false;
        Email = false;
    }
}