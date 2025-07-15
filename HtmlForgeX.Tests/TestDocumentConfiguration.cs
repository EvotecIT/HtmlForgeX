using HtmlForgeX;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Concurrent;

namespace HtmlForgeX.Tests;

/// <summary>
/// Tests the default and custom values of <see cref="DocumentConfiguration"/>.
/// </summary>
[TestClass]
public class TestDocumentConfiguration {

    [TestMethod]
    public void DocumentConfiguration_DefaultValues() {
        var config = new DocumentConfiguration();
        
        Assert.AreEqual(ThemeMode.System, config.ThemeMode);
        Assert.AreEqual(LibraryMode.Online, config.LibraryMode);
        Assert.AreEqual(false, config.EnableDeferredScripts);
        Assert.AreEqual(TempPath.Get(), config.Path);
        Assert.AreEqual("", config.StylePath);
        Assert.AreEqual("", config.ScriptPath);
        Assert.IsNotNull(config.Libraries);
        Assert.IsNotNull(config.Errors);
    }

    [TestMethod]
    public void DocumentConfiguration_SetProperties() {
        var config = new DocumentConfiguration();
        
        config.ThemeMode = ThemeMode.Dark;
        config.LibraryMode = LibraryMode.Offline;
        config.EnableDeferredScripts = true;
        config.Path = "/custom/path";
        config.StylePath = "/css/";
        config.ScriptPath = "/js/";
        
        Assert.AreEqual(ThemeMode.Dark, config.ThemeMode);
        Assert.AreEqual(LibraryMode.Offline, config.LibraryMode);
        Assert.AreEqual(true, config.EnableDeferredScripts);
        Assert.AreEqual("/custom/path", config.Path);
        Assert.AreEqual("/css/", config.StylePath);
        Assert.AreEqual("/js/", config.ScriptPath);
    }

    [TestMethod]
    public void DocumentConfiguration_LibrariesCollection() {
        var config = new DocumentConfiguration();
        
        Assert.IsTrue(config.Libraries.TryAdd(Libraries.ApexCharts, 0));
        Assert.IsTrue(config.Libraries.ContainsKey(Libraries.ApexCharts));
        Assert.AreEqual(1, config.Libraries.Count);
    }

    [TestMethod]
    public void DocumentConfiguration_ErrorsCollection() {
        var config = new DocumentConfiguration();
        
        config.Errors.Add("Test error 1");
        config.Errors.Add("Test error 2");
        
        Assert.AreEqual(2, config.Errors.Count);
        Assert.IsTrue(config.Errors.Contains("Test error 1"));
        Assert.IsTrue(config.Errors.Contains("Test error 2"));
    }

    [TestMethod]
    public void DocumentConfiguration_GenerateRandomId() {
        var config = new DocumentConfiguration();
        
        var id1 = config.GenerateRandomId("test");
        var id2 = config.GenerateRandomId("test");

        Assert.IsNotNull(id1);
        Assert.IsNotNull(id2);
        Assert.AreNotEqual(id1, id2);
        Assert.IsTrue(id1.StartsWith("test"));
        Assert.IsTrue(id2.StartsWith("test"));
        Assert.AreEqual("test-".Length + IdGenerator.DefaultRandomIdLength, id1.Length);
    }

    [TestMethod]
    public void DocumentConfiguration_GenerateRandomIdWithCustomLength() {
        var config = new DocumentConfiguration();

        var id = config.GenerateRandomId("test", 12);

        Assert.IsNotNull(id);
        Assert.IsTrue(id.StartsWith("test"));
        Assert.AreEqual("test-".Length + 12, id.Length);
    }

    [TestMethod]
    public void DocumentConfiguration_GenerateRandomId_InvalidInput() {
        var config = new DocumentConfiguration();

        Assert.ThrowsException<ArgumentException>(() => config.GenerateRandomId(null!));
        Assert.ThrowsException<ArgumentException>(() => config.GenerateRandomId(" \t\n"));
    }
}