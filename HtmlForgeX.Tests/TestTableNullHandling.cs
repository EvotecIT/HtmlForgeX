using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestTableNullHandling {
    [TestMethod]
    public void TableFromEnumerable_Null_ReturnsEmptyTable() {
        using var document = new Document();

        IEnumerable<object>? data = null;
        var table = document.Body.Table(data!, TableType.BootstrapTable);

        Assert.IsNotNull(table);
        Assert.AreEqual(0, table.TableRows.Count);
    }

    [TestMethod]
    public void TableFromObject_Null_ThrowsArgumentNullException() {
        using var document = new Document();

        Assert.ThrowsException<ArgumentNullException>(() => document.Body.Table((object)null!, TableType.BootstrapTable));
    }
}