using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlForgeX;

public class HtmlTableDataTables : HtmlTable {
    private readonly string id;
    private readonly Dictionary<string, object> config = new Dictionary<string, object>();

    public bool EnablePaging {
        get => config.ContainsKey("paging") && (bool)config["paging"];
        set => config["paging"] = value;
    }

    public bool EnableSearching {
        get => config.ContainsKey("searching") && (bool)config["searching"];
        set => config["searching"] = value;
    }

    public bool EnableOrdering {
        get => config.ContainsKey("ordering") && (bool)config["ordering"];
        set => config["ordering"] = value;
    }

    public bool EnableScrollX {
        get => config.ContainsKey("scrollX") && (bool)config["scrollX"];
        set => config["scrollX"] = value;
    }

    public HtmlTableDataTables() {
        id = GlobalStorage.GenerateRandomId("table");
    }

    public HtmlTableDataTables(IEnumerable<object> objects, TableType library) : base(objects, library) {
        id = GlobalStorage.GenerateRandomId("table");
    }

    // Override the BuildTable method to use these features
    public override string BuildTable() {
        StringBuilder html = new StringBuilder();
        html.AppendLine($"<table id=\"{id}\">");
        // Use the base class's BuildTable method, but add the Tabler modes
        string tableInside = base.BuildTable();
        // Add the Tabler modes to the table string
        html.AppendLine(tableInside);
        html.AppendLine("</table>");
        html.AppendLine(AddDataTableConfiguration());
        return html.ToString();
    }

    private string AddDataTableConfiguration() {
        var configJson = System.Text.Json.JsonSerializer.Serialize(config);
        return $@"
            <script>
                $(document).ready(function() {{
                    $('#{id}').DataTable({configJson});
                }});
            </script>
        ";
    }
}
