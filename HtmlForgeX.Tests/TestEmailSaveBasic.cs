using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestEmailSaveBasic {
    [TestMethod]
    public void Email_SaveCreatesFile() {
        var email = new Email();
        email.Body.Add(new HtmlTag("p", "Hello"));
        var path = Path.Combine(TestUtilities.GetFrameworkSpecificTempPath(), Path.GetRandomFileName() + ".html");
        email.Save(path, false);
        Assert.IsTrue(File.Exists(path));
        File.Delete(path);
    }
}
