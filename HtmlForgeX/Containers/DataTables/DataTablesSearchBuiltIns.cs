using System.Collections.Generic;

namespace HtmlForgeX;

/// <summary>
/// Provides JavaScript implementations for built-in SearchBuilder operators.
/// </summary>
public static class DataTablesSearchBuiltIns
{
    /// <summary>Mapping of built-in operator to name and script.</summary>
    public static readonly Dictionary<DataTablesBuiltInOperator, (string Name, string Script)> Scripts = new()
    {
        [DataTablesBuiltInOperator.StartsWith] = ("startsWith", "function(value,input){ return value.startsWith(input); }"),
        [DataTablesBuiltInOperator.EndsWith] = ("endsWith", "function(value,input){ return value.endsWith(input); }"),
        [DataTablesBuiltInOperator.ContainsCaseInsensitive] = ("containsCI", "function(value,input){ return value.toLowerCase().includes(input.toLowerCase()); }"),
        [DataTablesBuiltInOperator.Regex] = ("regex", "function(value,input){ var r=new RegExp(input); return r.test(value); }"),
        [DataTablesBuiltInOperator.NotContains] = ("notContains", "function(value,input){ return !value.includes(input); }"),
        [DataTablesBuiltInOperator.EqualsCaseInsensitive] = ("equalsCI", "function(value,input){ return value.toLowerCase() === input.toLowerCase(); }"),
        [DataTablesBuiltInOperator.GreaterThan] = ("gt", "function(value,input){ return parseFloat(value) > parseFloat(input); }"),
        [DataTablesBuiltInOperator.LessThan] = ("lt", "function(value,input){ return parseFloat(value) < parseFloat(input); }"),
        [DataTablesBuiltInOperator.IsNull] = ("isNull", "function(value){ return value === null; }"),
        [DataTablesBuiltInOperator.IsNotNull] = ("isNotNull", "function(value){ return value !== null; }")
    };
}
