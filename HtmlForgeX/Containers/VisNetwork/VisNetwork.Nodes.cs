using System.Reflection;
using System.Text.Json;

namespace HtmlForgeX;

public partial class VisNetwork {

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
    /// Adds a <see cref="VisNetworkHtmlNode"/> with full HTML support to the diagram.
    /// This requires the visjs-html-nodes plugin which will be automatically loaded.
    /// </summary>
    /// <param name="node">The HTML node to add.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork AddHtmlNode(VisNetworkHtmlNode node) {
        _htmlNodes.Add(node);
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

}