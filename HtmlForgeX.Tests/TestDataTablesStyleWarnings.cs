using System.Linq;
using HtmlForgeX.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestDataTablesStyleWarnings {
    private static InternalLogger GetLogger() {
        return Document._logger;
    }

    [TestMethod]
    public void Style_AddingConflictingSizeStyles_LogsWarning() {
        var logger = GetLogger();
        string? received = null;
        EventHandler<LogEventArgs> handler = (_, e) => received = e.FullMessage;
        logger.OnWarningMessage += handler;
        var table = new DataTablesTable();
        table.Style(BootStrapTableStyle.Small);
        table.Style(BootStrapTableStyle.Large);
        logger.OnWarningMessage -= handler;
        Assert.IsNotNull(received);
        StringAssert.Contains(received!, "Small");
        StringAssert.Contains(received!, "Large");
        Assert.AreEqual(1, table.StyleList.Count(s => s is BootStrapTableStyle.Small or BootStrapTableStyle.Medium or BootStrapTableStyle.Large));
    }
}
