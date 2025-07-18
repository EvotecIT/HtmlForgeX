using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Represents a custom node shape renderer for VisNetwork.
/// </summary>
public class VisNetworkCustomShape {
    /// <summary>
    /// Gets or sets the JavaScript function code for rendering the shape.
    /// </summary>
    [JsonIgnore]
    public string RenderFunction { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the name of the custom shape.
    /// </summary>
    [JsonIgnore]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Creates a custom shape with the specified render function.
    /// </summary>
    /// <param name="name">The name of the shape.</param>
    /// <param name="renderFunction">The JavaScript function code.</param>
    public VisNetworkCustomShape(string name, string renderFunction) {
        Name = name;
        RenderFunction = renderFunction;
    }

    /// <summary>
    /// Default constructor.
    /// </summary>
    public VisNetworkCustomShape() { }
}

/// <summary>
/// Provides predefined custom shapes for VisNetwork nodes.
/// </summary>
public static class VisNetworkCustomShapes {
    /// <summary>
    /// Creates a rounded rectangle shape.
    /// </summary>
    public static VisNetworkCustomShape RoundedRectangle(int radius = 10) => new("roundedRectangle", $@"
        function(ctx, x, y, state, doStroke, doFill) {{
            var r = this.options.size || 25;
            var radius = {radius};
            ctx.beginPath();
            ctx.moveTo(x - r + radius, y - r);
            ctx.lineTo(x + r - radius, y - r);
            ctx.quadraticCurveTo(x + r, y - r, x + r, y - r + radius);
            ctx.lineTo(x + r, y + r - radius);
            ctx.quadraticCurveTo(x + r, y + r, x + r - radius, y + r);
            ctx.lineTo(x - r + radius, y + r);
            ctx.quadraticCurveTo(x - r, y + r, x - r, y + r - radius);
            ctx.lineTo(x - r, y - r + radius);
            ctx.quadraticCurveTo(x - r, y - r, x - r + radius, y - r);
            ctx.closePath();
            if (doFill) {{
                ctx.fill();
            }}
            if (doStroke) {{
                ctx.stroke();
            }}
        }}");

    /// <summary>
    /// Creates a heart shape.
    /// </summary>
    public static VisNetworkCustomShape Heart => new("heart", @"
        function(ctx, x, y, state, doStroke, doFill) {
            var r = this.options.size || 25;
            var s = r * 0.8;
            ctx.beginPath();
            ctx.moveTo(x, y + s / 2);
            ctx.bezierCurveTo(x - s / 2, y - s / 2, x - s, y + s / 5, x, y + s);
            ctx.bezierCurveTo(x + s, y + s / 5, x + s / 2, y - s / 2, x, y + s / 2);
            ctx.closePath();
            if (doFill) {
                ctx.fill();
            }
            if (doStroke) {
                ctx.stroke();
            }
        }");

    /// <summary>
    /// Creates a cloud shape.
    /// </summary>
    public static VisNetworkCustomShape Cloud => new("cloud", @"
        function(ctx, x, y, state, doStroke, doFill) {
            var r = this.options.size || 25;
            ctx.beginPath();
            ctx.arc(x - r * 0.4, y, r * 0.5, 0, Math.PI * 2);
            ctx.arc(x + r * 0.4, y, r * 0.5, 0, Math.PI * 2);
            ctx.arc(x, y - r * 0.3, r * 0.6, 0, Math.PI * 2);
            ctx.arc(x - r * 0.2, y + r * 0.3, r * 0.4, 0, Math.PI * 2);
            ctx.arc(x + r * 0.2, y + r * 0.3, r * 0.4, 0, Math.PI * 2);
            ctx.closePath();
            if (doFill) {
                ctx.fill();
            }
            if (doStroke) {
                ctx.stroke();
            }
        }");

    /// <summary>
    /// Creates a gear/cog shape.
    /// </summary>
    public static VisNetworkCustomShape Gear(int teeth = 8) => new("gear", $@"
        function(ctx, x, y, state, doStroke, doFill) {{
            var r = this.options.size || 25;
            var teeth = {teeth};
            var innerRadius = r * 0.6;
            var outerRadius = r;
            var angle = Math.PI * 2 / teeth;
            
            ctx.beginPath();
            for (var i = 0; i < teeth; i++) {{
                var a = i * angle - Math.PI / 2;
                var nextA = (i + 1) * angle - Math.PI / 2;
                
                ctx.arc(x, y, outerRadius, a - angle * 0.1, a + angle * 0.1);
                ctx.arc(x, y, innerRadius, a + angle * 0.1, nextA - angle * 0.1);
            }}
            ctx.closePath();
            
            if (doFill) {{
                ctx.fill();
            }}
            if (doStroke) {{
                ctx.stroke();
            }}
            
            // Inner circle
            ctx.beginPath();
            ctx.arc(x, y, innerRadius * 0.5, 0, Math.PI * 2);
            ctx.closePath();
            if (doStroke) {{
                ctx.stroke();
            }}
        }}");

    /// <summary>
    /// Creates a lightning bolt shape.
    /// </summary>
    public static VisNetworkCustomShape Lightning => new("lightning", @"
        function(ctx, x, y, state, doStroke, doFill) {
            var r = this.options.size || 25;
            ctx.beginPath();
            ctx.moveTo(x - r * 0.3, y - r);
            ctx.lineTo(x + r * 0.1, y - r * 0.2);
            ctx.lineTo(x - r * 0.1, y - r * 0.2);
            ctx.lineTo(x + r * 0.3, y + r);
            ctx.lineTo(x, y + r * 0.2);
            ctx.lineTo(x + r * 0.2, y + r * 0.2);
            ctx.closePath();
            if (doFill) {
                ctx.fill();
            }
            if (doStroke) {
                ctx.stroke();
            }
        }");

    /// <summary>
    /// Creates a house shape.
    /// </summary>
    public static VisNetworkCustomShape House => new("house", @"
        function(ctx, x, y, state, doStroke, doFill) {
            var r = this.options.size || 25;
            // Roof
            ctx.beginPath();
            ctx.moveTo(x - r, y);
            ctx.lineTo(x, y - r);
            ctx.lineTo(x + r, y);
            ctx.closePath();
            if (doFill) {
                ctx.fill();
            }
            if (doStroke) {
                ctx.stroke();
            }
            
            // House body
            ctx.beginPath();
            ctx.rect(x - r * 0.8, y, r * 1.6, r * 0.8);
            if (doFill) {
                ctx.fill();
            }
            if (doStroke) {
                ctx.stroke();
            }
            
            // Door
            ctx.beginPath();
            ctx.rect(x - r * 0.2, y + r * 0.3, r * 0.4, r * 0.5);
            if (doStroke) {
                ctx.stroke();
            }
        }");

    /// <summary>
    /// Creates a person/user shape.
    /// </summary>
    public static VisNetworkCustomShape Person => new("person", @"
        function(ctx, x, y, state, doStroke, doFill) {
            var r = this.options.size || 25;
            
            // Head
            ctx.beginPath();
            ctx.arc(x, y - r * 0.5, r * 0.3, 0, Math.PI * 2);
            ctx.closePath();
            if (doFill) {
                ctx.fill();
            }
            if (doStroke) {
                ctx.stroke();
            }
            
            // Body
            ctx.beginPath();
            ctx.moveTo(x, y - r * 0.2);
            ctx.lineTo(x, y + r * 0.3);
            
            // Arms
            ctx.moveTo(x - r * 0.4, y);
            ctx.lineTo(x + r * 0.4, y);
            
            // Legs
            ctx.moveTo(x, y + r * 0.3);
            ctx.lineTo(x - r * 0.3, y + r * 0.8);
            ctx.moveTo(x, y + r * 0.3);
            ctx.lineTo(x + r * 0.3, y + r * 0.8);
            
            if (doStroke) {
                ctx.stroke();
            }
        }");

    /// <summary>
    /// Creates an arrow shape pointing in a specific direction.
    /// </summary>
    public static VisNetworkCustomShape Arrow(string direction = "right") => new("arrow", $@"
        function(ctx, x, y, state, doStroke, doFill) {{
            var r = this.options.size || 25;
            var direction = '{direction}';
            
            ctx.save();
            ctx.translate(x, y);
            
            switch(direction) {{
                case 'up': ctx.rotate(-Math.PI / 2); break;
                case 'down': ctx.rotate(Math.PI / 2); break;
                case 'left': ctx.rotate(Math.PI); break;
            }}
            
            ctx.beginPath();
            ctx.moveTo(-r, -r * 0.5);
            ctx.lineTo(0, -r * 0.5);
            ctx.lineTo(0, -r);
            ctx.lineTo(r, 0);
            ctx.lineTo(0, r);
            ctx.lineTo(0, r * 0.5);
            ctx.lineTo(-r, r * 0.5);
            ctx.closePath();
            
            ctx.restore();
            
            if (doFill) {{
                ctx.fill();
            }}
            if (doStroke) {{
                ctx.stroke();
            }}
        }}");

    /// <summary>
    /// Creates a custom shape from user-provided JavaScript code.
    /// </summary>
    /// <param name="name">The name of the shape.</param>
    /// <param name="renderFunction">The JavaScript render function.</param>
    public static VisNetworkCustomShape Custom(string name, string renderFunction) => 
        new(name, renderFunction);

    /// <summary>
    /// Creates a shape that displays an emoji or text.
    /// </summary>
    public static VisNetworkCustomShape Emoji(string emoji, int fontSize = 20) => new("emoji", $@"
        function(ctx, x, y, state, doStroke, doFill) {{
            var r = this.options.size || 25;
            
            // Background circle
            ctx.beginPath();
            ctx.arc(x, y, r, 0, Math.PI * 2);
            ctx.closePath();
            if (doFill) {{
                ctx.fill();
            }}
            if (doStroke) {{
                ctx.stroke();
            }}
            
            // Emoji text
            ctx.save();
            ctx.font = '{fontSize}px Arial';
            ctx.textAlign = 'center';
            ctx.textBaseline = 'middle';
            ctx.fillStyle = 'black';
            ctx.fillText('{emoji}', x, y);
            ctx.restore();
        }}");
}