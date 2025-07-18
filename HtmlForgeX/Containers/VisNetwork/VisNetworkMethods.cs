using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Represents a method call to be executed on the VisNetwork instance after initialization.
/// </summary>
public class VisNetworkMethodCall {
    /// <summary>
    /// Gets or sets the method name to call.
    /// </summary>
    public string Method { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the parameters for the method call.
    /// </summary>
    public object[]? Parameters { get; set; }

    /// <summary>
    /// Gets or sets whether this method should be called after a delay.
    /// </summary>
    public int? Delay { get; set; }
}

/// <summary>
/// Options for the fit() method.
/// </summary>
public class VisNetworkFitOptions {
    /// <summary>
    /// Gets or sets the node identifiers to fit. When <see langword="null"/>, all nodes are used.
    /// </summary>
    [JsonPropertyName("nodes")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object[]? Nodes { get; set; }

    /// <summary>
    /// Gets or sets the minimum zoom level.
    /// </summary>
    [JsonPropertyName("minZoomLevel")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MinZoomLevel { get; set; }

    /// <summary>
    /// Gets or sets the maximum zoom level.
    /// </summary>
    [JsonPropertyName("maxZoomLevel")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MaxZoomLevel { get; set; }

    /// <summary>
    /// Gets or sets the animation configuration. Can be a boolean or a complex options object.
    /// </summary>
    [JsonPropertyName("animation")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Animation { get; set; }

    /// <summary>
    /// Sets the nodes to fit. If not specified, fits all nodes.
    /// </summary>
    public VisNetworkFitOptions WithNodes(params object[] nodeIds) {
        Nodes = nodeIds;
        return this;
    }

    /// <summary>
    /// Sets the minimum zoom level.
    /// </summary>
    public VisNetworkFitOptions WithMinZoomLevel(double minZoom) {
        MinZoomLevel = minZoom;
        return this;
    }

    /// <summary>
    /// Sets the maximum zoom level.
    /// </summary>
    public VisNetworkFitOptions WithMaxZoomLevel(double maxZoom) {
        MaxZoomLevel = maxZoom;
        return this;
    }

    /// <summary>
    /// Enables animation with default settings.
    /// </summary>
    public VisNetworkFitOptions WithAnimation(bool enabled = true) {
        Animation = enabled;
        return this;
    }

    /// <summary>
    /// Configures animation options.
    /// </summary>
    public VisNetworkFitOptions WithAnimation(Action<VisNetworkAnimationOptions> configure) {
        var animOptions = new VisNetworkAnimationOptions();
        configure(animOptions);
        Animation = animOptions;
        return this;
    }
}

/// <summary>
/// Options for the focus() method.
/// </summary>
public class VisNetworkFocusOptions {
    /// <summary>
    /// Gets or sets the zoom scale where <c>1.0</c> represents 100&#x25;.
    /// </summary>
    [JsonPropertyName("scale")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Scale { get; set; }

    /// <summary>
    /// Gets or sets the offset from the viewport center.
    /// </summary>
    [JsonPropertyName("offset")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkPosition? Offset { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the view remains locked to the node.
    /// </summary>
    [JsonPropertyName("locked")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Locked { get; set; }

    /// <summary>
    /// Gets or sets the animation configuration. Can be a boolean or a complex options object.
    /// </summary>
    [JsonPropertyName("animation")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Animation { get; set; }

    /// <summary>
    /// Sets the zoom scale (1.0 = 100%).
    /// </summary>
    public VisNetworkFocusOptions WithScale(double scale) {
        Scale = scale;
        return this;
    }

    /// <summary>
    /// Sets the offset from center.
    /// </summary>
    public VisNetworkFocusOptions WithOffset(double x, double y) {
        Offset = new VisNetworkPosition { X = x, Y = y };
        return this;
    }

    /// <summary>
    /// Sets whether the view remains locked to the node.
    /// </summary>
    public VisNetworkFocusOptions WithLocked(bool locked = true) {
        Locked = locked;
        return this;
    }

    /// <summary>
    /// Enables animation with default settings.
    /// </summary>
    public VisNetworkFocusOptions WithAnimation(bool enabled = true) {
        Animation = enabled;
        return this;
    }

    /// <summary>
    /// Configures animation options.
    /// </summary>
    public VisNetworkFocusOptions WithAnimation(Action<VisNetworkAnimationOptions> configure) {
        var animOptions = new VisNetworkAnimationOptions();
        configure(animOptions);
        Animation = animOptions;
        return this;
    }
}

/// <summary>
/// Options for the moveTo() method.
/// </summary>
public class VisNetworkMoveToOptions {
    /// <summary>
    /// Gets or sets the absolute position to move the viewport to.
    /// </summary>
    [JsonPropertyName("position")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkPosition? Position { get; set; }

    /// <summary>
    /// Gets or sets the zoom level after moving.
    /// </summary>
    [JsonPropertyName("scale")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Scale { get; set; }

    /// <summary>
    /// Gets or sets the offset relative to the target position.
    /// </summary>
    [JsonPropertyName("offset")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkPosition? Offset { get; set; }

    /// <summary>
    /// Gets or sets the animation configuration. Can be a boolean or a complex options object.
    /// </summary>
    [JsonPropertyName("animation")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Animation { get; set; }

    /// <summary>
    /// Sets the position to move to.
    /// </summary>
    public VisNetworkMoveToOptions WithPosition(double x, double y) {
        Position = new VisNetworkPosition { X = x, Y = y };
        return this;
    }

    /// <summary>
    /// Sets the zoom scale.
    /// </summary>
    public VisNetworkMoveToOptions WithScale(double scale) {
        Scale = scale;
        return this;
    }

    /// <summary>
    /// Sets the offset.
    /// </summary>
    public VisNetworkMoveToOptions WithOffset(double x, double y) {
        Offset = new VisNetworkPosition { X = x, Y = y };
        return this;
    }

    /// <summary>
    /// Enables animation with default settings.
    /// </summary>
    public VisNetworkMoveToOptions WithAnimation(bool enabled = true) {
        Animation = enabled;
        return this;
    }

    /// <summary>
    /// Configures animation options.
    /// </summary>
    public VisNetworkMoveToOptions WithAnimation(Action<VisNetworkAnimationOptions> configure) {
        var animOptions = new VisNetworkAnimationOptions();
        configure(animOptions);
        Animation = animOptions;
        return this;
    }
}

/// <summary>
/// Animation options for network methods.
/// </summary>
public class VisNetworkAnimationOptions {
    /// <summary>
    /// Gets or sets the animation duration in milliseconds.
    /// </summary>
    [JsonPropertyName("duration")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Duration { get; set; }

    /// <summary>
    /// Gets or sets the name of the easing function to apply.
    /// </summary>
    [JsonPropertyName("easingFunction")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? EasingFunction { get; set; }

    /// <summary>
    /// Sets the animation duration in milliseconds.
    /// </summary>
    public VisNetworkAnimationOptions WithDuration(int milliseconds) {
        Duration = milliseconds;
        return this;
    }

    /// <summary>
    /// Sets the easing function.
    /// </summary>
    public VisNetworkAnimationOptions WithEasingFunction(VisNetworkEasingFunction easing) {
        EasingFunction = easing.ToString();
        return this;
    }
}

/// <summary>
/// Position representation.
/// </summary>
public class VisNetworkPosition {
    /// <summary>
    /// Gets or sets the horizontal coordinate.
    /// </summary>
    [JsonPropertyName("x")]
    public double X { get; set; }

    /// <summary>
    /// Gets or sets the vertical coordinate.
    /// </summary>
    [JsonPropertyName("y")]
    public double Y { get; set; }
}

/// <summary>
/// Easing functions for animations.
/// </summary>
public enum VisNetworkEasingFunction {
    /// <summary>Linear easing.</summary>
    Linear,
    /// <summary>Easing that accelerates from zero velocity.</summary>
    EaseInQuad,
    /// <summary>Easing that decelerates to zero velocity.</summary>
    EaseOutQuad,
    /// <summary>Easing that accelerates then decelerates.</summary>
    EaseInOutQuad,
    /// <summary>Cubic ease-in.</summary>
    EaseInCubic,
    /// <summary>Cubic ease-out.</summary>
    EaseOutCubic,
    /// <summary>Cubic ease-in-out.</summary>
    EaseInOutCubic,
    /// <summary>Quartic ease-in.</summary>
    EaseInQuart,
    /// <summary>Quartic ease-out.</summary>
    EaseOutQuart,
    /// <summary>Quartic ease-in-out.</summary>
    EaseInOutQuart,
    /// <summary>Quintic ease-in.</summary>
    EaseInQuint,
    /// <summary>Quintic ease-out.</summary>
    EaseOutQuint,
    /// <summary>Quintic ease-in-out.</summary>
    EaseInOutQuint
}

/// <summary>
/// Options for stabilization.
/// </summary>
public class VisNetworkStabilizeOptions {
    /// <summary>
    /// Gets or sets the number of iterations used during stabilization.
    /// </summary>
    [JsonPropertyName("iterations")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Iterations { get; set; }

    /// <summary>
    /// Sets the number of iterations to stabilize.
    /// </summary>
    public VisNetworkStabilizeOptions WithIterations(int iterations) {
        Iterations = iterations;
        return this;
    }
}

/// <summary>
/// Provides predefined method templates for common operations.
/// </summary>
public static class VisNetworkMethodTemplates {
    /// <summary>
    /// JavaScript to fit all nodes with animation.
    /// </summary>
    public static string FitAllAnimated => @"
        network.fit({
            animation: {
                duration: 1000,
                easingFunction: 'easeInOutQuad'
            }
        });";

    /// <summary>
    /// JavaScript to center the view on a specific node.
    /// </summary>
    public static string CenterOnNode(object nodeId) => $@"
        network.focus({JsonSerializer.Serialize(nodeId)}, {{
            scale: 1.5,
            animation: {{
                duration: 1000,
                easingFunction: 'easeInOutQuad'
            }}
        }});";

    /// <summary>
    /// JavaScript to select nodes and edges programmatically.
    /// </summary>
    public static string SelectNodesAndEdges(object[] nodeIds, object[] edgeIds) => $@"
        network.selectNodes({JsonSerializer.Serialize(nodeIds)});
        network.selectEdges({JsonSerializer.Serialize(edgeIds)});";

    /// <summary>
    /// JavaScript to get current viewport information.
    /// </summary>
    public static string GetViewportInfo => @"
        var viewPosition = network.getViewPosition();
        var scale = network.getScale();
        console.log('View Position:', viewPosition);
        console.log('Scale:', scale);";

    /// <summary>
    /// JavaScript to export network positions.
    /// </summary>
    public static string ExportPositions => @"
        var positions = network.getPositions();
        console.log('Network Positions:', JSON.stringify(positions, null, 2));
        return positions;";

    /// <summary>
    /// JavaScript to get bounding box of nodes.
    /// </summary>
    public static string GetBoundingBox(params object[] nodeIds) => $@"
        var boundingBox = network.getBoundingBox({JsonSerializer.Serialize(nodeIds)});
        console.log('Bounding Box:', boundingBox);
        return boundingBox;";
}