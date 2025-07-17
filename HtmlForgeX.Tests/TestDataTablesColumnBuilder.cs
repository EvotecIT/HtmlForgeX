using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestDataTablesColumnBuilder
{
    [TestMethod]
    public void ColumnBuilder_AssignsSequentialIndexes()
    {
        var table = new DataTablesTable();
        table.ConfigureColumns(cols =>
        {
            cols.Column(c => c.Title("First").Build());
            cols.Column(c => c.Title("Second").Build());
            cols.Column(c => c.Title("Third").Build());
        });

        var html = table.ToString();

        var first = html.IndexOf("\"targets\": 0");
        var second = html.IndexOf("\"targets\": 1");
        var third = html.IndexOf("\"targets\": 2");

        Assert.IsTrue(first >= 0, "First column index not found");
        Assert.IsTrue(second > first, "Second column index should follow first");
        Assert.IsTrue(third > second, "Third column index should follow second");
    }
}
