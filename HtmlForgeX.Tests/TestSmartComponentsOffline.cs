using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestSmartComponentsOffline {
    [DataTestMethod]
    [DataRow("tab")]
    [DataRow("wizard")]
    public void SmartComponent_OfflineMode_ShouldEmbedLibraries(string type) {
        using var doc = new Document { LibraryMode = LibraryMode.Offline };
        if (type == "tab") {
            doc.Body.SmartTab(tab => { });
        } else {
            doc.Body.SmartWizard(wz => { });
        }
        var html = doc.ToString();
        Assert.IsFalse(html.Contains("cdn"), "Offline mode should not use CDN links");
    }
}
