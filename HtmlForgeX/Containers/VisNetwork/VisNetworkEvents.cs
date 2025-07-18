namespace HtmlForgeX;

/// <summary>
/// Represents the event configuration for VisNetwork interactions
/// </summary>
public class VisNetworkEvents {
    /// <summary>
    /// JavaScript code to execute on node click event
    /// </summary>
    public string? OnClick { get; set; }
    
    /// <summary>
    /// JavaScript code to execute on node double click event
    /// </summary>
    public string? OnDoubleClick { get; set; }
    
    /// <summary>
    /// JavaScript code to execute on node right click (context menu) event
    /// </summary>
    public string? OnContext { get; set; }
    
    /// <summary>
    /// JavaScript code to execute on node hold event
    /// </summary>
    public string? OnHold { get; set; }
    
    /// <summary>
    /// JavaScript code to execute on node release event
    /// </summary>
    public string? OnRelease { get; set; }
    
    /// <summary>
    /// JavaScript code to execute on node select event
    /// </summary>
    public string? OnSelect { get; set; }
    
    /// <summary>
    /// JavaScript code to execute on node selection change event
    /// </summary>
    public string? OnSelectNode { get; set; }
    
    /// <summary>
    /// JavaScript code to execute on edge selection change event
    /// </summary>
    public string? OnSelectEdge { get; set; }
    
    /// <summary>
    /// JavaScript code to execute on node deselect event
    /// </summary>
    public string? OnDeselectNode { get; set; }
    
    /// <summary>
    /// JavaScript code to execute on edge deselect event
    /// </summary>
    public string? OnDeselectEdge { get; set; }
    
    /// <summary>
    /// JavaScript code to execute on drag start event
    /// </summary>
    public string? OnDragStart { get; set; }
    
    /// <summary>
    /// JavaScript code to execute on dragging event
    /// </summary>
    public string? OnDragging { get; set; }
    
    /// <summary>
    /// JavaScript code to execute on drag end event
    /// </summary>
    public string? OnDragEnd { get; set; }
    
    /// <summary>
    /// JavaScript code to execute on control node drag end event
    /// </summary>
    public string? OnControlNodeDragEnd { get; set; }
    
    /// <summary>
    /// JavaScript code to execute on control node dragging event
    /// </summary>
    public string? OnControlNodeDragging { get; set; }
    
    /// <summary>
    /// JavaScript code to execute on hover node event
    /// </summary>
    public string? OnHoverNode { get; set; }
    
    /// <summary>
    /// JavaScript code to execute on blur node event
    /// </summary>
    public string? OnBlurNode { get; set; }
    
    /// <summary>
    /// JavaScript code to execute on hover edge event
    /// </summary>
    public string? OnHoverEdge { get; set; }
    
    /// <summary>
    /// JavaScript code to execute on blur edge event
    /// </summary>
    public string? OnBlurEdge { get; set; }
    
    /// <summary>
    /// JavaScript code to execute on zoom event
    /// </summary>
    public string? OnZoom { get; set; }
    
    /// <summary>
    /// JavaScript code to execute on show popup event
    /// </summary>
    public string? OnShowPopup { get; set; }
    
    /// <summary>
    /// JavaScript code to execute on hide popup event
    /// </summary>
    public string? OnHidePopup { get; set; }
    
    /// <summary>
    /// JavaScript code to execute on stabilization start event
    /// </summary>
    public string? OnStartStabilizing { get; set; }
    
    /// <summary>
    /// JavaScript code to execute on stabilization progress event
    /// </summary>
    public string? OnStabilizationProgress { get; set; }
    
    /// <summary>
    /// JavaScript code to execute on stabilization iterations done event
    /// </summary>
    public string? OnStabilizationIterationsDone { get; set; }
    
    /// <summary>
    /// JavaScript code to execute on stabilized event
    /// </summary>
    public string? OnStabilized { get; set; }
    
    /// <summary>
    /// JavaScript code to execute on resize event
    /// </summary>
    public string? OnResize { get; set; }
    
    /// <summary>
    /// JavaScript code to execute on animation finished event
    /// </summary>
    public string? OnAnimationFinished { get; set; }
    
    /// <summary>
    /// JavaScript code to execute on configuration change event
    /// </summary>
    public string? OnConfigChange { get; set; }
    
    /// <summary>
    /// JavaScript code to execute before drawing event
    /// </summary>
    public string? OnBeforeDrawing { get; set; }
    
