using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlForgeX.Resources;

/// <summary>
/// Library descriptor for Vis Network diagrams.
/// </summary>
internal class VisNetworkLibrary : Library {
    /// <summary>
    /// Initializes a new instance of the <see cref="VisNetworkLibrary"/> class.
    /// </summary>
    public VisNetworkLibrary() {
        Header = new LibraryLinks {
            CssLink = [
                "https://cdn.jsdelivr.net/npm/vis-network@9.1.9/styles/vis-network.min.css"
            ],
            Css = [
                "vis-network.min.css"
            ],
            JsLink = [
                "https://cdn.jsdelivr.net/npm/vis-data@7.1.6/peer/umd/vis-data.min.js",
                "https://cdn.jsdelivr.net/npm/vis-network@9.1.9/peer/umd/vis-network.min.js"
            ],
            Js = [
                "vis-data.min.js",
                "vis-network.min.js"
            ],
            JsScript = [@"var diagramTracker = {};"],
            CssStyle = new List<Style> {
                new Style {
                    Selector = ".diagram",
                    Properties = new Dictionary<string, string> {
                        { "min-height", "400px" },
                        { "width", "100%" },
                        { "height", "100%" },
                        { "border", "0px solid unset" }
                    }
                },
                new Style {
                    Selector = ".vis-network:focus",
                    Properties = new Dictionary<string, string> {
                        { "outline", "none" }
                    }
                }
            }
        };
        Comment = "VisNetwork library";
        LicenseLink = "https://github.com/visjs/vis-network/blob/master/LICENSE-MIT";
        License = "MIT";
        SourceCodes = "https://github.com/visjs/vis-network";
    }
}
