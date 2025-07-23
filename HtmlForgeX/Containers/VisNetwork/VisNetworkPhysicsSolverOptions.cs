using System.Text.Json.Serialization;

namespace HtmlForgeX;

public partial class VisNetworkPhysicsOptions {
    /// <summary>
    /// Gets or sets the options for the Barnes Hut physics solver.
    /// </summary>
    [JsonPropertyName("barnesHut")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkBarnesHutOptions? BarnesHut { get; set; }

    /// <summary>
    /// Gets or sets the options for the Force Atlas 2 based physics solver.
    /// </summary>
    [JsonPropertyName("forceAtlas2Based")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkForceAtlas2Options? ForceAtlas2Based { get; set; }

    /// <summary>
    /// Gets or sets the options for the repulsion physics solver.
    /// </summary>
    [JsonPropertyName("repulsion")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkRepulsionOptions? Repulsion { get; set; }

    /// <summary>
    /// Gets or sets the options for the hierarchical repulsion solver.
    /// </summary>
    [JsonPropertyName("hierarchicalRepulsion")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkHierarchicalRepulsionOptions? HierarchicalRepulsion { get; set; }
    /// <summary>
    /// Gets or sets the physics solver to use.
    /// </summary>
    [JsonPropertyName("solver")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkPhysicsSolver? Solver { get; set; }

    /// <summary>
    /// Sets the physics solver to use.
    /// </summary>
    /// <param name="solver">The solver to apply.</param>
    /// <returns>The current <see cref="VisNetworkPhysicsOptions"/> instance.</returns>
    public VisNetworkPhysicsOptions WithSolver(VisNetworkPhysicsSolver solver) {
        Solver = solver;
        return this;
    }

    /// <summary>
    /// Configures and enables the Barnes Hut solver.
    /// </summary>
    /// <param name="configure">Callback to configure the solver options.</param>
    /// <returns>The current <see cref="VisNetworkPhysicsOptions"/> instance.</returns>
    public VisNetworkPhysicsOptions WithBarnesHut(Action<VisNetworkBarnesHutOptions> configure) {
        BarnesHut ??= new VisNetworkBarnesHutOptions();
        configure(BarnesHut);
        Solver = VisNetworkPhysicsSolver.BarnesHut;
        return this;
    }

    /// <summary>
    /// Configures and enables the Force Atlas 2 based solver.
    /// </summary>
    /// <param name="configure">Callback to configure the solver options.</param>
    /// <returns>The current <see cref="VisNetworkPhysicsOptions"/> instance.</returns>
    public VisNetworkPhysicsOptions WithForceAtlas2Based(Action<VisNetworkForceAtlas2Options> configure) {
        ForceAtlas2Based ??= new VisNetworkForceAtlas2Options();
        configure(ForceAtlas2Based);
        Solver = VisNetworkPhysicsSolver.ForceAtlas2based;
        return this;
    }

    /// <summary>
    /// Configures and enables the repulsion solver.
    /// </summary>
    /// <param name="configure">Callback to configure the solver options.</param>
    /// <returns>The current <see cref="VisNetworkPhysicsOptions"/> instance.</returns>
    public VisNetworkPhysicsOptions WithRepulsion(Action<VisNetworkRepulsionOptions> configure) {
        Repulsion ??= new VisNetworkRepulsionOptions();
        configure(Repulsion);
        Solver = VisNetworkPhysicsSolver.Repulsion;
        return this;
    }

    /// <summary>
    /// Configures and enables the hierarchical repulsion solver.
    /// </summary>
    /// <param name="configure">Callback to configure the solver options.</param>
    /// <returns>The current <see cref="VisNetworkPhysicsOptions"/> instance.</returns>
    public VisNetworkPhysicsOptions WithHierarchicalRepulsion(Action<VisNetworkHierarchicalRepulsionOptions> configure) {
        HierarchicalRepulsion ??= new VisNetworkHierarchicalRepulsionOptions();
        configure(HierarchicalRepulsion);
        Solver = VisNetworkPhysicsSolver.HierarchicalRepulsion;
        return this;
    }


/// <summary>
/// Barnes Hut physics solver options.
/// </summary>
public class VisNetworkBarnesHutOptions {
    /// <summary>Gets or sets the theta parameter.</summary>
    [JsonPropertyName("theta")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Theta { get; set; }

    /// <summary>Gets or sets the gravitational constant.</summary>
    [JsonPropertyName("gravitationalConstant")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? GravitationalConstant { get; set; }

    /// <summary>Gets or sets the central gravity.</summary>
    [JsonPropertyName("centralGravity")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? CentralGravity { get; set; }

    /// <summary>Gets or sets the spring length.</summary>
    [JsonPropertyName("springLength")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? SpringLength { get; set; }

    /// <summary>Gets or sets the spring constant.</summary>
    [JsonPropertyName("springConstant")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? SpringConstant { get; set; }

    /// <summary>Gets or sets the damping factor.</summary>
    [JsonPropertyName("damping")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Damping { get; set; }

    /// <summary>Gets or sets the overlap avoidance.</summary>
    [JsonPropertyName("avoidOverlap")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? AvoidOverlap { get; set; }

    /// <summary>
    /// Sets the theta parameter.
    /// </summary>
    /// <param name="theta">The theta value.</param>
    /// <returns>The current <see cref="VisNetworkBarnesHutOptions"/> instance.</returns>
    public VisNetworkBarnesHutOptions WithTheta(double theta) {
        Theta = theta;
        return this;
    }

    /// <summary>
    /// Sets the gravitational constant.
    /// </summary>
    /// <param name="constant">The constant value.</param>
    /// <returns>The current <see cref="VisNetworkBarnesHutOptions"/> instance.</returns>
    public VisNetworkBarnesHutOptions WithGravitationalConstant(double constant) {
        GravitationalConstant = constant;
        return this;
    }

    /// <summary>
    /// Sets the central gravity value.
    /// </summary>
    /// <param name="gravity">The central gravity.</param>
    /// <returns>The current <see cref="VisNetworkBarnesHutOptions"/> instance.</returns>
    public VisNetworkBarnesHutOptions WithCentralGravity(double gravity) {
        CentralGravity = gravity;
        return this;
    }

    /// <summary>
    /// Sets the spring length.
    /// </summary>
    /// <param name="length">The spring length.</param>
    /// <returns>The current <see cref="VisNetworkBarnesHutOptions"/> instance.</returns>
    public VisNetworkBarnesHutOptions WithSpringLength(double length) {
        SpringLength = length;
        return this;
    }

    /// <summary>
    /// Sets the spring constant.
    /// </summary>
    /// <param name="constant">The spring constant.</param>
    /// <returns>The current <see cref="VisNetworkBarnesHutOptions"/> instance.</returns>
    public VisNetworkBarnesHutOptions WithSpringConstant(double constant) {
        SpringConstant = constant;
        return this;
    }

    /// <summary>
    /// Sets the damping factor.
    /// </summary>
    /// <param name="damping">The damping value.</param>
    /// <returns>The current <see cref="VisNetworkBarnesHutOptions"/> instance.</returns>
    public VisNetworkBarnesHutOptions WithDamping(double damping) {
        Damping = damping;
        return this;
    }

    /// <summary>
    /// Sets the overlap avoidance value.
    /// </summary>
    /// <param name="overlap">The overlap value.</param>
    /// <returns>The current <see cref="VisNetworkBarnesHutOptions"/> instance.</returns>
    public VisNetworkBarnesHutOptions WithAvoidOverlap(double overlap) {
        AvoidOverlap = overlap;
        return this;
    }
}

/// <summary>
/// Force Atlas 2 physics solver options.
/// </summary>
public class VisNetworkForceAtlas2Options {
    /// <summary>Gets or sets the theta parameter.</summary>
    [JsonPropertyName("theta")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Theta { get; set; }

    /// <summary>Gets or sets the gravitational constant.</summary>
    [JsonPropertyName("gravitationalConstant")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? GravitationalConstant { get; set; }

    /// <summary>Gets or sets the central gravity.</summary>
    [JsonPropertyName("centralGravity")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? CentralGravity { get; set; }

    /// <summary>Gets or sets the spring length.</summary>
    [JsonPropertyName("springLength")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? SpringLength { get; set; }

    /// <summary>Gets or sets the spring constant.</summary>
    [JsonPropertyName("springConstant")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? SpringConstant { get; set; }

    /// <summary>Gets or sets the damping factor.</summary>
    [JsonPropertyName("damping")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Damping { get; set; }

    /// <summary>Gets or sets the overlap avoidance.</summary>
    [JsonPropertyName("avoidOverlap")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? AvoidOverlap { get; set; }

    /// <summary>
    /// Sets the theta parameter.
    /// </summary>
    /// <param name="theta">The theta value.</param>
    /// <returns>The current <see cref="VisNetworkForceAtlas2Options"/> instance.</returns>
    public VisNetworkForceAtlas2Options WithTheta(double theta) {
        Theta = theta;
        return this;
    }

    /// <summary>
    /// Sets the gravitational constant.
    /// </summary>
    /// <param name="constant">The constant value.</param>
    /// <returns>The current <see cref="VisNetworkForceAtlas2Options"/> instance.</returns>
    public VisNetworkForceAtlas2Options WithGravitationalConstant(double constant) {
        GravitationalConstant = constant;
        return this;
    }

    /// <summary>
    /// Sets the central gravity value.
    /// </summary>
    /// <param name="gravity">The central gravity.</param>
    /// <returns>The current <see cref="VisNetworkForceAtlas2Options"/> instance.</returns>
    public VisNetworkForceAtlas2Options WithCentralGravity(double gravity) {
        CentralGravity = gravity;
        return this;
    }

    /// <summary>
    /// Sets the spring length.
    /// </summary>
    /// <param name="length">The spring length.</param>
    /// <returns>The current <see cref="VisNetworkForceAtlas2Options"/> instance.</returns>
    public VisNetworkForceAtlas2Options WithSpringLength(double length) {
        SpringLength = length;
        return this;
    }

    /// <summary>
    /// Sets the spring constant.
    /// </summary>
    /// <param name="constant">The spring constant.</param>
    /// <returns>The current <see cref="VisNetworkForceAtlas2Options"/> instance.</returns>
    public VisNetworkForceAtlas2Options WithSpringConstant(double constant) {
        SpringConstant = constant;
        return this;
    }

    /// <summary>
    /// Sets the damping factor.
    /// </summary>
    /// <param name="damping">The damping value.</param>
    /// <returns>The current <see cref="VisNetworkForceAtlas2Options"/> instance.</returns>
    public VisNetworkForceAtlas2Options WithDamping(double damping) {
        Damping = damping;
        return this;
    }

    /// <summary>
    /// Sets the overlap avoidance value.
    /// </summary>
    /// <param name="overlap">The overlap value.</param>
    /// <returns>The current <see cref="VisNetworkForceAtlas2Options"/> instance.</returns>
    public VisNetworkForceAtlas2Options WithAvoidOverlap(double overlap) {
        AvoidOverlap = overlap;
        return this;
    }
}

/// <summary>
/// Repulsion physics solver options.
/// </summary>
public class VisNetworkRepulsionOptions {
    /// <summary>Gets or sets the distance between nodes.</summary>
    [JsonPropertyName("nodeDistance")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? NodeDistance { get; set; }

    /// <summary>Gets or sets the central gravity.</summary>
    [JsonPropertyName("centralGravity")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? CentralGravity { get; set; }

    /// <summary>Gets or sets the spring length.</summary>
    [JsonPropertyName("springLength")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? SpringLength { get; set; }

    /// <summary>Gets or sets the spring constant.</summary>
    [JsonPropertyName("springConstant")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? SpringConstant { get; set; }

    /// <summary>Gets or sets the damping factor.</summary>
    [JsonPropertyName("damping")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Damping { get; set; }

    /// <summary>
    /// Sets the distance between nodes.
    /// </summary>
    /// <param name="distance">The distance value.</param>
    /// <returns>The current <see cref="VisNetworkRepulsionOptions"/> instance.</returns>
    public VisNetworkRepulsionOptions WithNodeDistance(double distance) {
        NodeDistance = distance;
        return this;
    }

    /// <summary>
    /// Sets the central gravity value.
    /// </summary>
    /// <param name="gravity">The central gravity.</param>
    /// <returns>The current <see cref="VisNetworkRepulsionOptions"/> instance.</returns>
    public VisNetworkRepulsionOptions WithCentralGravity(double gravity) {
        CentralGravity = gravity;
        return this;
    }

    /// <summary>
    /// Sets the spring length.
    /// </summary>
    /// <param name="length">The spring length.</param>
    /// <returns>The current <see cref="VisNetworkRepulsionOptions"/> instance.</returns>
    public VisNetworkRepulsionOptions WithSpringLength(double length) {
        SpringLength = length;
        return this;
    }

    /// <summary>
    /// Sets the spring constant.
    /// </summary>
    /// <param name="constant">The spring constant.</param>
    /// <returns>The current <see cref="VisNetworkRepulsionOptions"/> instance.</returns>
    public VisNetworkRepulsionOptions WithSpringConstant(double constant) {
        SpringConstant = constant;
        return this;
    }

    /// <summary>
    /// Sets the damping factor.
    /// </summary>
    /// <param name="damping">The damping value.</param>
    /// <returns>The current <see cref="VisNetworkRepulsionOptions"/> instance.</returns>
    public VisNetworkRepulsionOptions WithDamping(double damping) {
        Damping = damping;
        return this;
    }
}

/// <summary>
/// Hierarchical repulsion physics solver options.
/// </summary>
public class VisNetworkHierarchicalRepulsionOptions {
    /// <summary>Gets or sets the distance between nodes.</summary>
    [JsonPropertyName("nodeDistance")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? NodeDistance { get; set; }

    /// <summary>Gets or sets the central gravity.</summary>
    [JsonPropertyName("centralGravity")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? CentralGravity { get; set; }

    /// <summary>Gets or sets the spring length.</summary>
    [JsonPropertyName("springLength")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? SpringLength { get; set; }

    /// <summary>Gets or sets the spring constant.</summary>
    [JsonPropertyName("springConstant")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? SpringConstant { get; set; }

    /// <summary>Gets or sets the damping factor.</summary>
    [JsonPropertyName("damping")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Damping { get; set; }

    /// <summary>Gets or sets the overlap avoidance.</summary>
    [JsonPropertyName("avoidOverlap")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? AvoidOverlap { get; set; }

    /// <summary>
    /// Sets the distance between nodes.
    /// </summary>
    /// <param name="distance">The distance value.</param>
    /// <returns>The current <see cref="VisNetworkHierarchicalRepulsionOptions"/> instance.</returns>
    public VisNetworkHierarchicalRepulsionOptions WithNodeDistance(double distance) {
        NodeDistance = distance;
        return this;
    }

    /// <summary>
    /// Sets the central gravity value.
    /// </summary>
    /// <param name="gravity">The central gravity.</param>
    /// <returns>The current <see cref="VisNetworkHierarchicalRepulsionOptions"/> instance.</returns>
    public VisNetworkHierarchicalRepulsionOptions WithCentralGravity(double gravity) {
        CentralGravity = gravity;
        return this;
    }

    /// <summary>
    /// Sets the spring length.
    /// </summary>
    /// <param name="length">The spring length.</param>
    /// <returns>The current <see cref="VisNetworkHierarchicalRepulsionOptions"/> instance.</returns>
    public VisNetworkHierarchicalRepulsionOptions WithSpringLength(double length) {
        SpringLength = length;
        return this;
    }

    /// <summary>
    /// Sets the spring constant.
    /// </summary>
    /// <param name="constant">The spring constant.</param>
    /// <returns>The current <see cref="VisNetworkHierarchicalRepulsionOptions"/> instance.</returns>
    public VisNetworkHierarchicalRepulsionOptions WithSpringConstant(double constant) {
        SpringConstant = constant;
        return this;
    }

    /// <summary>
    /// Sets the damping factor.
    /// </summary>
    /// <param name="damping">The damping value.</param>
    /// <returns>The current <see cref="VisNetworkHierarchicalRepulsionOptions"/> instance.</returns>
    public VisNetworkHierarchicalRepulsionOptions WithDamping(double damping) {
        Damping = damping;
        return this;
    }

    /// <summary>
    /// Sets the overlap avoidance value.
    /// </summary>
    /// <param name="overlap">The overlap value.</param>
    /// <returns>The current <see cref="VisNetworkHierarchicalRepulsionOptions"/> instance.</returns>
    public VisNetworkHierarchicalRepulsionOptions WithAvoidOverlap(double overlap) {
        AvoidOverlap = overlap;
        return this;
    }
}
}
