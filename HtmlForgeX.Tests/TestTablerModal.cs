using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestTablerModal {
    [TestMethod]
    public void Modal_GeneratesBasicHtml() {
        var modal = new TablerModal()
            .Title("Test")
            .Content(c => c.Text("Body"))
            .Footer(f => f.Button("Close", TablerColor.Primary).Dismiss());
        var html = modal.ToString();
        Assert.IsTrue(html.Contains("modal-content"));
        Assert.IsTrue(html.Contains("modal-header"));
        Assert.IsTrue(html.Contains("modal-body"));
        Assert.IsTrue(html.Contains("modal-footer"));
    }

    [TestMethod]
    public void Modal_ScrollableAddsClass() {
        var modal = new TablerModal().Scrollable();
        var html = modal.ToString();
        Assert.IsTrue(html.Contains("modal-dialog-scrollable"));
    }

    [DataTestMethod]
    [DataRow(TablerModalSize.Small, "modal-sm")]
    [DataRow(TablerModalSize.Large, "modal-lg")]
    [DataRow(TablerModalSize.FullWidth, "modal-full-width")]
    [DataRow(TablerModalSize.Default, "")]
    public void Modal_SizeAddsCorrectClass(TablerModalSize size, string expected) {
        var modal = new TablerModal().Size(size);
        var html = modal.ToString();
        if (string.IsNullOrEmpty(expected)) {
            Assert.IsFalse(html.Contains("modal-sm") || html.Contains("modal-lg") || html.Contains("modal-full-width"));
        } else {
            Assert.IsTrue(html.Contains(expected));
        }
    }

    [TestMethod]
    public void Modal_FooterButtonAddsDismissAttribute() {
        var modal = new TablerModal()
            .Footer(f => f.Button("Close", TablerColor.Primary).Dismiss());
        var html = modal.ToString();
        Assert.IsTrue(html.Contains("data-bs-dismiss=\"modal\""));
    }
}
