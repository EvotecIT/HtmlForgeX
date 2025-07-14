using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlForgeX.Resources;

/// <summary>
/// Provides assets for the Vis Network loading bar plugin.
/// </summary>
public class VisNetworkLoadingBarLibrary : Library {
    /// <summary>
    /// Initializes a new instance of the <see cref="VisNetworkLoadingBarLibrary"/> class.
    /// </summary>
    public VisNetworkLoadingBarLibrary() {
        Header = new LibraryLinks {
            CssLink = [
                "https://cdn.jsdelivr.net/gh/evotecit/cdn@0.0.22/CSS/vis-network.loadingbar.min.css",
            ],
            Css = [
                "vis-network.loadingbar.min.css",
            ],
            JsLink = [
                "https://cdn.jsdelivr.net/gh/evotecit/cdn@0.0.22/JS/vis-networkLoadDiagram.min.js",
            ],
            Js = [
                "vis-networkLoadDiagram.min.js",
            ]
        };
        Comment = "VisNetwork library";
        LicenseLink = "https://github.com/visjs/vis-network/blob/master/LICENSE-MIT";
        License = "MIT";
        SourceCodes = "https://github.com/visjs/vis-network";
    }
}
