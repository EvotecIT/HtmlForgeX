using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestTablerAlerts {
    [TestMethod]
    public void AlertImportant() {
        var alert = new TablerAlert("Title", "Message").Important();
        StringAssert.Contains(alert.ToString(), "alert-important");
    }

    [TestMethod]
    public void AlertMinor() {
        var alert = new TablerAlert("Title", "Message").Minor();
        StringAssert.Contains(alert.ToString(), "alert-minor");
    }

    [TestMethod]
    public void AlertActionLink() {
        var alert = new TablerAlert(string.Empty, "Info", TablerColor.Info, TablerAlertType.Dismissible)
            .Action("https://example.com", "Link");
        StringAssert.Contains(alert.ToString(), "alert-action");
        StringAssert.Contains(alert.ToString(), "btn-close");
    }

    [TestMethod]
    public void AlertDescription() {
        var alert = new TablerAlert("Heading", "Description").WithDescription();
        var html = alert.ToString();
        StringAssert.Contains(html, "alert-heading");
        StringAssert.Contains(html, "alert-description");
    }
}
