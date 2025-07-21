namespace HtmlForgeX.Resources;

/// <summary>
/// FontAwesome 6 Free icon library configuration
/// </summary>
public class FontAwesome6Library : Library {
    /// <summary>
    /// Creates a new instance of the FontAwesome 6 library configuration
    /// </summary>
    public FontAwesome6Library() {
        Comment = "Font Awesome 6 Free";
        
        // Header links for CSS
        Header = new LibraryLinks {
            CssLink = {
                "https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.7.2/css/all.min.css"
            },
            Css = {
                "font-awesome.6.7.2.all.min.css"
            }
        };
    }
}