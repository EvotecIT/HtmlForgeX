using Microsoft.VisualStudio.TestTools.UnitTesting;
using HtmlForgeX.Containers.Tabler;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestTablerDropdown {
    [TestMethod]
    public void Dropdown_RendersItems() {
        var dropdown = new TablerDropdown("Actions")
            .Item("Edit", "/edit")
            .Divider()
            .Item("Delete", "/del");

        var html = dropdown.ToString();

        StringAssert.Contains(html, "dropdown-item");
        StringAssert.Contains(html, "/edit");
        StringAssert.Contains(html, "dropdown-divider");
        StringAssert.Contains(html, "text-danger");
    }

    [TestMethod]
    public void Card_WithHeaderDropdown_UsesFluentConfiguration() {
        var card = new TablerCardEnhanced()
            .WithHeader("Test")
            .WithHeaderDropdown(d => d.Item("Edit").Item("Delete"));

        var html = card.ToString();

        StringAssert.Contains(html, "dropdown-item");
        StringAssert.Contains(html, "Delete");
    }
}