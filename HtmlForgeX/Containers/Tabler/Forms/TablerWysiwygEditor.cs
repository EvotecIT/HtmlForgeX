using System.Collections.Generic;

namespace HtmlForgeX;

/// <summary>
/// Rich text editor form element styled for Tabler.
/// </summary>
public class TablerWysiwygEditor : Element {
    private readonly string _name;
    private string? _label;
    private string _height = "200px";
    private readonly QuillEditor _editor = new();

    /// <summary>
    /// Initializes the editor with the specified name.
    /// </summary>
    public TablerWysiwygEditor(string name) {
        _name = name;
        _editor.Id = name;
    }

    /// <summary>
    /// Sets the label displayed above the editor.
    /// </summary>
    /// <param name="text">Label text.</param>
    /// <returns>The current <see cref="TablerWysiwygEditor"/> instance.</returns>
    public TablerWysiwygEditor Label(string text) { _label = text; return this; }

    /// <summary>
    /// Sets the height of the editor container.
    /// </summary>
    /// <param name="css">CSS height value.</param>
    /// <returns>The current <see cref="TablerWysiwygEditor"/> instance.</returns>
    public TablerWysiwygEditor Height(string css) { _height = css; return this; }

    /// <summary>
    /// Sets placeholder text shown when the editor is empty.
    /// </summary>
    /// <param name="text">Placeholder text.</param>
    /// <returns>The current <see cref="TablerWysiwygEditor"/> instance.</returns>
    public TablerWysiwygEditor Placeholder(string text) { _editor.Options.Placeholder = text; return this; }

    /// <summary>
    /// Sets the editor theme.
    /// </summary>
    /// <param name="theme">Theme to use.</param>
    /// <returns>The current <see cref="TablerWysiwygEditor"/> instance.</returns>
    public TablerWysiwygEditor Theme(QuillTheme theme) { _editor.Options.Theme = theme; return this; }

    /// <summary>
    /// Configures the toolbar using the given list of formats.
    /// </summary>
    /// <param name="formats">Toolbar formats.</param>
    /// <returns>The current <see cref="TablerWysiwygEditor"/> instance.</returns>
    public TablerWysiwygEditor Toolbar(List<QuillFormat> formats) {
        _editor.Options.Modules.Toolbar = formats;
        return this;
    }

    /// <inheritdoc />
    protected internal override void RegisterLibraries() {
        _editor.Document = Document;
        _editor.RegisterLibraries();
    }

    /// <inheritdoc />
    public override string ToString() {
        var wrapper = new HtmlTag("div").Class("mb-3");
        if (!string.IsNullOrEmpty(_label)) {
            wrapper.Value(new HtmlTag("label").Class("form-label").Attribute("for", _name).Value(_label));
        }
        _editor.Id = _name;
        _editor.Height = _height;
        _editor.Document = Document;
        wrapper.Value(_editor.ToString());
        return wrapper.ToString();
    }
}
