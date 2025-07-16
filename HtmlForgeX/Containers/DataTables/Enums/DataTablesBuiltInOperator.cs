namespace HtmlForgeX;

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
    Regex,

    /// <summary>Checks if value does not contain the input.</summary>
    NotContains,

    /// <summary>Case-insensitive equality check.</summary>
    EqualsCaseInsensitive,

    /// <summary>Checks if numeric value is greater than input.</summary>
    GreaterThan,

    /// <summary>Checks if numeric value is less than input.</summary>
    LessThan,

    /// <summary>Checks if value is null.</summary>
    IsNull,

    /// <summary>Checks if value is not null.</summary>
    IsNotNull
}
