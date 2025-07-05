using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestTablerComponentsBasic {

    [TestMethod]
    public void TablerRow_BasicCreation() {
        var row = new TablerRow();
        var html = row.ToString();
        
        Assert.IsTrue(html.Contains("class=\"row\""));
    }

    [TestMethod]
    public void TablerColumn_BasicCreation() {
        var column = new TablerColumn();
        var html = column.ToString();
        
        Assert.IsTrue(html.Contains("class=\"col\""));
    }

    [TestMethod]
    public void TablerIcon_BasicCreation() {
        var icon = new TablerIcon("<svg>test</svg>");
        var html = icon.ToString();
        
        Assert.IsTrue(html.Contains("<svg>test</svg>"));
    }

    [TestMethod]
    public void TablerText_BasicCreation() {
        var text = new TablerText("Sample text");
        var html = text.ToString();
        
        Assert.IsTrue(html.Contains("Sample text"));
    }

    [TestMethod]
    public void TablerCard_BasicCreation() {
        var card = new TablerCard();
        var html = card.ToString();
        
        Assert.IsTrue(html.Contains("class=\"card col\""));
    }

    [TestMethod]
    public void UnorderedList_BasicCreation() {
        var list = new UnorderedList();
        var html = list.ToString();
        
        Assert.IsTrue(html.Contains("<ul"));
    }

    [TestMethod]
    public void TablerProgressBar_BasicCreation() {
        var progressBar = new TablerProgressBar();
        var html = progressBar.ToString();
        
        Assert.IsTrue(html.Contains("class=\"progress\""));
    }

    [TestMethod]
    public void TablerTable_BasicCreation() {
        var data = new List<object> { "Item 1", "Item 2" };
        var table = new TablerTable(data, TableType.Tabler);
        var html = table.ToString();
        
        Assert.IsTrue(html.Contains("class=\"table\""));
    }

    [TestMethod]
    public void TablerAvatar_BasicCreation() {
        var avatar = new TablerAvatar();
        var html = avatar.ToString();
        
        Assert.IsTrue(html.Contains("class=\"avatar\""));
    }

    [TestMethod]
    public void TablerBadgeSpan_BasicCreation() {
        var badge = new TablerBadgeSpan("Test", TablerColor.Primary);
        var html = badge.ToString();
        
        Assert.IsTrue(html.Contains("Test"));
        Assert.IsTrue(html.Contains("class=\"badge bg-primary\""));
    }
}