namespace HtmlForgeX.Resources;

/// <summary>
/// FontAwesome 5 Free icon library configuration (for compatibility with vis.js and other libraries)
/// </summary>
public class FontAwesome5Library : Library {
    /// <summary>
    /// Creates a new instance of the FontAwesome 5 library configuration
    /// </summary>
    public FontAwesome5Library() {
        Comment = "Font Awesome 5 Free";

        // Header links for CSS
        Header = new LibraryLinks {
            CssLink = {
                "https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css"
            },
            Css = {
                "font-awesome.5.15.4.all.min.css"
            }
        };
    }
}