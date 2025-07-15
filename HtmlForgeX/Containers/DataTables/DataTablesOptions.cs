using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Configuration options for the DataTables JavaScript plugin.
/// </summary>
public class DataTablesOptions
{
    /// <summary>Default number of rows per page.</summary>
    [JsonPropertyName("pageLength")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? PageLength { get; set; }

    /// <summary>Available page length options.</summary>
    [JsonPropertyName("lengthMenu")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int[]? LengthMenu { get; set; }

    /// <summary>Enable DataTables state saving.</summary>
    [JsonPropertyName("stateSave")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? StateSave { get; set; }

    /// <summary>Vertical scroll height.</summary>
    [JsonPropertyName("scrollY")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ScrollY { get; set; }

    /// <summary>Enable collapsing the table height when fewer rows are present.</summary>
    [JsonPropertyName("scrollCollapse")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ScrollCollapse { get; set; }

    /// <summary>Automatically calculate column widths.</summary>
    [JsonPropertyName("autoWidth")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? AutoWidth { get; set; }

    /// <summary>Defer rendering for speed on large data sets.</summary>
    [JsonPropertyName("deferRender")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? DeferRender { get; set; }

    /// <summary>Show the processing indicator.</summary>
    [JsonPropertyName("processing")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Processing { get; set; }

    /// <summary>Enable server-side processing.</summary>
    [JsonPropertyName("serverSide")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ServerSide { get; set; }

    /// <summary>Localization options.</summary>
    [JsonPropertyName("language")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DataTablesLanguage? Language { get; set; }

    /// <summary>DOM positioning configuration string.</summary>
    [JsonPropertyName("dom")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Dom { get; set; }
}

