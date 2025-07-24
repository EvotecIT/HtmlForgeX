using System.Text.Json;
using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Represents a Quill rich text editor instance.
/// </summary>
public class QuillEditor : Element {
    /// <summary>
    /// Gets or sets the id assigned to the editor container.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets the height of the editor area.
    /// </summary>
    public string Height { get; set; } = "200px";

    /// <summary>
    /// Gets or sets configuration options for the editor.
    /// </summary>
    public QuillEditorOptions Options { get; set; } = new QuillEditorOptions();

    /// <summary>
    /// Initializes a new instance of the <see cref="QuillEditor"/> class with a random identifier.
    /// </summary>
    public QuillEditor() {
        Id = GlobalStorage.GenerateRandomId("quill");
    }

    /// <summary>
    /// Registers Quill library requirements with the document.
    /// </summary>
    protected internal override void RegisterLibraries() {
        Document?.AddLibrary(Libraries.Quill);
    }

    /// <summary>
    /// Returns HTML markup representing the editor and initialization script.
    /// </summary>
    /// <returns>The HTML string that renders the editor.</returns>
    public override string ToString() {
        var div = new HtmlTag("div").Id(Id).Style("height", Height);
        var options = new JsonSerializerOptions {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        options.Converters.Add(new DescriptionEnumConverter<QuillTheme>());
        options.Converters.Add(new QuillToolbarConverter());
        var json = JsonSerializer.Serialize(Options, options);
        var safeId = Id.Replace("-", "_");
        var script = new HtmlTag("script").Value($@"
document.addEventListener('DOMContentLoaded', function() {{
    try {{
        var quill_{safeId} = new Quill('#{Id}', {json});
    }} catch (e) {{
        console.error('Error initializing Quill editor {Id}:', e);
    }}
}});");
        return div + script.ToString();
    }
}