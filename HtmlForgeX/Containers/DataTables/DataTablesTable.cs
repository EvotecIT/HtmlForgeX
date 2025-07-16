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

    /// <summary>Rendering mode for this table (overrides global setting if set)</summary>
    public DataTablesRenderMode? RenderMode { get; set; }

    /// <summary>Data source for JavaScript rendering</summary>
    private object[]? _dataSource;

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

    #region Rendering Mode Methods

    /// <summary>Set the rendering mode for this table.</summary>
    public DataTablesTable SetRenderMode(DataTablesRenderMode mode) {
        RenderMode = mode;
        return this;
    }

    /// <summary>Enable JavaScript rendering for better performance.</summary>
    public DataTablesTable EnableJavaScriptRendering() {
        RenderMode = DataTablesRenderMode.JavaScript;
        return this;
    }

    /// <summary>Enable HTML rendering (traditional mode).</summary>
    public DataTablesTable EnableHtmlRendering() {
        RenderMode = DataTablesRenderMode.Html;
        return this;
    }

    /// <summary>Enable automatic rendering mode selection based on data size.</summary>
    public DataTablesTable EnableAutoRendering() {
        RenderMode = DataTablesRenderMode.Auto;
        return this;
    }

    /// <summary>Determines the effective rendering mode for this table.</summary>
    private DataTablesRenderMode GetEffectiveRenderMode() {
        // Use table-specific setting if available
        if (RenderMode.HasValue) {
            if (RenderMode.Value == DataTablesRenderMode.Auto) {
                return DetermineAutoRenderMode();
            }
            return RenderMode.Value;
        }

        // Fall back to global document setting
        var globalConfig = Document?.Configuration.DataTables;
        if (globalConfig != null) {
            if (globalConfig.DefaultRenderMode == DataTablesRenderMode.Auto) {
                return DetermineAutoRenderMode();
            }
            return globalConfig.DefaultRenderMode;
        }

        // Default to HTML rendering
        return DataTablesRenderMode.Html;
    }

    /// <summary>Determines render mode automatically based on data size.</summary>
    private DataTablesRenderMode DetermineAutoRenderMode() {
        var threshold = Document?.Configuration.DataTables?.AutoModeThreshold ?? 1000;
        var rowCount = TableRows.Count;

        return rowCount > threshold ? DataTablesRenderMode.JavaScript : DataTablesRenderMode.Html;
    }

    /// <summary>Prepares data source for JavaScript rendering.</summary>
    private void PrepareDataSource() {
        if (TableRows.Count == 0) return;

        var data = new List<object>();

        foreach (var row in TableRows) {
            var rowData = new List<object>();
            foreach (var cell in row) {
                rowData.Add(cell);
            }
            data.Add(rowData.ToArray());
        }

        _dataSource = data.ToArray();
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
        base.RegisterLibraries();

        // Always register base DataTables and jQuery
        Document?.AddLibrary(Libraries.JQuery);
        Document?.AddLibrary(Libraries.DataTables);

        // Register extension libraries based on features used
        RegisterFeatureLibraries();
    }

    /// <summary>Registers libraries for specific features that are enabled.</summary>
    private void RegisterFeatureLibraries() {
        // Export functionality
        if (_exportButtons.Any() || Options.Buttons?.Any() == true) {
            Document?.AddLibrary(Libraries.DataTablesButtons);
        }

        // Responsive design
        if (Options.Responsive != null) {
            Document?.AddLibrary(Libraries.DataTablesResponsive);
        }

        // Fixed header
        if (Options.FixedHeader?.Enable == true) {
            Document?.AddLibrary(Libraries.DataTablesFixedHeader);
        }

        // Fixed columns
        if (Options.FixedColumns?.LeftColumns > 0 || Options.FixedColumns?.RightColumns > 0) {
            Document?.AddLibrary(Libraries.DataTablesFixedColumns);
        }

        // Row grouping
        if (Options.RowGroup != null) {
            Document?.AddLibrary(Libraries.DataTablesRowGroup);
        }

        // Search builder
        if (Options.SearchBuilder?.Enable == true) {
            Document?.AddLibrary(Libraries.DataTablesSearchBuilder);
        }

        // Search panes
        if (Options.SearchPanes?.Enable == true) {
            Document?.AddLibrary(Libraries.DataTablesSearchPanes);
        }

        // Row selection
        if (Options.Select != null) {
            Document?.AddLibrary(Libraries.DataTablesSelect);
        }
    }

    #endregion

    #region Build Methods

    /// <summary>Builds the final table markup including initialization script.</summary>
    public override string BuildTable() {
        // Register libraries before building
        RegisterLibraries();

        // Determine effective rendering mode
        var renderMode = GetEffectiveRenderMode();

        // Apply global configuration defaults
        ApplyGlobalConfiguration();

        // Build table based on rendering mode
        return renderMode switch {
            DataTablesRenderMode.JavaScript => BuildJavaScriptTable(),
            DataTablesRenderMode.Html => BuildHtmlTable(),
            _ => BuildHtmlTable() // Default fallback
        };
    }

    /// <summary>Applies global configuration settings to this table.</summary>
    private void ApplyGlobalConfiguration() {
        var globalConfig = Document?.Configuration.DataTables;
        if (globalConfig == null) return;

        // Apply global defaults if not already set
        if (!_features.ContainsKey("deferRender") && globalConfig.EnableDeferredRendering) {
            _features["deferRender"] = true;
        }

        if (!_features.ContainsKey("processing") && globalConfig.EnableProcessingIndicator) {
            _features["processing"] = true;
        }

        if (!_features.ContainsKey("serverSide") && globalConfig.EnableServerSideProcessing) {
            _features["serverSide"] = true;
        }

        // Set default page length if not already configured
        if (Options.PageLength == null) {
            Options.PageLength = globalConfig.DefaultPageLength;
        }

        // Apply global column defaults to all columns
        ApplyGlobalColumnDefaults(globalConfig);
    }

    /// <summary>Applies global column defaults to all columns in the table.</summary>
    private void ApplyGlobalColumnDefaults(DataTablesGlobalConfig globalConfig) {
        // If no columns are explicitly configured, create default column configurations
        if (!_columns.Any() && TableHeaders.Count > 0) {
            for (int i = 0; i < TableHeaders.Count; i++) {
                var column = new DataTablesColumn {
                    Targets = i,
                    Title = TableHeaders[i]
                };
                ApplyGlobalDefaultsToColumn(column, globalConfig);
                _columns.Add(column);
            }
        } else {
            // Apply global defaults to existing columns where not already set
            foreach (var column in _columns) {
                ApplyGlobalDefaultsToColumn(column, globalConfig);
            }
        }
    }

    /// <summary>Applies global defaults to a single column configuration.</summary>
    private void ApplyGlobalDefaultsToColumn(DataTablesColumn column, DataTablesGlobalConfig globalConfig) {
        // Apply default width if not set
        if (string.IsNullOrEmpty(column.Width) && !string.IsNullOrEmpty(globalConfig.DefaultColumnWidth)) {
            column.Width = globalConfig.DefaultColumnWidth;
        }

        // Apply default type if not set
        if (string.IsNullOrEmpty(column.Type) && globalConfig.DefaultColumnType.HasValue) {
            column.Type = globalConfig.DefaultColumnType.Value.ToString().ToLowerInvariant();
        }

        // Build CSS class string from global defaults
        var cssClasses = new List<string>();

        // Add existing classes if any
        if (!string.IsNullOrEmpty(column.ClassName)) {
            cssClasses.AddRange(column.ClassName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        }

        // Apply default alignment if not already in CSS classes
        if (globalConfig.DefaultColumnAlignment.HasValue &&
            !cssClasses.Any(c => c.Contains("text-") || c.Contains("align-"))) {
            var alignmentClass = globalConfig.DefaultColumnAlignment.Value switch {
                DataTablesTextAlign.Left => "text-start",
                DataTablesTextAlign.Center => "text-center",
                DataTablesTextAlign.Right => "text-end",
                DataTablesTextAlign.Justify => "text-justify",
                DataTablesTextAlign.Start => "text-start",
                DataTablesTextAlign.End => "text-end",
                _ => null
            };
            if (alignmentClass != null) {
                cssClasses.Add(alignmentClass);
            }
        }

        // Apply default font weight if not already in CSS classes
        if (globalConfig.DefaultColumnFontWeight.HasValue &&
            !cssClasses.Any(c => c.Contains("fw-") || c.Contains("font-weight-"))) {
            var fontWeightClass = globalConfig.DefaultColumnFontWeight.Value switch {
                DataTablesFontWeight.Normal => "fw-normal",
                DataTablesFontWeight.Bold => "fw-bold",
                DataTablesFontWeight.Light => "fw-light",
                DataTablesFontWeight.SemiBold => "fw-semibold",
                DataTablesFontWeight.ExtraBold => "fw-bolder",
                DataTablesFontWeight.Lighter => "fw-lighter",
                DataTablesFontWeight.Bolder => "fw-bolder",
                _ => null
            };
            if (fontWeightClass != null) {
                cssClasses.Add(fontWeightClass);
            }
        }

        // Apply default column style if not already in CSS classes
        if (globalConfig.DefaultColumnStyle.HasValue &&
            !cssClasses.Any(c => c.Contains("text-") || c.Contains("bg-"))) {
            var styleClass = globalConfig.DefaultColumnStyle.Value switch {
                DataTablesColumnStyle.Highlight => "table-warning",
                DataTablesColumnStyle.Muted => "text-muted",
                DataTablesColumnStyle.Success => "text-success",
                DataTablesColumnStyle.Warning => "text-warning",
                DataTablesColumnStyle.Danger => "text-danger",
                DataTablesColumnStyle.Info => "text-info",
                DataTablesColumnStyle.Primary => "text-primary",
                DataTablesColumnStyle.Secondary => "text-secondary",
                DataTablesColumnStyle.Dark => "text-dark",
                DataTablesColumnStyle.Light => "text-light",
                _ => null
            };
            if (styleClass != null) {
                cssClasses.Add(styleClass);
            }
        }

        // Update column className if we have classes to apply
        if (cssClasses.Any()) {
            column.ClassName = string.Join(" ", cssClasses.Distinct());
        }
    }

    /// <summary>Builds traditional HTML table with DataTables initialization.</summary>
    private string BuildHtmlTable() {
        string tableInside = base.BuildTable();
        string classNames = StyleList.BuildTableStyles();

        var tableTag = new HtmlTag("table")
            .Id(Id)
            .Class(classNames)
            .Value(tableInside)
            .Attribute("width", "100%");

        var scriptTag = BuildInitializationScript();
        return tableTag + scriptTag.ToString();
    }

    /// <summary>Builds JavaScript-rendered table for better performance.</summary>
    private string BuildJavaScriptTable() {
        // Prepare data source for JavaScript rendering
        PrepareDataSource();

        string classNames = StyleList.BuildTableStyles();

        // Create empty table structure - DataTables will populate it
        var tableTag = new HtmlTag("table")
            .Id(Id)
            .Class(classNames)
            .Attribute("width", "100%");

        // Add headers if available
        if (TableHeaders.Count > 0) {
            var thead = "<thead><tr>";
            foreach (var header in TableHeaders) {
                thead += $"<th>{header}</th>";
            }
            thead += "</tr></thead>";
            tableTag.Value(thead);
        }

        var scriptTag = BuildJavaScriptInitializationScript();
        return tableTag + scriptTag.ToString();
    }

    /// <summary>Builds the DataTables initialization script.</summary>
    private HtmlTag BuildInitializationScript() {
        var merged = PrepareConfiguration();

        var configuration = JsonSerializer.Serialize(merged, new JsonSerializerOptions {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        });

        return new HtmlTag("script").Value($@"
        $(document).ready(function() {{
            $('#{Id}').DataTable({configuration});
        }});
        ");
    }

    /// <summary>Builds the JavaScript initialization script with data source.</summary>
    private HtmlTag BuildJavaScriptInitializationScript() {
        var merged = PrepareConfiguration();

        // Add data source for JavaScript rendering
        if (_dataSource != null) {
            merged["data"] = _dataSource;
        }

        // Enable deferred rendering for better performance
        merged["deferRender"] = true;

        var configuration = JsonSerializer.Serialize(merged, new JsonSerializerOptions {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        });

        var debugComment = Document?.Configuration.DataTables?.DebugMode == true
            ? $"/* DataTables JavaScript Rendering Mode - {TableRows.Count} rows */"
            : "";

        return new HtmlTag("script").Value($@"
        {debugComment}
        $(document).ready(function() {{
            $('#{Id}').DataTable({configuration});
        }});
        ");
    }

    /// <summary>Prepares the configuration object for DataTables initialization.</summary>
    private Dictionary<string, object> PrepareConfiguration() {
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

        return merged;
    }

    #endregion
}