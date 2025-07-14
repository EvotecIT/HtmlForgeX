namespace HtmlForgeX.Resources;

/// <summary>
/// Provides metadata and asset links for the FancyTree jQuery plugin used for
/// creating interactive tree views. This library encapsulates the required CSS
/// and JavaScript references.
/// </summary>
public class FancyTreeLibrary : Library {
    /// <summary>
    /// Initializes a new instance of the <see cref="FancyTreeLibrary"/> class.
    /// </summary>
    public FancyTreeLibrary() {
        Header = new LibraryLinks {
            CssLink = ["https://cdn.jsdelivr.net/npm/jquery.fancytree@2.38.2/dist/skin-win8/ui.fancytree.min.css"],
            Css = [
                "ui.fancytree.min.css"
            ],
            JsLink = ["https://cdn.jsdelivr.net/npm/jquery.fancytree@2.38.2/dist/jquery.fancytree-all-deps.min.js"],
            Js = [
                "jquery.fancytree-all-deps.min.js"
            ],
            CssStyle = [
                new Style {
                    Selector = "ul.fancytree-container",
                    Properties = new Dictionary<string, string> {
                        ["border"] = "unset", ["background-color"] = "unset",
                    }
                }
            ]
        };
        Comment = "FancyTree library";
        LicenseLink = "https://github.com/mar10/fancytree/blob/master/LICENSE.txt";
        License = "MIT";
        SourceCodes = "https://github.com/mar10/fancytree";
    }
}
