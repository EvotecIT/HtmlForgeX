using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Enhanced DataTables table with comprehensive feature support and fluent API.
/// </summary>
public class DataTablesTable : Table {
    /// <summary>Gets the table identifier.</summary>
    public string Id;

    /// <summary>List of table styles to apply.</summary>
    public List<BootStrapTableStyle> StyleList { get; set; } = new List<BootStrapTableStyle>();

    /// <summary>DataTables configuration options.</summary>
    public DataTablesOptions Options { get; } = new();

    /// <summary>Feature toggles for DataTables functionality.</summary>
    private readonly Dictionary<string, object> _features = new Dictionary<string, object>();

    /// <summary>Column configurations.</summary>
    private readonly List<DataTablesColumn> _columns = new List<DataTablesColumn>();

    /// <summary>Export button configurations.</summary>
    private readonly List<DataTablesExport> _exportButtons = new List<DataTablesExport>();

    /// <summary>Initializes a new instance of the <see cref="DataTablesTable"/> class.</summary>
    public DataTablesTable() {
        Id = GlobalStorage.GenerateRandomId("table");
        InitializeDefaults();
    }

    /// <summary>Initializes a new instance populated with data.</summary>
    public DataTablesTable(IEnumerable<object> objects, TableType library) : base(objects, library) {
        Id = GlobalStorage.GenerateRandomId("table");
        InitializeDefaults();
    }

    /// <summary>Initialize default settings.</summary>
    private void InitializeDefaults() {
        _features["paging"] = true;
        _features["searching"] = true;
        _features["ordering"] = true;
        _features["info"] = true;
    }

    #region Feature Control Methods

    /// <summary>Enable or disable specific DataTables features.</summary>
    public DataTablesTable Feature(DataTablesFeature feature, bool enabled = true) {
        string featureName = feature switch {
            DataTablesFeature.Paging => "paging",
            DataTablesFeature.Searching => "searching",
            DataTablesFeature.Ordering => "ordering",
            DataTablesFeature.ScrollX => "scrollX",
            DataTablesFeature.ScrollY => "scrollY",
            DataTablesFeature.StateSave => "stateSave",
            DataTablesFeature.Processing => "processing",
            DataTablesFeature.ServerSide => "serverSide",
            DataTablesFeature.AutoWidth => "autoWidth",
            DataTablesFeature.DeferRender => "deferRender",
            _ => feature.ToString().ToLowerInvariant()
        };

        _features[featureName] = enabled;
        return this;
    }

    /// <summary>Enable paging with optional configuration.</summary>
    public DataTablesTable EnablePaging(int pageLength = 10, int[]? lengthMenu = null) {
        _features["paging"] = true;
        Options.PageLength = pageLength;
        Options.LengthMenu = lengthMenu ?? new[] { 10, 25, 50, 100 };
        return this;
    }

    /// <summary>Disable paging.</summary>
    public DataTablesTable DisablePaging() {
        _features["paging"] = false;
        return this;
    }

    /// <summary>Enable searching with optional configuration.</summary>
    public DataTablesTable EnableSearching(bool global = true) {
        _features["searching"] = global;
        return this;
    }

    /// <summary>Disable searching.</summary>
    public DataTablesTable DisableSearching() {
        _features["searching"] = false;
        return this;
    }

    /// <summary>Enable column ordering.</summary>
    public DataTablesTable EnableOrdering(bool enabled = true) {
        _features["ordering"] = enabled;
        return this;
    }

    /// <summary>Configure scrolling options.</summary>
    public DataTablesTable Scrolling(string? scrollY = null, bool scrollX = false, bool scrollCollapse = false) {
        if (!string.IsNullOrEmpty(scrollY)) {
            Options.ScrollY = scrollY;
            _features["scrollY"] = true;
        }
        if (scrollX) {
            _features["scrollX"] = true;
        }
        Options.ScrollCollapse = scrollCollapse;
        return this;
    }

    #endregion

    #region Styling Methods

    /// <summary>Add a bootstrap table style.</summary>
    public DataTablesTable Style(BootStrapTableStyle style) {
        StyleList.Add(style);
        return this;
    }

