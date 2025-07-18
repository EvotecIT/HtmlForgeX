using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Represents comprehensive configuration options for VisNetwork.
/// </summary>
public class VisNetworkOptions {
    [JsonPropertyName("autoResize")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? AutoResize { get; set; }

    [JsonPropertyName("width")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Width { get; set; }

    [JsonPropertyName("height")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Height { get; set; }

    [JsonPropertyName("locale")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkLocale? Locale { get; set; }

    [JsonPropertyName("locales")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Locales { get; set; }

    [JsonPropertyName("clickToUse")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ClickToUse { get; set; }

    [JsonPropertyName("configure")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Configure { get; set; }

    [JsonPropertyName("edges")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkEdgeGlobalOptions? Edges { get; set; }

    [JsonPropertyName("nodes")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkNodeGlobalOptions? Nodes { get; set; }

    [JsonPropertyName("groups")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, VisNetworkGroupOptions>? Groups { get; set; }

    [JsonPropertyName("layout")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkLayoutOptions? Layout { get; set; }

    [JsonPropertyName("interaction")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkInteractionOptions? Interaction { get; set; }

    [JsonPropertyName("manipulation")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkManipulationOptions? Manipulation { get; set; }

    [JsonPropertyName("physics")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkPhysicsOptions? Physics { get; set; }

    // Fluent API Methods

    public VisNetworkOptions WithAutoResize(bool autoResize = true) {
        AutoResize = autoResize;
        return this;
    }

    public VisNetworkOptions WithSize(string width, string height) {
        Width = width;
        Height = height;
        return this;
    }

    public VisNetworkOptions WithLocale(VisNetworkLocale locale) {
        Locale = locale;
        return this;
    }

    public VisNetworkOptions WithClickToUse(bool clickToUse = true) {
        ClickToUse = clickToUse;
        return this;
    }

    public VisNetworkOptions WithConfigure(bool enabled = true) {
        Configure = enabled;
        return this;
    }

    public VisNetworkOptions WithConfigure(VisNetworkConfigureOptions configureOptions) {
        Configure = configureOptions;
        return this;
    }

    public VisNetworkOptions WithEdges(Action<VisNetworkEdgeGlobalOptions> configure) {
        Edges ??= new VisNetworkEdgeGlobalOptions();
        configure(Edges);
        return this;
    }

    public VisNetworkOptions WithNodes(Action<VisNetworkNodeGlobalOptions> configure) {
        Nodes ??= new VisNetworkNodeGlobalOptions();
        configure(Nodes);
        return this;
    }

    public VisNetworkOptions WithGroup(string name, Action<VisNetworkGroupOptions> configure) {
        Groups ??= new Dictionary<string, VisNetworkGroupOptions>();
        var group = new VisNetworkGroupOptions();
        configure(group);
        Groups[name] = group;
        return this;
    }

    public VisNetworkOptions WithLayout(Action<VisNetworkLayoutOptions> configure) {
        Layout ??= new VisNetworkLayoutOptions();
        configure(Layout);
        return this;
    }

    public VisNetworkOptions WithInteraction(Action<VisNetworkInteractionOptions> configure) {
        Interaction ??= new VisNetworkInteractionOptions();
        configure(Interaction);
        return this;
    }

    public VisNetworkOptions WithManipulation(Action<VisNetworkManipulationOptions> configure) {
        Manipulation ??= new VisNetworkManipulationOptions();
        configure(Manipulation);
        return this;
    }

    public VisNetworkOptions WithPhysics(Action<VisNetworkPhysicsOptions> configure) {
        Physics ??= new VisNetworkPhysicsOptions();
        configure(Physics);
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
    [JsonPropertyName("enabled")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Enabled { get; set; }

    [JsonPropertyName("filter")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Filter { get; set; }

    [JsonPropertyName("container")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Container { get; set; }

    [JsonPropertyName("showButton")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ShowButton { get; set; }

    public VisNetworkConfigureOptions WithEnabled(bool enabled = true) {
        Enabled = enabled;
        return this;
    }

    public VisNetworkConfigureOptions WithFilter(string filter) {
        Filter = filter;
        return this;
    }

    public VisNetworkConfigureOptions WithContainer(string containerId) {
        Container = containerId;
        return this;
    }

    public VisNetworkConfigureOptions WithShowButton(bool show = true) {
        ShowButton = show;
        return this;
    }
}

/// <summary>
/// Layout configuration options.
/// </summary>
public class VisNetworkLayoutOptions {
    [JsonPropertyName("randomSeed")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? RandomSeed { get; set; }

    [JsonPropertyName("improvedLayout")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ImprovedLayout { get; set; }

    [JsonPropertyName("clusterThreshold")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? ClusterThreshold { get; set; }

    [JsonPropertyName("hierarchical")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Hierarchical { get; set; }

    public VisNetworkLayoutOptions WithRandomSeed(int seed) {
        RandomSeed = seed;
        return this;
    }

    public VisNetworkLayoutOptions WithImprovedLayout(bool improved = true) {
        ImprovedLayout = improved;
        return this;
    }

    public VisNetworkLayoutOptions WithClusterThreshold(int threshold) {
        ClusterThreshold = threshold;
        return this;
    }

    public VisNetworkLayoutOptions WithHierarchical(bool enabled = true) {
        Hierarchical = enabled;
        return this;
    }

    public VisNetworkLayoutOptions WithHierarchical(VisNetworkHierarchicalOptions hierarchicalOptions) {
        Hierarchical = hierarchicalOptions;
        return this;
    }
}

/// <summary>
/// Hierarchical layout configuration.
/// </summary>
public class VisNetworkHierarchicalOptions {
    [JsonPropertyName("enabled")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Enabled { get; set; }

    [JsonPropertyName("levelSeparation")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? LevelSeparation { get; set; }

    [JsonPropertyName("nodeSpacing")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? NodeSpacing { get; set; }

    [JsonPropertyName("treeSpacing")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? TreeSpacing { get; set; }

    [JsonPropertyName("blockShifting")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? BlockShifting { get; set; }

    [JsonPropertyName("edgeMinimization")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? EdgeMinimization { get; set; }

    [JsonPropertyName("parentCentralization")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ParentCentralization { get; set; }

    [JsonPropertyName("direction")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkLayoutDirection? Direction { get; set; }

    [JsonPropertyName("sortMethod")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkLayoutSort? SortMethod { get; set; }

    [JsonPropertyName("shakeTowards")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ShakeTowards { get; set; }

    public VisNetworkHierarchicalOptions WithEnabled(bool enabled = true) {
        Enabled = enabled;
        return this;
    }

    public VisNetworkHierarchicalOptions WithLevelSeparation(double separation) {
        LevelSeparation = separation;
        return this;
    }

    public VisNetworkHierarchicalOptions WithNodeSpacing(double spacing) {
        NodeSpacing = spacing;
        return this;
    }

    public VisNetworkHierarchicalOptions WithTreeSpacing(double spacing) {
        TreeSpacing = spacing;
        return this;
    }

    public VisNetworkHierarchicalOptions WithBlockShifting(bool enabled = true) {
        BlockShifting = enabled;
        return this;
    }

    public VisNetworkHierarchicalOptions WithEdgeMinimization(bool enabled = true) {
        EdgeMinimization = enabled;
        return this;
    }

    public VisNetworkHierarchicalOptions WithParentCentralization(bool enabled = true) {
        ParentCentralization = enabled;
        return this;
    }

    public VisNetworkHierarchicalOptions WithDirection(VisNetworkLayoutDirection direction) {
        Direction = direction;
        return this;
    }

    public VisNetworkHierarchicalOptions WithSortMethod(VisNetworkLayoutSort sortMethod) {
        SortMethod = sortMethod;
        return this;
    }

    public VisNetworkHierarchicalOptions WithShakeTowards(string direction) {
        ShakeTowards = direction;
        return this;
    }
}

/// <summary>
/// Interaction configuration options.
/// </summary>
public class VisNetworkInteractionOptions {
    [JsonPropertyName("dragNodes")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? DragNodes { get; set; }

    [JsonPropertyName("dragView")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? DragView { get; set; }

    [JsonPropertyName("hideEdgesOnDrag")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? HideEdgesOnDrag { get; set; }

    [JsonPropertyName("hideEdgesOnZoom")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? HideEdgesOnZoom { get; set; }

    [JsonPropertyName("hideNodesOnDrag")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? HideNodesOnDrag { get; set; }

    [JsonPropertyName("hover")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Hover { get; set; }

    [JsonPropertyName("hoverConnectedEdges")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? HoverConnectedEdges { get; set; }

    [JsonPropertyName("keyboard")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Keyboard { get; set; }

    [JsonPropertyName("multiselect")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Multiselect { get; set; }

    [JsonPropertyName("navigationButtons")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? NavigationButtons { get; set; }

    [JsonPropertyName("selectable")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Selectable { get; set; }

    [JsonPropertyName("selectConnectedEdges")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SelectConnectedEdges { get; set; }

    [JsonPropertyName("tooltipDelay")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? TooltipDelay { get; set; }

    [JsonPropertyName("zoomView")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ZoomView { get; set; }

    [JsonPropertyName("zoomSpeed")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? ZoomSpeed { get; set; }

    public VisNetworkInteractionOptions WithDragNodes(bool enabled = true) {
        DragNodes = enabled;
        return this;
    }

    public VisNetworkInteractionOptions WithDragView(bool enabled = true) {
        DragView = enabled;
        return this;
    }

    public VisNetworkInteractionOptions WithHideEdgesOnDrag(bool hide = true) {
        HideEdgesOnDrag = hide;
        return this;
    }

    public VisNetworkInteractionOptions WithHideEdgesOnZoom(bool hide = true) {
        HideEdgesOnZoom = hide;
        return this;
    }

    public VisNetworkInteractionOptions WithHideNodesOnDrag(bool hide = true) {
        HideNodesOnDrag = hide;
        return this;
    }

    public VisNetworkInteractionOptions WithHover(bool enabled = true) {
        Hover = enabled;
        return this;
    }

    public VisNetworkInteractionOptions WithHoverConnectedEdges(bool enabled = true) {
        HoverConnectedEdges = enabled;
        return this;
    }

    public VisNetworkInteractionOptions WithKeyboard(bool enabled = true) {
        Keyboard = enabled;
        return this;
    }

    public VisNetworkInteractionOptions WithKeyboard(VisNetworkKeyboardOptions keyboardOptions) {
        Keyboard = keyboardOptions;
        return this;
    }

    public VisNetworkInteractionOptions WithMultiselect(bool enabled = true) {
        Multiselect = enabled;
        return this;
    }

    public VisNetworkInteractionOptions WithNavigationButtons(bool show = true) {
        NavigationButtons = show;
        return this;
    }

    public VisNetworkInteractionOptions WithSelectable(bool selectable = true) {
        Selectable = selectable;
        return this;
    }

    public VisNetworkInteractionOptions WithSelectConnectedEdges(bool select = true) {
        SelectConnectedEdges = select;
        return this;
    }

    public VisNetworkInteractionOptions WithTooltipDelay(int delay) {
        TooltipDelay = delay;
        return this;
    }

    public VisNetworkInteractionOptions WithZoomView(bool enabled = true) {
        ZoomView = enabled;
        return this;
    }

    public VisNetworkInteractionOptions WithZoomSpeed(double speed) {
        ZoomSpeed = speed;
        return this;
    }
}

/// <summary>
/// Keyboard interaction options.
/// </summary>
public class VisNetworkKeyboardOptions {
    [JsonPropertyName("enabled")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Enabled { get; set; }

    [JsonPropertyName("speed")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Speed { get; set; }

    [JsonPropertyName("bindToWindow")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? BindToWindow { get; set; }

    [JsonPropertyName("autoFocus")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? AutoFocus { get; set; }

    public VisNetworkKeyboardOptions WithEnabled(bool enabled = true) {
        Enabled = enabled;
        return this;
    }

    public VisNetworkKeyboardOptions WithSpeed(double x, double y, double zoom) {
        Speed = new { x, y, zoom };
        return this;
    }

    public VisNetworkKeyboardOptions WithBindToWindow(bool bind = true) {
        BindToWindow = bind;
        return this;
    }

    public VisNetworkKeyboardOptions WithAutoFocus(bool autoFocus = true) {
        AutoFocus = autoFocus;
        return this;
    }
}

/// <summary>
/// Manipulation configuration options.
/// </summary>
public class VisNetworkManipulationOptions {
    [JsonPropertyName("enabled")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Enabled { get; set; }

    [JsonPropertyName("initiallyActive")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? InitiallyActive { get; set; }

    [JsonPropertyName("addNode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? AddNode { get; set; }

    [JsonPropertyName("addEdge")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? AddEdge { get; set; }

    [JsonPropertyName("editNode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? EditNode { get; set; }

    [JsonPropertyName("editEdge")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? EditEdge { get; set; }

    [JsonPropertyName("deleteNode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? DeleteNode { get; set; }

    [JsonPropertyName("deleteEdge")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? DeleteEdge { get; set; }

    [JsonPropertyName("controlNodeStyle")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? ControlNodeStyle { get; set; }

    public VisNetworkManipulationOptions WithEnabled(bool enabled = true) {
        Enabled = enabled;
        return this;
    }

    public VisNetworkManipulationOptions WithInitiallyActive(bool active = true) {
        InitiallyActive = active;
        return this;
    }

    public VisNetworkManipulationOptions WithAddNode(bool enabled = true) {
        AddNode = enabled;
        return this;
    }

    public VisNetworkManipulationOptions WithAddEdge(bool enabled = true) {
        AddEdge = enabled;
        return this;
    }

    public VisNetworkManipulationOptions WithEditNode(bool enabled = true) {
        EditNode = enabled;
        return this;
    }

    public VisNetworkManipulationOptions WithEditEdge(bool enabled = true) {
        EditEdge = enabled;
        return this;
    }

    public VisNetworkManipulationOptions WithDeleteNode(bool enabled = true) {
        DeleteNode = enabled;
        return this;
    }

    public VisNetworkManipulationOptions WithDeleteEdge(bool enabled = true) {
        DeleteEdge = enabled;
        return this;
    }
}