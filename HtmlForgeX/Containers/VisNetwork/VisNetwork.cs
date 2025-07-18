using System.Text.Json;

namespace HtmlForgeX;

/// <summary>
/// Container for building interactive network diagrams using the Vis Network library.
/// </summary>
public class VisNetwork : Element {
    private readonly List<VisNetworkNodeOptions> _nodes = new();
    private readonly List<VisNetworkEdgeOptions> _edges = new();
    private VisNetworkOptions _options = new();
    private Dictionary<string, object>? _customOptions;
    private bool _enableLoadingBar;
    private string _id;

    /// <summary>
    /// Gets or sets the unique identifier of the diagram container element.
    /// </summary>
    public string Id {
        get => _id;
        set => _id = value;
    }

    /// <summary>
    /// Gets the collection of nodes to render (legacy property).
    /// </summary>
    [Obsolete("Use AddNode methods instead. This property is for backward compatibility only.")]
    public List<object> Nodes { get; } = new List<object>();

    /// <summary>
    /// Gets the collection of edges connecting nodes (legacy property).
    /// </summary>
    [Obsolete("Use AddEdge methods instead. This property is for backward compatibility only.")]
    public List<object> Edges { get; } = new List<object>();

    /// <summary>
    /// Gets a dictionary of additional options passed directly to Vis Network (legacy property).
    /// </summary>
    [Obsolete("Use WithOptions method instead. This property is for backward compatibility only.")]
    public Dictionary<string, object> Options { get; } = new Dictionary<string, object>();

    /// <summary>
    /// Gets or sets a value indicating whether the loading bar should be displayed.
    /// </summary>
    public bool EnableLoadingBar {
        get => _enableLoadingBar;
        set => _enableLoadingBar = value;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="VisNetwork"/> class.
    /// </summary>
    public VisNetwork() {
        _id = GlobalStorage.GenerateRandomId("Diagram");
    }

    /// <summary>
    /// Registers the required libraries for VisNetwork.
    /// </summary>
    protected internal override void RegisterLibraries() {
        Document?.AddLibrary(Libraries.VisNetwork);
        if (_enableLoadingBar) {
            Document?.AddLibrary(Libraries.VisNetworkLoadingBar);
        }
    }

    /// <summary>
    /// Called when the element is added to a <see cref="Document"/>.
    /// Ensures that offline embedding rules are applied to all nodes.
    /// </summary>
    protected internal override void OnAddedToDocument() {
        foreach (var node in _nodes) {
            ApplyImageEmbedding(node);
        }

        foreach (var edge in _edges) {
            if (edge.Arrows is VisNetworkArrowOptions arrowOptions) {
                ApplyArrowImageEmbedding(arrowOptions);
            }
        }

        // Handle legacy nodes
        foreach (var nodeObj in Nodes) {
            if (nodeObj is VisNetworkNode node) {
                node.ApplyDocumentConfiguration(Document!);
            }
        }
    }

    #region Fluent API - Configuration

    /// <summary>
    /// Sets the unique identifier for the network container.
    /// </summary>
    /// <param name="id">The identifier to use.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork WithId(string id) {
        _id = id;
        return this;
    }

