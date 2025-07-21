using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlForgeX.Resources;

/// <summary>
/// Library descriptor for Vis Network HTML Nodes plugin that enables full HTML support in network nodes.
/// </summary>
internal class VisNetworkHtmlNodesLibrary : Library {
    /// <summary>
    /// Initializes a new instance of the <see cref="VisNetworkHtmlNodesLibrary"/> class.
    /// </summary>
    public VisNetworkHtmlNodesLibrary() {
        Header = new LibraryLinks {
            JsLink = [],
            Js = [
                "visjs-html-nodes.js"
            ]
        };
        Comment = "VisNetwork HTML Nodes plugin - Custom implementation for full HTML support in network nodes";
        LicenseLink = "";
        License = "MIT";
        SourceCodes = "";
        BlockDownload = true; // Prevent CDN refresh since this is a custom implementation
    }
}