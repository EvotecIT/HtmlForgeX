using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;

namespace HtmlForgeX;

public partial class ChartJs {
    /// <summary>
    /// Generates the HTML required to render the chart.
    /// </summary>
    /// <returns>The HTML markup.</returns>
    public override string ToString() {
        var canvas = new HtmlTag("canvas").Id(Id);
        
        if (!string.IsNullOrEmpty(Width)) {
            canvas.Attributes["width"] = Width!;
        }
        
        if (!string.IsNullOrEmpty(Height)) {
            canvas.Attributes["height"] = Height!;
        }

        // If using the simple API, create a default dataset
        if (Datasets.Count == 0 && (Data.Count > 0 || Points.Count > 0 || Bubbles.Count > 0)) {
            var dataset = new ChartJsDataset { Label = "Dataset" };
            
            switch (Type) {
                case ChartJsType.Scatter:
                    dataset.PointData = Points.Select(p => (object)new { x = p.x, y = p.y }).ToList();
                    break;
                case ChartJsType.Bubble:
                    dataset.PointData = Bubbles.Select(p => (object)new { x = p.x, y = p.y, r = p.r }).ToList();
                    break;
                default:
                    dataset.Data = Data;
                    break;
            }
            
            Datasets.Add(dataset);
        }

        // Prepare the data object
        object dataObj;
        if (Type == ChartJsType.Scatter || Type == ChartJsType.Bubble) {
            dataObj = new {
                datasets = Datasets
            };
        } else {
            dataObj = new {
                labels = Labels,
                datasets = Datasets
            };
        }

        var config = new {
            type = Type,
            data = dataObj,
            options = Options
        };

        var options = new JsonSerializerOptions { 
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        
        // Add custom converters for enums
        options.Converters.Add(new ChartJsPositionConverter());
        options.Converters.Add(new ChartJsAlignConverter());
        options.Converters.Add(new ChartJsInteractionModeConverter());
        options.Converters.Add(new ChartJsFontStyleConverter());
        options.Converters.Add(new ChartJsFontWeightConverter());
        options.Converters.Add(new ChartJsPositionNullableConverter());
        options.Converters.Add(new ChartJsAlignNullableConverter());
        options.Converters.Add(new ChartJsInteractionModeNullableConverter());
        
        var json = JsonSerializer.Serialize(config, options);

        var script = new HtmlTag("script").Value($@"
(function() {{
    var ctx = document.getElementById('{Id}');
    if (ctx) {{
        ctx = ctx.getContext('2d');
        new Chart(ctx, {json});
    }}
}})();");

        return canvas + script.ToString();
    }
}