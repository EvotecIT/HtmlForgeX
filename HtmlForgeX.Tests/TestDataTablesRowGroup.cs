using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestDataTablesRowGroup
{
    [TestMethod]
    public void RowGrouping_ShouldRegisterLibraryAndSerialize()
    {
        var document = new Document(LibraryMode.Online);
        var table = new DataTablesTable();
        table.RowGrouping(g =>
        {
            g.Enable = true;
            g.DataSrc = "Department";
        });
        document.Body.Add(table);

        var html = document.ToString();

        Assert.IsTrue(document.Configuration.Libraries.ContainsKey(Libraries.DataTablesRowGroup));
        StringAssert.Contains(html, "rowGroup");
        StringAssert.Contains(html, "Department");
    }
}
