using System;

using HtmlForgeX.Extensions;

namespace HtmlForgeX;

/// <summary>
/// Generic textarea element styled with Tabler classes.
/// </summary>
public class TablerTextarea : Element {
    private readonly string _name;
    private string? _label;
    private string? _placeholder;
    private bool _required;
    private int? _rows;
    private int? _cols;
    private ValidationState? _state;
    private string? _message;
    private string? _value;
    private bool _autoResize;

    /// <summary>
    /// Initializes or configures TablerTextarea.
    /// </summary>
    public TablerTextarea(string name) {
        _name = name;
    }

    /// <summary>
    /// Sets the label text displayed above the textarea.
    /// </summary>
    /// <param name="text">The label text.</param>
    /// <returns>The current <see cref="TablerTextarea"/> instance.</returns>
    public TablerTextarea Label(string text) { _label = text; return this; }

    /// <summary>
    /// Sets the placeholder text for the textarea element.
    /// </summary>
    /// <param name="text">The placeholder text.</param>
    /// <returns>The current <see cref="TablerTextarea"/> instance.</returns>
    public TablerTextarea Placeholder(string text) { _placeholder = text; return this; }

    /// <summary>
    /// Marks the textarea as required.
    /// </summary>
    /// <param name="required">Whether the textarea is required.</param>
    /// <returns>The current <see cref="TablerTextarea"/> instance.</returns>
    public TablerTextarea Required(bool required = true) { _required = required; return this; }

    /// <summary>
    /// Sets the number of visible rows for the textarea.
    /// </summary>
    /// <param name="rows">The number of rows.</param>
    /// <returns>The current <see cref="TablerTextarea"/> instance.</returns>
    public TablerTextarea Rows(int rows) { _rows = rows; return this; }

    /// <summary>
    /// Sets the number of visible columns for the textarea.
    /// </summary>
    /// <param name="cols">The number of columns.</param>
    /// <returns>The current <see cref="TablerTextarea"/> instance.</returns>
    public TablerTextarea Cols(int cols) { _cols = cols; return this; }

    /// <summary>
    /// Sets the default value for the textarea.
    /// </summary>
    /// <param name="value">The default value.</param>
    /// <returns>The current <see cref="TablerTextarea"/> instance.</returns>
    public TablerTextarea Value(string value) { _value = value; return this; }

    /// <summary>
    /// Enables auto-resize functionality for the textarea.
    /// </summary>
    /// <param name="autoResize">Whether to enable auto-resize.</param>
    /// <returns>The current <see cref="TablerTextarea"/> instance.</returns>
    public TablerTextarea AutoResize(bool autoResize = true) { _autoResize = autoResize; return this; }

    /// <summary>
    /// Sets validation state and message for the textarea element.
    /// </summary>
    /// <param name="state">Validation state.</param>
    /// <param name="message">Message shown below the textarea.</param>
    /// <returns>The current <see cref="TablerTextarea"/> instance.</returns>
    public TablerTextarea Validation(ValidationState state, string message) { _state = state; _message = message; return this; }

    /// <summary>
    /// Generates the HTML markup for the textarea element and its wrapper.
    /// </summary>
    public override string ToString() {
        var wrapper = new HtmlTag("div").Class("mb-3");
        if (!string.IsNullOrEmpty(_label)) {
            wrapper.Value(new HtmlTag("label").Class("form-label").Attribute("for", _name).Value(_label));
        }

        var textarea = new HtmlTag("textarea")
            .Class("form-control")
            .Id(_name)
            .Attribute("name", _name);

        if (!string.IsNullOrEmpty(_placeholder)) textarea.Attribute("placeholder", _placeholder!);
        if (_required) textarea.Attribute("required", "required");
        if (_rows.HasValue) textarea.Attribute("rows", _rows.Value.ToString());
        if (_cols.HasValue) textarea.Attribute("cols", _cols.Value.ToString());
        if (_state != null) textarea.Class(_state.Value.ToInputClass());
        if (_autoResize) textarea.Attribute("data-auto-resize", "true");
        if (!string.IsNullOrEmpty(_value)) textarea.Value(_value);

        wrapper.Value(textarea);

        if (_state != null && !string.IsNullOrEmpty(_message)) {
            wrapper.Value(new HtmlTag("div").Class(_state.Value.ToFeedbackClass()).Value(_message));
        }
        return wrapper.ToString();
    }
}