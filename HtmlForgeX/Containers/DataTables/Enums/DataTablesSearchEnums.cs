namespace HtmlForgeX;

/// <summary>
/// Logical operators for SearchBuilder groups.
/// </summary>
public enum DataTablesSearchLogic
{
    /// <summary>Logical AND grouping.</summary>
    And,

    /// <summary>Logical OR grouping.</summary>
    Or
}

/// <summary>
/// Comparison conditions for SearchBuilder criteria.
/// </summary>
public enum DataTablesSearchCondition
{
    /// <summary>Equality comparison.</summary>
    Equals,

    /// <summary>Inequality comparison.</summary>
    NotEquals,

    /// <summary>Greater than comparison.</summary>
    GreaterThan,

    /// <summary>Less than comparison.</summary>
    LessThan,

    /// <summary>Greater than or equal comparison.</summary>
    GreaterThanOrEqual,

    /// <summary>Less than or equal comparison.</summary>
    LessThanOrEqual,

    /// <summary>Contains substring.</summary>
    Contains,

    /// <summary>Does not contain substring.</summary>
    DoesNotContain,

    /// <summary>Starts with substring.</summary>
    StartsWith,

    /// <summary>Ends with substring.</summary>
    EndsWith
}

/// <summary>
/// Built in custom operators for SearchBuilder.
/// </summary>
public enum DataTablesBuiltInOperator
{
    /// <summary>Checks if value starts with the input.</summary>
    StartsWith,

    /// <summary>Checks if value ends with the input.</summary>
    EndsWith,

    /// <summary>Case-insensitive contains check.</summary>
    ContainsCaseInsensitive,

    /// <summary>Matches input as regular expression.</summary>
    Regex
}

/// <summary>
/// Extension helpers for SearchBuilder enums.
/// </summary>
public static class DataTablesSearchEnumExtensions
{
    /// <summary>Converts logic enum to string.</summary>
    public static string ToLogicString(this DataTablesSearchLogic logic) => logic switch
    {
        DataTablesSearchLogic.And => "AND",
        DataTablesSearchLogic.Or => "OR",
        _ => "AND"
    };

    /// <summary>Converts condition enum to string.</summary>
    public static string ToConditionString(this DataTablesSearchCondition condition) => condition switch
    {
        DataTablesSearchCondition.Equals => "equals",
        DataTablesSearchCondition.NotEquals => "not",
        DataTablesSearchCondition.GreaterThan => ">",
        DataTablesSearchCondition.LessThan => "<",
        DataTablesSearchCondition.GreaterThanOrEqual => ">=",
        DataTablesSearchCondition.LessThanOrEqual => "<=",
        DataTablesSearchCondition.Contains => "contains",
        DataTablesSearchCondition.DoesNotContain => "doesNotContain",
        DataTablesSearchCondition.StartsWith => "startsWith",
        DataTablesSearchCondition.EndsWith => "endsWith",
        _ => "equals"
    };
}
