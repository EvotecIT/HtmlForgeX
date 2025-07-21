using System.Reflection;
using System.Text;
using System.Text.Json;

namespace HtmlForgeX;

/// <summary>
/// Container for building interactive network diagrams using the Vis Network library.
/// </summary>
public class VisNetwork : Element {
    private readonly List<VisNetworkNodeOptions> _nodes = new();
    private readonly List<VisNetworkEdgeOptions> _edges = new();
    private VisNetworkOptions _options = new();
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
        Document?.AddLibrary(Libraries.VisNetworkLoadingBar);
        
        // Check if any nodes use Font Awesome icons
        bool usesFontAwesome6 = _nodes.Any(node => 
            node.Shape == VisNetworkNodeShape.Icon && 
            node.Icon?.Face != null && 
            node.Icon.Face.Contains("Font Awesome 6")
        );
        
        bool usesFontAwesome5 = _nodes.Any(node => 
            node.Shape == VisNetworkNodeShape.Icon && 
            node.Icon?.Face != null && 
            node.Icon.Face.Contains("Font Awesome 5")
        );
        
        if (usesFontAwesome6) {
            Document?.AddLibrary(Libraries.FontAwesome6);
        }
        
        if (usesFontAwesome5) {
            Document?.AddLibrary(Libraries.FontAwesome5);
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
    /// Sets a specific option using a key-value pair (for backward compatibility).
    /// </summary>
    /// <param name="key">The option key (e.g., "nodes", "edges", "physics")</param>
    /// <param name="value">The option value</param>
    /// <returns>The current VisNetwork instance for method chaining</returns>
    public VisNetwork WithOptions(string key, object value) {
        // Use reflection to set the appropriate property on _options
        var property = _options.GetType().GetProperty(key, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
        if (property != null) {
            // Convert anonymous type to JSON and back to target type for compatibility
            var json = JsonSerializer.Serialize(value);
            var convertedValue = JsonSerializer.Deserialize(json, property.PropertyType);
            property.SetValue(_options, convertedValue);
        }
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
        } else {
            // Handle anonymous objects and other types using reflection
            var type = node.GetType();
            var properties = type.GetProperties();
            
            foreach (var prop in properties) {
                var value = prop.GetValue(node);
                if (value == null) continue;
                
                switch (prop.Name.ToLowerInvariant()) {
                    case "id":
                        nodeOptions.Id = value;
                        break;
                    case "label":
                        nodeOptions.Label = value.ToString();
                        break;
                    case "title":
                        nodeOptions.Title = value.ToString();
                        break;
                    case "group":
                        nodeOptions.Group = value.ToString();
                        break;
                    case "color":
                        nodeOptions.Color = value.ToString();
                        break;
                    case "image":
                        nodeOptions.Image = value.ToString();
                        break;
                    case "shape":
                        if (value is string shapeStr && Enum.TryParse<VisNetworkNodeShape>(shapeStr, true, out var shape)) {
                            nodeOptions.Shape = shape;
                        }
                        break;
                    case "size":
                        if (value is double size) {
                            nodeOptions.Size = size;
                        } else if (double.TryParse(value.ToString(), out var sizeValue)) {
                            nodeOptions.Size = sizeValue;
                        }
                        break;
                    case "hidden":
                        if (value is bool hidden) {
                            nodeOptions.Hidden = hidden;
                        }
                        break;
                    case "physics":
                        if (value is bool physics) {
                            nodeOptions.Physics = physics;
                        }
                        break;
                    case "x":
                        if (value is double x) {
                            nodeOptions.X = x;
                        } else if (double.TryParse(value.ToString(), out var xValue)) {
                            nodeOptions.X = xValue;
                        }
                        break;
                    case "y":
                        if (value is double y) {
                            nodeOptions.Y = y;
                        } else if (double.TryParse(value.ToString(), out var yValue)) {
                            nodeOptions.Y = yValue;
                        }
                        break;
                }
            }
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
        } else {
            // Handle anonymous objects and other types using reflection
            var type = edge.GetType();
            var properties = type.GetProperties();
            
            foreach (var prop in properties) {
                var value = prop.GetValue(edge);
                if (value == null) continue;
                
                switch (prop.Name.ToLowerInvariant()) {
                    case "id":
                        edgeOptions.Id = value;
                        break;
                    case "from":
                        edgeOptions.From = value;
                        break;
                    case "to":
                        edgeOptions.To = value;
                        break;
                    case "label":
                        edgeOptions.Label = value.ToString();
                        break;
                    case "title":
                        edgeOptions.Title = value.ToString();
                        break;
                    case "color":
                        edgeOptions.Color = value.ToString();
                        break;
                    case "width":
                        if (value is double width) {
                            edgeOptions.Width = width;
                        } else if (double.TryParse(value.ToString(), out var widthValue)) {
                            edgeOptions.Width = widthValue;
                        }
                        break;
                    case "length":
                        if (value is double length) {
                            edgeOptions.Length = length;
                        } else if (double.TryParse(value.ToString(), out var lengthValue)) {
                            edgeOptions.Length = lengthValue;
                        }
                        break;
                    case "dashes":
                        if (value is bool dashes) {
                            edgeOptions.Dashes = dashes;
                        }
                        break;
                    case "hidden":
                        if (value is bool hidden) {
                            edgeOptions.Hidden = hidden;
                        }
                        break;
                    case "physics":
                        if (value is bool physics) {
                            edgeOptions.Physics = physics;
                        }
                        break;
                    case "arrows":
                        if (value is string arrowsStr) {
                            // Handle string arrows like "to" or "from"
                            var arrowsValue = VisNetworkArrows.None;
                            if (arrowsStr.IndexOf("to", StringComparison.OrdinalIgnoreCase) >= 0) {
                                arrowsValue |= VisNetworkArrows.To;
                            }
                            if (arrowsStr.IndexOf("from", StringComparison.OrdinalIgnoreCase) >= 0) {
                                arrowsValue |= VisNetworkArrows.From;
                            }
                            if (arrowsStr.IndexOf("middle", StringComparison.OrdinalIgnoreCase) >= 0) {
                                arrowsValue |= VisNetworkArrows.Middle;
                            }
                            if (arrowsValue != VisNetworkArrows.None) {
                                edgeOptions.Arrows = arrowsValue;
                            }
                        }
                        break;
                }
            }
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
    /// Configures event handlers for the network.
    /// </summary>
    /// <param name="configure">Action to configure events.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork WithEvents(Action<VisNetworkEvents> configure) {
        _options.WithEvents(configure);
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

    #region Clustering Methods

    private List<VisNetworkClusteringCommand>? _clusteringCommands;

    /// <summary>
    /// Clusters nodes based on custom join condition.
    /// </summary>
    /// <param name="configure">Action to configure clustering options.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork Cluster(Action<VisNetworkClusteringOptions> configure) {
        var options = new VisNetworkClusteringOptions();
        configure(options);
        
        _clusteringCommands ??= new List<VisNetworkClusteringCommand>();
        _clusteringCommands.Add(new VisNetworkClusteringCommand {
            Method = "cluster",
            Options = options
        });
        
        return this;
    }

    /// <summary>
    /// Clusters a node and all nodes connected to it.
    /// </summary>
    /// <param name="nodeId">The node ID to cluster with its connections.</param>
    /// <param name="configure">Optional action to configure clustering options.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork ClusterByConnection(object nodeId, Action<VisNetworkClusterByConnectionOptions>? configure = null) {
        var options = new VisNetworkClusterByConnectionOptions { NodeId = nodeId };
        configure?.Invoke(options);
        
        _clusteringCommands ??= new List<VisNetworkClusteringCommand>();
        _clusteringCommands.Add(new VisNetworkClusteringCommand {
            Method = "clusterByConnection",
            NodeId = nodeId,
            Options = options
        });
        
        return this;
    }

    /// <summary>
    /// Clusters nodes that have equal or more edges than the specified hubsize.
    /// </summary>
    /// <param name="hubsize">Minimum number of edges to be considered a hub. Default is 3.</param>
    /// <param name="configure">Optional action to configure clustering options.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork ClusterByHubsize(int hubsize = 3, Action<VisNetworkClusterByHubsizeOptions>? configure = null) {
        var options = new VisNetworkClusterByHubsizeOptions { Hubsize = hubsize };
        configure?.Invoke(options);
        
        _clusteringCommands ??= new List<VisNetworkClusteringCommand>();
        _clusteringCommands.Add(new VisNetworkClusteringCommand {
            Method = "clusterByHubsize",
            Hubsize = hubsize,
            Options = options
        });
        
        return this;
    }

