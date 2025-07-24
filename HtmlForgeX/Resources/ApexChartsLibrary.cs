using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlForgeX.Resources;

/// <summary>
/// Provides metadata and asset links for the ApexCharts library used for
/// rendering rich interactive charts. Includes links for both JavaScript and
/// style dependencies.
/// </summary>
public class ApexChartsLibrary : Library {
    /// <summary>
    /// Initializes a new instance of the <see cref="ApexChartsLibrary"/> class.
    /// </summary>
    public ApexChartsLibrary() {
        Header = new LibraryLinks {
            JsLink = [
                "https://cdn.jsdelivr.net/npm/apexcharts@3.48.0/dist/apexcharts.min.js"
            ],
            Js = [
                "apexcharts.min.js"
            ]
        };
        Comment = "ApexCharts library";
        LicenseLink = "https://github.com/apexcharts/apexcharts.js/blob/main/LICENSE";
        License = "MIT";
        SourceCodes = "https://github.com/apexcharts/apexcharts.js";
        Default = true;
        Email = false;
    }
}