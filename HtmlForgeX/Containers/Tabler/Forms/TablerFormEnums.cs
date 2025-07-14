namespace HtmlForgeX;

public enum InputType {
    Text,
    Email,
    Password,
    Number,
    Date,
    Time,
    File,
    Tel,
    Url
}

public enum ValidationState {
    Valid,
    Invalid,
    Warning
}

public static class InputTypeExtensions {
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
    public static string ToInputClass(this ValidationState state) => state switch {
        ValidationState.Valid => "is-valid",
        ValidationState.Invalid => "is-invalid",
        ValidationState.Warning => "is-warning",
        _ => string.Empty
    };

    public static string ToFeedbackClass(this ValidationState state) => state switch {
        ValidationState.Valid => "valid-feedback",
        ValidationState.Invalid => "invalid-feedback",
        ValidationState.Warning => "invalid-feedback text-warning",
        _ => string.Empty
    };
}
