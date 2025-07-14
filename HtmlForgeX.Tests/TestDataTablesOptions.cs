using Microsoft.VisualStudio.TestTools.UnitTesting;

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
}
