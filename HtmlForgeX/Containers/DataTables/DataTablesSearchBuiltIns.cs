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
        [DataTablesBuiltInOperator.NotStartsWith] = ("notStartsWith", "function(value,input){ return !value.startsWith(input); }"),
        [DataTablesBuiltInOperator.EndsWith] = ("endsWith", "function(value,input){ return value.endsWith(input); }"),
        [DataTablesBuiltInOperator.NotEndsWith] = ("notEndsWith", "function(value,input){ return !value.endsWith(input); }"),
        [DataTablesBuiltInOperator.Contains] = ("contains", "function(value,input){ return value.includes(input); }"),
        [DataTablesBuiltInOperator.NotContains] = ("notContains", "function(value,input){ return !value.includes(input); }"),
        [DataTablesBuiltInOperator.ContainsCaseInsensitive] = ("containsCI", "function(value,input){ return value.toLowerCase().includes(input.toLowerCase()); }"),
        [DataTablesBuiltInOperator.Regex] = ("regex", "function(value,input){ var r=new RegExp(input); return r.test(value); }"),
        [DataTablesBuiltInOperator.NotRegex] = ("notRegex", "function(value,input){ var r=new RegExp(input); return !r.test(value); }"),
        [DataTablesBuiltInOperator.Equals] = ("equals", "function(value,input){ return value === input; }"),
        [DataTablesBuiltInOperator.NotEquals] = ("notEquals", "function(value,input){ return value !== input; }"),
        [DataTablesBuiltInOperator.EqualsCaseInsensitive] = ("equalsCI", "function(value,input){ return value.toLowerCase() === input.toLowerCase(); }"),
        [DataTablesBuiltInOperator.GreaterThan] = ("gt", "function(value,input){ return parseFloat(value) > parseFloat(input); }"),
        [DataTablesBuiltInOperator.GreaterThanOrEqual] = ("gte", "function(value,input){ return parseFloat(value) >= parseFloat(input); }"),
        [DataTablesBuiltInOperator.LessThan] = ("lt", "function(value,input){ return parseFloat(value) < parseFloat(input); }"),
        [DataTablesBuiltInOperator.LessThanOrEqual] = ("lte", "function(value,input){ return parseFloat(value) <= parseFloat(input); }"),
        [DataTablesBuiltInOperator.Between] = ("between", "function(value,start,end){ var v=parseFloat(value); var s=parseFloat(start); var e=parseFloat(end); return s<e ? (v>=s && v<=e) : (v>=e && v<=s); }"),
        [DataTablesBuiltInOperator.NotBetween] = ("notBetween", "function(value,start,end){ var v=parseFloat(value); var s=parseFloat(start); var e=parseFloat(end); return s<e ? (v<s || v>e) : (v<e || v>s); }"),
        [DataTablesBuiltInOperator.In] = ("in", "function(value,list){ return list.includes(value); }"),
        [DataTablesBuiltInOperator.NotIn] = ("notIn", "function(value,list){ return !list.includes(value); }"),
        [DataTablesBuiltInOperator.IsNull] = ("isNull", "function(value){ return value === null; }"),
        [DataTablesBuiltInOperator.IsNotNull] = ("isNotNull", "function(value){ return value !== null; }"),
        [DataTablesBuiltInOperator.IsEmpty] = ("isEmpty", "function(value){ return value === null || value === undefined || value.length === 0; }"),
        [DataTablesBuiltInOperator.IsNotEmpty] = ("isNotEmpty", "function(value){ return !(value === null || value === undefined || value.length === 0); }"),
        [DataTablesBuiltInOperator.IsTrue] = ("isTrue", "function(value){ return value === true; }"),
        [DataTablesBuiltInOperator.IsFalse] = ("isFalse", "function(value){ return value === false; }"),
        [DataTablesBuiltInOperator.Before] = ("before", "function(value,date){ return new Date(value) < new Date(date); }"),
        [DataTablesBuiltInOperator.After] = ("after", "function(value,date){ return new Date(value) > new Date(date); }"),
        [DataTablesBuiltInOperator.BetweenDates] = ("betweenDates", "function(value,start,end){ var v=new Date(value); var s=new Date(start); var e=new Date(end); return s<e ? (v>=s && v<=e) : (v>=e && v<=s); }"),
        [DataTablesBuiltInOperator.NotBetweenDates] = ("notBetweenDates", "function(value,start,end){ var v=new Date(value); var s=new Date(start); var e=new Date(end); return s<e ? (v<s || v>e) : (v<e || v>s); }")
    };
}
