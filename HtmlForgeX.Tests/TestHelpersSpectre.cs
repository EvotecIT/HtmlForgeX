#if NET8_0_OR_GREATER
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spectre.Console;
using Spectre.Console.Testing;
using System.Reflection;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestHelpersSpectre {
    [TestMethod]
    public void PrintTitle_UsesUnicodeBorders() {
        var console = new TestConsole { EmitAnsiSequences = false };
        var previous = AnsiConsole.Console;
        AnsiConsole.Console = console;
        try {
            var assembly = Assembly.Load("HtmlForgeX.Examples");
            var type = assembly.GetType("HtmlForgeX.Examples.HelpersSpectre");
            var method = type!.GetMethod("PrintTitle", BindingFlags.Static | BindingFlags.Public);
            method?.Invoke(null, new object[] { "Demo Title" });
        } finally {
            AnsiConsole.Console = previous;
        }

        var output = console.Output;
        Assert.IsTrue(output.Contains("Demo Title"));
        Assert.IsTrue(output.Contains("═"));
    }
}
#endif