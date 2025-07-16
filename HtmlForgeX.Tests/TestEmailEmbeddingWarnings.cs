using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestEmailEmbeddingWarnings
{
    [TestMethod]
    public void EmbeddingWarningCount_IncrementsOnWarning()
    {
        var email = new Email();
        email.SetEmbeddingWarnings(true);
        var image = new EmailImage();
        email.Body.Add(image);
        image.EmbedSmart("non-existent-file.png");
        Assert.AreEqual(1, email.EmbeddingWarningCount);
        Assert.AreEqual(1, email.Configuration.Errors.Count);
    }

    [TestMethod]
    public async Task EmbeddingWarningCount_PersistsThroughSaveAsync()
    {
        var email = new Email();
        email.SetEmbeddingWarnings(true);
        var image = new EmailImage();
        email.Body.Add(image);
        image.EmbedSmart("non-existent-file.png");
        var path = Path.Combine(TestUtilities.GetFrameworkSpecificTempPath(), Path.GetRandomFileName() + ".html");
        await email.SaveAsync(path);
        Assert.AreEqual(1, email.EmbeddingWarningCount);
        File.Delete(path);
    }
}
