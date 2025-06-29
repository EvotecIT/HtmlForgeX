namespace HtmlForgeX;

/// <summary>
/// Fancy Tree element provides a tree view of the data in a graphical way.
/// </summary>
public class FancyTree : Element {
    public string Id { get; set; }
    public List<FancyTreeNode> Items { get; set; } = new List<FancyTreeNode>();

    public FancyTreeOptions Options { get; set; } = new FancyTreeOptions();

    public FancyTree MinimumExpandLevel(int level) {
        Options.MinExpandLevel = level;
        return this;
    }

    public FancyTree AutoScroll(bool autoScroll) {
        Options.AutoScroll = autoScroll;
        return this;
    }

    public FancyTree() {
        // add library to the global storage, for HTML processing
        GlobalStorage.Libraries.TryAdd(Libraries.JQuery, 0);
        GlobalStorage.Libraries.TryAdd(Libraries.FancyTree, 0);
        Id = GlobalStorage.GenerateRandomId("fancyTree");
    }

    public override string ToString() {
        var jsonOptions = new JsonSerializerOptions {
            WriteIndented = true
        };

        var divTag = new HtmlTag("div").Attribute("id", Id).Attribute("class", "fancyTree");
        Options.Source = Items; // Add this line to set the source in the options
        var serializedOptions = System.Text.Json.JsonSerializer.Serialize(Options, jsonOptions);
        var scriptTag = new HtmlTag("script").Value($@"
        $(function () {{
            $('#{Id}').fancytree({serializedOptions});
            }});
        ");

        return divTag + scriptTag.ToString();
    }


    public FancyTreeNode Title(string title) {
        var item = new FancyTreeNode().Title(title);
        Items.Add(item);
        return item;
    }
}