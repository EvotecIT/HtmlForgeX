namespace HtmlForgeX.Resources;

public class ScrollingTextLibrary : Library {
    public ScrollingTextLibrary() {
        Header = new LibraryLinks {
            CssLink = ["https://cdn.jsdelivr.net/gh/evotecit/cdn@0.0.27/CSS/sectionScrolling.min.css"],
            JsLink = ["https://cdn.jsdelivr.net/gh/evotecit/cdn@0.0.27/JS/sectionScrolling.min.js"],
            Js = ["bootstrap.bundle.min.js"],
            Css = ["bootstrap.min.css"]
        };
        Comment = "Bootstrap library";
        LicenseLink = "https://www.bram.us/2020/01/10/smooth-scrolling-sticky-scrollspy-navigation/";
        License = "";
        SourceCodes = "https://www.bram.us/2020/01/10/smooth-scrolling-sticky-scrollspy-navigation/";
        Default = true;
        Email = false;
    }
}