    /// <summary>Set pagination type.</summary>
    public DataTablesTable PagingType(DataTablesPagingType type) {
        Options.PagingType = type switch {
            DataTablesPagingType.Simple => "simple",
            DataTablesPagingType.SimpleNumbers => "simple_numbers",
            DataTablesPagingType.Full => "full",
            DataTablesPagingType.FullNumbers => "full_numbers",
            DataTablesPagingType.FirstLastNumbers => "first_last_numbers",
            DataTablesPagingType.Ellipsis => "ellipsis",
            _ => "full_numbers"
        };
        return this;
    }

    #endregion

    #region Column Configuration Methods

    /// <summary>Configure columns with fluent API.</summary>
    public DataTablesTable ConfigureColumns(Action<DataTablesColumnBuilder> configure) {
        var builder = new DataTablesColumnBuilder();
        configure(builder);
        _columns.AddRange(builder.GetColumns());
        return this;
    }

    /// <summary>Set default column ordering.</summary>
    public DataTablesTable DefaultOrder(int columnIndex, string direction = "asc") {
        Options.Order = new object[][] { new object[] { columnIndex, direction } };
        return this;
    }

    /// <summary>Set multiple column ordering.</summary>
    public DataTablesTable DefaultOrder(params (int column, string direction)[] orders) {
        Options.Order = orders.Select(o => new object[] { o.column, o.direction }).ToArray();
        return this;
    }

    #endregion

    #region Export Methods

    /// <summary>Enable export functionality with specified formats.</summary>
    public DataTablesTable EnableExport(params DataTablesExportFormat[] formats) {
        foreach (var format in formats) {
            var export = new DataTablesExport {
                Extend = format switch {
                    DataTablesExportFormat.Excel => "excel",
                    DataTablesExportFormat.CSV => "csv",
                    DataTablesExportFormat.PDF => "pdf",
                    DataTablesExportFormat.Copy => "copy",
                    DataTablesExportFormat.Print => "print",
                    _ => "copy"
                },
                Text = format.ToString(),
                ClassName = "btn btn-secondary btn-sm"
            };
            _exportButtons.Add(export);
        }
        return this;
    }

    /// <summary>Configure export options with fluent API.</summary>
    public DataTablesTable ConfigureExport(Action<DataTablesExportBuilder> configure) {
        var builder = new DataTablesExportBuilder();
        configure(builder);
        _exportButtons.AddRange(builder.GetExports());
        return this;
    }

    #endregion

    #region Advanced Features

    /// <summary>Enable row grouping.</summary>
    public DataTablesTable EnableRowGrouping(int columnIndex, Action<DataTablesRowGroup>? configure = null) {
        Options.RowGroup = new DataTablesRowGroup { DataSrc = columnIndex };
        configure?.Invoke(Options.RowGroup);
        return this;
    }

    /// <summary>Enable search builder.</summary>
    public DataTablesTable EnableSearchBuilder(Action<DataTablesSearchBuilder>? configure = null) {
        Options.SearchBuilder = new DataTablesSearchBuilder { Enable = true };
        configure?.Invoke(Options.SearchBuilder);
        return this;
    }

    /// <summary>Enable search panes.</summary>
    public DataTablesTable EnableSearchPanes(Action<DataTablesSearchPanes>? configure = null) {
        Options.SearchPanes = new DataTablesSearchPanes { Enable = true };
        configure?.Invoke(Options.SearchPanes);
        return this;
    }

    /// <summary>Enable fixed header.</summary>
    public DataTablesTable EnableFixedHeader(int headerOffset = 0, bool footer = false) {
        Options.FixedHeader = new DataTablesFixedHeader {
            Enable = true,
            HeaderOffset = headerOffset,
            Footer = footer
        };
        return this;
    }

    /// <summary>Enable fixed columns.</summary>
    public DataTablesTable EnableFixedColumns(int leftColumns = 0, int rightColumns = 0) {
        Options.FixedColumns = new DataTablesFixedColumns {
            LeftColumns = leftColumns > 0 ? leftColumns : null,
            RightColumns = rightColumns > 0 ? rightColumns : null
        };
        return this;
    }

    /// <summary>Enable responsive design.</summary>
    public DataTablesTable EnableResponsive(bool enabled = true) {
        Options.Responsive = enabled;
        return this;
    }

    /// <summary>Enable row selection.</summary>
    public DataTablesTable EnableSelection(string style = "single") {
        Options.Select = new { style = style };
        return this;
    }

    #endregion

    #region Configuration Methods

    /// <summary>Apply comprehensive DataTables configuration.</summary>
    public DataTablesTable Configure(Action<DataTablesOptions> configure) {
        configure?.Invoke(Options);
        return this;
    }

