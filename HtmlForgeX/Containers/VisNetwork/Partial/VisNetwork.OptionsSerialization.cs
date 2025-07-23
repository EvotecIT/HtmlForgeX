using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HtmlForgeX;

public partial class VisNetwork {
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
                
                var shapeKey = nodeOptions.CtxRenderer!.GetHashCode().ToString();
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
                var shapeKey = nodeOptions.CtxRenderer!.GetHashCode().ToString();
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
        
        // Convert HTML nodes to regular nodes and collect HTML content
        var htmlNodeContents = new Dictionary<string, string>();
        foreach (var htmlNode in _htmlNodes) {
            // Create a basic node structure for vis.js
            var nodeOptions = new VisNetworkNodeOptions()
                .WithId(htmlNode.Id)
                .WithShape(VisNetworkNodeShape.Box); // HTML nodes need a shape
            
            // Store the HTML content for later
            htmlNodeContents[htmlNode.Id.ToString()] = htmlNode.GetHtmlContent();
            
            allNodes.Add(nodeOptions);
        }

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
        
        // Generate HTML nodes initialization if needed
        var htmlNodesInit = "";
        if (htmlNodeContents.Count > 0) {
            var htmlNodesJson = JsonSerializer.Serialize(htmlNodeContents, jsonOptions);
            htmlNodesInit = $@"
                // Initialize HTML nodes
                var htmlContents = {htmlNodesJson};
                
                // Apply HTML content after network is created
                setTimeout(function() {{
                    if (typeof VisJsHtmlNodes !== 'undefined') {{
                        network.htmlNodes = new VisJsHtmlNodes(network, {{
                            template: function(nodeData) {{
                                // Return HTML content for HTML nodes, null for regular nodes
                                return htmlContents[nodeData.id] || null;
                            }}
                        }});
                    }} else {{
                        console.error('VisJsHtmlNodes library not loaded.');
                    }}
                }}, 100);";
        }

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
                {htmlNodesInit}
                {eventHandlers}
                {clusteringCommands}
                {GenerateMethodCalls()}
            }})();
        ");

        return divTag + scriptTag.ToString();
    }
}
