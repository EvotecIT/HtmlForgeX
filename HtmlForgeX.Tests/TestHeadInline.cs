using HtmlForgeX;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestHeadInline {
    [TestMethod]
    public void AddCssInline_TrimsBeforeDeduplication() {
        var doc = new Document();
        doc.Head.AddCssInline("body { color: red; }");
        doc.Head.AddCssInline(" body { color: red; } ");
        Assert.AreEqual(1, doc.Head.Styles.Count);
    }

    [TestMethod]
    public void AddJsInline_TrimsBeforeDeduplication() {
        var doc = new Document();
        doc.Head.AddJsInline("console.log('hi');");
        doc.Head.AddJsInline(" console.log('hi'); ");
        Assert.AreEqual(1, doc.Head.Scripts.Count);
    }
}