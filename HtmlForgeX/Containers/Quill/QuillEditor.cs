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
        Document?.Configuration.Libraries.TryAdd(Libraries.Quill, 0);
    }

    /// <summary>
    /// Returns HTML markup representing the editor and initialization script.
    /// </summary>
    /// <returns>The HTML string that renders the editor.</returns>
    public override string ToString() {
        var div = new HtmlTag("div").Id(Id).Style("height", Height);
        var options = new JsonSerializerOptions {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        options.Converters.Add(new DescriptionEnumConverter<QuillTheme>());
        options.Converters.Add(new EnumListDescriptionConverter<QuillFormat>());
        var json = JsonSerializer.Serialize(Options, options);
        var script = new HtmlTag("script").Value($"var quill = new Quill('#{Id}', {json});");
        return div + script.ToString();
    }
}
