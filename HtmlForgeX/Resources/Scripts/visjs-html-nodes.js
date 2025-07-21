/**
 * HtmlForgeX VisJS HTML Nodes Plugin
 * Custom implementation to support HTML content in VisJS network nodes
 * 
 * This is a custom implementation since the original visjs-html-nodes package
 * only provides ES6 modules which cannot be loaded directly in browsers.
 * 
 * Based on the concept from: https://github.com/NickvanDyke/visjs-html-nodes
 * MIT License
 */
(function(global) {
    'use strict';

    // Constructor function
    function VisJsHtmlNodes(network, options) {
        this.network = network;
        this.options = options || {};
        this.htmlContainer = null;
        this.nodeElements = {};
        
        this.init();
    }

    // Initialize the HTML nodes
    VisJsHtmlNodes.prototype.init = function() {
        var self = this;
        
        // Create container for HTML elements
        var networkContainer = this.network.body.container;
        this.htmlContainer = document.createElement('div');
        this.htmlContainer.style.position = 'absolute';
        this.htmlContainer.style.top = '0';
        this.htmlContainer.style.left = '0';
        this.htmlContainer.style.width = '100%';
        this.htmlContainer.style.height = '100%';
        this.htmlContainer.style.pointerEvents = 'none';
        this.htmlContainer.style.overflow = 'hidden';
        networkContainer.appendChild(this.htmlContainer);
        
        // Update HTML positions after drawing
        this.network.on('afterDrawing', function() {
            self.updatePositions();
        });
        
        // Update on zoom/pan
        this.network.on('zoom', function() {
            self.updatePositions();
        });
        
        this.network.on('dragEnd', function() {
            self.updatePositions();
        });
        
        // Initial render
        this.renderNodes();
        this.updatePositions();
    };

    // Render HTML nodes
    VisJsHtmlNodes.prototype.renderNodes = function() {
        var self = this;
        var nodes = this.network.body.data.nodes;
        
        // Clear existing HTML elements
        this.htmlContainer.innerHTML = '';
        this.nodeElements = {};
        
        // Create HTML elements for each node
        nodes.forEach(function(nodeData) {
            var htmlContent = null;
            
            // Get HTML content from template function
            if (self.options.template && typeof self.options.template === 'function') {
                htmlContent = self.options.template(nodeData);
            }
            
            // Only create HTML element if there's content
            if (htmlContent) {
                var element = document.createElement('div');
                element.style.position = 'absolute';
                element.style.pointerEvents = 'auto';
                element.innerHTML = htmlContent;
                
                self.htmlContainer.appendChild(element);
                self.nodeElements[nodeData.id] = element;
            }
        });
    };

    // Update positions of HTML elements
    VisJsHtmlNodes.prototype.updatePositions = function() {
        var self = this;
        
        Object.keys(this.nodeElements).forEach(function(nodeId) {
            var element = self.nodeElements[nodeId];
            var nodePosition = self.network.getPositions([nodeId])[nodeId];
            
            if (nodePosition) {
                // Convert canvas position to DOM position
                var domPos = self.network.canvasToDOM({
                    x: nodePosition.x,
                    y: nodePosition.y
                });
                
                // Center the element on the node
                var rect = element.getBoundingClientRect();
                element.style.left = (domPos.x - rect.width / 2) + 'px';
                element.style.top = (domPos.y - rect.height / 2) + 'px';
            }
        });
    };

    // Export to global scope
    global.VisJsHtmlNodes = VisJsHtmlNodes;
    
})(typeof window !== 'undefined' ? window : this);