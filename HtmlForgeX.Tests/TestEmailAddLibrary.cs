using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestEmailAddLibrary {
    [TestMethod]
    public void AddLibrary_RegistersLibrary() {
        var email = new Email();
        email.AddLibrary(EmailLibraries.EmailCore);

        Assert.IsTrue(email.Configuration.Email.Libraries.ContainsKey(EmailLibraries.EmailCore));
    }
}