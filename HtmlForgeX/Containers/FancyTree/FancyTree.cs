namespace HtmlForgeX;

/// <summary>
/// Fancy Tree element provides a tree view of the data in a graphical way.
/// </summary>
public class FancyTree : Element {
    /// <summary>
    /// Gets the unique identifier of the tree element.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Gets the list of nodes displayed by the control.
    /// </summary>
    public List<FancyTreeNode> Items { get; set; } = new List<FancyTreeNode>();

    /// <summary>
    /// Gets the options used when rendering the tree.
    /// </summary>
    public FancyTreeOptions Options { get; set; } = new FancyTreeOptions();

    /// <summary>
    /// Sets the minimum expand level for the tree.
    /// </summary>
    /// <param name="level">The level to expand to by default.</param>
    /// <returns>The current <see cref="FancyTree"/> instance.</returns>
    public FancyTree MinimumExpandLevel(int level) {
        Options.MinExpandLevel = level;
        return this;
    }

    /// <summary>
    /// Enables or disables automatic scrolling of the tree.
    /// </summary>
    /// <param name="autoScroll">Whether auto scroll should be enabled.</param>
    /// <returns>The current <see cref="FancyTree"/> instance.</returns>
    public FancyTree AutoScroll(bool autoScroll) {
        Options.AutoScroll = autoScroll;
        return this;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FancyTree"/> class.
    /// </summary>
    public FancyTree() {
        // Libraries will be registered via RegisterLibraries method
        Id = GlobalStorage.GenerateRandomId("fancyTree");
    }

    /// <summary>
    /// Registers the required libraries for FancyTree.
    /// </summary>
    protected internal override void RegisterLibraries() {
        Document?.Configuration.Libraries.TryAdd(Libraries.JQuery, 0);
        Document?.Configuration.Libraries.TryAdd(Libraries.FancyTree, 0);
    }

    /// <summary>
    /// Renders the element as an HTML fragment.
    /// </summary>
    /// <returns>The generated HTML.</returns>
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


    /// <summary>
    /// Adds a new top level node to the tree.
    /// </summary>
    /// <param name="title">Text displayed for the new node.</param>
    /// <returns>The created <see cref="FancyTreeNode"/>.</returns>
    public FancyTreeNode Title(string title) {
        var item = new FancyTreeNode().Title(title);
        Items.Add(item);
        return item;
    }
}