namespace HtmlForgeX;

/// <summary>
/// TablerFormEnums enumeration.
/// </summary>
public enum InputType {
    /// <summary>Standard single-line text input.</summary>
    Text,
    /// <summary>Email address input field.</summary>
    Email,
    /// <summary>Password input field.</summary>
    Password,
    /// <summary>Numeric input field.</summary>
    Number,
    /// <summary>Date picker field.</summary>
    Date,
    /// <summary>Time picker field.</summary>
    Time,
    /// <summary>File selection input.</summary>
    File,
    /// <summary>Telephone number input.</summary>
    Tel,
    /// <summary>URL input field.</summary>
    Url
}

/// <summary>
/// TablerFormEnums enumeration.
/// </summary>
public enum ValidationState {
    /// <summary>Input is valid.</summary>
    Valid,
    /// <summary>Input is invalid.</summary>
    Invalid,
    /// <summary>Input has a warning state.</summary>
    Warning
}

public static class InputTypeExtensions {
    /// <summary>
    /// Converts the <see cref="InputType"/> value to its HTML <c>type</c> attribute value.
    /// </summary>
    public static string ToInputString(this InputType type) => type switch {
        InputType.Text => "text",
        InputType.Email => "email",
        InputType.Password => "password",
        InputType.Number => "number",
        InputType.Date => "date",
        InputType.Time => "time",
        InputType.File => "file",
        InputType.Tel => "tel",
        InputType.Url => "url",
        _ => "text"
    };
}

public static class ValidationStateExtensions {
    /// <summary>
    /// Returns the CSS class name that represents the validation state for an input element.
    /// </summary>
    public static string ToInputClass(this ValidationState state) => state switch {
        ValidationState.Valid => "is-valid",
        ValidationState.Invalid => "is-invalid",
        ValidationState.Warning => "is-warning",
        _ => string.Empty
    };

    /// <summary>
    /// Returns the CSS class name used for validation feedback elements.
    /// </summary>
    public static string ToFeedbackClass(this ValidationState state) => state switch {
        ValidationState.Valid => "valid-feedback",
        ValidationState.Invalid => "invalid-feedback",
        ValidationState.Warning => "invalid-feedback text-warning",
        _ => string.Empty
    };
}