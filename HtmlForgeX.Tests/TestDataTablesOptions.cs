using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HtmlForgeX.Tests;

/// <summary>
/// Checks that DataTables configuration options serialize to JavaScript correctly.
/// </summary>
[TestClass]
public class TestDataTablesOptions
{
    [TestMethod]
    public void ConfigureOptions_ShouldSerializeValues()
    {
        var table = new DataTablesTable();
        table.Configure(o =>
        {
            o.PageLength = 25;
            o.StateSave = true;
        });

        var html = table.ToString();
        StringAssert.Contains(html, "\"pageLength\": 25");
        StringAssert.Contains(html, "\"stateSave\": true");
    }

    [TestMethod]
    public void Options_ShouldSerializePropertyNames()
    {
        var options = new DataTablesOptions
        {
            AutoWidth = true,
            ScrollCollapse = true,
            FixedHeader = new DataTablesFixedHeader { Enable = true }
        };

        var json = JsonSerializer.Serialize(options, new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        StringAssert.Contains(json, "\"autoWidth\":true");
        StringAssert.Contains(json, "\"scrollCollapse\":true");
        StringAssert.Contains(json, "\"fixedHeader\":{\"enable\":true}");
    }
}
