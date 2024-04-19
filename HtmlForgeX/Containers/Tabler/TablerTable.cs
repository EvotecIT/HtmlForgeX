using System.Text;

namespace HtmlForgeX;

public class TablerTable : HtmlTable {
    public TablerTable(IEnumerable<object> objects, TableType library) : base(objects, library) {
        // Additional initialization code specific to Tabler...
    }

    public void EnableDarkMode() {
        // Enable dark mode for Tabler tables
    }

    public void EnableCompactMode() {
        // Enable compact mode for Tabler tables
    }

    // Override the BuildTable method to use these modes
    public override string BuildTable() {
        StringBuilder html = new StringBuilder();
        html.AppendLine("<table class=\"table\">");

        // Use the base class's BuildTable method, but add the Tabler modes
        html.AppendLine(base.BuildTable());
        // Add the Tabler modes to the table string




        html.AppendLine("</table>");
        return html.ToString();
    }
}
