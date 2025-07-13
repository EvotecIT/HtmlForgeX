using System.Text.Json;
using System.Text.Json.Serialization;

namespace HtmlForgeX;

public class QuillEditor : Element {
    public string Id { get; set; }

    public QuillEditorOptions Options { get; set; } = new QuillEditorOptions();

    public QuillEditor() {
        Id = GlobalStorage.GenerateRandomId("quill");
    }

    protected internal override void RegisterLibraries() {
        Document?.Configuration.Libraries.TryAdd(Libraries.Quill, 0);
    }

    public override string ToString() {
        var div = new HtmlTag("div").Id(Id);
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
