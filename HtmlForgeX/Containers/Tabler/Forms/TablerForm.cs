using System.Linq;

using HtmlForgeX.Extensions;

namespace HtmlForgeX;

/// <summary>
/// Form container that provides fluent APIs for building Tabler forms.
/// </summary>
public class TablerForm : Element {
    /// <summary>
    /// Adds a standard input element to the form.
    /// </summary>
    /// <param name="name">Name and identifier of the input.</param>
    /// <param name="config">Optional configuration callback.</param>
    /// <returns>The created <see cref="TablerInput"/>.</returns>
    public TablerInput Input(string name, Action<TablerInput>? config = null) {
        var input = new TablerInput(name);
        config?.Invoke(input);
        this.Add(input);
        return input;
    }

    /// <summary>
    /// Adds a select element to the form.
    /// </summary>
    /// <param name="name">Name and identifier of the select.</param>
    /// <param name="config">Optional configuration callback.</param>
    /// <returns>The created <see cref="TablerSelect"/>.</returns>
    public TablerSelect Select(string name, Action<TablerSelect>? config = null) {
        var select = new TablerSelect(name);
        config?.Invoke(select);
        this.Add(select);
        return select;
    }

    /// <summary>
    /// Adds an input mask element to the form.
    /// </summary>
    /// <param name="name">Name and identifier of the mask.</param>
    /// <param name="config">Optional configuration callback.</param>
    /// <returns>The created <see cref="TablerInputMask"/>.</returns>
    public TablerInputMask InputMask(string name, Action<TablerInputMask>? config = null) {
        var mask = new TablerInputMask(name);
        config?.Invoke(mask);
        this.Add(mask);
        return mask;
    }

    /// <summary>
    /// Adds a rich text editor element to the form.
    /// </summary>
    /// <param name="name">Name and identifier of the editor.</param>
    /// <param name="config">Optional configuration callback.</param>
    /// <returns>The created <see cref="TablerWysiwygEditor"/>.</returns>
    public TablerWysiwygEditor Wysiwyg(string name, Action<TablerWysiwygEditor>? config = null) {
        var editor = new TablerWysiwygEditor(name);
        config?.Invoke(editor);
        this.Add(editor);
        return editor;
    }

    /// <summary>
    /// Adds a textarea element to the form.
    /// </summary>
    /// <param name="name">Name and identifier of the textarea.</param>
    /// <param name="config">Optional configuration callback.</param>
    /// <returns>The created <see cref="TablerTextarea"/>.</returns>
    public TablerTextarea Textarea(string name, Action<TablerTextarea>? config = null) {
        var textarea = new TablerTextarea(name);
        config?.Invoke(textarea);
        this.Add(textarea);
        return textarea;
    }

    /// <summary>
    /// Generates the HTML markup for the form and its child elements.
    /// </summary>
    public override string ToString() {
        var form = new HtmlTag("form").Class("card");
        var body = new HtmlTag("div").Class("card-body");
        foreach (var child in Children.WhereNotNull()) {
            body.Value(child);
        }
        form.Value(body);
        return form.ToString();
    }
}