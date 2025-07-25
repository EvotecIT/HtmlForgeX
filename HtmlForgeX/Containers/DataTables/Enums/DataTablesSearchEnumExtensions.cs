namespace HtmlForgeX;

/// <summary>
/// Helper methods that convert the strongly typed enumeration values used for
/// SearchBuilder into the string representations expected by DataTables.
/// </summary>
public static class DataTablesSearchEnumExtensions {
    /// <summary>Converts logic enum to string.</summary>
    public static string ToLogicString(this DataTablesSearchLogic logic) => logic switch {
        DataTablesSearchLogic.And => "AND",
        DataTablesSearchLogic.Or => "OR",
        _ => "AND"
    };

    /// <summary>Converts condition enum to string.</summary>
    public static string ToConditionString(this DataTablesSearchCondition condition) => condition switch {
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