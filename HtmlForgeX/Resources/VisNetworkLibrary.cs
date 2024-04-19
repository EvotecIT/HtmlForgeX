using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlForgeX.Resources;
internal class VisNetworkLibrary : Library {
    public VisNetworkLibrary() {
        Header = new LibraryLinks {
            CssLink = [
                "https://cdn.jsdelivr.net/gh/evotecit/cdn@0.0.22/CSS/vis-network.loadingbar.min.css",
                "https://cdn.jsdelivr.net/npm/vis-network@9.1.9/styles/vis-network.min.css"
            ],
            JsLink = [
                "https://cdn.jsdelivr.net/npm/vis-data@7.1.6/peer/umd/vis-data.min.js",
                "https://cdn.jsdelivr.net/gh/evotecit/cdn@0.0.22/JS/vis-networkLoadDiagram.min.js",
                "https://cdn.jsdelivr.net/npm/vis-network@9.1.9/peer/umd/vis-network.min.js"
            ]
        };
        Comment = "VisNetwork library";
        LicenseLink = "https://github.com/visjs/vis-network/blob/master/LICENSE-MIT";
        License = "MIT";
        SourceCodes = "https://github.com/visjs/vis-network";
    }
}
