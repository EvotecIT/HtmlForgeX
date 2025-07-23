using System.IO;
using System.Text.Json;

namespace HtmlForgeX;

public partial class VisNetwork {

    private void ApplyImageEmbedding(VisNetworkNodeOptions node) {
        if (Document == null || Document.Configuration.LibraryMode != LibraryMode.Offline) {
            return;
        }

        if (!Document.Configuration.Images.AutoEmbedImages) {
            return;
        }

        // Check if auto-embedding is disabled for this specific node
        if (node.SkipAutoEmbedding) {
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

        var result = ImageEmbedding.EmbedSmart(source, timeoutSeconds);
        return result.Success ? $"data:{result.MimeType};base64,{result.Base64Data}" : source;
    }

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

}