    /// <summary>
    /// JavaScript code to execute after drawing event
    /// </summary>
    public string? OnAfterDrawing { get; set; }
    
    /// <summary>
    /// Sets the JavaScript code for click event
    /// </summary>
    public VisNetworkEvents WithClick(string jsCode) {
        OnClick = jsCode;
        return this;
    }
    
    /// <summary>
    /// Sets the JavaScript code for double click event
    /// </summary>
    public VisNetworkEvents WithDoubleClick(string jsCode) {
        OnDoubleClick = jsCode;
        return this;
    }
    
    /// <summary>
    /// Sets the JavaScript code for context menu event
    /// </summary>
    public VisNetworkEvents WithContext(string jsCode) {
        OnContext = jsCode;
        return this;
    }
    
    /// <summary>
    /// Sets the JavaScript code for hold event
    /// </summary>
    public VisNetworkEvents WithHold(string jsCode) {
        OnHold = jsCode;
        return this;
    }
    
    /// <summary>
    /// Sets the JavaScript code for release event
    /// </summary>
    public VisNetworkEvents WithRelease(string jsCode) {
        OnRelease = jsCode;
        return this;
    }
    
    /// <summary>
    /// Sets the JavaScript code for select event
    /// </summary>
    public VisNetworkEvents WithSelect(string jsCode) {
        OnSelect = jsCode;
        return this;
    }
    
    /// <summary>
    /// Sets the JavaScript code for node selection event
    /// </summary>
    public VisNetworkEvents WithSelectNode(string jsCode) {
        OnSelectNode = jsCode;
        return this;
    }
    
    /// <summary>
    /// Sets the JavaScript code for edge selection event
    /// </summary>
    public VisNetworkEvents WithSelectEdge(string jsCode) {
        OnSelectEdge = jsCode;
        return this;
    }
    
    /// <summary>
    /// Sets the JavaScript code for node deselection event
    /// </summary>
    public VisNetworkEvents WithDeselectNode(string jsCode) {
        OnDeselectNode = jsCode;
        return this;
    }
    
    /// <summary>
    /// Sets the JavaScript code for edge deselection event
    /// </summary>
    public VisNetworkEvents WithDeselectEdge(string jsCode) {
        OnDeselectEdge = jsCode;
        return this;
    }
    
    /// <summary>
    /// Sets the JavaScript code for drag start event
    /// </summary>
    public VisNetworkEvents WithDragStart(string jsCode) {
        OnDragStart = jsCode;
        return this;
    }
    
    /// <summary>
    /// Sets the JavaScript code for dragging event
    /// </summary>
    public VisNetworkEvents WithDragging(string jsCode) {
        OnDragging = jsCode;
        return this;
    }
    
    /// <summary>
    /// Sets the JavaScript code for drag end event
    /// </summary>
    public VisNetworkEvents WithDragEnd(string jsCode) {
        OnDragEnd = jsCode;
        return this;
    }
    
    /// <summary>
    /// Sets the JavaScript code for hover node event
    /// </summary>
    public VisNetworkEvents WithHoverNode(string jsCode) {
        OnHoverNode = jsCode;
        return this;
    }
    
    /// <summary>
    /// Sets the JavaScript code for blur node event
    /// </summary>
    public VisNetworkEvents WithBlurNode(string jsCode) {
        OnBlurNode = jsCode;
        return this;
    }
    
    /// <summary>
    /// Sets the JavaScript code for hover edge event
    /// </summary>
    public VisNetworkEvents WithHoverEdge(string jsCode) {
        OnHoverEdge = jsCode;
        return this;
    }
    
    /// <summary>
    /// Sets the JavaScript code for blur edge event
    /// </summary>
    public VisNetworkEvents WithBlurEdge(string jsCode) {
        OnBlurEdge = jsCode;
        return this;
    }
    
    /// <summary>
    /// Sets the JavaScript code for zoom event
    /// </summary>
    public VisNetworkEvents WithZoom(string jsCode) {
        OnZoom = jsCode;
        return this;
    }
    
    /// <summary>
    /// Sets the JavaScript code for show popup event
    /// </summary>
    public VisNetworkEvents WithShowPopup(string jsCode) {
        OnShowPopup = jsCode;
        return this;
    }
    
