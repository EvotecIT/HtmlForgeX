using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Configuration options for the DataTables JavaScript plugin.
/// </summary>
public class DataTablesOptions {
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

    /// <summary>Pagination type styling.</summary>
    [JsonPropertyName("pagingType")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? PagingType { get; set; }

    /// <summary>Column definitions for advanced configuration.</summary>
    [JsonPropertyName("columnDefs")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<DataTablesColumn>? ColumnDefs { get; set; }

    /// <summary>Column configuration array.</summary>
    [JsonPropertyName("columns")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<DataTablesColumn>? Columns { get; set; }

    /// <summary>Default ordering configuration.</summary>
    [JsonPropertyName("order")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object[][]? Order { get; set; }

    /// <summary>Buttons extension configuration.</summary>
    [JsonPropertyName("buttons")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<DataTablesExport>? Buttons { get; set; }

    /// <summary>Row grouping configuration.</summary>
    [JsonPropertyName("rowGroup")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DataTablesRowGroup? RowGroup { get; set; }

    /// <summary>Search Builder configuration.</summary>
    [JsonPropertyName("searchBuilder")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DataTablesSearchBuilder? SearchBuilder { get; set; }

    /// <summary>Search Panes configuration.</summary>
    [JsonPropertyName("searchPanes")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DataTablesSearchPanes? SearchPanes { get; set; }

    /// <summary>Fixed Header configuration.</summary>
    [JsonPropertyName("fixedHeader")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DataTablesFixedHeader? FixedHeader { get; set; }

    /// <summary>Fixed Columns configuration.</summary>
    [JsonPropertyName("fixedColumns")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DataTablesFixedColumns? FixedColumns { get; set; }

    /// <summary>Responsive configuration.</summary>
    [JsonPropertyName("responsive")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Responsive { get; set; }

    /// <summary>Select extension configuration.</summary>
    [JsonPropertyName("select")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Select { get; set; }

    /// <summary>Key table navigation.</summary>
    [JsonPropertyName("keys")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Keys { get; set; }

    /// <summary>Column reordering.</summary>
    [JsonPropertyName("colReorder")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? ColReorder { get; set; }

    /// <summary>Row callback function name.</summary>
    [JsonPropertyName("rowCallback")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? RowCallback { get; set; }

    /// <summary>Header callback function name.</summary>
    [JsonPropertyName("headerCallback")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? HeaderCallback { get; set; }

    /// <summary>Footer callback function name.</summary>
    [JsonPropertyName("footerCallback")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? FooterCallback { get; set; }

    /// <summary>Draw callback function name.</summary>
    [JsonPropertyName("drawCallback")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DrawCallback { get; set; }

    /// <summary>Init complete callback function name.</summary>
    [JsonPropertyName("initComplete")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? InitComplete { get; set; }
}