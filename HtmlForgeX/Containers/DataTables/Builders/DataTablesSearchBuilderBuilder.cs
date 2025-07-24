namespace HtmlForgeX;

/// <summary>
/// Fluent builder used to configure the DataTables <c>SearchBuilder</c> plugin
/// without having to create the underlying option objects manually.  This
/// allows complex groups and custom operators to be declared using a C# API
/// and serialized to the structure expected by DataTables.
/// </summary>
public class DataTablesSearchBuilderBuilder {
    private readonly DataTablesSearchBuilder _searchBuilder = new();
    private readonly List<DataTablesSearchGroup> _groups = new();
    private readonly Dictionary<string, string> _operators = new();

    /// <summary>
    /// Enables or disables the SearchBuilder plug-in for the table.
    /// </summary>
    /// <param name="enable">Whether SearchBuilder should be enabled.</param>
    /// <returns>The current builder instance.</returns>
    public DataTablesSearchBuilderBuilder Enable(bool enable = true) {
        _searchBuilder.Enable = enable;
        return this;
    }

    /// <summary>
    /// Defines the logical operator used between top level groups.
    /// </summary>
    /// <param name="logic">Value to assign, typically <c>"AND"</c> or <c>"OR"</c>.</param>
    /// <returns>The current builder instance.</returns>
    public DataTablesSearchBuilderBuilder Logic(string logic) {
        _searchBuilder.Logic = logic;
        return this;
    }

    /// <summary>
    /// Defines the logical operator used between top level groups using
    /// a typed enumeration.
    /// </summary>
    public DataTablesSearchBuilderBuilder Logic(DataTablesSearchLogic logic) => Logic(logic.ToLogicString());

    /// <summary>
    /// Sets the default number of conditions that will be available to the
    /// user when SearchBuilder is first initialised.
    /// </summary>
    /// <param name="count">Number of conditions.</param>
    /// <returns>The current builder instance.</returns>
    public DataTablesSearchBuilderBuilder Conditions(int count) {
        _searchBuilder.Conditions = count;
        return this;
    }

    /// <summary>
    /// Enables grey-scale colour scheme which can improve readability on some
    /// backgrounds.
    /// </summary>
    /// <param name="greyscale">Value indicating whether grey-scale styling should be used.</param>
    /// <returns>The current builder instance.</returns>
    public DataTablesSearchBuilderBuilder Greyscale(bool greyscale = true) {
        _searchBuilder.Greyscale = greyscale;
        return this;
    }

    /// <summary>
    /// Injects a predefined SearchBuilder configuration object.  Useful for
    /// restoring a previous state.
    /// </summary>
    /// <param name="predefined">Object describing SearchBuilder state.</param>
    /// <returns>The current builder instance.</returns>
    public DataTablesSearchBuilderBuilder PreDefined(object predefined) {
        _searchBuilder.PreDefined = predefined;
        return this;
    }

    /// <summary>
    /// Adds a group of conditions to the SearchBuilder configuration.
    /// </summary>
    /// <param name="configure">Delegate used to configure the group.</param>
    /// <returns>The current builder instance.</returns>
    public DataTablesSearchBuilderBuilder Group(Action<DataTablesSearchGroupBuilder> configure) {
        if (configure is null)
            throw new ArgumentNullException(nameof(configure));

        var builder = new DataTablesSearchGroupBuilder();
        configure(builder);
        _groups.Add(builder.Build());
        return this;
    }

    /// <summary>
    /// Registers a custom filtering operator.
    /// </summary>
    /// <param name="name">Name of the operator as used by DataTables.</param>
    /// <param name="javascript">JavaScript implementation of the operator.</param>
    /// <returns>The current builder instance.</returns>
    public DataTablesSearchBuilderBuilder CustomOperator(string name, string javascript) {
        _operators[name] = javascript;
        return this;
    }

    /// <summary>
    /// Adds one of the predefined operators provided by <see cref="DataTablesSearchBuiltIns"/>.
    /// </summary>
    /// <param name="op">Identifier of the built-in operator.</param>
    /// <returns>The current builder instance.</returns>
    public DataTablesSearchBuilderBuilder CustomOperator(DataTablesBuiltInOperator op) {
        var (name, script) = DataTablesSearchBuiltIns.Scripts[op];
        return CustomOperator(name, script);
    }

    /// <summary>
    /// Finalises configuration and returns the resulting <see cref="DataTablesSearchBuilder"/> instance.
    /// </summary>
    /// <returns>The configured <see cref="DataTablesSearchBuilder"/>.</returns>
    internal DataTablesSearchBuilder Build() {
        if (_groups.Count > 0) {
            _searchBuilder.ConditionGroups = _groups;
        }

        if (_operators.Count > 0) {
            _searchBuilder.CustomOperators = _operators;
        }

        if (_searchBuilder.Enable is null) {
            _searchBuilder.Enable = true;
        }

        return _searchBuilder;
    }
}

/// <summary>
/// Fluent builder used to construct a single condition group for the
/// SearchBuilder configuration.
/// </summary>
public class DataTablesSearchGroupBuilder {
    private readonly DataTablesSearchGroup _group = new();

    /// <summary>
    /// Specifies the logical operator applied between conditions inside this group.
    /// </summary>
    /// <param name="logic">Typically <c>"AND"</c> or <c>"OR"</c>.</param>
    /// <returns>The current group builder.</returns>
    public DataTablesSearchGroupBuilder Logic(string logic) {
        _group.Logic = logic;
        return this;
    }

    /// <summary>
    /// Specifies the logical operator using an enumeration value.
    /// </summary>
    public DataTablesSearchGroupBuilder Logic(DataTablesSearchLogic logic) => Logic(logic.ToLogicString());

    /// <summary>
    /// Adds a filtering criterion to the group.
    /// </summary>
    /// <param name="data">Column name or data source.</param>
    /// <param name="condition">Condition identifier as expected by DataTables.</param>
    /// <param name="values">Values used by the condition.</param>
    /// <returns>The current group builder.</returns>
    public DataTablesSearchGroupBuilder Criterion(string data, string condition, params object[] values) {
        _group.Criteria ??= new List<DataTablesSearchCriterion>();
        _group.Criteria.Add(new DataTablesSearchCriterion {
            Data = data,
            Condition = condition,
            Value = values
        });
        return this;
    }

    /// <summary>
    /// Adds a filtering criterion using a strongly typed condition enumeration.
    /// </summary>
    public DataTablesSearchGroupBuilder Criterion(string data, DataTablesSearchCondition condition, params object[] values) => Criterion(data, condition.ToConditionString(), values);

    internal DataTablesSearchGroup Build() => _group;
}