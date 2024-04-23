namespace HtmlForgeX;

public class FancyTree : Element {
    public string Id { get; set; }
    public List<FancyTreeNode> Items { get; set; } = new List<FancyTreeNode>();

    public FancyTree() {
        // add library to the global storage, for HTML processing
        GlobalStorage.Libraries.Add(Libraries.FancyTree);
        Id = GlobalStorage.GenerateRandomId("fancyTree");
    }

    public override string ToString() {
        var divTag = new HtmlTag("div").Attribute("id", Id).Attribute("class", "fancyTree");
        var serializedNodes = System.Text.Json.JsonSerializer.Serialize(Items);
        var scriptTag = new HtmlTag("script").Value($@"
                $(function () {{
                    $('#{Id}').fancytree({{
                        extensions: ['edit', 'filter', 'childcounter'],
                        selectMode: 2,
                        autoScroll: true,
                        minExpandLevel: 1,
                        source: {serializedNodes},
                        activate: function (event, data) {{
                            var node = data.node;
                            if (node.data.href) {{
                                window.open(node.data.href, node.data.target);
                            }}
                        }},
                    }});
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