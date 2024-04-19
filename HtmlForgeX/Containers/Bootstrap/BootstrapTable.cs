using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlForgeX;

public class BootstrapTable : HtmlTable {
    public bool EnableResponsive { get; set; }
    public bool EnableStriped { get; set; }
    public bool EnableDarkMode { get; set; }
    public bool EnableBorders { get; set; }
    public bool EnableHover { get; set; }
    public bool EnableSmall { get; set; }
    public bool EnableMedium { get; set; }
    public bool EnableLarge { get; set; }

    public BootstrapTable() : base() {
        // Additional initialization code specific to Bootstrap...
    }

    public BootstrapTable(IEnumerable<object> objects, TableType library) : base(objects, library) {
        // Additional initialization code specific to Bootstrap...
    }

    private string BuildClassString() {
        var classes = new List<string> { "table" };
        if (EnableResponsive) classes.Add("table-responsive");
        if (EnableStriped) classes.Add("table-striped");
        if (EnableDarkMode) classes.Add("table-dark");
        if (EnableBorders) classes.Add("table-bordered");
        if (EnableHover) classes.Add("table-hover");
        if (EnableSmall) classes.Add("table-sm");
        if (EnableMedium) classes.Add("table-md");
        if (EnableLarge) classes.Add("table-lg");
        return string.Join(" ", classes);
    }

    public override string BuildTable() {
        StringBuilder html = new StringBuilder();
        html.AppendLine($"<table class=\"{BuildClassString()}\">");

        // Use the base class's BuildTable method, but add the Bootstrap classes
        html.AppendLine(base.BuildTable());

        html.AppendLine("</table>");
        return html.ToString();
    }
}