    /// <summary>
    /// Enables the loading bar display while the network is being rendered.
    /// </summary>
    /// <param name="enable">True to enable the loading bar.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork WithLoadingBar(bool enable = true) {
        _enableLoadingBar = enable;
        return this;
    }

    /// <summary>
    /// Configures the network options.
    /// </summary>
    /// <param name="configure">Action to configure the options.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork WithOptions(Action<VisNetworkOptions> configure) {
        configure(_options);
        return this;
    }

    /// <summary>
    /// Sets an option that will be passed to the underlying Vis Network instance (legacy support).
    /// </summary>
    /// <param name="key">Option name.</param>
    /// <param name="value">Option value.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    [Obsolete("Use WithOptions method with strongly-typed configuration instead.")]
    public VisNetwork SetOption(string key, object value) {
        // This is a legacy method that directly manipulates options
        // For better type safety, use the WithOptions method
        // We'll need to handle this in the ToString method
        _customOptions ??= new Dictionary<string, object>();
        _customOptions[key] = value;
        return this;
    }

    #endregion

    #region Fluent API - Nodes

    /// <summary>
    /// Adds a node to the network.
    /// </summary>
    /// <param name="configure">Action to configure the node.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork AddNode(Action<VisNetworkNodeOptions> configure) {
        var node = new VisNetworkNodeOptions();
        configure(node);
        if (Document != null) {
            ApplyImageEmbedding(node);
        }
        _nodes.Add(node);
        return this;
    }

    /// <summary>
    /// Adds a node with the specified ID.
    /// </summary>
    /// <param name="id">The node identifier.</param>
    /// <param name="configure">Optional action to configure additional node properties.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork AddNode(object id, Action<VisNetworkNodeOptions>? configure = null) {
        var node = new VisNetworkNodeOptions { Id = id };
        configure?.Invoke(node);
        if (Document != null) {
            ApplyImageEmbedding(node);
        }
        _nodes.Add(node);
        return this;
    }

    /// <summary>
    /// Adds a strongly typed <see cref="VisNetworkNode"/> to the diagram (legacy support).
    /// </summary>
    /// <param name="node">Node to add.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork AddNode(VisNetworkNode node) {
        var nodeOptions = node.ToNodeOptions();
        if (Document != null) {
            ApplyImageEmbedding(nodeOptions);
        }
        _nodes.Add(nodeOptions);
        return this;
    }

    /// <summary>
    /// Adds a raw node object to the diagram (legacy support).
    /// </summary>
    /// <param name="node">Object containing node definition.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork AddNode(object node) {
        if (node is VisNetworkNode visNode) {
            return AddNode(visNode);
        }
        // For raw objects, we need to convert them to VisNetworkNodeOptions
        // This is a simplified conversion - in real usage, users should use the strongly-typed API
        var nodeOptions = new VisNetworkNodeOptions();
        if (node is IDictionary<string, object> dict) {
            if (dict.TryGetValue("id", out var id)) nodeOptions.Id = id;
            if (dict.TryGetValue("label", out var label)) nodeOptions.Label = label?.ToString();
            // Add more properties as needed
        }
        _nodes.Add(nodeOptions);
        return this;
    }

    /// <summary>
    /// Adds multiple nodes to the network.
    /// </summary>
    /// <param name="nodes">Collection of node configurations.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork AddNodes(params VisNetworkNodeOptions[] nodes) {
        foreach (var node in nodes) {
            if (Document != null) {
                ApplyImageEmbedding(node);
            }
            _nodes.Add(node);
        }
        return this;
    }

    /// <summary>
    /// Adds multiple nodes to the network.
    /// </summary>
    /// <param name="nodes">Collection of node configurations.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork AddNodes(IEnumerable<VisNetworkNodeOptions> nodes) {
        foreach (var node in nodes) {
            if (Document != null) {
                ApplyImageEmbedding(node);
            }
            _nodes.Add(node);
        }
        return this;
    }

    #endregion

    #region Fluent API - Edges

    /// <summary>
    /// Adds an edge to the network.
    /// </summary>
    /// <param name="configure">Action to configure the edge.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork AddEdge(Action<VisNetworkEdgeOptions> configure) {
        var edge = new VisNetworkEdgeOptions();
        configure(edge);
        if (Document != null && edge.Arrows is VisNetworkArrowOptions arrowOptions) {
            ApplyArrowImageEmbedding(arrowOptions);
        }
        _edges.Add(edge);
        return this;
    }

    /// <summary>
    /// Adds an edge connecting two nodes.
    /// </summary>
    /// <param name="from">Source node identifier.</param>
    /// <param name="to">Target node identifier.</param>
    /// <param name="configure">Optional action to configure additional edge properties.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork AddEdge(object from, object to, Action<VisNetworkEdgeOptions>? configure = null) {
        var edge = new VisNetworkEdgeOptions { From = from, To = to };
        configure?.Invoke(edge);
        if (Document != null && edge.Arrows is VisNetworkArrowOptions arrowOptions) {
            ApplyArrowImageEmbedding(arrowOptions);
        }
        _edges.Add(edge);
        return this;
    }

    /// <summary>
    /// Adds a <see cref="VisNetworkEdge"/> to the diagram (legacy support).
    /// </summary>
    /// <param name="edge">Edge to add.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork AddEdge(VisNetworkEdge edge) {
        var edgeOptions = edge.ToEdgeOptions();
        if (Document != null && edgeOptions.Arrows is VisNetworkArrowOptions arrowOptions) {
            ApplyArrowImageEmbedding(arrowOptions);
        }
        _edges.Add(edgeOptions);
        return this;
    }

    /// <summary>
    /// Adds a raw edge object to the diagram (legacy support).
    /// </summary>
    /// <param name="edge">Object containing edge definition.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork AddEdge(object edge) {
        if (edge is VisNetworkEdge visEdge) {
            return AddEdge(visEdge);
        }
        // For raw objects, we need to convert them to VisNetworkEdgeOptions
        // This is a simplified conversion - in real usage, users should use the strongly-typed API
        var edgeOptions = new VisNetworkEdgeOptions();
        if (edge is IDictionary<string, object> dict) {
            if (dict.TryGetValue("id", out var id)) edgeOptions.Id = id;
            if (dict.TryGetValue("from", out var from)) edgeOptions.From = from;
            if (dict.TryGetValue("to", out var to)) edgeOptions.To = to;
            if (dict.TryGetValue("label", out var label)) edgeOptions.Label = label?.ToString();
            // Add more properties as needed
        }
        _edges.Add(edgeOptions);
        return this;
    }

    /// <summary>
    /// Adds multiple edges to the network.
    /// </summary>
    /// <param name="edges">Collection of edge configurations.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork AddEdges(params VisNetworkEdgeOptions[] edges) {
        foreach (var edge in edges) {
            if (Document != null && edge.Arrows is VisNetworkArrowOptions arrowOptions) {
                ApplyArrowImageEmbedding(arrowOptions);
            }
            _edges.Add(edge);
        }
        return this;
    }

    /// <summary>
    /// Adds multiple edges to the network.
    /// </summary>
    /// <param name="edges">Collection of edge configurations.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork AddEdges(IEnumerable<VisNetworkEdgeOptions> edges) {
        foreach (var edge in edges) {
            if (Document != null && edge.Arrows is VisNetworkArrowOptions arrowOptions) {
                ApplyArrowImageEmbedding(arrowOptions);
            }
            _edges.Add(edge);
        }
        return this;
    }

    #endregion

    #region Fluent API - Quick Configuration

    /// <summary>
    /// Configures the physics simulation.
    /// </summary>
    /// <param name="configure">Action to configure physics options.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork WithPhysics(Action<VisNetworkPhysicsOptions> configure) {
        _options.WithPhysics(configure);
        return this;
    }

    /// <summary>
    /// Enables or disables physics simulation.
    /// </summary>
    /// <param name="enabled">True to enable physics.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork WithPhysics(bool enabled = true) {
        _options.WithPhysics(physics => physics.WithEnabled(enabled));
        return this;
    }

    /// <summary>
    /// Configures the layout algorithm.
    /// </summary>
    /// <param name="configure">Action to configure layout options.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork WithLayout(Action<VisNetworkLayoutOptions> configure) {
        _options.WithLayout(configure);
        return this;
    }

    /// <summary>
    /// Enables hierarchical layout.
    /// </summary>
    /// <param name="direction">The direction of the hierarchy.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork WithHierarchicalLayout(VisNetworkLayoutDirection direction = VisNetworkLayoutDirection.Ud) {
        _options.WithLayout(layout => {
            var hierarchicalOptions = new VisNetworkHierarchicalOptions()
                .WithEnabled(true)
                .WithDirection(direction);
            layout.WithHierarchical(hierarchicalOptions);
        });
        return this;
    }

    /// <summary>
    /// Configures interaction options.
    /// </summary>
    /// <param name="configure">Action to configure interaction options.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork WithInteraction(Action<VisNetworkInteractionOptions> configure) {
        _options.WithInteraction(configure);
        return this;
    }

    /// <summary>
    /// Configures manipulation options.
    /// </summary>
    /// <param name="configure">Action to configure manipulation options.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork WithManipulation(Action<VisNetworkManipulationOptions> configure) {
        _options.WithManipulation(configure);
        return this;
    }

    /// <summary>
    /// Sets the size of the network container.
    /// </summary>
    /// <param name="width">Width (e.g., "100%", "800px").</param>
    /// <param name="height">Height (e.g., "600px", "100vh").</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork WithSize(string width, string height) {
        _options.WithSize(width, height);
        return this;
    }

    /// <summary>
    /// Configures node groups for consistent styling.
    /// </summary>
    /// <param name="groupName">Name of the group.</param>
    /// <param name="configure">Action to configure group options.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork WithGroup(string groupName, Action<VisNetworkGroupOptions> configure) {
        _options.WithGroup(groupName, configure);
        return this;
    }

    #endregion

    #region Private Methods

    private void ApplyImageEmbedding(VisNetworkNodeOptions node) {
        if (Document == null || Document.Configuration.LibraryMode != LibraryMode.Offline) {
            return;
        }

        if (!Document.Configuration.Images.AutoEmbedImages) {
            return;
        }

        if (node.Image is string imageUrl && !string.IsNullOrEmpty(imageUrl)) {
            if (!imageUrl.StartsWith("data:", StringComparison.OrdinalIgnoreCase)) {
                node.Image = EmbedImage(imageUrl, Document.Configuration.Images.EmbeddingTimeout);
            }
        } else if (node.Image is VisNetworkImageOptions imageOptions) {
            if (imageOptions.Unselected != null && !imageOptions.Unselected.StartsWith("data:", StringComparison.OrdinalIgnoreCase)) {
                imageOptions.Unselected = EmbedImage(imageOptions.Unselected, Document.Configuration.Images.EmbeddingTimeout);
            }
            if (imageOptions.Selected != null && !imageOptions.Selected.StartsWith("data:", StringComparison.OrdinalIgnoreCase)) {
                imageOptions.Selected = EmbedImage(imageOptions.Selected, Document.Configuration.Images.EmbeddingTimeout);
            }
        }
    }

    private void ApplyArrowImageEmbedding(VisNetworkArrowOptions arrowOptions) {
        if (Document == null || Document.Configuration.LibraryMode != LibraryMode.Offline) {
            return;
        }

        if (!Document.Configuration.Images.AutoEmbedImages) {
            return;
        }

        void ProcessArrowType(object? arrowType) {
            if (arrowType is VisNetworkArrowTypeOptions typeOptions && 
                typeOptions.Src != null && 
                !typeOptions.Src.StartsWith("data:", StringComparison.OrdinalIgnoreCase)) {
                typeOptions.Src = EmbedImage(typeOptions.Src, Document.Configuration.Images.EmbeddingTimeout);
            }
        }

        ProcessArrowType(arrowOptions.To);
        ProcessArrowType(arrowOptions.From);
        ProcessArrowType(arrowOptions.Middle);
    }

    private static string EmbedImage(string source, int timeoutSeconds) {
        if (string.IsNullOrEmpty(source)) {
            return source;
        }

        try {
            byte[] bytes;
            string mimeType;

            if (Uri.TryCreate(source, UriKind.Absolute, out var uri) && 
                (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps)) {
                var download = ImageUtilities.DownloadImage(source, timeoutSeconds);
                if (download is null) {
                    return source;
                }
                (bytes, mimeType) = download.Value;
            } else if (File.Exists(source)) {
                (bytes, mimeType) = ImageUtilities.LoadImageFromFile(source);
            } else {
                return source;
            }

            var base64 = Convert.ToBase64String(bytes);
            return $"data:{mimeType};base64,{base64}";
        } catch {
            return source;
        }
    }

    #endregion

    /// <summary>
    /// Generates the HTML and JavaScript required to render the diagram.
    /// </summary>
    /// <returns>HTML string representing the network diagram.</returns>
    public override string ToString() {
        HtmlTag divTag;
        if (_enableLoadingBar || EnableLoadingBar) {
            divTag = new HtmlTag("div").Class("diagramWrapper")
                .Value(new HtmlTag("div").Class("diagram").Style("position", "relative")
                    .Value(new HtmlTag("div").Class("diagram diagramObject").Style("position", "absolute").Id(_id)))
                .Value(new HtmlTag("div").Id($"{_id}-diagramLoadingBar").Class("diagramLoadingBar")
                    .Value(new HtmlTag("div").Class("diagramOuterBorder")
                        .Value(new HtmlTag("div").Id($"{_id}-diagramText").Class("diagramText").Value("0%"))
                        .Value(new HtmlTag("div").Class("diagramBorder")
                            .Value(new HtmlTag("div").Id($"{_id}-diagramBar").Class("diagramBar")))));
        } else {
            divTag = new HtmlTag("div").Class("diagram").Style("position", "relative")
                        .Value(new HtmlTag("div").Class("diagram diagramObject").Style("position", "absolute").Id(_id));
        }

        // Combine new and legacy nodes
        var allNodes = new List<object>(_nodes);
        foreach (var node in Nodes) {
            if (node is VisNetworkNode visNode) {
                allNodes.Add(visNode.ToNodeOptions());
            } else {
                allNodes.Add(node);
            }
        }

        // Apply image embedding before serialization
        foreach (var node in allNodes.OfType<VisNetworkNodeOptions>()) {
            ApplyImageEmbedding(node);
        }

        // Combine new and legacy edges
        var allEdges = new List<object>(_edges);
        foreach (var edge in Edges) {
            if (edge is VisNetworkEdge visEdge) {
                allEdges.Add(visEdge.ToEdgeOptions());
            } else {
                allEdges.Add(edge);
            }
        }

        foreach (var edge in allEdges.OfType<VisNetworkEdgeOptions>()) {
            if (edge.Arrows is VisNetworkArrowOptions arrowOptions) {
                ApplyArrowImageEmbedding(arrowOptions);
            }
        }

        var jsonOptions = new JsonSerializerOptions {
            WriteIndented = false,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        var nodesJson = JsonSerializer.Serialize(allNodes, jsonOptions);
        var edgesJson = JsonSerializer.Serialize(allEdges, jsonOptions);
        
        // Merge options from different sources
        var mergedOptions = JsonSerializer.Deserialize<Dictionary<string, object>>(
            JsonSerializer.Serialize(_options, jsonOptions)) ?? new Dictionary<string, object>();
        
        // Add custom options from SetOption calls
        if (_customOptions != null) {
            foreach (var kvp in _customOptions) {
                mergedOptions[kvp.Key] = kvp.Value;
            }
        }
        
        // Add legacy Options
        foreach (var kvp in Options) {
            mergedOptions[kvp.Key] = kvp.Value;
        }
        
        var optionsJson = JsonSerializer.Serialize(mergedOptions, jsonOptions);

        var scriptTag = new HtmlTag("script").Value($@"
            var nodes = new vis.DataSet({nodesJson});
            var edges = new vis.DataSet({edgesJson});
            var container = document.getElementById('{_id}');
            var data = {{
                nodes: nodes,
                edges: edges
            }};
            var options = {optionsJson};
            var network = loadDiagramWithFonts(container, data, options, '{_id}', {(_enableLoadingBar || EnableLoadingBar).ToString().ToLower()}, false);
            diagramTracker['{_id}'] = network;
        ");

        return divTag + scriptTag.ToString();
    }
}

/// <summary>
/// Extension methods for VisNetwork legacy compatibility.
/// </summary>
public static class VisNetworkExtensions {
    /// <summary>
    /// Converts legacy VisNetworkNode to new VisNetworkNodeOptions.
    /// </summary>
    public static VisNetworkNodeOptions ToNodeOptions(this VisNetworkNode node) {
        var options = new VisNetworkNodeOptions()
            .WithId(node.Id!)
            .WithLabel(node.Label!)
            .WithTitle(node.Title!);

        if (node.Shape.HasValue) options.WithShape(node.Shape.Value);
        if (node.Group != null) options.WithGroup(node.Group);
        if (node.Color != null) options.WithColor(node.Color);
        if (node.Size.HasValue) options.WithSize(node.Size.Value);
        if (node.Hidden.HasValue) options.WithHidden(node.Hidden.Value);
        if (node.Physics.HasValue) options.WithPhysics(node.Physics.Value);
        if (node.X.HasValue && node.Y.HasValue) options.WithPosition(node.X.Value, node.Y.Value);
        if (node.Image != null) options.WithImage(node.Image);

        return options;
    }

    /// <summary>
    /// Converts legacy VisNetworkEdge to new VisNetworkEdgeOptions.
    /// </summary>
    public static VisNetworkEdgeOptions ToEdgeOptions(this VisNetworkEdge edge) {
        var options = new VisNetworkEdgeOptions()
            .WithConnection(edge.From!, edge.To!)
            .WithLabel(edge.Label!)
            .WithTitle(edge.Title!);

        if (edge.Arrows.HasValue && edge.Arrows.Value != VisNetworkArrows.None) {
            var arrowOptions = new VisNetworkArrowOptions();
            if (edge.Arrows.Value.HasFlag(VisNetworkArrows.To)) arrowOptions.WithTo(true);
            if (edge.Arrows.Value.HasFlag(VisNetworkArrows.From)) arrowOptions.WithFrom(true);
            if (edge.Arrows.Value.HasFlag(VisNetworkArrows.Middle)) arrowOptions.WithMiddle(true);
            options.WithArrows(arrowOptions);
        }

        if (edge.Color != null) options.WithColor(edge.Color);
        if (edge.Width.HasValue) options.WithWidth(edge.Width.Value);
        if (edge.Dashes.HasValue) options.WithDashes(edge.Dashes.Value);
        if (edge.Hidden.HasValue) options.WithHidden(edge.Hidden.Value);
        if (edge.Physics.HasValue) options.WithPhysics(edge.Physics.Value);
        if (edge.Length.HasValue) options.WithLength(edge.Length.Value);

        return options;
    }
}