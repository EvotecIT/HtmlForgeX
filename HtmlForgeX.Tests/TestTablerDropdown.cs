using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestTablerDropdown {
    [TestMethod]
    public void Dropdown_RendersItems() {
        var dropdown = new TablerDropdown()
            .AddItem("Edit", "/edit")
            .AddDivider()
            .AddItem("Delete", "/del", true);

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
            .WithHeaderDropdown(d => d.AddItem("Edit").AddItem("Delete"));

        var html = card.ToString();

        StringAssert.Contains(html, "dropdown-item");
        StringAssert.Contains(html, "Delete");
    }
}
