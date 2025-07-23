using System.Text;
using System.Text.Json;

namespace HtmlForgeX;

public partial class VisNetwork : Element {
    private readonly List<VisNetworkNodeOptions> _nodes = new();
    private readonly List<VisNetworkEdgeOptions> _edges = new();
    private readonly List<VisNetworkHtmlNode> _htmlNodes = new();
    private VisNetworkOptions _options = new();
    private static readonly Dictionary<string, Action<VisNetworkOptions, object>> _optionSetters =
        new(StringComparer.OrdinalIgnoreCase) {
            ["nodes"] = (opts, val) => opts.Nodes = ConvertValue<VisNetworkNodeGlobalOptions>(val),
            ["edges"] = (opts, val) => opts.Edges = ConvertValue<VisNetworkEdgeGlobalOptions>(val),
            ["physics"] = (opts, val) => opts.Physics = ConvertValue<VisNetworkPhysicsOptions>(val),
            ["layout"] = (opts, val) => opts.Layout = ConvertValue<VisNetworkLayoutOptions>(val),
            ["interaction"] = (opts, val) => opts.Interaction = ConvertValue<VisNetworkInteractionOptions>(val),
            ["manipulation"] = (opts, val) => opts.Manipulation = ConvertValue<VisNetworkManipulationOptions>(val),
            ["groups"] = (opts, val) => opts.Groups = ConvertValue<Dictionary<string, VisNetworkGroupOptions>>(val)
        };
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
        
        // Check if any nodes are HTML nodes
        bool usesHtmlNodes = _htmlNodes.Count > 0;
        if (usesHtmlNodes) {
            // HTML nodes plugin must be loaded after VisNetwork, use a higher weight
            Document?.AddLibrary(Libraries.VisNetworkHtmlNodes, 50);
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
        if (_optionSetters.TryGetValue(key, out var setter)) {
            setter(_options, value);
        }
        return this;
    }

    private static T? ConvertValue<T>(object value) {
        var json = JsonSerializer.Serialize(value);
        return JsonSerializer.Deserialize<T>(json);
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
}
