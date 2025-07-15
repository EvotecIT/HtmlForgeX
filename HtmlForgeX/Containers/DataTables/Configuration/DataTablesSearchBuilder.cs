using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace HtmlForgeX;

/// <summary>
/// Search Builder configuration for DataTables
/// </summary>
public class DataTablesSearchBuilder
{
    /// <summary>Enable/disable search builder</summary>
    [JsonPropertyName("enable")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Enable { get; set; }

    /// <summary>Default number of condition groups</summary>
    [JsonPropertyName("conditions")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Conditions { get; set; }

    /// <summary>Enable/disable group logic (AND/OR)</summary>
    [JsonPropertyName("logic")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Logic { get; set; }

    /// <summary>Greyscale styling</summary>
    [JsonPropertyName("greyscale")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Greyscale { get; set; }

    /// <summary>Pre-defined search criteria</summary>
    [JsonPropertyName("preDefined")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? PreDefined { get; set; }

    /// <summary>Complex condition groups used for pre-defined filtering.</summary>
    [JsonPropertyName("conditionGroups")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<DataTablesSearchGroup>? ConditionGroups { get; set; }

    /// <summary>Custom operators for filtering logic.</summary>
    [JsonPropertyName("customOperators")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, string>? CustomOperators { get; set; }
}

/// <summary>
/// Represents a group of conditions in SearchBuilder.
/// </summary>
public class DataTablesSearchGroup
{
    /// <summary>Group logic (AND/OR).</summary>
    [JsonPropertyName("logic")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Logic { get; set; }

    /// <summary>List of criteria in the group.</summary>
    [JsonPropertyName("criteria")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<DataTablesSearchCriterion>? Criteria { get; set; }
}

/// <summary>
/// Represents single filtering criterion.
/// </summary>
public class DataTablesSearchCriterion
{
    /// <summary>Column data source.</summary>
    [JsonPropertyName("data")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Data { get; set; }

    /// <summary>Condition operator.</summary>
    [JsonPropertyName("condition")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Condition { get; set; }

    /// <summary>Value used for filtering.</summary>
    [JsonPropertyName("value")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object[]? Value { get; set; }
}