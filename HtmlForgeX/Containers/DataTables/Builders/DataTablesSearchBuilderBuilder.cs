namespace HtmlForgeX;

/// <summary>
/// Fluent builder for configuring DataTables SearchBuilder.
/// </summary>
public class DataTablesSearchBuilderBuilder
{
    private readonly DataTablesSearchBuilder _searchBuilder = new();
    private readonly List<DataTablesSearchGroup> _groups = new();
    private readonly Dictionary<string, string> _operators = new();

    /// <summary>Enable or disable SearchBuilder.</summary>
    public DataTablesSearchBuilderBuilder Enable(bool enable = true)
    {
        _searchBuilder.Enable = enable;
        return this;
    }

    /// <summary>Set group logic for top level.</summary>
    public DataTablesSearchBuilderBuilder Logic(string logic)
    {
        _searchBuilder.Logic = logic;
        return this;
    }

    /// <summary>Set default number of conditions.</summary>
    public DataTablesSearchBuilderBuilder Conditions(int count)
    {
        _searchBuilder.Conditions = count;
        return this;
    }

    /// <summary>Enable grey scale.</summary>
    public DataTablesSearchBuilderBuilder Greyscale(bool greyscale = true)
    {
        _searchBuilder.Greyscale = greyscale;
        return this;
    }

    /// <summary>Set predefined configuration object.</summary>
    public DataTablesSearchBuilderBuilder PreDefined(object predefined)
    {
        _searchBuilder.PreDefined = predefined;
        return this;
    }

    /// <summary>Add a condition group.</summary>
    public DataTablesSearchBuilderBuilder Group(Action<DataTablesSearchGroupBuilder> configure)
    {
        var builder = new DataTablesSearchGroupBuilder();
        configure(builder);
        _groups.Add(builder.Build());
        return this;
    }

    /// <summary>Add a custom operator.</summary>
    public DataTablesSearchBuilderBuilder CustomOperator(string name, string javascript)
    {
        _operators[name] = javascript;
        return this;
    }

    internal DataTablesSearchBuilder Build()
    {
        if (_groups.Count > 0)
        {
            _searchBuilder.ConditionGroups = _groups;
        }

        if (_operators.Count > 0)
        {
            _searchBuilder.CustomOperators = _operators;
        }

        if (_searchBuilder.Enable is null)
        {
            _searchBuilder.Enable = true;
        }

        return _searchBuilder;
    }
}

/// <summary>
/// Fluent builder for a SearchBuilder condition group.
/// </summary>
public class DataTablesSearchGroupBuilder
{
    private readonly DataTablesSearchGroup _group = new();

    /// <summary>Set logic for the group (AND/OR).</summary>
    public DataTablesSearchGroupBuilder Logic(string logic)
    {
        _group.Logic = logic;
        return this;
    }

    /// <summary>Add a criterion to the group.</summary>
    public DataTablesSearchGroupBuilder Criterion(string data, string condition, params object[] values)
    {
        _group.Criteria ??= new List<DataTablesSearchCriterion>();
        _group.Criteria.Add(new DataTablesSearchCriterion
        {
            Data = data,
            Condition = condition,
            Value = values
        });
        return this;
    }

    internal DataTablesSearchGroup Build() => _group;
}
