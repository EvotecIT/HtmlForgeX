using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestTablerFormControls {
    [TestMethod]
    public void TablerInput_EmailAttributes() {
        var input = new TablerInput("email")
            .Type(InputType.Email)
            .Placeholder("user@example.com")
            .Required();
        var html = input.ToString();
        StringAssert.Contains(html, "type=\"email\"");
        StringAssert.Contains(html, "id=\"email\"");
        StringAssert.Contains(html, "name=\"email\"");
        StringAssert.Contains(html, "placeholder=\"user@example.com\"");
        StringAssert.Contains(html, "required");
    }

    [TestMethod]
    public void TablerInput_PasswordAttributes() {
        var input = new TablerInput("password")
            .Type(InputType.Password)
            .Required();
        var html = input.ToString();
        StringAssert.Contains(html, "type=\"password\"");
        StringAssert.Contains(html, "id=\"password\"");
        StringAssert.Contains(html, "name=\"password\"");
        StringAssert.Contains(html, "required");
    }

    [TestMethod]
    public void TablerSelect_GeneratesOptions() {
        var select = new TablerSelect("country")
            .Option("United States", "US")
            .Option("Canada", "CA")
            .Multiple()
            .Required();
        var html = select.ToString();
        StringAssert.Contains(html, "id=\"country\"");
        StringAssert.Contains(html, "name=\"country\"");
        StringAssert.Contains(html, "multiple");
        StringAssert.Contains(html, "required");
        StringAssert.Contains(html, "<option value=\"US\">United States</option>");
        StringAssert.Contains(html, "<option value=\"CA\">Canada</option>");
    }

    [TestMethod]
    public void TablerInputMask_PatternAttributes() {
        var mask = new TablerInputMask("phone")
            .Pattern("+1 (999) 999-9999");
        var html = mask.ToString();
        StringAssert.Contains(html, "data-mask=\"+1 (999) 999-9999\"");
        StringAssert.Contains(html, "data-mask-visible=\"true\"");
    }
}