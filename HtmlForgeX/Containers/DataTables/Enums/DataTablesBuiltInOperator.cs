namespace HtmlForgeX;

/// <summary>
/// List of built in filtering operators that can be added to the
/// DataTables SearchBuilder plugin.  The operators are implemented in
/// <see cref="DataTablesSearchBuiltIns"/> and exposed here as a strongly
/// typed list for convenience.
/// </summary>
public enum DataTablesBuiltInOperator
{
    /// <summary>Checks if value starts with the input.</summary>
    StartsWith,

    /// <summary>Checks if value does not start with the input.</summary>
    NotStartsWith,

    /// <summary>Checks if value ends with the input.</summary>
    EndsWith,

    /// <summary>Checks if value does not end with the input.</summary>
    NotEndsWith,

    /// <summary>Checks if value contains the input.</summary>
    Contains,

    /// <summary>Checks if value does not contain the input.</summary>
    NotContains,

    /// <summary>Case-insensitive contains check.</summary>
    ContainsCaseInsensitive,

    /// <summary>Matches input as regular expression.</summary>
    Regex,

    /// <summary>Does not match input as regular expression.</summary>
    NotRegex,

    /// <summary>Checks if value equals the input.</summary>
    Equals,

    /// <summary>Checks if value does not equal the input.</summary>
    NotEquals,

    /// <summary>Case-insensitive equality check.</summary>
    EqualsCaseInsensitive,

    /// <summary>Checks if numeric value is greater than input.</summary>
    GreaterThan,

    /// <summary>Checks if numeric value is greater than or equal to input.</summary>
    GreaterThanOrEqual,

    /// <summary>Checks if numeric value is less than input.</summary>
    LessThan,

    /// <summary>Checks if numeric value is less than or equal to input.</summary>
    LessThanOrEqual,

    /// <summary>Checks if numeric value falls between two inputs.</summary>
    Between,

    /// <summary>Checks if numeric value falls outside two inputs.</summary>
    NotBetween,

    /// <summary>Checks if value exists in provided list.</summary>
    In,

    /// <summary>Checks if value does not exist in provided list.</summary>
    NotIn,

    /// <summary>Checks if value is null.</summary>
    IsNull,

    /// <summary>Checks if value is not null.</summary>
    IsNotNull,

    /// <summary>Checks if string value is empty.</summary>
    IsEmpty,

    /// <summary>Checks if string value is not empty.</summary>
    IsNotEmpty,

    /// <summary>Checks if boolean value is true.</summary>
    IsTrue,

    /// <summary>Checks if boolean value is false.</summary>
    IsFalse,

    /// <summary>Checks if date is before provided date.</summary>
    Before,

    /// <summary>Checks if date is after provided date.</summary>
    After,

    /// <summary>Checks if date falls between two dates.</summary>
    BetweenDates,

    /// <summary>Checks if date falls outside two dates.</summary>
    NotBetweenDates
}
