using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestUncPaths {
    [TestMethod]
    public void PathUtilities_Validate_UncPath() {
        string path = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
            ? "\\\\server\\share\\file.html"
            : "//server/share/file.html";
        PathUtilities.Validate(path);
    }

    [TestMethod]
    public void Document_Save_UncStylePath() {
        using var doc = new Document();
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
            string local = Path.Combine(TempPath.Get(), Guid.NewGuid().ToString(), "file.html");
            Directory.CreateDirectory(Path.GetDirectoryName(local)!);
            string uncPath = "\\\\?\\" + local;
            doc.Save(uncPath);
            Assert.IsTrue(File.Exists(uncPath));
            File.Delete(uncPath);
        } else {
            string path = Path.Combine("//", Path.GetTempFileName());
            doc.Save(path);
            Assert.IsTrue(File.Exists(path));
            File.Delete(path);
        }
    }

    [TestMethod]
    public void Document_IsUncRoot_DetectsRoot() {
        var method = typeof(Document).GetMethod("IsUncRoot", BindingFlags.NonPublic | BindingFlags.Static)!;
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
            Assert.IsTrue((bool)method.Invoke(null, new object[] { "\\\\server\\share" })!);
            Assert.IsFalse((bool)method.Invoke(null, new object[] { "\\\\server\\share\\folder" })!);
        } else {
            Assert.IsFalse((bool)method.Invoke(null, new object[] { "//server/share" })!);
        }
    }
}