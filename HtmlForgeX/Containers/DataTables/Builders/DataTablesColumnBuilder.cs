namespace HtmlForgeX;

/// <summary>
/// Fluent builder for DataTables column configuration
/// </summary>
public class DataTablesColumnBuilder
{
    private readonly List<DataTablesColumn> _columns = new List<DataTablesColumn>();
    // Tracks the next available column index when none is specified
    private int _nextIndex;

    /// <summary>Add a column configuration</summary>
    public DataTablesColumnBuilder Column(int targetIndex, Action<DataTablesColumn> configure)
    {
        var column = new DataTablesColumn { Targets = targetIndex };
        configure(column);
        _columns.Add(column);
        _nextIndex = Math.Max(_nextIndex, targetIndex + 1);
        return this;
    }

    /// <summary>Add a column configuration by name</summary>
    public DataTablesColumnBuilder Column(string name, Action<DataTablesColumn> configure)
    {
        var column = new DataTablesColumn { Name = name, Targets = _nextIndex++ };
        configure(column);
        _columns.Add(column);
        return this;
    }

    /// <summary>Configure column with fluent API</summary>
    public DataTablesColumnBuilder Column(Action<DataTablesColumnConfiguration> configure)
    {
        var config = new DataTablesColumnConfiguration(this);
        configure(config);
        return this;
    }

    /// <summary>Set column as non-orderable</summary>
    public DataTablesColumnBuilder DisableOrdering(params int[] columnIndexes)
    {
        foreach (var index in columnIndexes)
        {
            _columns.Add(new DataTablesColumn { Targets = index, Orderable = false });
        }
        return this;
    }

    /// <summary>Set column as non-searchable</summary>
    public DataTablesColumnBuilder DisableSearching(params int[] columnIndexes)
    {
        foreach (var index in columnIndexes)
        {
            _columns.Add(new DataTablesColumn { Targets = index, Searchable = false });
        }
        return this;
    }

    /// <summary>Hide columns</summary>
    public DataTablesColumnBuilder HideColumns(params int[] columnIndexes)
    {
        foreach (var index in columnIndexes)
        {
            _columns.Add(new DataTablesColumn { Targets = index, Visible = false });
        }
        return this;
    }

    /// <summary>Set column widths</summary>
    public DataTablesColumnBuilder SetWidth(int columnIndex, string width)
    {
        _columns.Add(new DataTablesColumn { Targets = columnIndex, Width = width });
        return this;
    }

    /// <summary>Set column data type</summary>
    public DataTablesColumnBuilder SetType(int columnIndex, DataTablesColumnType type)
    {
        var typeString = type switch
        {
            DataTablesColumnType.String => "string",
            DataTablesColumnType.Numeric => "num",
            DataTablesColumnType.Date => "date",
            DataTablesColumnType.Html => "html",
            DataTablesColumnType.Currency => "currency",
            DataTablesColumnType.Percentage => "percent",
            DataTablesColumnType.FileSize => "file-size",
            DataTablesColumnType.IpAddress => "ip-address",
            DataTablesColumnType.Natural => "natural",
            _ => "string"
        };

        _columns.Add(new DataTablesColumn { Targets = columnIndex, Type = typeString });
        return this;
    }

    /// <summary>Add CSS class to column</summary>
    public DataTablesColumnBuilder AddClass(int columnIndex, string className)
    {
        _columns.Add(new DataTablesColumn { Targets = columnIndex, ClassName = className });
        return this;
    }

    /// <summary>Add a column to the collection</summary>
    internal void AddColumn(DataTablesColumn column)
    {
        if (!column.Targets.HasValue)
        {
            column.Targets = _nextIndex++;
        }
        else
        {
            _nextIndex = Math.Max(_nextIndex, column.Targets.Value + 1);
        }
        _columns.Add(column);
    }

    /// <summary>Get configured columns</summary>
    internal List<DataTablesColumn> GetColumns() => _columns;
}

/// <summary>
/// Fluent configuration for individual columns
/// </summary>
public class DataTablesColumnConfiguration
{
    private readonly DataTablesColumnBuilder _builder;
    private DataTablesColumn _column = new DataTablesColumn();

    internal DataTablesColumnConfiguration(DataTablesColumnBuilder builder)
    {
        _builder = builder;
    }

    /// <summary>Set column target index</summary>
    public DataTablesColumnConfiguration Target(int index)
    {
        _column.Targets = index;
        return this;
    }

    /// <summary>Set column name</summary>
    public DataTablesColumnConfiguration Name(string name)
    {
        _column.Name = name;
        return this;
    }

    /// <summary>Set column title</summary>
    public DataTablesColumnConfiguration Title(string title)
    {
        _column.Title = title;
        return this;
    }

    /// <summary>Set column data source</summary>
    public DataTablesColumnConfiguration Data(string data)
    {
        _column.Data = data;
        return this;
    }

    /// <summary>Set column width</summary>
    public DataTablesColumnConfiguration Width(string width)
    {
        _column.Width = width;
        return this;
    }

    /// <summary>Set column type</summary>
    public DataTablesColumnConfiguration Type(DataTablesColumnType type)
    {
        _column.Type = type switch
        {
            DataTablesColumnType.String => "string",
            DataTablesColumnType.Numeric => "num",
            DataTablesColumnType.Date => "date",
            DataTablesColumnType.Html => "html",
            DataTablesColumnType.Currency => "currency",
            DataTablesColumnType.Percentage => "percent",
            DataTablesColumnType.FileSize => "file-size",
            DataTablesColumnType.IpAddress => "ip-address",
            DataTablesColumnType.Natural => "natural",
            _ => "string"
        };
        return this;
    }

