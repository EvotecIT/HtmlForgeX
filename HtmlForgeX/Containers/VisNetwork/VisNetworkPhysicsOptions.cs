using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Physics simulation configuration options for VisNetwork.
/// </summary>
public partial class VisNetworkPhysicsOptions {
    /// <summary>
    /// Gets or sets a value indicating whether physics simulation is enabled.
    /// </summary>
    [JsonPropertyName("enabled")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Enabled { get; set; }

    /// <summary>
    /// Gets or sets the maximum allowed velocity for the physics simulation.
    /// </summary>
    [JsonPropertyName("maxVelocity")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MaxVelocity { get; set; }

    /// <summary>
    /// Gets or sets the minimum velocity for the physics simulation.
    /// </summary>
    [JsonPropertyName("minVelocity")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MinVelocity { get; set; }


    /// <summary>
    /// Gets or sets stabilization settings. Can be a boolean to enable or disable
    /// stabilization or a <see cref="VisNetworkStabilizationOptions"/> instance for
    /// detailed configuration.
    /// </summary>
    [JsonPropertyName("stabilization")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Stabilization { get; set; }

    /// <summary>
    /// Gets or sets the time step for the physics simulation.
    /// </summary>
    [JsonPropertyName("timestep")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Timestep { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the timestep is adaptive.
    /// </summary>
    [JsonPropertyName("adaptiveTimestep")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? AdaptiveTimestep { get; set; }

    /// <summary>
    /// Gets or sets the wind force applied to all nodes.
    /// </summary>
    [JsonPropertyName("wind")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkWindOptions? Wind { get; set; }

    // Fluent API Methods

    /// <summary>
    /// Enables or disables physics simulation.
    /// </summary>
    /// <param name="enabled">Whether physics should be enabled.</param>
    /// <returns>The current <see cref="VisNetworkPhysicsOptions"/> instance.</returns>
    public VisNetworkPhysicsOptions WithEnabled(bool enabled = true) {
        Enabled = enabled;
        return this;
    }
    /// <summary>
    /// Sets the maximum velocity for the simulation.
    /// </summary>
    /// <param name="velocity">The maximum velocity value.</param>
    /// <returns>The current <see cref="VisNetworkPhysicsOptions"/> instance.</returns>
    public VisNetworkPhysicsOptions WithMaxVelocity(double velocity) {
        MaxVelocity = velocity;
        return this;
    }

    /// <summary>
    /// Sets the minimum velocity for the simulation.
    /// </summary>
    /// <param name="velocity">The minimum velocity value.</param>
    /// <returns>The current <see cref="VisNetworkPhysicsOptions"/> instance.</returns>
    public VisNetworkPhysicsOptions WithMinVelocity(double velocity) {
        MinVelocity = velocity;
        return this;
    }

    /// <summary>
    /// Enables stabilization using a simple boolean flag.
    /// </summary>
    /// <param name="enabled">Whether stabilization is enabled.</param>
    /// <returns>The current <see cref="VisNetworkPhysicsOptions"/> instance.</returns>
    public VisNetworkPhysicsOptions WithStabilization(bool enabled = true) {
        Stabilization = enabled;
        return this;
    }

    /// <summary>
    /// Enables stabilization using the provided options instance.
    /// </summary>
    /// <param name="stabilizationOptions">Detailed stabilization options.</param>
    /// <returns>The current <see cref="VisNetworkPhysicsOptions"/> instance.</returns>
    public VisNetworkPhysicsOptions WithStabilization(VisNetworkStabilizationOptions stabilizationOptions) {
        Stabilization = stabilizationOptions;
        return this;
    }

    /// <summary>
    /// Configures stabilization using a callback.
    /// </summary>
    /// <param name="configure">Callback to configure the options.</param>
    /// <returns>The current <see cref="VisNetworkPhysicsOptions"/> instance.</returns>
    public VisNetworkPhysicsOptions WithStabilization(Action<VisNetworkStabilizationOptions> configure) {
        var stabilizationOptions = new VisNetworkStabilizationOptions();
        configure(stabilizationOptions);
        Stabilization = stabilizationOptions;
        return this;
    }

    /// <summary>
    /// Sets the simulation time step.
    /// </summary>
    /// <param name="timestep">The time step value.</param>
    /// <returns>The current <see cref="VisNetworkPhysicsOptions"/> instance.</returns>
    public VisNetworkPhysicsOptions WithTimestep(double timestep) {
        Timestep = timestep;
        return this;
    }

    /// <summary>
    /// Enables or disables adaptive time stepping.
    /// </summary>
    /// <param name="adaptive">Whether adaptive time stepping is enabled.</param>
    /// <returns>The current <see cref="VisNetworkPhysicsOptions"/> instance.</returns>
    public VisNetworkPhysicsOptions WithAdaptiveTimestep(bool adaptive = true) {
        AdaptiveTimestep = adaptive;
        return this;
    }

    /// <summary>
    /// Sets a constant wind force.
    /// </summary>
    /// <param name="x">Horizontal force component.</param>
    /// <param name="y">Vertical force component.</param>
    /// <returns>The current <see cref="VisNetworkPhysicsOptions"/> instance.</returns>
    public VisNetworkPhysicsOptions WithWind(double x, double y) {
        Wind = new VisNetworkWindOptions { X = x, Y = y };
        return this;
    }
}

/// <summary>
/// Barnes Hut physics solver options.
/// </summary>

/// <summary>
/// Stabilization configuration options.
/// </summary>
public class VisNetworkStabilizationOptions {
    /// <summary>Gets or sets whether stabilization is enabled.</summary>
    [JsonPropertyName("enabled")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Enabled { get; set; }

    /// <summary>Gets or sets the number of stabilization iterations.</summary>
    [JsonPropertyName("iterations")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Iterations { get; set; }

    /// <summary>Gets or sets the update interval.</summary>
    [JsonPropertyName("updateInterval")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? UpdateInterval { get; set; }

    /// <summary>Gets or sets a value indicating whether only dynamic edges are stabilized.</summary>
    [JsonPropertyName("onlyDynamicEdges")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? OnlyDynamicEdges { get; set; }

    /// <summary>Gets or sets whether the view should fit after stabilization.</summary>
    [JsonPropertyName("fit")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Fit { get; set; }

    /// <summary>
    /// Enables or disables stabilization.
    /// </summary>
    /// <param name="enabled">Whether stabilization is enabled.</param>
    /// <returns>The current <see cref="VisNetworkStabilizationOptions"/> instance.</returns>
    public VisNetworkStabilizationOptions WithEnabled(bool enabled = true) {
        Enabled = enabled;
        return this;
    }

    /// <summary>
    /// Sets the number of stabilization iterations.
    /// </summary>
    /// <param name="iterations">The iteration count.</param>
    /// <returns>The current <see cref="VisNetworkStabilizationOptions"/> instance.</returns>
    public VisNetworkStabilizationOptions WithIterations(int iterations) {
        Iterations = iterations;
        return this;
    }

    /// <summary>
    /// Sets the update interval.
    /// </summary>
    /// <param name="interval">The interval value.</param>
    /// <returns>The current <see cref="VisNetworkStabilizationOptions"/> instance.</returns>
    public VisNetworkStabilizationOptions WithUpdateInterval(int interval) {
        UpdateInterval = interval;
        return this;
    }

    /// <summary>
    /// Specifies whether only dynamic edges should be stabilized.
    /// </summary>
    /// <param name="onlyDynamic">Value indicating whether to stabilize only dynamic edges.</param>
    /// <returns>The current <see cref="VisNetworkStabilizationOptions"/> instance.</returns>
    public VisNetworkStabilizationOptions WithOnlyDynamicEdges(bool onlyDynamic = true) {
        OnlyDynamicEdges = onlyDynamic;
        return this;
    }

    /// <summary>
    /// Sets whether the view should fit after stabilization.
    /// </summary>
    /// <param name="fit">If set to <c>true</c>, the view will fit to all nodes.</param>
    /// <returns>The current <see cref="VisNetworkStabilizationOptions"/> instance.</returns>
    public VisNetworkStabilizationOptions WithFit(bool fit = true) {
        Fit = fit;
        return this;
    }
}

/// <summary>
/// Wind force configuration.
/// </summary>
public class VisNetworkWindOptions {
    /// <summary>Gets or sets the horizontal component of the wind force.</summary>
    [JsonPropertyName("x")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? X { get; set; }

    /// <summary>Gets or sets the vertical component of the wind force.</summary>
    [JsonPropertyName("y")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Y { get; set; }
}