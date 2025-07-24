using System;

namespace HtmlForgeX.Resources;

/// <summary>
/// Provides metadata and asset links for the Chart.js library. Use this class
/// when you want to include interactive charts and graphs in your document.
/// </summary>
public class ChartJsLibrary : Library {
    /// <summary>
    /// Initializes a new instance of the <see cref="ChartJsLibrary"/> class.
    /// </summary>
    public ChartJsLibrary() {
        Header = new LibraryLinks {
            JsLink = [
                "https://cdn.jsdelivr.net/npm/chart.js@4.4.1/dist/chart.umd.min.js"
            ],
            Js = ["chart.umd.min.js"]
        };
        Comment = "Chart.js library";
        LicenseLink = "https://github.com/chartjs/Chart.js/blob/master/LICENSE.md";
        License = "MIT";
        SourceCodes = "https://github.com/chartjs/Chart.js";
        Default = true;
    }
}