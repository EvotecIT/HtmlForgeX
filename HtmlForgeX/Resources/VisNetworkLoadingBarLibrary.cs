using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlForgeX.Resources;
public class VisNetworkLoadingBarLibrary : Library {
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
