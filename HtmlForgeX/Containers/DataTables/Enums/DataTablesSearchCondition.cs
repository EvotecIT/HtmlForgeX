namespace HtmlForgeX;

/// <summary>
/// Enumeration describing the available comparison operations that can be used
/// when building SearchBuilder criteria.  The enum values are converted to the
/// strings required by DataTables through <see cref="DataTablesSearchEnumExtensions"/>.
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
