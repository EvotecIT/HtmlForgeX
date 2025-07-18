using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Physics simulation configuration options for VisNetwork.
/// </summary>
public class VisNetworkPhysicsOptions {
    [JsonPropertyName("enabled")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Enabled { get; set; }

    [JsonPropertyName("barnesHut")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkBarnesHutOptions? BarnesHut { get; set; }

    [JsonPropertyName("forceAtlas2Based")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkForceAtlas2Options? ForceAtlas2Based { get; set; }

    [JsonPropertyName("repulsion")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkRepulsionOptions? Repulsion { get; set; }

    [JsonPropertyName("hierarchicalRepulsion")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkHierarchicalRepulsionOptions? HierarchicalRepulsion { get; set; }

    [JsonPropertyName("maxVelocity")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MaxVelocity { get; set; }

    [JsonPropertyName("minVelocity")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MinVelocity { get; set; }

    [JsonPropertyName("solver")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkPhysicsSolver? Solver { get; set; }

    [JsonPropertyName("stabilization")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Stabilization { get; set; }

    [JsonPropertyName("timestep")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Timestep { get; set; }

    [JsonPropertyName("adaptiveTimestep")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? AdaptiveTimestep { get; set; }

    [JsonPropertyName("wind")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkWindOptions? Wind { get; set; }

    // Fluent API Methods

    public VisNetworkPhysicsOptions WithEnabled(bool enabled = true) {
        Enabled = enabled;
        return this;
    }

    public VisNetworkPhysicsOptions WithSolver(VisNetworkPhysicsSolver solver) {
        Solver = solver;
        return this;
    }

    public VisNetworkPhysicsOptions WithBarnesHut(Action<VisNetworkBarnesHutOptions> configure) {
        BarnesHut ??= new VisNetworkBarnesHutOptions();
        configure(BarnesHut);
        Solver = VisNetworkPhysicsSolver.BarnesHut;
        return this;
    }

    public VisNetworkPhysicsOptions WithForceAtlas2Based(Action<VisNetworkForceAtlas2Options> configure) {
        ForceAtlas2Based ??= new VisNetworkForceAtlas2Options();
        configure(ForceAtlas2Based);
        Solver = VisNetworkPhysicsSolver.ForceAtlas2based;
        return this;
    }

    public VisNetworkPhysicsOptions WithRepulsion(Action<VisNetworkRepulsionOptions> configure) {
        Repulsion ??= new VisNetworkRepulsionOptions();
        configure(Repulsion);
        Solver = VisNetworkPhysicsSolver.Repulsion;
        return this;
    }

    public VisNetworkPhysicsOptions WithHierarchicalRepulsion(Action<VisNetworkHierarchicalRepulsionOptions> configure) {
        HierarchicalRepulsion ??= new VisNetworkHierarchicalRepulsionOptions();
        configure(HierarchicalRepulsion);
        Solver = VisNetworkPhysicsSolver.HierarchicalRepulsion;
        return this;
    }

    public VisNetworkPhysicsOptions WithMaxVelocity(double velocity) {
        MaxVelocity = velocity;
        return this;
    }

    public VisNetworkPhysicsOptions WithMinVelocity(double velocity) {
        MinVelocity = velocity;
        return this;
    }

    public VisNetworkPhysicsOptions WithStabilization(bool enabled = true) {
        Stabilization = enabled;
        return this;
    }

    public VisNetworkPhysicsOptions WithStabilization(VisNetworkStabilizationOptions stabilizationOptions) {
        Stabilization = stabilizationOptions;
        return this;
    }

    public VisNetworkPhysicsOptions WithTimestep(double timestep) {
        Timestep = timestep;
        return this;
    }

    public VisNetworkPhysicsOptions WithAdaptiveTimestep(bool adaptive = true) {
        AdaptiveTimestep = adaptive;
        return this;
    }

    public VisNetworkPhysicsOptions WithWind(double x, double y) {
        Wind = new VisNetworkWindOptions { X = x, Y = y };
        return this;
    }
}

/// <summary>
/// Barnes Hut physics solver options.
/// </summary>
public class VisNetworkBarnesHutOptions {
    [JsonPropertyName("theta")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Theta { get; set; }

    [JsonPropertyName("gravitationalConstant")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? GravitationalConstant { get; set; }

    [JsonPropertyName("centralGravity")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? CentralGravity { get; set; }

    [JsonPropertyName("springLength")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? SpringLength { get; set; }

    [JsonPropertyName("springConstant")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? SpringConstant { get; set; }

    [JsonPropertyName("damping")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Damping { get; set; }

    [JsonPropertyName("avoidOverlap")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? AvoidOverlap { get; set; }

    public VisNetworkBarnesHutOptions WithTheta(double theta) {
        Theta = theta;
        return this;
    }

    public VisNetworkBarnesHutOptions WithGravitationalConstant(double constant) {
        GravitationalConstant = constant;
        return this;
    }

    public VisNetworkBarnesHutOptions WithCentralGravity(double gravity) {
        CentralGravity = gravity;
        return this;
    }

    public VisNetworkBarnesHutOptions WithSpringLength(double length) {
        SpringLength = length;
        return this;
    }

    public VisNetworkBarnesHutOptions WithSpringConstant(double constant) {
        SpringConstant = constant;
        return this;
    }

    public VisNetworkBarnesHutOptions WithDamping(double damping) {
        Damping = damping;
        return this;
    }

    public VisNetworkBarnesHutOptions WithAvoidOverlap(double overlap) {
        AvoidOverlap = overlap;
        return this;
    }
}

/// <summary>
/// Force Atlas 2 physics solver options.
/// </summary>
public class VisNetworkForceAtlas2Options {
    [JsonPropertyName("theta")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Theta { get; set; }

    [JsonPropertyName("gravitationalConstant")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? GravitationalConstant { get; set; }

    [JsonPropertyName("centralGravity")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? CentralGravity { get; set; }

    [JsonPropertyName("springLength")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? SpringLength { get; set; }

    [JsonPropertyName("springConstant")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? SpringConstant { get; set; }

    [JsonPropertyName("damping")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Damping { get; set; }

    [JsonPropertyName("avoidOverlap")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? AvoidOverlap { get; set; }

    public VisNetworkForceAtlas2Options WithTheta(double theta) {
        Theta = theta;
        return this;
    }

    public VisNetworkForceAtlas2Options WithGravitationalConstant(double constant) {
        GravitationalConstant = constant;
        return this;
    }

    public VisNetworkForceAtlas2Options WithCentralGravity(double gravity) {
        CentralGravity = gravity;
        return this;
    }

    public VisNetworkForceAtlas2Options WithSpringLength(double length) {
        SpringLength = length;
        return this;
    }

    public VisNetworkForceAtlas2Options WithSpringConstant(double constant) {
        SpringConstant = constant;
        return this;
    }

    public VisNetworkForceAtlas2Options WithDamping(double damping) {
        Damping = damping;
        return this;
    }

    public VisNetworkForceAtlas2Options WithAvoidOverlap(double overlap) {
        AvoidOverlap = overlap;
        return this;
    }
}

/// <summary>
/// Repulsion physics solver options.
/// </summary>
public class VisNetworkRepulsionOptions {
    [JsonPropertyName("nodeDistance")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? NodeDistance { get; set; }

    [JsonPropertyName("centralGravity")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? CentralGravity { get; set; }

    [JsonPropertyName("springLength")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? SpringLength { get; set; }

    [JsonPropertyName("springConstant")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? SpringConstant { get; set; }

    [JsonPropertyName("damping")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Damping { get; set; }

    public VisNetworkRepulsionOptions WithNodeDistance(double distance) {
        NodeDistance = distance;
        return this;
    }

    public VisNetworkRepulsionOptions WithCentralGravity(double gravity) {
        CentralGravity = gravity;
        return this;
    }

    public VisNetworkRepulsionOptions WithSpringLength(double length) {
        SpringLength = length;
        return this;
    }

    public VisNetworkRepulsionOptions WithSpringConstant(double constant) {
        SpringConstant = constant;
        return this;
    }

    public VisNetworkRepulsionOptions WithDamping(double damping) {
        Damping = damping;
        return this;
    }
}

/// <summary>
/// Hierarchical repulsion physics solver options.
/// </summary>
public class VisNetworkHierarchicalRepulsionOptions {
    [JsonPropertyName("nodeDistance")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? NodeDistance { get; set; }

    [JsonPropertyName("centralGravity")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? CentralGravity { get; set; }

    [JsonPropertyName("springLength")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? SpringLength { get; set; }

    [JsonPropertyName("springConstant")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? SpringConstant { get; set; }

    [JsonPropertyName("damping")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Damping { get; set; }

    [JsonPropertyName("avoidOverlap")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? AvoidOverlap { get; set; }

    public VisNetworkHierarchicalRepulsionOptions WithNodeDistance(double distance) {
        NodeDistance = distance;
        return this;
    }

    public VisNetworkHierarchicalRepulsionOptions WithCentralGravity(double gravity) {
        CentralGravity = gravity;
        return this;
    }

    public VisNetworkHierarchicalRepulsionOptions WithSpringLength(double length) {
        SpringLength = length;
        return this;
    }

    public VisNetworkHierarchicalRepulsionOptions WithSpringConstant(double constant) {
        SpringConstant = constant;
        return this;
    }

    public VisNetworkHierarchicalRepulsionOptions WithDamping(double damping) {
        Damping = damping;
        return this;
    }

    public VisNetworkHierarchicalRepulsionOptions WithAvoidOverlap(double overlap) {
        AvoidOverlap = overlap;
        return this;
    }
}

/// <summary>
/// Stabilization configuration options.
/// </summary>
public class VisNetworkStabilizationOptions {
    [JsonPropertyName("enabled")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Enabled { get; set; }

    [JsonPropertyName("iterations")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Iterations { get; set; }

    [JsonPropertyName("updateInterval")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? UpdateInterval { get; set; }

    [JsonPropertyName("onlyDynamicEdges")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? OnlyDynamicEdges { get; set; }

    [JsonPropertyName("fit")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Fit { get; set; }

    public VisNetworkStabilizationOptions WithEnabled(bool enabled = true) {
        Enabled = enabled;
        return this;
    }

    public VisNetworkStabilizationOptions WithIterations(int iterations) {
        Iterations = iterations;
        return this;
    }

    public VisNetworkStabilizationOptions WithUpdateInterval(int interval) {
        UpdateInterval = interval;
        return this;
    }

    public VisNetworkStabilizationOptions WithOnlyDynamicEdges(bool onlyDynamic = true) {
        OnlyDynamicEdges = onlyDynamic;
        return this;
    }

    public VisNetworkStabilizationOptions WithFit(bool fit = true) {
        Fit = fit;
        return this;
    }
}

/// <summary>
/// Wind force configuration.
/// </summary>
public class VisNetworkWindOptions {
    [JsonPropertyName("x")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? X { get; set; }

    [JsonPropertyName("y")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Y { get; set; }
}