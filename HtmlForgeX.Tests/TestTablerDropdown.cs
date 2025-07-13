using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestTablerDropdown {
    [TestMethod]
    public void Dropdown_GeneratesBasicHtml() {
        var dropdown = new TablerDropdown("Menu")
            .Dark()
            .WithArrow();
        dropdown.Item("Edit").Icon(TablerIconType.Edit);
        dropdown.Separator();
        dropdown.Item("Delete").Danger();

        var html = dropdown.ToString();
        Assert.IsTrue(html.Contains("dropdown-menu"));
        Assert.IsTrue(html.Contains("dropdown-menu-dark"));
        Assert.IsTrue(html.Contains("dropdown-menu-arrow"));
        Assert.IsTrue(html.Contains("dropdown-item"));
        Assert.IsTrue(html.Contains("role=\"button\""));
    }

    [TestMethod]
    public void Dropdown_CheckboxAndRadioItems() {
        var dropdown = new TablerDropdown("Menu");
        dropdown.CheckboxItem("Option 1", true);
        dropdown.RadioItem("Option A", "grp", true);

        var html = dropdown.ToString();
        Assert.IsTrue(html.Contains("type=\"checkbox\""));
        Assert.IsTrue(html.Contains("type=\"radio\""));
        Assert.IsTrue(html.Contains("name=\"grp\""));
    }
}
