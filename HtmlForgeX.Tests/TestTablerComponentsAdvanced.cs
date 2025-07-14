using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestTablerComponentsAdvanced {

    [TestMethod]
    public void TablerAccordion_WithItems() {
        var accordion = new TablerAccordion();
        accordion.Add(new TablerAccordionItem("accordion1"));
        accordion.Add(new TablerAccordionItem("accordion2"));
        var html = accordion.ToString();

        Assert.IsTrue(html.Contains("class=\"accordion\""));
        Assert.IsTrue(html.Contains("id=\""));
    }

    [TestMethod]
    public void TablerTabs_WithPanels() {
        var tabs = new TablerTabs();
        var panel1 = new TablerTabsPanel();
        var panel2 = new TablerTabsPanel();
        tabs.Add(panel1);
        tabs.Add(panel2);
        var html = tabs.ToString();

        Assert.IsNotNull(html);
        Assert.IsTrue(html.Length > 0);
    }

    [TestMethod]
    public void TablerSteps_BasicCreation() {
        var steps = new TablerSteps();
        var html = steps.ToString();

        // Check that it contains the required classes (order might vary due to inline styles)
        Assert.IsTrue(html.Contains("steps") && html.Contains("steps-horizontal"));
        Assert.IsTrue(html.StartsWith("<ul"));
    }

    [TestMethod]
    public void TablerDataGrid_BasicCreation() {
        var dataGrid = new TablerDataGrid();
        var html = dataGrid.ToString();

        Assert.IsTrue(html.Contains("class=\"datagrid\""));
    }

    [TestMethod]
    public void TablerLayout_BasicCreation() {
        var layout = new TablerLayout();
        var html = layout.ToString();

        Assert.IsNotNull(html);
        Assert.IsTrue(html.Length > 0);
    }

    [TestMethod]
    public void TablerPage_BasicCreation() {
        var page = new TablerPage();
        var html = page.ToString();

        Assert.IsTrue(html.Contains("class=\"page-wrapper\""));
    }

    [TestMethod]
    public void TablerCardBasic_BasicCreation() {
        var card = new TablerCardBasic();
        var html = card.ToString();

        // Card should contain the card class
        Assert.IsTrue(html.Contains("card"));
        Assert.IsTrue(html.Contains("<div"));
    }

    [TestMethod]
    public void TablerCardMini_BasicCreation() {
        var card = new TablerCardMini();
        var html = card.ToString();

        Assert.IsTrue(html.Contains("class=\"card\""));
    }

    [TestMethod]
    public void TablerDivider_BasicCreation() {
        var divider = new TablerDivider("Test Divider");
        var html = divider.ToString();

        Assert.IsTrue(html.Contains("Test Divider"));
    }

    [TestMethod]
    public void TablerTag_BasicCreation() {
        var tag = new TablerTag("Test Tag");
        var html = tag.ToString();

        Assert.IsTrue(html.Contains("Test Tag"));
        Assert.IsTrue(html.Contains("class=\"tag\""));
    }
}