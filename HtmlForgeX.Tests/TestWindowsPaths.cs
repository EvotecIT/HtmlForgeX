using System;
using System.Runtime.InteropServices;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestWindowsPaths {
    [TestMethod]
    public void PathUtilities_Validate_ColonInFilename() {
        string path = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
            ? @"C:\\temp\\file:stream.html"
            : "/tmp/file:stream.html";
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
            Assert.ThrowsException<ArgumentException>(() => PathUtilities.Validate(path));
        } else {
            PathUtilities.Validate(path);
        }
    }

    [TestMethod]
    public void PathUtilities_Validate_DriveColonOnly() {
        string path = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
            ? @"C:\\temp\\file.html"
            : "/tmp/file.html";
        PathUtilities.Validate(path);
    }
}