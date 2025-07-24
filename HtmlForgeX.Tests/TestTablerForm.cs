using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestTablerForm {
    [TestMethod]
    public void Input_GeneratesCorrectHtml() {
        var form = new TablerForm();
        form.Input("email", i => i.Type(InputType.Email).Label("Email"));
        var html = form.ToString();
        Assert.IsTrue(html.Contains("form"));
        Assert.IsTrue(html.Contains("type=\"email\""));
    }

    [TestMethod]
    public void Select_SearchableAddsScript() {
        var form = new TablerForm();
        form.Select("country", s => s.Searchable().Option("US", "US"));
        var html = form.ToString();
        Assert.IsTrue(html.Contains("TomSelect"));
    }

    [TestMethod]
    public void InputMask_IncludesDataMask() {
        var form = new TablerForm();
        form.InputMask("phone", m => m.Pattern("(00) 0000-0000"));
        var html = form.ToString();
        Assert.IsTrue(html.Contains("data-mask=\"(00) 0000-0000\""));
    }
}