using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlForgeX.Resources;
public class ApexChartsLibrary : Library {
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
