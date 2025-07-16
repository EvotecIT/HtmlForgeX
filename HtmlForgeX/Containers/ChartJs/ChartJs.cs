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

    /// <summary>
    /// Gets or sets the chart type.
    /// </summary>
    public ChartJsType Type { get; set; } = ChartJsType.Bar;

    /// <summary>
    /// Gets the labels for the dataset.
    /// </summary>
    public List<string> Labels { get; } = new();

    /// <summary>
    /// Gets the numeric values for the dataset.
    /// </summary>
    public List<double> Data { get; } = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="ChartJs"/> class.
    /// </summary>
    public ChartJs() {
        Id = GlobalStorage.GenerateRandomId("chartjs");
    }

    /// <summary>
    /// Registers the Chart.js library with the current document.
    /// </summary>
    protected internal override void RegisterLibraries() {
        Document?.AddLibrary(Libraries.ChartJs);
    }

    /// <summary>
    /// Adds a data point to the chart.
    /// </summary>
    /// <param name="label">Label for the data point.</param>
    /// <param name="value">Numeric value.</param>
    /// <returns>The current <see cref="ChartJs"/> instance.</returns>
    public ChartJs AddData(string label, double value) {
        Labels.Add(label);
        Data.Add(value);
        return this;
    }

    /// <summary>
    /// Sets the chart type.
    /// </summary>
    /// <param name="type">Chart type.</param>
    /// <returns>The current <see cref="ChartJs"/> instance.</returns>
    public ChartJs SetType(ChartJsType type) {
        Type = type;
        return this;
    }

    /// <summary>
    /// Shortcut for calling <see cref="SetType(ChartJsType)"/> with
    /// <see cref="ChartJsType.Line"/>.
    /// </summary>
    /// <returns>The current <see cref="ChartJs"/> instance.</returns>
    public ChartJs Line() => SetType(ChartJsType.Line);

    /// <summary>
    /// Shortcut for calling <see cref="SetType(ChartJsType)"/> with
    /// <see cref="ChartJsType.Bar"/>.
    /// </summary>
    /// <returns>The current <see cref="ChartJs"/> instance.</returns>
    public ChartJs Bar() => SetType(ChartJsType.Bar);

    /// <summary>
    /// Shortcut for calling <see cref="SetType(ChartJsType)"/> with
    /// <see cref="ChartJsType.Pie"/>.
    /// </summary>
    /// <returns>The current <see cref="ChartJs"/> instance.</returns>
    public ChartJs Pie() => SetType(ChartJsType.Pie);

    /// <summary>
    /// Generates the HTML required to render the chart.
    /// </summary>
    /// <returns>The HTML markup.</returns>
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
