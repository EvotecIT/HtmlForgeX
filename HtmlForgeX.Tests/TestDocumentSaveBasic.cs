using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

/// <summary>
/// Confirms that a simple document can be saved to disk successfully.
/// </summary>
[TestClass]
public class TestDocumentSaveBasic {
    [TestMethod]
    public void Document_SaveCreatesFile() {
        using var doc = new Document();
        doc.Body.Add(new HtmlTag("p", "Hello"));
        var path = Path.Combine(TempPath.Get(), Path.GetRandomFileName() + ".html");
        doc.Save(path, false);
        Assert.IsTrue(File.Exists(path));
        File.Delete(path);
    }
}