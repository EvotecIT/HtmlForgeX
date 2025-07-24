namespace HtmlForgeX;

public partial class VisNetwork {

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
    /// Adds a <see cref="VisNetworkEdgeOptions"/> to the diagram.
    /// </summary>
    /// <param name="edgeOptions">Edge options to add.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork AddEdge(VisNetworkEdgeOptions edgeOptions) {
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

}