    /// <summary>Add CSS class (use styling methods instead for better type safety)</summary>
    public DataTablesColumnConfiguration ClassName(string className)
    {
        _column.ClassName = className;
        return this;
    }

    /// <summary>Set text alignment</summary>
    public DataTablesColumnConfiguration TextAlign(DataTablesTextAlign alignment)
    {
        var alignClass = alignment switch
        {
            DataTablesTextAlign.Left => "text-start",
            DataTablesTextAlign.Center => "text-center",
            DataTablesTextAlign.Right => "text-end",
            DataTablesTextAlign.Justify => "text-justify",
            DataTablesTextAlign.Start => "text-start",
            DataTablesTextAlign.End => "text-end",
            _ => "text-start"
        };

        _column.ClassName = CombineClasses(_column.ClassName, alignClass);
        return this;
    }

    /// <summary>Set font weight</summary>
    public DataTablesColumnConfiguration FontWeight(DataTablesFontWeight weight)
    {
        var weightClass = weight switch
        {
            DataTablesFontWeight.Normal => "fw-normal",
            DataTablesFontWeight.Bold => "fw-bold",
            DataTablesFontWeight.Light => "fw-light",
            DataTablesFontWeight.SemiBold => "fw-semibold",
            DataTablesFontWeight.ExtraBold => "fw-bolder",
            DataTablesFontWeight.Lighter => "fw-lighter",
            DataTablesFontWeight.Bolder => "fw-bolder",
            _ => "fw-normal"
        };

        _column.ClassName = CombineClasses(_column.ClassName, weightClass);
        return this;
    }

    /// <summary>Apply column styling</summary>
    public DataTablesColumnConfiguration Style(DataTablesColumnStyle style)
    {
        var styleClass = style switch
        {
            DataTablesColumnStyle.None => "",
            DataTablesColumnStyle.Highlight => "table-active",
            DataTablesColumnStyle.Muted => "text-muted",
            DataTablesColumnStyle.Success => "text-success",
            DataTablesColumnStyle.Warning => "text-warning",
            DataTablesColumnStyle.Danger => "text-danger",
            DataTablesColumnStyle.Info => "text-info",
            DataTablesColumnStyle.Primary => "text-primary",
            DataTablesColumnStyle.Secondary => "text-secondary",
            DataTablesColumnStyle.Dark => "text-dark",
            DataTablesColumnStyle.Light => "text-light",
            _ => ""
        };

        if (!string.IsNullOrEmpty(styleClass))
        {
            _column.ClassName = CombineClasses(_column.ClassName, styleClass);
        }
        return this;
    }

    /// <summary>Make column content bold (shorthand for FontWeight.Bold)</summary>
    public DataTablesColumnConfiguration Bold()
    {
        return FontWeight(DataTablesFontWeight.Bold);
    }

    /// <summary>Center align column content (shorthand for TextAlign.Center)</summary>
    public DataTablesColumnConfiguration Centered()
    {
        return TextAlign(DataTablesTextAlign.Center);
    }

    /// <summary>Right align column content (shorthand for TextAlign.Right)</summary>
    public DataTablesColumnConfiguration RightAligned()
    {
        return TextAlign(DataTablesTextAlign.Right);
    }

    /// <summary>Apply numeric column styling (right-aligned, monospace)</summary>
    public DataTablesColumnConfiguration NumericStyle()
    {
        _column.ClassName = CombineClasses(_column.ClassName, "text-end font-monospace");
        return this;
    }

    /// <summary>Apply currency column styling (right-aligned, bold)</summary>
    public DataTablesColumnConfiguration CurrencyStyle()
    {
        _column.ClassName = CombineClasses(_column.ClassName, "text-end fw-bold");
        return this;
    }

    /// <summary>Apply percentage column styling (right-aligned, centered)</summary>
    public DataTablesColumnConfiguration PercentageStyle()
    {
        _column.ClassName = CombineClasses(_column.ClassName, "text-end");
        return this;
    }

    /// <summary>Apply date column styling (centered)</summary>
    public DataTablesColumnConfiguration DateStyle()
    {
        _column.ClassName = CombineClasses(_column.ClassName, "text-center");
        return this;
    }

    /// <summary>Apply action column styling (centered, no wrap)</summary>
    public DataTablesColumnConfiguration ActionStyle()
    {
        _column.ClassName = CombineClasses(_column.ClassName, "text-center text-nowrap");
        return this;
    }

    /// <summary>Helper method to combine CSS classes</summary>
    private static string CombineClasses(string? existing, string newClass)
    {
        if (string.IsNullOrEmpty(existing))
            return newClass;

        return $"{existing} {newClass}";
    }

    /// <summary>Set orderable state</summary>
    public DataTablesColumnConfiguration Orderable(bool orderable = true)
    {
        _column.Orderable = orderable;
        return this;
    }

    /// <summary>Set searchable state</summary>
    public DataTablesColumnConfiguration Searchable(bool searchable = true)
    {
        _column.Searchable = searchable;
        return this;
    }

    /// <summary>Set visibility</summary>
    public DataTablesColumnConfiguration Visible(bool visible = true)
    {
        _column.Visible = visible;
        return this;
    }

    /// <summary>Set default content for empty cells</summary>
    public DataTablesColumnConfiguration DefaultContent(string content)
    {
        _column.DefaultContent = content;
        return this;
    }

    /// <summary>Set custom render function</summary>
    public DataTablesColumnConfiguration Render(string renderFunction)
    {
        _column.Render = renderFunction;
        return this;
    }

    /// <summary>Complete column configuration</summary>
    public DataTablesColumnBuilder Build()
    {
        _builder.AddColumn(_column);
        return _builder;
    }
}