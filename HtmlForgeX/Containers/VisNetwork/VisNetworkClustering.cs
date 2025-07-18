using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Represents clustering configuration for VisNetwork.
/// </summary>
public class VisNetworkClusteringOptions {
    /// <summary>
    /// Gets or sets the cluster node properties that will be applied to the created cluster.
    /// </summary>
    [JsonPropertyName("clusterNodeProperties")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkNodeOptions? ClusterNodeProperties { get; set; }

    /// <summary>
    /// Gets or sets the cluster edge properties that will be applied to edges connected to the cluster.
    /// </summary>
    [JsonPropertyName("clusterEdgeProperties")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkEdgeOptions? ClusterEdgeProperties { get; set; }

    /// <summary>
    /// Gets or sets the JavaScript function that determines which nodes to include in the cluster.
    /// The function should return true to include the node.
    /// </summary>
    [JsonIgnore]
    public string? JoinCondition { get; set; }

    /// <summary>
    /// Gets or sets the JavaScript function that processes cluster node properties.
    /// This allows dynamic modification of cluster properties based on contained nodes.
    /// </summary>
    [JsonIgnore]
    public string? ProcessProperties { get; set; }

    // Fluent API Methods

    /// <summary>
    /// Sets the properties for the cluster node.
    /// </summary>
    public VisNetworkClusteringOptions WithClusterNodeProperties(Action<VisNetworkNodeOptions> configure) {
        ClusterNodeProperties ??= new VisNetworkNodeOptions();
        configure(ClusterNodeProperties);
        return this;
    }

    /// <summary>
    /// Sets the properties for edges connected to the cluster.
    /// </summary>
    public VisNetworkClusteringOptions WithClusterEdgeProperties(Action<VisNetworkEdgeOptions> configure) {
        ClusterEdgeProperties ??= new VisNetworkEdgeOptions();
        configure(ClusterEdgeProperties);
        return this;
    }

    /// <summary>
    /// Sets the join condition function that determines which nodes to include in the cluster.
    /// </summary>
    /// <param name="jsFunction">JavaScript function that receives (nodeOptions, childNodeOptions) and returns boolean</param>
    public VisNetworkClusteringOptions WithJoinCondition(string jsFunction) {
        JoinCondition = jsFunction;
        return this;
    }

    /// <summary>
    /// Sets the process properties function that modifies cluster node properties based on contained nodes.
    /// </summary>
    /// <param name="jsFunction">JavaScript function that receives (clusterOptions, childNodesOptions, childEdgesOptions)</param>
    public VisNetworkClusteringOptions WithProcessProperties(string jsFunction) {
        ProcessProperties = jsFunction;
        return this;
    }
}

/// <summary>
/// Provides predefined clustering templates and configurations.
/// </summary>
public static class VisNetworkClusteringTemplates {
    /// <summary>
    /// Join condition that clusters all nodes connected to the specified node.
    /// </summary>
    public static string ClusterConnected => @"
        function(nodeOptions, childNodeOptions) {
            return true; // Include all connected nodes
        }";

    /// <summary>
    /// Join condition that clusters nodes based on a specific property value.
    /// </summary>
    public static string ClusterByProperty(string propertyName, object value) => $@"
        function(nodeOptions, childNodeOptions) {{
            return childNodeOptions.{propertyName} === {System.Text.Json.JsonSerializer.Serialize(value)};
        }}";

    /// <summary>
    /// Process properties function that shows the count of clustered nodes.
    /// </summary>
    public static string ShowNodeCount => @"
        function(clusterOptions, childNodesOptions, childEdgesOptions) {
            var childrenCount = childNodesOptions.length;
            clusterOptions.label = 'Cluster (' + childrenCount + ' nodes)';
            clusterOptions.title = 'Contains ' + childrenCount + ' nodes';
            clusterOptions.value = childrenCount;
        }";

    /// <summary>
    /// Process properties function that uses the first child's label with count.
    /// </summary>
    public static string UseFirstChildLabel => @"
        function(clusterOptions, childNodesOptions, childEdgesOptions) {
            if (childNodesOptions.length > 0) {
                var firstChild = childNodesOptions[0];
                clusterOptions.label = firstChild.label + ' +' + (childNodesOptions.length - 1);
            }
        }";

    /// <summary>
    /// Process properties function that calculates cluster color based on contained nodes.
    /// </summary>
    public static string AverageColor => @"
        function(clusterOptions, childNodesOptions, childEdgesOptions) {
            var colors = childNodesOptions
                .filter(function(node) { return node.color; })
                .map(function(node) { return node.color; });
            
            if (colors.length > 0) {
                // Simple approach: use the most common color
                var colorCounts = {};
                colors.forEach(function(color) {
                    colorCounts[color] = (colorCounts[color] || 0) + 1;
                });
                
                var maxColor = colors[0];
                var maxCount = 0;
                for (var color in colorCounts) {
                    if (colorCounts[color] > maxCount) {
                        maxCount = colorCounts[color];
                        maxColor = color;
                    }
                }
                clusterOptions.color = maxColor;
            }
        }";
}

/// <summary>
/// Clustering method configurations for specific clustering operations.
/// </summary>
public class VisNetworkClusterByConnectionOptions : VisNetworkClusteringOptions {
    /// <summary>
    /// The node ID to cluster with its connections.
    /// </summary>
    [JsonIgnore]
    public object? NodeId { get; set; }

    /// <summary>
    /// Sets the node ID to cluster.
    /// </summary>
    public VisNetworkClusterByConnectionOptions WithNodeId(object nodeId) {
        NodeId = nodeId;
        return this;
    }
}

/// <summary>
/// Options for clustering by hub size.
/// </summary>
public class VisNetworkClusterByHubsizeOptions : VisNetworkClusteringOptions {
    /// <summary>
    /// Minimum number of edges a node must have to be considered a hub.
    /// </summary>
    [JsonIgnore]
    public int? Hubsize { get; set; }

    /// <summary>
    /// Sets the minimum hub size.
    /// </summary>
    public VisNetworkClusterByHubsizeOptions WithHubsize(int hubsize) {
        Hubsize = hubsize;
        return this;
    }
}

/// <summary>
/// Options for opening a cluster.
/// </summary>
public class VisNetworkOpenClusterOptions {
    /// <summary>
    /// JavaScript function to determine how to release nodes from the cluster.
    /// </summary>
    [JsonIgnore]
    public string? ReleaseFunction { get; set; }

    /// <summary>
    /// Sets the release function for opening clusters.
    /// </summary>
    public VisNetworkOpenClusterOptions WithReleaseFunction(string jsFunction) {
        ReleaseFunction = jsFunction;
        return this;
    }
}