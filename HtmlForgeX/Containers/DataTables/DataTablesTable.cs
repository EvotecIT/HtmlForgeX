using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace HtmlForgeX;

/// <summary>
/// Table integrated with the DataTables library.
/// </summary>
public class DataTablesTable : Table {
    /// <summary>
    /// Gets the table identifier.
    /// </summary>
    public string Id;

    /// <summary>List of table styles to apply.</summary>
    public List<BootStrapTableStyle> StyleList { get; set; } = new List<BootStrapTableStyle>();
    private readonly Dictionary<string, object> config = new Dictionary<string, object>();

    /// <summary>DataTables configuration options.</summary>
    public DataTablesOptions Options { get; } = new();

    /// <summary>Enable paging feature.</summary>
    public bool EnablePaging {
        get => config.ContainsKey("paging") && (bool)config["paging"];
        set => config["paging"] = value;
    }

    /// <summary>Enable searching feature.</summary>
    public bool EnableSearching {
        get => config.ContainsKey("searching") && (bool)config["searching"];
        set => config["searching"] = value;
    }

    /// <summary>Enable column ordering.</summary>
    public bool EnableOrdering {
        get => config.ContainsKey("ordering") && (bool)config["ordering"];
        set => config["ordering"] = value;
    }

    /// <summary>Enable horizontal scrolling.</summary>
    public bool EnableScrollX {
        get => config.ContainsKey("scrollX") && (bool)config["scrollX"];
        set => config["scrollX"] = value;
    }

    /// <summary>Initializes a new instance of the <see cref="DataTablesTable"/> class.</summary>
    public DataTablesTable() {
        Id = GlobalStorage.GenerateRandomId("table");
    }

    /// <summary>
    /// Initializes a new instance populated with data.
    /// </summary>
    public DataTablesTable(IEnumerable<object> objects, TableType library) : base(objects, library) {
        Id = GlobalStorage.GenerateRandomId("table");
    }

    /// <summary>
    /// Adds a bootstrap table style.
    /// </summary>
    public DataTablesTable Style(BootStrapTableStyle style) {
        StyleList.Add(style);
        return this;
    }

    /// <summary>
    /// Applies additional DataTables configuration.
    /// </summary>
    public DataTablesTable Configure(Action<DataTablesOptions> configure) {
        configure?.Invoke(Options);
        return this;
    }

    /// <summary>
    /// Builds the final table markup including initialization script.
    /// </summary>
    public override string BuildTable() {
        string tableInside = base.BuildTable();
        string classNames = StyleList.BuildTableStyles();
        var tableTag = new HtmlTag("table")
            .Id(Id)
            .Class(classNames)
            .Value(tableInside)
            .Attribute("width", "100%");

        var merged = new Dictionary<string, object>(config);
        var optionsJson = JsonSerializer.Serialize(Options, new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });
        var optionsDict = JsonSerializer.Deserialize<Dictionary<string, object>>(optionsJson) ?? new Dictionary<string, object>();
        foreach (var kv in optionsDict) {
            merged[kv.Key] = kv.Value;
        }

        var configuration = JsonSerializer.Serialize(merged, new JsonSerializerOptions { WriteIndented = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });

        var scriptTag = new HtmlTag("script").Value($@"
        $(document).ready(function() {{
                $('#{Id}').DataTable({configuration});
            }});
        ");
        return tableTag + scriptTag.ToString();
    }
}