    /// <summary>Set localization options.</summary>
    public DataTablesTable Localize(Action<DataTablesLanguage> configure) {
        Options.Language ??= new DataTablesLanguage();
        configure(Options.Language);
        return this;
    }

    /// <summary>Set DOM layout string.</summary>
    public DataTablesTable DomLayout(string dom) {
        Options.Dom = dom;
        return this;
    }

    /// <summary>Enable state saving.</summary>
    public DataTablesTable EnableStateSaving(bool enabled = true) {
        Options.StateSave = enabled;
        return this;
    }

    #endregion

    #region Library Registration

    /// <summary>Registers the required libraries for DataTables based on features used.</summary>
    protected internal override void RegisterLibraries() {
        // Always register base DataTables and jQuery
        Document?.Configuration.Libraries.TryAdd(Libraries.JQuery, 0);
        Document?.Configuration.Libraries.TryAdd(Libraries.DataTables, 0);

        // Register extension libraries based on features used
        RegisterFeatureLibraries();
    }

    /// <summary>Registers libraries for specific features that are enabled.</summary>
    private void RegisterFeatureLibraries() {
        // Export functionality
        if (_exportButtons.Any() || Options.Buttons?.Any() == true) {
            Document?.Configuration.Libraries.TryAdd(Libraries.DataTablesButtons, 0);
        }

        // Responsive design
        if (Options.Responsive != null) {
            Document?.Configuration.Libraries.TryAdd(Libraries.DataTablesResponsive, 0);
        }

        // Fixed header
        if (Options.FixedHeader?.Enable == true) {
            Document?.Configuration.Libraries.TryAdd(Libraries.DataTablesFixedHeader, 0);
        }

        // Fixed columns
        if (Options.FixedColumns?.LeftColumns > 0 || Options.FixedColumns?.RightColumns > 0) {
            Document?.Configuration.Libraries.TryAdd(Libraries.DataTablesFixedColumns, 0);
        }

        // Row grouping
        if (Options.RowGroup != null) {
            Document?.Configuration.Libraries.TryAdd(Libraries.DataTablesRowGroup, 0);
        }

        // Search builder
        if (Options.SearchBuilder?.Enable == true) {
            Document?.Configuration.Libraries.TryAdd(Libraries.DataTablesSearchBuilder, 0);
        }

        // Search panes
        if (Options.SearchPanes?.Enable == true) {
            Document?.Configuration.Libraries.TryAdd(Libraries.DataTablesSearchPanes, 0);
        }

        // Row selection
        if (Options.Select != null) {
            Document?.Configuration.Libraries.TryAdd(Libraries.DataTablesSelect, 0);
        }
    }

    #endregion

    #region Build Methods

    /// <summary>Builds the final table markup including initialization script.</summary>
    public override string BuildTable() {
        // Register libraries before building
        RegisterLibraries();

        string tableInside = base.BuildTable();
        string classNames = StyleList.BuildTableStyles();

        var tableTag = new HtmlTag("table")
            .Id(Id)
            .Class(classNames)
            .Value(tableInside)
            .Attribute("width", "100%");

        // Merge all configurations
        var merged = new Dictionary<string, object>(_features);

        // Add column configurations
        if (_columns.Any()) {
            Options.ColumnDefs = _columns;
        }

        // Add export buttons
        if (_exportButtons.Any()) {
            Options.Buttons = _exportButtons;
            // Ensure DOM includes buttons if not already specified
            if (string.IsNullOrEmpty(Options.Dom)) {
                Options.Dom = "Bfrtip"; // B = buttons, f = filter, r = processing, t = table, i = info, p = pagination
            }
        }

        // Serialize options and merge with features
        var optionsJson = JsonSerializer.Serialize(Options, new JsonSerializerOptions {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        var optionsDict = JsonSerializer.Deserialize<Dictionary<string, object>>(optionsJson) ?? new Dictionary<string, object>();

        foreach (var kv in optionsDict.Where(kv => kv.Value != null)) {
            merged[kv.Key] = kv.Value;
        }

        var configuration = JsonSerializer.Serialize(merged, new JsonSerializerOptions {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        });

        var scriptTag = new HtmlTag("script").Value($@"
        $(document).ready(function() {{
            $('#{Id}').DataTable({configuration});
        }});
        ");

        return tableTag + scriptTag.ToString();
    }

    #endregion
}