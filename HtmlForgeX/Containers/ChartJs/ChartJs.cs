using System.Collections.Generic;
using System.Text.Json;

namespace HtmlForgeX;

/// <summary>
/// Helper for building simple Chart.js charts.
/// </summary>
public class ChartJs : Element {
    /// <summary>
    /// Gets or sets the canvas identifier.
    /// </summary>
    public string Id { get; set; }
    public ChartJsType Type { get; set; } = ChartJsType.Bar;
    public List<string> Labels { get; } = new();
    public List<double> Data { get; } = new();

    public ChartJs() {
        Id = GlobalStorage.GenerateRandomId("chartjs");
    }

    protected internal override void RegisterLibraries() {
        Document?.Configuration.Libraries.TryAdd(Libraries.ChartJs, 0);
    }

    public ChartJs AddData(string label, double value) {
        Labels.Add(label);
        Data.Add(value);
        return this;
    }

    public ChartJs SetType(ChartJsType type) {
        Type = type;
        return this;
    }

    public ChartJs Line() => SetType(ChartJsType.Line);
    public ChartJs Bar() => SetType(ChartJsType.Bar);
    public ChartJs Pie() => SetType(ChartJsType.Pie);

    public override string ToString() {
        var canvas = new HtmlTag("canvas").Id(Id);
        var options = new {
            type = Type,
            data = new {
                labels = Labels,
                datasets = new[] {
                    new {
                        label = "Dataset",
                        data = Data
                    }
                }
            }
        };
        var json = JsonSerializer.Serialize(options, new JsonSerializerOptions { WriteIndented = true });
        var script = new HtmlTag("script").Value($@"var ctx = document.getElementById('{Id}').getContext('2d');new Chart(ctx, {json});");
        return canvas + script.ToString();
    }
}