    /// <summary>
    /// Clusters all nodes with only one edge (outliers).
    /// </summary>
    /// <param name="configure">Optional action to configure clustering options.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork ClusterOutliers(Action<VisNetworkClusteringOptions>? configure = null) {
        var options = new VisNetworkClusteringOptions();
        configure?.Invoke(options);
        
        _clusteringCommands ??= new List<VisNetworkClusteringCommand>();
        _clusteringCommands.Add(new VisNetworkClusteringCommand {
            Method = "clusterOutliers",
            Options = options
        });
        
        return this;
    }

    /// <summary>
    /// Opens (releases nodes from) a cluster.
    /// </summary>
    /// <param name="nodeId">The cluster node ID to open.</param>
    /// <param name="configure">Optional action to configure opening options.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork OpenCluster(object nodeId, Action<VisNetworkOpenClusterOptions>? configure = null) {
        var options = new VisNetworkOpenClusterOptions();
        configure?.Invoke(options);
        
        _clusteringCommands ??= new List<VisNetworkClusteringCommand>();
        _clusteringCommands.Add(new VisNetworkClusteringCommand {
            Method = "openCluster",
            NodeId = nodeId,
            OpenOptions = options
        });
        
        return this;
    }

    /// <summary>
    /// Clusters nodes by their group property.
    /// </summary>
    /// <param name="groupName">The group name to cluster.</param>
    /// <param name="configure">Optional action to configure clustering options.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork ClusterByGroup(string groupName, Action<VisNetworkClusteringOptions>? configure = null) {
        var options = new VisNetworkClusteringOptions();
        configure?.Invoke(options);
        
        // Set default join condition for group clustering
        options.JoinCondition ??= $@"
            function(nodeOptions, childNodeOptions) {{
                return childNodeOptions && childNodeOptions.group === '{groupName}';
            }}";
        
        _clusteringCommands ??= new List<VisNetworkClusteringCommand>();
        _clusteringCommands.Add(new VisNetworkClusteringCommand {
            Method = "cluster",
            Options = options
        });
        
        return this;
    }

    /// <summary>
    /// Internal class to store clustering commands.
    /// </summary>
    private class VisNetworkClusteringCommand {
        public string Method { get; set; } = string.Empty;
        public object? NodeId { get; set; }
        public int? Hubsize { get; set; }
        public VisNetworkClusteringOptions? Options { get; set; }
        public VisNetworkOpenClusterOptions? OpenOptions { get; set; }
    }

    #endregion

    #region Methods API

    private List<VisNetworkMethodCall>? _methodCalls;

    /// <summary>
    /// Fits the network view to show all nodes or specified nodes.
    /// </summary>
    /// <param name="configure">Optional action to configure fit options.</param>
    /// <param name="delay">Optional delay in milliseconds before executing the fit method.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork Fit(Action<VisNetworkFitOptions>? configure = null, int? delay = null) {
        var options = new VisNetworkFitOptions();
        configure?.Invoke(options);
        
        _methodCalls ??= new List<VisNetworkMethodCall>();
        _methodCalls.Add(new VisNetworkMethodCall {
            Method = "fit",
            Parameters = options.Nodes == null ? null : new object[] { options },
            Delay = delay
        });
        
        return this;
    }

    /// <summary>
    /// Focuses the view on a specific node.
    /// </summary>
    /// <param name="nodeId">The node ID to focus on.</param>
    /// <param name="configure">Optional action to configure focus options.</param>
    /// <param name="delay">Optional delay in milliseconds before executing the focus method.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork Focus(object nodeId, Action<VisNetworkFocusOptions>? configure = null, int? delay = null) {
        var options = new VisNetworkFocusOptions();
        configure?.Invoke(options);
        
        _methodCalls ??= new List<VisNetworkMethodCall>();
        _methodCalls.Add(new VisNetworkMethodCall {
            Method = "focus",
            Parameters = new object[] { nodeId, options },
            Delay = delay
        });
        
        return this;
    }

    /// <summary>
    /// Moves the view to a specific position.
    /// </summary>
    /// <param name="configure">Action to configure move options.</param>
    /// <param name="delay">Optional delay in milliseconds before executing the move method.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork MoveTo(Action<VisNetworkMoveToOptions> configure, int? delay = null) {
        var options = new VisNetworkMoveToOptions();
        configure(options);
        
        _methodCalls ??= new List<VisNetworkMethodCall>();
        _methodCalls.Add(new VisNetworkMethodCall {
            Method = "moveTo",
            Parameters = new object[] { options },
            Delay = delay
        });
        
        return this;
    }

    /// <summary>
    /// Selects nodes in the network.
    /// </summary>
    /// <param name="nodeIds">The node IDs to select.</param>
    /// <param name="highlightEdges">Whether to highlight connected edges.</param>
    /// <param name="delay">Optional delay in milliseconds before executing the select method.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork SelectNodes(object[] nodeIds, bool highlightEdges = true, int? delay = null) {
        _methodCalls ??= new List<VisNetworkMethodCall>();
        _methodCalls.Add(new VisNetworkMethodCall {
            Method = "selectNodes",
            Parameters = new object[] { nodeIds, highlightEdges },
            Delay = delay
        });
        
        return this;
    }

    /// <summary>
    /// Selects edges in the network.
    /// </summary>
    /// <param name="edgeIds">The edge IDs to select.</param>
    /// <param name="delay">Optional delay in milliseconds before executing the select method.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork SelectEdges(object[] edgeIds, int? delay = null) {
        _methodCalls ??= new List<VisNetworkMethodCall>();
        _methodCalls.Add(new VisNetworkMethodCall {
            Method = "selectEdges",
            Parameters = new object[] { edgeIds },
            Delay = delay
        });
        
        return this;
    }

    /// <summary>
    /// Clears all selections.
    /// </summary>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork UnselectAll(int? delay = null) {
        _methodCalls ??= new List<VisNetworkMethodCall>();
        _methodCalls.Add(new VisNetworkMethodCall {
            Method = "unselectAll",
            Delay = delay
        });
        
        return this;
    }

    /// <summary>
    /// Starts the physics simulation.
    /// </summary>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork StartSimulation(int? delay = null) {
        _methodCalls ??= new List<VisNetworkMethodCall>();
        _methodCalls.Add(new VisNetworkMethodCall {
            Method = "startSimulation",
            Delay = delay
        });
        
        return this;
    }

    /// <summary>
    /// Stops the physics simulation.
    /// </summary>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork StopSimulation(int? delay = null) {
        _methodCalls ??= new List<VisNetworkMethodCall>();
        _methodCalls.Add(new VisNetworkMethodCall {
            Method = "stopSimulation",
            Delay = delay
        });
        
        return this;
    }

    /// <summary>
    /// Stabilizes the network.
    /// </summary>
    /// <param name="iterations">Optional number of iterations.</param>
    /// <param name="delay">Optional delay in milliseconds before executing the stabilize method.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork Stabilize(int? iterations = null, int? delay = null) {
        _methodCalls ??= new List<VisNetworkMethodCall>();
        _methodCalls.Add(new VisNetworkMethodCall {
            Method = "stabilize",
            Parameters = iterations.HasValue ? new object[] { iterations.Value } : null,
            Delay = delay
        });
        
        return this;
    }

    /// <summary>
    /// Sets the seed for the random layout.
    /// </summary>
    /// <param name="seed">The random seed value.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork SetSeed(int seed) {
        _methodCalls ??= new List<VisNetworkMethodCall>();
        _methodCalls.Add(new VisNetworkMethodCall {
            Method = "getSeed"  // Actually sets the seed despite the name
        });
        
        return this;
    }

    /// <summary>
    /// Redraws the network.
    /// </summary>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork Redraw(int? delay = null) {
        _methodCalls ??= new List<VisNetworkMethodCall>();
        _methodCalls.Add(new VisNetworkMethodCall {
            Method = "redraw",
            Delay = delay
        });
        
        return this;
    }

    /// <summary>
    /// Executes a custom JavaScript method on the network.
    /// </summary>
    /// <param name="methodName">The method name to call.</param>
    /// <param name="delay">Optional delay in milliseconds before executing the method.</param>
    /// <param name="parameters">Optional parameters for the method.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork ExecuteMethod(string methodName, int? delay = null, params object[] parameters) {
        _methodCalls ??= new List<VisNetworkMethodCall>();
        _methodCalls.Add(new VisNetworkMethodCall {
            Method = methodName,
            Parameters = parameters.Length > 0 ? parameters : null,
            Delay = delay
        });
        
        return this;
    }

    /// <summary>
    /// Executes a custom JavaScript method after a delay.
    /// </summary>
    /// <param name="methodName">The method name to call.</param>
    /// <param name="delay">Delay in milliseconds.</param>
    /// <param name="parameters">Optional parameters for the method.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork ExecuteMethodDelayed(string methodName, int delay, params object[] parameters) {
        _methodCalls ??= new List<VisNetworkMethodCall>();
        _methodCalls.Add(new VisNetworkMethodCall {
            Method = methodName,
            Parameters = parameters.Length > 0 ? parameters : null,
            Delay = delay
        });
        
        return this;
    }

    #endregion

    #region Public Methods - Export/Import

    /// <summary>
    /// Exports the current network state to a JSON string.
    /// </summary>
    /// <param name="configure">Optional action to configure export options.</param>
    /// <param name="callback">JavaScript callback function to receive the exported data.</param>
    /// <param name="delay">Optional delay in milliseconds before executing.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork Export(Action<VisNetworkExportOptions>? configure = null, string? callback = null, int? delay = null) {
        var options = new VisNetworkExportOptions();
        configure?.Invoke(options);

        var exportCode = @"
            var exportData = {
                nodes: nodes.get(),
                edges: edges.get(),
                timestamp: new Date().toISOString(),
                version: '1.0'
            };";

        if (options.IncludePositions) {
            exportCode += @"
            exportData.positions = network.getPositions();";
        }

        if (options.IncludeViewport) {
            exportCode += @"
            exportData.viewport = {
                position: network.getViewPosition(),
                scale: network.getScale()
            };";
        }

        if (options.IncludeOptions) {
            exportCode += @"
            exportData.options = options;";
        }

        if (!string.IsNullOrEmpty(callback)) {
            exportCode += $@"
            {callback}(exportData);";
        } else {
            exportCode += @"
            console.log('Exported network data:', exportData);
            return exportData;";
        }

        return ExecuteMethod(exportCode.Trim(), delay);
    }

    /// <summary>
    /// Imports network data from a JSON object.
    /// </summary>
    /// <param name="importDataJson">The JSON data to import.</param>
    /// <param name="clearExisting">Whether to clear existing nodes and edges.</param>
    /// <param name="delay">Optional delay in milliseconds before executing.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork Import(string importDataJson, bool clearExisting = true, int? delay = null) {
        var importCode = $@"
            var importData = {importDataJson};
            
            if ({clearExisting.ToString().ToLower()}) {{
                nodes.clear();
                edges.clear();
            }}
            
            if (importData.nodes) {{
                nodes.add(importData.nodes);
            }}
            
            if (importData.edges) {{
                edges.add(importData.edges);
            }}
            
            if (importData.positions) {{
                network.setOptions({{ physics: {{ enabled: false }} }});
                for (var nodeId in importData.positions) {{
                    if (nodes.get(nodeId)) {{
                        network.moveNode(nodeId, importData.positions[nodeId].x, importData.positions[nodeId].y);
                    }}
                }}
            }}
            
            if (importData.viewport && importData.viewport.position) {{
                network.moveTo({{
                    position: importData.viewport.position,
                    scale: importData.viewport.scale || 1
                }});
            }}
            
            network.redraw();
            console.log('Imported network data from', importData.timestamp);";

        return ExecuteMethod(importCode.Trim(), delay);
    }

    /// <summary>
    /// Exports node positions to a JSON object.
    /// </summary>
    /// <param name="callback">JavaScript callback function to receive the positions.</param>
    /// <param name="delay">Optional delay in milliseconds before executing.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork ExportPositions(string? callback = null, int? delay = null) {
        var exportCode = @"var positions = network.getPositions();";
        
        if (!string.IsNullOrEmpty(callback)) {
            exportCode += $@"
            {callback}(positions);";
        } else {
            exportCode += @"
            console.log('Node positions:', positions);
            return positions;";
        }

        return ExecuteMethod(exportCode.Trim(), delay);
    }

    /// <summary>
    /// Imports node positions from a JSON object.
    /// </summary>
    /// <param name="positionsJson">The JSON object containing node positions.</param>
    /// <param name="animate">Whether to animate the position changes.</param>
    /// <param name="delay">Optional delay in milliseconds before executing.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork ImportPositions(string positionsJson, bool animate = false, int? delay = null) {
        var importCode = $@"
            var positions = {positionsJson};
            network.setOptions({{ physics: {{ enabled: false }} }});
            
            for (var nodeId in positions) {{
                if (positions.hasOwnProperty(nodeId) && nodes.get(nodeId)) {{
                    network.moveNode(nodeId, positions[nodeId].x, positions[nodeId].y);
                }}
            }}
            
            if ({animate.ToString().ToLower()}) {{
                network.fit({{ animation: true }});
            }} else {{
                network.redraw();
            }}";

        return ExecuteMethod(importCode.Trim(), delay);
    }

    /// <summary>
    /// Downloads the network data as a JSON file.
    /// </summary>
    /// <param name="filename">The filename for the download (without extension).</param>
    /// <param name="configure">Optional action to configure export options.</param>
    /// <param name="delay">Optional delay in milliseconds before executing.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork DownloadAsJson(string filename = "network-export", Action<VisNetworkExportOptions>? configure = null, int? delay = null) {
        var options = new VisNetworkExportOptions();
        configure?.Invoke(options);

        var downloadCode = $@"
            var exportData = {{
                nodes: nodes.get(),
                edges: edges.get(),
                timestamp: new Date().toISOString(),
                version: '1.0'
            }};";

        if (options.IncludePositions) {
            downloadCode += @"
            exportData.positions = network.getPositions();";
        }

        if (options.IncludeViewport) {
            downloadCode += @"
            exportData.viewport = {
                position: network.getViewPosition(),
                scale: network.getScale()
            };";
        }

        downloadCode += $@"
            var dataStr = JSON.stringify(exportData, null, 2);
            var dataBlob = new Blob([dataStr], {{type: 'application/json'}});
            var url = URL.createObjectURL(dataBlob);
            var link = document.createElement('a');
            link.href = url;
            link.download = '{filename}.json';
            document.body.appendChild(link);
            link.click();
            document.body.removeChild(link);
            URL.revokeObjectURL(url);
            console.log('Downloaded network data as {filename}.json');";

        return ExecuteMethod(downloadCode.Trim(), delay);
    }

    /// <summary>
    /// Exports the network as an image.
    /// </summary>
    /// <param name="format">The image format (png or jpg).</param>
    /// <param name="filename">The filename for the download (without extension).</param>
    /// <param name="delay">Optional delay in milliseconds before executing.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork ExportAsImage(string format = "png", string filename = "network-image", int? delay = null) {
        var exportCode = $@"
            var canvas = network.canvas.frame.canvas;
            var url = canvas.toDataURL('image/{format}');
            var link = document.createElement('a');
            link.href = url;
            link.download = '{filename}.{format}';
            document.body.appendChild(link);
            link.click();
            document.body.removeChild(link);
            console.log('Downloaded network image as {filename}.{format}');";

        return ExecuteMethod(exportCode.Trim(), delay);
    }

    #endregion

    #region Private Methods - Event Handlers

    private string GenerateEventHandlers(VisNetworkEvents? events) {
        if (events == null) return string.Empty;

        var handlers = new List<string>();

        // Map event properties to VisNetwork event names
        var eventMappings = new Dictionary<string, string> {
            { nameof(events.OnClick), "click" },
            { nameof(events.OnDoubleClick), "doubleClick" },
            { nameof(events.OnContext), "oncontext" },
            { nameof(events.OnHold), "hold" },
            { nameof(events.OnRelease), "release" },
            { nameof(events.OnSelect), "select" },
            { nameof(events.OnSelectNode), "selectNode" },
            { nameof(events.OnSelectEdge), "selectEdge" },
            { nameof(events.OnDeselectNode), "deselectNode" },
            { nameof(events.OnDeselectEdge), "deselectEdge" },
            { nameof(events.OnDragStart), "dragStart" },
            { nameof(events.OnDragging), "dragging" },
            { nameof(events.OnDragEnd), "dragEnd" },
            { nameof(events.OnControlNodeDragEnd), "controlNodeDragEnd" },
            { nameof(events.OnControlNodeDragging), "controlNodeDragging" },
            { nameof(events.OnHoverNode), "hoverNode" },
            { nameof(events.OnBlurNode), "blurNode" },
            { nameof(events.OnHoverEdge), "hoverEdge" },
            { nameof(events.OnBlurEdge), "blurEdge" },
            { nameof(events.OnZoom), "zoom" },
            { nameof(events.OnShowPopup), "showPopup" },
            { nameof(events.OnHidePopup), "hidePopup" },
            { nameof(events.OnStartStabilizing), "startStabilizing" },
            { nameof(events.OnStabilizationProgress), "stabilizationProgress" },
            { nameof(events.OnStabilizationIterationsDone), "stabilizationIterationsDone" },
            { nameof(events.OnStabilized), "stabilized" },
            { nameof(events.OnResize), "resize" },
            { nameof(events.OnAnimationFinished), "animationFinished" },
            { nameof(events.OnConfigChange), "configChange" },
            { nameof(events.OnBeforeDrawing), "beforeDrawing" },
            { nameof(events.OnAfterDrawing), "afterDrawing" }
        };

        var eventsType = events.GetType();
        foreach (var mapping in eventMappings) {
            var property = eventsType.GetProperty(mapping.Key);
            if (property != null) {
                var value = property.GetValue(events) as string;
                if (!string.IsNullOrEmpty(value)) {
                    handlers.Add($"network.on('{mapping.Value}', {value});");
                }
            }
        }

        return handlers.Count > 0 ? "\n            " + string.Join("\n            ", handlers) : string.Empty;
    }

    #endregion

    #region Private Methods - Clustering

    private string GenerateClusteringCommands() {
        if (_clusteringCommands == null || _clusteringCommands.Count == 0) return string.Empty;

        var commands = new List<string>();
        foreach (var cmd in _clusteringCommands) {
            var jsCommand = GenerateSingleClusteringCommand(cmd);
            if (!string.IsNullOrEmpty(jsCommand)) {
                commands.Add(jsCommand);
            }
        }

        return commands.Count > 0 ? "\n            // Clustering commands\n            " + string.Join("\n            ", commands) : string.Empty;
    }

    private string GenerateSingleClusteringCommand(VisNetworkClusteringCommand cmd) {
        var jsonOptions = new JsonSerializerOptions {
            WriteIndented = false,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        switch (cmd.Method) {
            case "cluster":
                var clusterOptions = BuildClusterOptions(cmd.Options);
                return $"network.cluster({clusterOptions});";

            case "clusterByConnection":
                var nodeId = JsonSerializer.Serialize(cmd.NodeId, jsonOptions);
                var connOptions = BuildClusterOptions(cmd.Options);
                return $"network.clusterByConnection({nodeId}, {connOptions});";

            case "clusterByHubsize":
                var hubOptions = BuildClusterOptions(cmd.Options);
                if (cmd.Hubsize.HasValue) {
                    return $"network.clusterByHubsize({cmd.Hubsize.Value}, {hubOptions});";
                }
                return $"network.clusterByHubsize({hubOptions});";

            case "clusterOutliers":
                var outlierOptions = BuildClusterOptions(cmd.Options);
                return $"network.clusterOutliers({outlierOptions});";

            case "openCluster":
                var clusterId = JsonSerializer.Serialize(cmd.NodeId, jsonOptions);
                if (cmd.OpenOptions?.ReleaseFunction != null) {
                    return $"network.openCluster({clusterId}, {{{cmd.OpenOptions.ReleaseFunction}}});";
                }
                return $"network.openCluster({clusterId});";

            default:
                return string.Empty;
        }
    }

    private string BuildClusterOptions(VisNetworkClusteringOptions? options) {
        if (options == null) return "{}";

        var parts = new List<string>();
        
        // Add join condition if specified
        if (!string.IsNullOrEmpty(options.JoinCondition)) {
            parts.Add($"joinCondition: {options.JoinCondition}");
        }

        // Add process properties if specified
        if (!string.IsNullOrEmpty(options.ProcessProperties)) {
            parts.Add($"processProperties: {options.ProcessProperties}");
        }

        // Add cluster node properties
        if (options.ClusterNodeProperties != null) {
            var jsonOptions = new JsonSerializerOptions {
                WriteIndented = false,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
            var nodePropsJson = JsonSerializer.Serialize(options.ClusterNodeProperties, jsonOptions);
            parts.Add($"clusterNodeProperties: {nodePropsJson}");
        }

        // Add cluster edge properties
        if (options.ClusterEdgeProperties != null) {
            var jsonOptions = new JsonSerializerOptions {
                WriteIndented = false,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
            var edgePropsJson = JsonSerializer.Serialize(options.ClusterEdgeProperties, jsonOptions);
            parts.Add($"clusterEdgeProperties: {edgePropsJson}");
        }

        return parts.Count > 0 ? $"{{{string.Join(", ", parts)}}}" : "{}";
    }

    #endregion

    #region Private Methods - Method Calls

    private string GenerateMethodCalls() {
        if (_methodCalls == null || _methodCalls.Count == 0) return string.Empty;

        var calls = new List<string>();
        foreach (var call in _methodCalls) {
            var jsCall = GenerateSingleMethodCall(call);
            if (!string.IsNullOrEmpty(jsCall)) {
                calls.Add(jsCall);
            }
        }

        return calls.Count > 0 ? "\n            // Method calls\n            " + string.Join("\n            ", calls) : string.Empty;
    }

    private string GenerateSingleMethodCall(VisNetworkMethodCall call) {
        var jsonOptions = new JsonSerializerOptions {
            WriteIndented = false,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        string methodCall;
        
        // Check if this is custom JavaScript code
        if (call.Method.Contains("\n") || call.Method.Contains(";") || call.Method.Contains("{") || call.Method.Contains("var ") || call.Method.Contains("console.log")) {
            // This is custom JavaScript code, execute it directly
            methodCall = call.Method.Trim();
        } else {
            // Generate the parameters JSON
            var paramsJson = call.Parameters != null && call.Parameters.Length > 0
                ? string.Join(", ", call.Parameters.Select(p => JsonSerializer.Serialize(p, jsonOptions)))
                : "";

            // Generate the method call
            methodCall = $"network.{call.Method}({paramsJson});";
        }

        // Wrap with delay if specified
        if (call.Delay.HasValue && call.Delay.Value > 0) {
            return $@"setTimeout(function() {{
                {methodCall}
            }}, {call.Delay.Value});";
        }

        return methodCall;
    }

    #endregion

    /// <summary>
    /// Processes nodes to handle custom shapes by converting ctxRenderer strings to functions.
    /// </summary>
    private string ProcessCustomShapes(List<object> nodes, string networkId) {
        var customShapeMap = new Dictionary<string, string>();
        var nodesWithCustomShapes = new List<(VisNetworkNodeOptions node, string shapeName)>();
        var shapeCounter = 0;
        
        // First pass: collect all unique custom shapes
        foreach (var node in nodes) {
            if (node is VisNetworkNodeOptions nodeOptions && 
                nodeOptions.Shape == VisNetworkNodeShape.Custom && 
                !string.IsNullOrEmpty(nodeOptions.CtxRenderer)) {
                
                var shapeKey = nodeOptions.CtxRenderer.GetHashCode().ToString();
                if (!customShapeMap.ContainsKey(shapeKey)) {
                    var shapeName = $"customShape{shapeCounter++}";
                    customShapeMap[shapeKey] = shapeName;
                }
                nodesWithCustomShapes.Add((nodeOptions, customShapeMap[shapeKey]));
            }
        }
        
        var script = new StringBuilder();
        
        // Register custom shapes as functions
        if (customShapeMap.Count > 0) {
            script.AppendLine("// Register custom shapes");
            foreach (var kvp in customShapeMap) {
                var shapeName = kvp.Value;
                var shapeFunc = nodesWithCustomShapes.First(n => n.shapeName == shapeName).node.CtxRenderer;
                script.AppendLine($"var {shapeName} = {shapeFunc};");
            }
            script.AppendLine();
        }
        
        // Build nodes array
        script.AppendLine("var nodesArray = [];");
        
        foreach (var node in nodes) {
            if (node is VisNetworkNodeOptions nodeOptions && 
                nodeOptions.Shape == VisNetworkNodeShape.Custom && 
                !string.IsNullOrEmpty(nodeOptions.CtxRenderer)) {
                
                // Find the shape name for this node
                var shapeKey = nodeOptions.CtxRenderer.GetHashCode().ToString();
                var shapeName = customShapeMap[shapeKey];
                
                // Create node object without ctxRenderer
                var nodeClone = new VisNetworkNodeOptions();
                var properties = typeof(VisNetworkNodeOptions).GetProperties();
                foreach (var prop in properties) {
                    if (prop.Name != "CtxRenderer" && prop.CanRead && prop.CanWrite) {
                        prop.SetValue(nodeClone, prop.GetValue(nodeOptions));
                    }
                }
                
                var jsonOptions = new JsonSerializerOptions {
                    WriteIndented = false,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                };
                var baseNodeJson = JsonSerializer.Serialize(nodeClone, jsonOptions);
                
                // Add the node with the function reference
                script.AppendLine($@"(function() {{
                    var node = {baseNodeJson};
                    node.ctxRenderer = {shapeName};
                    nodesArray.push(node);
                }})();");
            } else {
                // Regular node
                var jsonOptions = new JsonSerializerOptions {
                    WriteIndented = false,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                };
                var nodeJson = JsonSerializer.Serialize(node, jsonOptions);
                script.AppendLine($"nodesArray.push({nodeJson});");
            }
        }
        
        script.AppendLine("var nodes = new vis.DataSet(nodesArray);");
        
        // Add edges
        var edgesJsonOptions = new JsonSerializerOptions {
            WriteIndented = false,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        var edgesJsonData = JsonSerializer.Serialize(_edges, edgesJsonOptions);
        script.AppendLine($"var edges = new vis.DataSet({edgesJsonData});");
        
        return script.ToString();
    }

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

        // Use the current nodes collection
        var allNodes = new List<object>(_nodes);

        // Apply image embedding before serialization
        foreach (var node in allNodes.OfType<VisNetworkNodeOptions>()) {
            ApplyImageEmbedding(node);
        }

        // Use the current edges collection
        var allEdges = new List<object>(_edges);

        foreach (var edge in allEdges.OfType<VisNetworkEdgeOptions>()) {
            if (edge.Arrows is VisNetworkArrowOptions arrowOptions) {
                ApplyArrowImageEmbedding(arrowOptions);
            }
        }

        var jsonOptions = new JsonSerializerOptions {
            WriteIndented = false,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        
        // Use the current options
        var mergedOptions = JsonSerializer.Deserialize<Dictionary<string, object>>(
            JsonSerializer.Serialize(_options, jsonOptions)) ?? new Dictionary<string, object>();
        
        var optionsJson = JsonSerializer.Serialize(mergedOptions, jsonOptions);

        // Generate event handlers JavaScript
        var eventHandlers = GenerateEventHandlers(_options.Events);
        
        // Generate clustering commands JavaScript
        var clusteringCommands = GenerateClusteringCommands();

        // Process nodes to handle custom shapes
        var processedNodesScript = ProcessCustomShapes(allNodes, _id);
        
        var scriptTag = new HtmlTag("script").Value($@"
            (function() {{
                {processedNodesScript}
                var container = document.getElementById('{_id}');
                var data = {{
                    nodes: nodes,
                    edges: edges
                }};
                var options = {optionsJson};
                var network = loadDiagramWithFonts(container, data, options, '{_id}', {(_enableLoadingBar || EnableLoadingBar).ToString().ToLower()}, true);
                diagramTracker['{_id}'] = network;
                {eventHandlers}
                {clusteringCommands}
                {GenerateMethodCalls()}
            }})();
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