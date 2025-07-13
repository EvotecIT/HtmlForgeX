using System.Text.Json;

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
        var json = JsonSerializer.Serialize(Options, new JsonSerializerOptions { WriteIndented = true });
        var script = new HtmlTag("script").Value($"var quill = new Quill('#{Id}', {json});");
        return div + script.ToString();
    }
}