    /// <summary>
    /// Sets the JavaScript code for hide popup event
    /// </summary>
    public VisNetworkEvents WithHidePopup(string jsCode) {
        OnHidePopup = jsCode;
        return this;
    }
    
    /// <summary>
    /// Sets the JavaScript code for stabilization start event
    /// </summary>
    public VisNetworkEvents WithStartStabilizing(string jsCode) {
        OnStartStabilizing = jsCode;
        return this;
    }
    
    /// <summary>
    /// Sets the JavaScript code for stabilization progress event
    /// </summary>
    public VisNetworkEvents WithStabilizationProgress(string jsCode) {
        OnStabilizationProgress = jsCode;
        return this;
    }
    
    /// <summary>
    /// Sets the JavaScript code for stabilization iterations done event
    /// </summary>
    public VisNetworkEvents WithStabilizationIterationsDone(string jsCode) {
        OnStabilizationIterationsDone = jsCode;
        return this;
    }
    
    /// <summary>
    /// Sets the JavaScript code for stabilized event
    /// </summary>
    public VisNetworkEvents WithStabilized(string jsCode) {
        OnStabilized = jsCode;
        return this;
    }
    
    /// <summary>
    /// Sets the JavaScript code for resize event
    /// </summary>
    public VisNetworkEvents WithResize(string jsCode) {
        OnResize = jsCode;
        return this;
    }
    
    /// <summary>
    /// Sets the JavaScript code for animation finished event
    /// </summary>
    public VisNetworkEvents WithAnimationFinished(string jsCode) {
        OnAnimationFinished = jsCode;
        return this;
    }
    
    /// <summary>
    /// Sets the JavaScript code for configuration change event
    /// </summary>
    public VisNetworkEvents WithConfigChange(string jsCode) {
        OnConfigChange = jsCode;
        return this;
    }
    
    /// <summary>
    /// Sets the JavaScript code for before drawing event
    /// </summary>
    public VisNetworkEvents WithBeforeDrawing(string jsCode) {
        OnBeforeDrawing = jsCode;
        return this;
    }
    
    /// <summary>
    /// Sets the JavaScript code for after drawing event
    /// </summary>
    public VisNetworkEvents WithAfterDrawing(string jsCode) {
        OnAfterDrawing = jsCode;
        return this;
    }
    
    /// <summary>
    /// Provides predefined event handler templates
    /// </summary>
    public static class Templates {
        /// <summary>
        /// Template for showing node information on click
        /// </summary>
        public static string ShowNodeInfo => @"
            function(params) {
                if (params.nodes.length > 0) {
                    var nodeId = params.nodes[0];
                    var node = nodes.get(nodeId);
                    alert('Clicked node: ' + node.label);
                }
            }";
        
        /// <summary>
        /// Template for highlighting connected nodes on hover
        /// </summary>
        public static string HighlightConnected => @"
            function(params) {
                var nodeId = params.node;
                var connectedNodes = network.getConnectedNodes(nodeId);
                var updateArray = [];
                
                connectedNodes.forEach(function(id) {
                    updateArray.push({id: id, color: {background: '#FFA500'}});
                });
                
                nodes.update(updateArray);
            }";
        
        /// <summary>
        /// Template for console logging event data
        /// </summary>
        public static string LogEventData => @"
            function(params) {
                console.log('Event triggered:', params);
            }";
        
        /// <summary>
        /// Template for updating external element with selection
        /// </summary>
        public static string UpdateSelectionDisplay => @"
            function(params) {
                var selectedNodes = params.nodes;
                var selectedEdges = params.edges;
                var display = document.getElementById('selection-display');
                if (display) {
                    display.innerHTML = 'Selected nodes: ' + selectedNodes.join(', ') + 
                                      '<br>Selected edges: ' + selectedEdges.join(', ');
                }
            }";
        
        /// <summary>
        /// Template for preventing default context menu
        /// </summary>
        public static string PreventContextMenu => @"
            function(params) {
                params.event.preventDefault();
                // Add custom context menu logic here
            }";
        
        /// <summary>
        /// Template for zoom level display
        /// </summary>
        public static string DisplayZoomLevel => @"
            function(params) {
                var scale = network.getScale();
                console.log('Zoom level:', scale);
                var display = document.getElementById('zoom-display');
                if (display) {
                    display.innerHTML = 'Zoom: ' + (scale * 100).toFixed(0) + '%';
                }
            }";
    }
}