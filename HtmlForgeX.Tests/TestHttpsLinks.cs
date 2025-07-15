using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestHttpsLinks {
    [TestMethod]
    public void Document_Online_HttpsLinksOnly() {
        var doc = new Document();
        doc.LibraryMode = LibraryMode.Online;

        doc.Body.Add(element => {
            element.QRCode("https://example.com");
        });

        var html = doc.ToString();

        Assert.IsFalse(html.Contains("http://"), "HTML should not contain insecure http links");
        Assert.IsTrue(html.Contains("https://"), "HTML should contain https links");
    }

    [TestMethod]
    public void Document_Offline_LibraryContentUsesHttps() {
        var doc = new Document();
        doc.LibraryMode = LibraryMode.Offline;

        doc.Body.Add(element => {
            element.DiagramNetwork(network => {
                network.AddNode(new { id = 1, label = "Node" });
            });
        });

        var html = doc.ToString();

        Assert.IsFalse(html.Contains("http://"), "Embedded libraries should use HTTPS");
        Assert.IsTrue(html.Contains("https://"), "Embedded content should contain https references");
    }
}
