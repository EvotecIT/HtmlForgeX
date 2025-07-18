using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Represents comprehensive configuration options for VisNetwork.
/// </summary>
public class VisNetworkOptions {
    /// <summary>
    /// Gets or sets a value indicating whether the network should automatically resize with its container.
    /// </summary>
    [JsonPropertyName("autoResize")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? AutoResize { get; set; }

    /// <summary>
    /// Gets or sets the width of the network container.
    /// </summary>
    [JsonPropertyName("width")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Width { get; set; }

    /// <summary>
    /// Gets or sets the height of the network container.
    /// </summary>
    [JsonPropertyName("height")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Height { get; set; }

    /// <summary>
    /// Gets or sets the locale to use when rendering the network.
    /// </summary>
    [JsonPropertyName("locale")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkLocale? Locale { get; set; }

    /// <summary>
    /// Gets or sets custom locale definitions.
    /// </summary>
    [JsonPropertyName("locales")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Locales { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the network requires click to activate.
    /// </summary>
    [JsonPropertyName("clickToUse")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ClickToUse { get; set; }

    /// <summary>
    /// Gets or sets the configuration panel options.
    /// </summary>
    [JsonPropertyName("configure")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Configure { get; set; }

    /// <summary>
    /// Gets or sets global edge options applied to all edges.
    /// </summary>
    [JsonPropertyName("edges")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkEdgeGlobalOptions? Edges { get; set; }

    /// <summary>
    /// Gets or sets global node options applied to all nodes.
    /// </summary>
    [JsonPropertyName("nodes")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkNodeGlobalOptions? Nodes { get; set; }

    /// <summary>
    /// Gets or sets per-group visual options.
    /// </summary>
    [JsonPropertyName("groups")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, VisNetworkGroupOptions>? Groups { get; set; }

    /// <summary>
    /// Gets or sets layout options controlling how nodes are positioned.
    /// </summary>
    [JsonPropertyName("layout")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkLayoutOptions? Layout { get; set; }

    /// <summary>
    /// Gets or sets interaction options for user input.
    /// </summary>
    [JsonPropertyName("interaction")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkInteractionOptions? Interaction { get; set; }

    /// <summary>
    /// Gets or sets options that control node and edge manipulation tools.
    /// </summary>
    [JsonPropertyName("manipulation")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkManipulationOptions? Manipulation { get; set; }

    /// <summary>
    /// Gets or sets physics simulation options.
    /// </summary>
    [JsonPropertyName("physics")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkPhysicsOptions? Physics { get; set; }

    /// <summary>
    /// Gets the events configuration. Events are not serialized to JSON and are handled separately.
    /// </summary>
    [JsonIgnore]
    public VisNetworkEvents? Events { get; set; }

    // Fluent API Methods

    /// <summary>
    /// Sets <see cref="AutoResize"/> and returns the current options instance.
    /// </summary>
    /// <param name="autoResize">Whether the network should auto resize.</param>
    /// <returns>The current <see cref="VisNetworkOptions"/> instance.</returns>
    public VisNetworkOptions WithAutoResize(bool autoResize = true) {
        AutoResize = autoResize;
        return this;
    }

    /// <summary>
    /// Sets the <see cref="Width"/> and <see cref="Height"/> of the network container.
    /// </summary>
    /// <param name="width">Width value.</param>
    /// <param name="height">Height value.</param>
    /// <returns>The current <see cref="VisNetworkOptions"/> instance.</returns>
    public VisNetworkOptions WithSize(string width, string height) {
        Width = width;
        Height = height;
        return this;
    }

    /// <summary>
    /// Sets the <see cref="Locale"/> used to render the network.
    /// </summary>
    /// <param name="locale">The locale value.</param>
    /// <returns>The current <see cref="VisNetworkOptions"/> instance.</returns>
    public VisNetworkOptions WithLocale(VisNetworkLocale locale) {
        Locale = locale;
        return this;
    }

    /// <summary>
    /// Sets <see cref="ClickToUse"/> to enable or disable click activation.
    /// </summary>
    /// <param name="clickToUse">Whether click to use is required.</param>
    /// <returns>The current <see cref="VisNetworkOptions"/> instance.</returns>
    public VisNetworkOptions WithClickToUse(bool clickToUse = true) {
        ClickToUse = clickToUse;
        return this;
    }

    /// <summary>
    /// Enables or disables the configuration panel.
    /// </summary>
    /// <param name="enabled">True to enable the panel.</param>
    /// <returns>The current <see cref="VisNetworkOptions"/> instance.</returns>
    public VisNetworkOptions WithConfigure(bool enabled = true) {
        Configure = enabled;
        return this;
    }

    /// <summary>
    /// Sets the configuration panel options.
    /// </summary>
    /// <param name="configureOptions">Options to apply.</param>
    /// <returns>The current <see cref="VisNetworkOptions"/> instance.</returns>
    public VisNetworkOptions WithConfigure(VisNetworkConfigureOptions configureOptions) {
        Configure = configureOptions;
        return this;
    }

    /// <summary>
    /// Configures the panel options via delegate.
    /// </summary>
    /// <param name="configure">Delegate to configure the options.</param>
    /// <returns>The current <see cref="VisNetworkOptions"/> instance.</returns>
    public VisNetworkOptions WithConfigure(Action<VisNetworkConfigureOptions> configure) {
        var configureOptions = Configure as VisNetworkConfigureOptions ?? new VisNetworkConfigureOptions();
        configure(configureOptions);
        Configure = configureOptions;
        return this;
    }

    /// <summary>
    /// Configures global edge options.
    /// </summary>
    /// <param name="configure">Delegate to configure edges.</param>
    /// <returns>The current <see cref="VisNetworkOptions"/> instance.</returns>
    public VisNetworkOptions WithEdges(Action<VisNetworkEdgeGlobalOptions> configure) {
        Edges ??= new VisNetworkEdgeGlobalOptions();
        configure(Edges);
        return this;
    }

    /// <summary>
    /// Configures global node options.
    /// </summary>
    /// <param name="configure">Delegate to configure nodes.</param>
    /// <returns>The current <see cref="VisNetworkOptions"/> instance.</returns>
    public VisNetworkOptions WithNodes(Action<VisNetworkNodeGlobalOptions> configure) {
        Nodes ??= new VisNetworkNodeGlobalOptions();
        configure(Nodes);
        return this;
    }

    /// <summary>
    /// Adds or updates a group configuration by name.
    /// </summary>
    /// <param name="name">Group name.</param>
    /// <param name="configure">Delegate to configure the group.</param>
    /// <returns>The current <see cref="VisNetworkOptions"/> instance.</returns>
    public VisNetworkOptions WithGroup(string name, Action<VisNetworkGroupOptions> configure) {
        Groups ??= new Dictionary<string, VisNetworkGroupOptions>();
        var group = new VisNetworkGroupOptions();
        configure(group);
        Groups[name] = group;
        return this;
    }

    /// <summary>
    /// Configures layout options.
    /// </summary>
    /// <param name="configure">Delegate to configure layout.</param>
    /// <returns>The current <see cref="VisNetworkOptions"/> instance.</returns>
    public VisNetworkOptions WithLayout(Action<VisNetworkLayoutOptions> configure) {
        Layout ??= new VisNetworkLayoutOptions();
        configure(Layout);
        return this;
    }

    /// <summary>
    /// Configures interaction options.
    /// </summary>
    /// <param name="configure">Delegate to configure interactions.</param>
    /// <returns>The current <see cref="VisNetworkOptions"/> instance.</returns>
    public VisNetworkOptions WithInteraction(Action<VisNetworkInteractionOptions> configure) {
        Interaction ??= new VisNetworkInteractionOptions();
        configure(Interaction);
        return this;
    }

    /// <summary>
    /// Configures manipulation options.
    /// </summary>
    /// <param name="configure">Delegate to configure manipulation.</param>
    /// <returns>The current <see cref="VisNetworkOptions"/> instance.</returns>
    public VisNetworkOptions WithManipulation(Action<VisNetworkManipulationOptions> configure) {
        Manipulation ??= new VisNetworkManipulationOptions();
        configure(Manipulation);
        return this;
    }

    /// <summary>
    /// Configures physics options.
    /// </summary>
    /// <param name="configure">Delegate to configure physics.</param>
    /// <returns>The current <see cref="VisNetworkOptions"/> instance.</returns>
    public VisNetworkOptions WithPhysics(Action<VisNetworkPhysicsOptions> configure) {
        Physics ??= new VisNetworkPhysicsOptions();
        configure(Physics);
        return this;
    }

    /// <summary>
    /// Configures network events.
    /// </summary>
    /// <param name="configure">Delegate to configure events.</param>
    /// <returns>The current <see cref="VisNetworkOptions"/> instance.</returns>
    public VisNetworkOptions WithEvents(Action<VisNetworkEvents> configure) {
        Events ??= new VisNetworkEvents();
        configure(Events);
        return this;
    }
}

/// <summary>
/// Global edge configuration options.
/// </summary>
public class VisNetworkEdgeGlobalOptions : VisNetworkEdgeOptions {
    // Inherits all properties from VisNetworkEdgeOptions
    // This represents default options for all edges
}

/// <summary>
/// Global node configuration options.
/// </summary>
public class VisNetworkNodeGlobalOptions : VisNetworkNodeOptions {
    // Inherits all properties from VisNetworkNodeOptions
    // This represents default options for all nodes
}

/// <summary>
/// Group configuration options.
/// </summary>
public class VisNetworkGroupOptions : VisNetworkNodeOptions {
    // Inherits all properties from VisNetworkNodeOptions
    // Groups define visual styles for nodes assigned to a group
}

/// <summary>
/// Configure panel options.
/// </summary>
public class VisNetworkConfigureOptions {
    /// <summary>
    /// Gets or sets a value indicating whether the configure panel is enabled.
    /// </summary>
    [JsonPropertyName("enabled")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Enabled { get; set; }

    /// <summary>
    /// Gets or sets the filter determining which options are shown.
    /// </summary>
    [JsonPropertyName("filter")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Filter { get; set; }

    /// <summary>
    /// Gets or sets the DOM element or selector for the configure container.
    /// </summary>
    [JsonPropertyName("container")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Container { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the configuration button should be shown.
    /// </summary>
    [JsonPropertyName("showButton")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ShowButton { get; set; }

    /// <summary>
    /// Sets <see cref="Enabled"/>.
    /// </summary>
    /// <param name="enabled">Whether the panel is enabled.</param>
    /// <returns>The current <see cref="VisNetworkConfigureOptions"/> instance.</returns>
    public VisNetworkConfigureOptions WithEnabled(bool enabled = true) {
        Enabled = enabled;
        return this;
    }

    /// <summary>
    /// Sets the <see cref="Filter"/> property.
    /// </summary>
    /// <param name="filter">Filter string.</param>
    /// <returns>The current <see cref="VisNetworkConfigureOptions"/> instance.</returns>
    public VisNetworkConfigureOptions WithFilter(string filter) {
        Filter = filter;
        return this;
    }

    /// <summary>
    /// Sets the <see cref="Container"/> property.
    /// </summary>
    /// <param name="containerId">Container identifier.</param>
    /// <returns>The current <see cref="VisNetworkConfigureOptions"/> instance.</returns>
    public VisNetworkConfigureOptions WithContainer(string containerId) {
        Container = containerId;
        return this;
    }

    /// <summary>
    /// Sets whether the configure button is shown.
    /// </summary>
    /// <param name="show">True to show the button.</param>
    /// <returns>The current <see cref="VisNetworkConfigureOptions"/> instance.</returns>
    public VisNetworkConfigureOptions WithShowButton(bool show = true) {
        ShowButton = show;
        return this;
    }
}

/// <summary>
/// Layout configuration options.
/// </summary>
public class VisNetworkLayoutOptions {
    /// <summary>
    /// Gets or sets the seed used for initial random positioning.
    /// </summary>
    [JsonPropertyName("randomSeed")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? RandomSeed { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether improved layout heuristics are enabled.
    /// </summary>
    [JsonPropertyName("improvedLayout")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ImprovedLayout { get; set; }

    /// <summary>
    /// Gets or sets the cluster threshold used for performance tuning.
    /// </summary>
    [JsonPropertyName("clusterThreshold")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? ClusterThreshold { get; set; }

    /// <summary>
    /// Gets or sets hierarchical layout options or a boolean to enable them.
    /// </summary>
    [JsonPropertyName("hierarchical")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Hierarchical { get; set; }

    /// <summary>
    /// Sets the <see cref="RandomSeed"/> property.
    /// </summary>
    /// <param name="seed">Random seed value.</param>
    /// <returns>The current <see cref="VisNetworkLayoutOptions"/> instance.</returns>
    public VisNetworkLayoutOptions WithRandomSeed(int seed) {
        RandomSeed = seed;
        return this;
    }

    /// <summary>
    /// Enables or disables improved layout heuristics.
    /// </summary>
    /// <param name="improved">True to enable improved layout.</param>
    /// <returns>The current <see cref="VisNetworkLayoutOptions"/> instance.</returns>
    public VisNetworkLayoutOptions WithImprovedLayout(bool improved = true) {
        ImprovedLayout = improved;
        return this;
    }

    /// <summary>
    /// Sets the <see cref="ClusterThreshold"/> property.
    /// </summary>
    /// <param name="threshold">Cluster threshold value.</param>
    /// <returns>The current <see cref="VisNetworkLayoutOptions"/> instance.</returns>
    public VisNetworkLayoutOptions WithClusterThreshold(int threshold) {
        ClusterThreshold = threshold;
        return this;
    }

    /// <summary>
    /// Enables or disables hierarchical layout.
    /// </summary>
    /// <param name="enabled">True to enable hierarchical layout.</param>
    /// <returns>The current <see cref="VisNetworkLayoutOptions"/> instance.</returns>
    public VisNetworkLayoutOptions WithHierarchical(bool enabled = true) {
        Hierarchical = enabled;
        return this;
    }

    /// <summary>
    /// Sets the hierarchical layout options.
    /// </summary>
    /// <param name="hierarchicalOptions">Options to apply.</param>
    /// <returns>The current <see cref="VisNetworkLayoutOptions"/> instance.</returns>
    public VisNetworkLayoutOptions WithHierarchical(VisNetworkHierarchicalOptions hierarchicalOptions) {
        Hierarchical = hierarchicalOptions;
        return this;
    }

    /// <summary>
    /// Configures hierarchical layout options via delegate.
    /// </summary>
    /// <param name="configure">Delegate to configure hierarchical options.</param>
    /// <returns>The current <see cref="VisNetworkLayoutOptions"/> instance.</returns>
    public VisNetworkLayoutOptions WithHierarchical(Action<VisNetworkHierarchicalOptions> configure) {
        var hierarchicalOptions = Hierarchical as VisNetworkHierarchicalOptions ?? new VisNetworkHierarchicalOptions();
        configure(hierarchicalOptions);
        Hierarchical = hierarchicalOptions;
        return this;
    }
}

/// <summary>
/// Hierarchical layout configuration.
/// </summary>
public class VisNetworkHierarchicalOptions {
    /// <summary>
    /// Gets or sets a value indicating whether hierarchical layout is enabled.
    /// </summary>
    [JsonPropertyName("enabled")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Enabled { get; set; }

    /// <summary>
    /// Gets or sets the separation distance between levels.
    /// </summary>
    [JsonPropertyName("levelSeparation")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? LevelSeparation { get; set; }

    /// <summary>
    /// Gets or sets the spacing between nodes on the same level.
    /// </summary>
    [JsonPropertyName("nodeSpacing")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? NodeSpacing { get; set; }

    /// <summary>
    /// Gets or sets the spacing between different branches.
    /// </summary>
    [JsonPropertyName("treeSpacing")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? TreeSpacing { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether blocks may shift to reduce edge crossings.
    /// </summary>
    [JsonPropertyName("blockShifting")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? BlockShifting { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether edge crossings should be minimized.
    /// </summary>
    [JsonPropertyName("edgeMinimization")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? EdgeMinimization { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether parents are centered above their children.
    /// </summary>
    [JsonPropertyName("parentCentralization")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ParentCentralization { get; set; }

    /// <summary>
    /// Gets or sets the layout direction.
    /// </summary>
    [JsonPropertyName("direction")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkLayoutDirection? Direction { get; set; }

    /// <summary>
    /// Gets or sets the sorting method for nodes on the same level.
    /// </summary>
    [JsonPropertyName("sortMethod")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkLayoutSort? SortMethod { get; set; }

    /// <summary>
    /// Gets or sets the direction in which nodes are shaken when stabilizing.
    /// </summary>
    [JsonPropertyName("shakeTowards")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? ShakeTowards { get; set; }

    /// <summary>
    /// Sets <see cref="Enabled"/>.
    /// </summary>
    /// <param name="enabled">Whether hierarchical layout is enabled.</param>
    /// <returns>The current <see cref="VisNetworkHierarchicalOptions"/> instance.</returns>
    public VisNetworkHierarchicalOptions WithEnabled(bool enabled = true) {
        Enabled = enabled;
        return this;
    }

    /// <summary>
    /// Sets the <see cref="LevelSeparation"/> value.
    /// </summary>
    /// <param name="separation">Distance between levels.</param>
    /// <returns>The current <see cref="VisNetworkHierarchicalOptions"/> instance.</returns>
    public VisNetworkHierarchicalOptions WithLevelSeparation(double separation) {
        LevelSeparation = separation;
        return this;
    }

    /// <summary>
    /// Sets the <see cref="NodeSpacing"/> value.
    /// </summary>
    /// <param name="spacing">Spacing between nodes.</param>
    /// <returns>The current <see cref="VisNetworkHierarchicalOptions"/> instance.</returns>
    public VisNetworkHierarchicalOptions WithNodeSpacing(double spacing) {
        NodeSpacing = spacing;
        return this;
    }

    /// <summary>
    /// Sets the <see cref="TreeSpacing"/> value.
    /// </summary>
    /// <param name="spacing">Spacing between branches.</param>
    /// <returns>The current <see cref="VisNetworkHierarchicalOptions"/> instance.</returns>
    public VisNetworkHierarchicalOptions WithTreeSpacing(double spacing) {
        TreeSpacing = spacing;
        return this;
    }

    /// <summary>
    /// Sets the <see cref="BlockShifting"/> value.
    /// </summary>
    /// <param name="enabled">Whether block shifting is enabled.</param>
    /// <returns>The current <see cref="VisNetworkHierarchicalOptions"/> instance.</returns>
    public VisNetworkHierarchicalOptions WithBlockShifting(bool enabled = true) {
        BlockShifting = enabled;
        return this;
    }

    /// <summary>
    /// Sets the <see cref="EdgeMinimization"/> value.
    /// </summary>
    /// <param name="enabled">Whether edge minimization is enabled.</param>
    /// <returns>The current <see cref="VisNetworkHierarchicalOptions"/> instance.</returns>
    public VisNetworkHierarchicalOptions WithEdgeMinimization(bool enabled = true) {
        EdgeMinimization = enabled;
        return this;
    }

    /// <summary>
    /// Sets the <see cref="ParentCentralization"/> value.
    /// </summary>
    /// <param name="enabled">Whether parents should be centered.</param>
    /// <returns>The current <see cref="VisNetworkHierarchicalOptions"/> instance.</returns>
    public VisNetworkHierarchicalOptions WithParentCentralization(bool enabled = true) {
        ParentCentralization = enabled;
        return this;
    }

    /// <summary>
    /// Sets the <see cref="Direction"/> property.
    /// </summary>
    /// <param name="direction">Layout direction.</param>
    /// <returns>The current <see cref="VisNetworkHierarchicalOptions"/> instance.</returns>
    public VisNetworkHierarchicalOptions WithDirection(VisNetworkLayoutDirection direction) {
        Direction = direction;
        return this;
    }

    /// <summary>
    /// Sets the <see cref="SortMethod"/> property.
    /// </summary>
    /// <param name="sortMethod">The sort method to use.</param>
    /// <returns>The current <see cref="VisNetworkHierarchicalOptions"/> instance.</returns>
    public VisNetworkHierarchicalOptions WithSortMethod(VisNetworkLayoutSort sortMethod) {
        SortMethod = sortMethod;
        return this;
    }

    /// <summary>
    /// Sets the <see cref="ShakeTowards"/> property using an enum value.
    /// </summary>
    /// <param name="direction">Direction to shake towards.</param>
    /// <returns>The current <see cref="VisNetworkHierarchicalOptions"/> instance.</returns>
    public VisNetworkHierarchicalOptions WithShakeTowards(VisNetworkShakeTowards direction) {
        ShakeTowards = direction;
        return this;
    }
    
    /// <summary>
    /// Sets the <see cref="ShakeTowards"/> property using a string value.
    /// </summary>
    /// <param name="direction">String representation of the direction.</param>
    /// <returns>The current <see cref="VisNetworkHierarchicalOptions"/> instance.</returns>
    public VisNetworkHierarchicalOptions WithShakeTowards(string direction) {
        // For backward compatibility
        ShakeTowards = direction;
        return this;
    }
}

/// <summary>
/// Interaction configuration options.
/// </summary>
public class VisNetworkInteractionOptions {
    /// <summary>
    /// Gets or sets a value indicating whether nodes can be dragged.
    /// </summary>
    [JsonPropertyName("dragNodes")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? DragNodes { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the view can be panned by dragging.
    /// </summary>
    [JsonPropertyName("dragView")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? DragView { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether edges are hidden during dragging.
    /// </summary>
    [JsonPropertyName("hideEdgesOnDrag")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? HideEdgesOnDrag { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether edges are hidden while zooming.
    /// </summary>
    [JsonPropertyName("hideEdgesOnZoom")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? HideEdgesOnZoom { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether nodes are hidden while dragging.
    /// </summary>
    [JsonPropertyName("hideNodesOnDrag")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? HideNodesOnDrag { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether hover interactions are enabled.
    /// </summary>
    [JsonPropertyName("hover")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Hover { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether edges connected to a hovered node are highlighted.
    /// </summary>
    [JsonPropertyName("hoverConnectedEdges")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? HoverConnectedEdges { get; set; }

    /// <summary>
    /// Gets or sets keyboard interaction options or a boolean value.
    /// </summary>
    [JsonPropertyName("keyboard")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Keyboard { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether multiple nodes can be selected.
    /// </summary>
    [JsonPropertyName("multiselect")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Multiselect { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether navigation buttons are displayed.
    /// </summary>
    [JsonPropertyName("navigationButtons")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? NavigationButtons { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether nodes are selectable.
    /// </summary>
    [JsonPropertyName("selectable")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Selectable { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether selecting a node also selects connected edges.
    /// </summary>
    [JsonPropertyName("selectConnectedEdges")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SelectConnectedEdges { get; set; }

    /// <summary>
    /// Gets or sets the delay before tooltips appear in milliseconds.
    /// </summary>
    [JsonPropertyName("tooltipDelay")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? TooltipDelay { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether zooming is allowed.
    /// </summary>
    [JsonPropertyName("zoomView")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ZoomView { get; set; }

    /// <summary>
    /// Gets or sets the zoom speed factor.
    /// </summary>
    [JsonPropertyName("zoomSpeed")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? ZoomSpeed { get; set; }

    /// <summary>
    /// Enables or disables node dragging.
    /// </summary>
    /// <param name="enabled">True to allow dragging nodes.</param>
    /// <returns>The current <see cref="VisNetworkInteractionOptions"/> instance.</returns>
    public VisNetworkInteractionOptions WithDragNodes(bool enabled = true) {
        DragNodes = enabled;
        return this;
    }

    /// <summary>
    /// Enables or disables view dragging.
    /// </summary>
    /// <param name="enabled">True to allow dragging the view.</param>
    /// <returns>The current <see cref="VisNetworkInteractionOptions"/> instance.</returns>
    public VisNetworkInteractionOptions WithDragView(bool enabled = true) {
        DragView = enabled;
        return this;
    }

    /// <summary>
    /// Sets <see cref="HideEdgesOnDrag"/>.
    /// </summary>
    /// <param name="hide">Whether to hide edges while dragging.</param>
    /// <returns>The current <see cref="VisNetworkInteractionOptions"/> instance.</returns>
    public VisNetworkInteractionOptions WithHideEdgesOnDrag(bool hide = true) {
        HideEdgesOnDrag = hide;
        return this;
    }

    /// <summary>
    /// Sets <see cref="HideEdgesOnZoom"/>.
    /// </summary>
    /// <param name="hide">Whether to hide edges when zooming.</param>
    /// <returns>The current <see cref="VisNetworkInteractionOptions"/> instance.</returns>
    public VisNetworkInteractionOptions WithHideEdgesOnZoom(bool hide = true) {
        HideEdgesOnZoom = hide;
        return this;
    }

    /// <summary>
    /// Sets <see cref="HideNodesOnDrag"/>.
    /// </summary>
    /// <param name="hide">Whether to hide nodes when dragging.</param>
    /// <returns>The current <see cref="VisNetworkInteractionOptions"/> instance.</returns>
    public VisNetworkInteractionOptions WithHideNodesOnDrag(bool hide = true) {
        HideNodesOnDrag = hide;
        return this;
    }

    /// <summary>
    /// Enables or disables hover events.
    /// </summary>
    /// <param name="enabled">True to enable hover events.</param>
    /// <returns>The current <see cref="VisNetworkInteractionOptions"/> instance.</returns>
    public VisNetworkInteractionOptions WithHover(bool enabled = true) {
        Hover = enabled;
        return this;
    }

    /// <summary>
    /// Enables or disables highlighting of edges connected to a hovered node.
    /// </summary>
    /// <param name="enabled">True to highlight connected edges.</param>
    /// <returns>The current <see cref="VisNetworkInteractionOptions"/> instance.</returns>
    public VisNetworkInteractionOptions WithHoverConnectedEdges(bool enabled = true) {
        HoverConnectedEdges = enabled;
        return this;
    }

    /// <summary>
    /// Enables or disables basic keyboard navigation.
    /// </summary>
    /// <param name="enabled">True to enable keyboard navigation.</param>
    /// <returns>The current <see cref="VisNetworkInteractionOptions"/> instance.</returns>
    public VisNetworkInteractionOptions WithKeyboard(bool enabled = true) {
        Keyboard = enabled;
        return this;
    }

    /// <summary>
    /// Sets keyboard options.
    /// </summary>
    /// <param name="keyboardOptions">Options to apply.</param>
    /// <returns>The current <see cref="VisNetworkInteractionOptions"/> instance.</returns>
    public VisNetworkInteractionOptions WithKeyboard(VisNetworkKeyboardOptions keyboardOptions) {
        Keyboard = keyboardOptions;
        return this;
    }

    /// <summary>
    /// Configures keyboard options via delegate.
    /// </summary>
    /// <param name="configure">Delegate to configure keyboard options.</param>
    /// <returns>The current <see cref="VisNetworkInteractionOptions"/> instance.</returns>
    public VisNetworkInteractionOptions WithKeyboard(Action<VisNetworkKeyboardOptions> configure) {
        var keyboard = Keyboard as VisNetworkKeyboardOptions ?? new VisNetworkKeyboardOptions();
        configure(keyboard);
        Keyboard = keyboard;
        return this;
    }

    /// <summary>
    /// Enables or disables multiple selection of nodes.
    /// </summary>
    /// <param name="enabled">True to allow multiple selection.</param>
    /// <returns>The current <see cref="VisNetworkInteractionOptions"/> instance.</returns>
    public VisNetworkInteractionOptions WithMultiselect(bool enabled = true) {
        Multiselect = enabled;
        return this;
    }

    /// <summary>
    /// Shows or hides navigation buttons.
    /// </summary>
    /// <param name="show">True to show navigation buttons.</param>
    /// <returns>The current <see cref="VisNetworkInteractionOptions"/> instance.</returns>
    public VisNetworkInteractionOptions WithNavigationButtons(bool show = true) {
        NavigationButtons = show;
        return this;
    }

    /// <summary>
    /// Sets whether nodes can be selected.
    /// </summary>
    /// <param name="selectable">True to allow selection.</param>
    /// <returns>The current <see cref="VisNetworkInteractionOptions"/> instance.</returns>
    public VisNetworkInteractionOptions WithSelectable(bool selectable = true) {
        Selectable = selectable;
        return this;
    }

    /// <summary>
    /// Sets whether selecting a node also selects connected edges.
    /// </summary>
    /// <param name="select">True to select connected edges.</param>
    /// <returns>The current <see cref="VisNetworkInteractionOptions"/> instance.</returns>
    public VisNetworkInteractionOptions WithSelectConnectedEdges(bool select = true) {
        SelectConnectedEdges = select;
        return this;
    }

    /// <summary>
    /// Sets the tooltip delay.
    /// </summary>
    /// <param name="delay">Delay in milliseconds.</param>
    /// <returns>The current <see cref="VisNetworkInteractionOptions"/> instance.</returns>
    public VisNetworkInteractionOptions WithTooltipDelay(int delay) {
        TooltipDelay = delay;
        return this;
    }

    /// <summary>
    /// Enables or disables zooming of the view.
    /// </summary>
    /// <param name="enabled">True to enable zooming.</param>
    /// <returns>The current <see cref="VisNetworkInteractionOptions"/> instance.</returns>
    public VisNetworkInteractionOptions WithZoomView(bool enabled = true) {
        ZoomView = enabled;
        return this;
    }

    /// <summary>
    /// Sets the <see cref="ZoomSpeed"/> value.
    /// </summary>
    /// <param name="speed">Zoom speed factor.</param>
    /// <returns>The current <see cref="VisNetworkInteractionOptions"/> instance.</returns>
    public VisNetworkInteractionOptions WithZoomSpeed(double speed) {
        ZoomSpeed = speed;
        return this;
    }
}

/// <summary>
/// Keyboard interaction options.
/// </summary>
public class VisNetworkKeyboardOptions {
    /// <summary>
    /// Gets or sets a value indicating whether keyboard navigation is enabled.
    /// </summary>
    [JsonPropertyName("enabled")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Enabled { get; set; }

    /// <summary>
    /// Gets or sets the keyboard movement speed.
    /// </summary>
    [JsonPropertyName("speed")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Speed { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether keyboard events are bound to the window.
    /// </summary>
    [JsonPropertyName("bindToWindow")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? BindToWindow { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the network should autofocus when initialized.
    /// </summary>
    [JsonPropertyName("autoFocus")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? AutoFocus { get; set; }

    /// <summary>
    /// Sets <see cref="Enabled"/>.
    /// </summary>
    /// <param name="enabled">Whether keyboard navigation is enabled.</param>
    /// <returns>The current <see cref="VisNetworkKeyboardOptions"/> instance.</returns>
    public VisNetworkKeyboardOptions WithEnabled(bool enabled = true) {
        Enabled = enabled;
        return this;
    }

    /// <summary>
    /// Sets the <see cref="Speed"/> property.
    /// </summary>
    /// <param name="x">Horizontal speed.</param>
    /// <param name="y">Vertical speed.</param>
    /// <param name="zoom">Zoom speed.</param>
    /// <returns>The current <see cref="VisNetworkKeyboardOptions"/> instance.</returns>
    public VisNetworkKeyboardOptions WithSpeed(double x, double y, double zoom) {
        Speed = new { x, y, zoom };
        return this;
    }

    /// <summary>
    /// Sets the <see cref="BindToWindow"/> property.
    /// </summary>
    /// <param name="bind">Whether to bind keyboard events to the window.</param>
    /// <returns>The current <see cref="VisNetworkKeyboardOptions"/> instance.</returns>
    public VisNetworkKeyboardOptions WithBindToWindow(bool bind = true) {
        BindToWindow = bind;
        return this;
    }

    /// <summary>
    /// Sets the <see cref="AutoFocus"/> property.
    /// </summary>
    /// <param name="autoFocus">Whether autofocus is enabled.</param>
    /// <returns>The current <see cref="VisNetworkKeyboardOptions"/> instance.</returns>
    public VisNetworkKeyboardOptions WithAutoFocus(bool autoFocus = true) {
        AutoFocus = autoFocus;
        return this;
    }
}

/// <summary>
/// Manipulation configuration options.
/// </summary>
public class VisNetworkManipulationOptions {
    /// <summary>
    /// Gets or sets a value indicating whether manipulation is enabled.
    /// </summary>
    [JsonPropertyName("enabled")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Enabled { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the manipulation toolbar is active initially.
    /// </summary>
    [JsonPropertyName("initiallyActive")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? InitiallyActive { get; set; }

    /// <summary>
    /// Gets or sets options or a boolean value controlling adding nodes.
    /// </summary>
    [JsonPropertyName("addNode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? AddNode { get; set; }

    /// <summary>
    /// Gets or sets options or a boolean value controlling adding edges.
    /// </summary>
    [JsonPropertyName("addEdge")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? AddEdge { get; set; }

    /// <summary>
    /// Gets or sets options or a boolean value controlling node editing.
    /// </summary>
    [JsonPropertyName("editNode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? EditNode { get; set; }

    /// <summary>
    /// Gets or sets options or a boolean value controlling edge editing.
    /// </summary>
    [JsonPropertyName("editEdge")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? EditEdge { get; set; }

    /// <summary>
    /// Gets or sets options or a boolean value controlling node deletion.
    /// </summary>
    [JsonPropertyName("deleteNode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? DeleteNode { get; set; }

    /// <summary>
    /// Gets or sets options or a boolean value controlling edge deletion.
    /// </summary>
    [JsonPropertyName("deleteEdge")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? DeleteEdge { get; set; }

    /// <summary>
    /// Gets or sets the style used for control nodes during manipulation.
    /// </summary>
    [JsonPropertyName("controlNodeStyle")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? ControlNodeStyle { get; set; }

    /// <summary>
    /// Sets <see cref="Enabled"/>.
    /// </summary>
    /// <param name="enabled">Whether manipulation is enabled.</param>
    /// <returns>The current <see cref="VisNetworkManipulationOptions"/> instance.</returns>
    public VisNetworkManipulationOptions WithEnabled(bool enabled = true) {
        Enabled = enabled;
        return this;
    }

    /// <summary>
    /// Sets <see cref="InitiallyActive"/>.
    /// </summary>
    /// <param name="active">True to start with the toolbar active.</param>
    /// <returns>The current <see cref="VisNetworkManipulationOptions"/> instance.</returns>
    public VisNetworkManipulationOptions WithInitiallyActive(bool active = true) {
        InitiallyActive = active;
        return this;
    }

    /// <summary>
    /// Enables or disables the ability to add nodes.
    /// </summary>
    /// <param name="enabled">True to enable adding nodes.</param>
    /// <returns>The current <see cref="VisNetworkManipulationOptions"/> instance.</returns>
    public VisNetworkManipulationOptions WithAddNode(bool enabled = true) {
        // When true, we don't set the property to let VisNetwork use default handlers
        // When false, we explicitly disable it
        AddNode = enabled ? null : false;
        return this;
    }

    /// <summary>
    /// Enables or disables the ability to add edges.
    /// </summary>
    /// <param name="enabled">True to enable adding edges.</param>
    /// <returns>The current <see cref="VisNetworkManipulationOptions"/> instance.</returns>
    public VisNetworkManipulationOptions WithAddEdge(bool enabled = true) {
        // When true, we don't set the property to let VisNetwork use default handlers
        // When false, we explicitly disable it
        AddEdge = enabled ? null : false;
        return this;
    }

    /// <summary>
    /// Enables or disables node editing.
    /// </summary>
    /// <param name="enabled">True to enable node editing.</param>
    /// <returns>The current <see cref="VisNetworkManipulationOptions"/> instance.</returns>
    public VisNetworkManipulationOptions WithEditNode(bool enabled = true) {
        // When true, we don't set the property to let VisNetwork use default handlers
        // When false, we explicitly disable it
        EditNode = enabled ? null : false;
        return this;
    }

    /// <summary>
    /// Enables or disables edge editing.
    /// </summary>
    /// <param name="enabled">True to enable edge editing.</param>
    /// <returns>The current <see cref="VisNetworkManipulationOptions"/> instance.</returns>
    public VisNetworkManipulationOptions WithEditEdge(bool enabled = true) {
        // When true, we don't set the property to let VisNetwork use default handlers
        // When false, we explicitly disable it
        EditEdge = enabled ? null : false;
        return this;
    }

    /// <summary>
    /// Enables or disables node deletion.
    /// </summary>
    /// <param name="enabled">True to enable node deletion.</param>
    /// <returns>The current <see cref="VisNetworkManipulationOptions"/> instance.</returns>
    public VisNetworkManipulationOptions WithDeleteNode(bool enabled = true) {
        // When true, we don't set the property to let VisNetwork use default handlers
        // When false, we explicitly disable it
        DeleteNode = enabled ? null : false;
        return this;
    }

    /// <summary>
    /// Enables or disables edge deletion.
    /// </summary>
    /// <param name="enabled">True to enable edge deletion.</param>
    /// <returns>The current <see cref="VisNetworkManipulationOptions"/> instance.</returns>
    public VisNetworkManipulationOptions WithDeleteEdge(bool enabled = true) {
        // When true, we don't set the property to let VisNetwork use default handlers
        // When false, we explicitly disable it
        DeleteEdge = enabled ? null : false;
        return this;
    }
}
