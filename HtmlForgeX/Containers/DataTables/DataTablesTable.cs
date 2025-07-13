using System.Linq;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace HtmlForgeX;

/// <summary>
/// Table integrated with the DataTables library.
/// </summary>
public class DataTablesTable : Table {
    /// <summary>
    /// Gets the table identifier.
    /// </summary>
    public string Id;
    public List<BootStrapTableStyle> StyleList { get; set; } = new List<BootStrapTableStyle>();
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

    public DataTablesTable() {
        Id = GlobalStorage.GenerateRandomId("table");
    }

    public DataTablesTable(IEnumerable<object> objects, TableType library) : base(objects, library) {
        Id = GlobalStorage.GenerateRandomId("table");
    }

    public DataTablesTable Style(BootStrapTableStyle style) {
        StyleList.Add(style);
        return this;
    }

    public override string BuildTable() {
        string tableInside = base.BuildTable();
        string classNames = StyleList.BuildTableStyles();
        var tableTag = new HtmlTag("table")
            .Id(Id)
            .Class(classNames)
            .Value(tableInside)
            .Attribute("width", "100%");

        //var configuration = System.Text.Json.JsonSerializer.Serialize(config);
        var configuration = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });

        var scriptTag = new HtmlTag("script").Value($@"
        $(document).ready(function() {{
                $('#{Id}').DataTable({configuration});
            }});
        ");
        return tableTag + scriptTag.ToString();
    }
}