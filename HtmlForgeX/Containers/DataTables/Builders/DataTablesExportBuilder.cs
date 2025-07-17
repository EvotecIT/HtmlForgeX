namespace HtmlForgeX;

/// <summary>
/// Fluent builder for DataTables export configuration
/// </summary>
public class DataTablesExportBuilder
{
    private readonly List<DataTablesExport> _exports = new List<DataTablesExport>();

    /// <summary>Add Excel export button</summary>
    public DataTablesExportBuilder Excel(string? text = null, string? filename = null, string? title = null)
    {
        _exports.Add(new DataTablesExport
        {
            Extend = "excel",
            Text = text ?? "Excel",
            Filename = filename,
            Title = title,
            ClassName = "btn btn-success btn-sm"
        });
        return this;
    }

    /// <summary>Add CSV export button</summary>
    public DataTablesExportBuilder CSV(string? text = null, string? filename = null, string? title = null)
    {
        _exports.Add(new DataTablesExport
        {
            Extend = "csv",
            Text = text ?? "CSV",
            Filename = filename,
            Title = title,
            ClassName = "btn btn-info btn-sm"
        });
        return this;
    }

    /// <summary>Add PDF export button</summary>
    public DataTablesExportBuilder PDF(string? text = null, string? filename = null, string? title = null)
    {
        _exports.Add(new DataTablesExport
        {
            Extend = "pdf",
            Text = text ?? "PDF",
            Filename = filename,
            Title = title,
            ClassName = "btn btn-danger btn-sm"
        });
        return this;
    }

    /// <summary>Add Copy to clipboard button</summary>
    public DataTablesExportBuilder Copy(string? text = null, string? title = null)
    {
        _exports.Add(new DataTablesExport
        {
            Extend = "copy",
            Text = text ?? "Copy",
            Title = title,
            ClassName = "btn btn-secondary btn-sm"
        });
        return this;
    }

    /// <summary>Add Print button</summary>
    public DataTablesExportBuilder Print(string? text = null, string? title = null)
    {
        _exports.Add(new DataTablesExport
        {
            Extend = "print",
            Text = text ?? "Print",
            Title = title,
            ClassName = "btn btn-primary btn-sm"
        });
        return this;
    }

    /// <summary>Add column visibility toggle button</summary>
    public DataTablesExportBuilder ColumnVisibility(string? text = null)
    {
        _exports.Add(new DataTablesExport
        {
            Extend = "colvis",
            Text = text ?? "Columns",
            ClassName = "btn btn-outline-secondary btn-sm"
        });
        return this;
    }

    /// <summary>Add custom export button</summary>
    public DataTablesExportBuilder Custom(Action<DataTablesExport> configure)
    {
        if (configure is null)
            throw new ArgumentNullException(nameof(configure));

        var export = new DataTablesExport();
        configure(export);
        _exports.Add(export);
        return this;
    }

    /// <summary>Configure export options for all buttons</summary>
    public DataTablesExportBuilder ConfigureAll(Action<DataTablesExportOptions> configure)
    {
        if (configure is null)
            throw new ArgumentNullException(nameof(configure));

        var options = new DataTablesExportOptions();
        configure(options);

        foreach (var export in _exports)
        {
            export.ExportOptions = options;
        }
        return this;
    }

    /// <summary>Set export options to visible columns only</summary>
    public DataTablesExportBuilder VisibleColumnsOnly()
    {
        foreach (var export in _exports)
        {
            export.ExportOptions = new DataTablesExportOptions { Columns = ":visible" };
        }
        return this;
    }

    /// <summary>Set export options to selected rows only</summary>
    public DataTablesExportBuilder SelectedRowsOnly()
    {
        foreach (var export in _exports)
        {
            export.ExportOptions = new DataTablesExportOptions { Rows = ".selected" };
        }
        return this;
    }

    /// <summary>Exclude specific columns from export</summary>
    public DataTablesExportBuilder ExcludeColumns(params int[] columnIndexes)
    {
        var excludeString = string.Join(",", columnIndexes.Select(i => $":not(:eq({i}))"));
        foreach (var export in _exports)
        {
            export.ExportOptions = new DataTablesExportOptions { Columns = excludeString };
        }
        return this;
    }

    /// <summary>Include only specific columns in export</summary>
    public DataTablesExportBuilder IncludeColumns(params int[] columnIndexes)
    {
        var includeString = string.Join(",", columnIndexes);
        foreach (var export in _exports)
        {
            export.ExportOptions = new DataTablesExportOptions { Columns = includeString };
        }
        return this;
    }

    /// <summary>Get configured exports</summary>
    internal List<DataTablesExport> GetExports() => _exports;
}