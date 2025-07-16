namespace HtmlForgeX;

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
