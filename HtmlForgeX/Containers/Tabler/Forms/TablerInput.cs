using System;
using HtmlForgeX.Extensions;

namespace HtmlForgeX;

public class TablerInput : Element {
    private readonly string _name;
    private InputType _type = InputType.Text;
    private string? _label;
    private string? _placeholder;
    private bool _required;
    private TablerIconType? _icon;
    private ValidationState? _state;
    private string? _message;

    public TablerInput(string name) {
        _name = name;
    }

/// <summary>
/// Method Type.
/// </summary>
    public TablerInput Type(InputType type) { _type = type; return this; }
/// <summary>
/// Method Label.
/// </summary>
    public TablerInput Label(string text) { _label = text; return this; }
/// <summary>
/// Method Placeholder.
/// </summary>
    public TablerInput Placeholder(string text) { _placeholder = text; return this; }
/// <summary>
/// Method Required.
/// </summary>
    public TablerInput Required(bool required = true) { _required = required; return this; }
/// <summary>
/// Method Icon.
/// </summary>
    public TablerInput Icon(TablerIconType icon) { _icon = icon; return this; }
/// <summary>
/// Method Validation.
/// </summary>
    public TablerInput Validation(ValidationState state, string message) { _state = state; _message = message; return this; }

/// <summary>
/// Method ToString.
/// </summary>
    public override string ToString() {
        var wrapper = new HtmlTag("div").Class("mb-3");
        if (!string.IsNullOrEmpty(_label)) {
            wrapper.Value(new HtmlTag("label").Class("form-label").Attribute("for", _name).Value(_label));
        }
        var input = new HtmlTag("input")
            .Class("form-control")
            .Attribute("type", _type.ToInputString())
            .Id(_name)
            .Attribute("name", _name);
        if (!string.IsNullOrEmpty(_placeholder)) input.Attribute("placeholder", _placeholder);
        if (_required) input.Attribute("required", "required");
        if (_state != null) input.Class(_state.Value.ToInputClass());

        if (_icon != null) {
            var iconWrap = new HtmlTag("div").Class("input-icon mb-3");
            iconWrap.Value(input);
            iconWrap.Value(new HtmlTag("span").Class("input-icon-addon").Value(new TablerIconElement(_icon.Value)));
            wrapper.Value(iconWrap);
        } else {
            wrapper.Value(input);
        }
        if (_state != null && !string.IsNullOrEmpty(_message)) {
            wrapper.Value(new HtmlTag("div").Class(_state.Value.ToFeedbackClass()).Value(_message));
        }
        return wrapper.ToString();
    }
}