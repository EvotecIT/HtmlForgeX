using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestEmailBoxBuilder
{
    [TestMethod]
    public void BuilderProducesSameOutputAsDirectConstruction()
    {
        var direct = new EmailBox();
        direct.WithPadding("20px");
        direct.WithBackground("#ffffff");
        direct.Add(new BasicElement("Inner"));

        var built = new EmailBoxBuilder()
            .WithPadding("20px")
            .WithBackground("#ffffff")
            .Build();
        built.Add(new BasicElement("Inner"));

        Assert.AreEqual(direct.ToString(), built.ToString());
    }
}
