using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestDocumentSaveBasic {
    [TestMethod]
    public void Document_SaveCreatesFile() {
        var doc = new Document();
        doc.Body.Add(new HtmlTag("p", "Hello"));
        var path = Path.Combine(TestUtilities.GetFrameworkSpecificTempPath(), Path.GetRandomFileName() + ".html");
        doc.Save(path, false);
        Assert.IsTrue(File.Exists(path));
        File.Delete(path);
    }
}
