using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Helper for building simple Chart.js charts.
/// </summary>
public partial class ChartJs : Element {
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
    /// Gets the numeric values for the dataset (for line, bar, pie and radar charts).
    /// </summary>
    public List<double> Data { get; } = new();

    /// <summary>
    /// Gets the scatter points for scatter charts.
    /// </summary>
    public List<(double x, double y)> Points { get; } = new();

    /// <summary>
    /// Gets the bubble points for bubble charts.
    /// </summary>
    public List<(double x, double y, double r)> Bubbles { get; } = new();

    /// <summary>
    /// Gets the datasets for advanced configuration.
    /// </summary>
    public List<ChartJsDataset> Datasets { get; } = new();

    /// <summary>
    /// Gets or sets the chart options.
    /// </summary>
    public ChartJsOptions Options { get; set; } = new();

    /// <summary>
    /// Gets or sets the canvas width.
    /// </summary>
    public string? Width { get; set; }

    /// <summary>
    /// Gets or sets the canvas height.
    /// </summary>
    public string? Height { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ChartJs"/> class.
    /// </summary>
    public ChartJs() {
        Id = GlobalStorage.GenerateRandomId("chartjs");
        // Set default options
        Options.Responsive = true;
        Options.MaintainAspectRatio = true;
    }

    /// <summary>
    /// Registers the Chart.js library with the current document.
    /// </summary>
    protected internal override void RegisterLibraries() {
        Document?.AddLibrary(Libraries.ChartJs);
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
    /// Shortcut for calling <see cref="SetType(ChartJsType)"/> with
    /// <see cref="ChartJsType.Radar"/>.
    /// </summary>
    /// <returns>The current <see cref="ChartJs"/> instance.</returns>
    public ChartJs Radar() => SetType(ChartJsType.Radar);

    /// <summary>
    /// Shortcut for calling <see cref="SetType(ChartJsType)"/> with
    /// <see cref="ChartJsType.Scatter"/>.
    /// </summary>
    /// <returns>The current <see cref="ChartJs"/> instance.</returns>
    public ChartJs Scatter() => SetType(ChartJsType.Scatter);

    /// <summary>
    /// Shortcut for calling <see cref="SetType(ChartJsType)"/> with
    /// <see cref="ChartJsType.Bubble"/>.
    /// </summary>
    /// <returns>The current <see cref="ChartJs"/> instance.</returns>
    public ChartJs Bubble() => SetType(ChartJsType.Bubble);

    /// <summary>
    /// Shortcut for calling <see cref="SetType(ChartJsType)"/> with
    /// <see cref="ChartJsType.Doughnut"/>.
    /// </summary>
    /// <returns>The current <see cref="ChartJs"/> instance.</returns>
    public ChartJs Doughnut() => SetType(ChartJsType.Doughnut);

    /// <summary>
    /// Shortcut for calling <see cref="SetType(ChartJsType)"/> with
    /// <see cref="ChartJsType.PolarArea"/>.
    /// </summary>
    /// <returns>The current <see cref="ChartJs"/> instance.</returns>
    public ChartJs PolarArea() => SetType(ChartJsType.PolarArea);

    }
