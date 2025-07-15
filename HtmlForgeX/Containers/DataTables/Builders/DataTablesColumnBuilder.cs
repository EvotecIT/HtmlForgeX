namespace HtmlForgeX;

/// <summary>
/// Fluent builder for DataTables column configuration
/// </summary>
public class DataTablesColumnBuilder
{
    private readonly List<DataTablesColumn> _columns = new List<DataTablesColumn>();

    /// <summary>Add a column configuration</summary>
    public DataTablesColumnBuilder Column(int targetIndex, Action<DataTablesColumn> configure)
    {
        var column = new DataTablesColumn { Targets = targetIndex };
        configure(column);
        _columns.Add(column);
        return this;
    }

    /// <summary>Add a column configuration by name</summary>
    public DataTablesColumnBuilder Column(string name, Action<DataTablesColumn> configure)
    {
        var column = new DataTablesColumn { Name = name };
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

    /// <summary>Add CSS class</summary>
    public DataTablesColumnConfiguration ClassName(string className)
    {
        _column.ClassName = className;
        return this;
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