using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestDataTablesBuilderNullChecks
{
    [TestMethod]
    public void ColumnBuilder_NullAction_Throws()
    {
        var builder = new DataTablesColumnBuilder();
        Assert.ThrowsException<ArgumentNullException>(() => builder.Column(0, null!));
    }

    [TestMethod]
    public void ColumnBuilder_StringOverload_NullAction_Throws()
    {
        var builder = new DataTablesColumnBuilder();
        Assert.ThrowsException<ArgumentNullException>(() => builder.Column("name", null!));
    }

    [TestMethod]
    public void ColumnBuilder_ConfigOverload_NullAction_Throws()
    {
        var builder = new DataTablesColumnBuilder();
        Assert.ThrowsException<ArgumentNullException>(() => builder.Column(null!));
    }

    [TestMethod]
    public void SearchBuilder_Group_NullAction_Throws()
    {
        var builder = new DataTablesSearchBuilderBuilder();
        Assert.ThrowsException<ArgumentNullException>(() => builder.Group(null!));
    }

    [TestMethod]
    public void ExportBuilder_Custom_NullAction_Throws()
    {
        var builder = new DataTablesExportBuilder();
        Assert.ThrowsException<ArgumentNullException>(() => builder.Custom(null!));
    }

    [TestMethod]
    public void ExportBuilder_ConfigureAll_NullAction_Throws()
    {
        var builder = new DataTablesExportBuilder();
        Assert.ThrowsException<ArgumentNullException>(() => builder.ConfigureAll(null!));
    }
}
