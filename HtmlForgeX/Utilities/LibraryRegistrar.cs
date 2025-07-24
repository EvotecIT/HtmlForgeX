namespace HtmlForgeX;

using System;
using System.IO;
using System.Reflection;
using System.Text;

internal static class LibraryRegistrar {
    internal static bool RegisterLibrary(Document document, Head head, Library library, bool fromFiles) {
        var config = document.Configuration;
        var headerLinks = library.Header;
        var success = true;

        if (config.LibraryMode == LibraryMode.Online) {
            foreach (var link in headerLinks.CssLink) {
                head.AddCssLink(link);
            }

            foreach (var link in headerLinks.JsLink) {
                head.AddJsLink(link);
            }

            if (!fromFiles) {
                if (headerLinks.JsLink.Count == 0 && headerLinks.Js.Count > 0) {
                    foreach (var js in headerLinks.Js) {
                        var jsContent = ReadEmbeddedResource(js);
                        head.AddJsInline(jsContent);
                    }
                }

                if (headerLinks.CssLink.Count == 0 && headerLinks.Css.Count > 0) {
                    foreach (var css in headerLinks.Css) {
                        var cssContent = ReadEmbeddedResource(css, false);
                        head.AddCssInline(cssContent);
                    }
                }
            }
        } else if (config.LibraryMode == LibraryMode.Offline) {
            if (fromFiles) {
                foreach (var css in headerLinks.Css) {
                    var resolved = Path.IsPathRooted(css) ? css : Path.Combine(config.Path, css);
                    if (!File.Exists(resolved)) {
                        Document._logger.WriteError($"CSS file '{resolved}' not found.");
                        success = false;
                        continue;
                    }

                    try {
                        var cssContent = File.ReadAllText(resolved, Encoding.UTF8);
                        head.AddCssInline(cssContent);
                    } catch (Exception ex) {
                        Document._logger.WriteError($"Failed to read CSS file '{resolved}'. {ex.Message}");
                        success = false;
                    }
                }

                foreach (var js in headerLinks.Js) {
                    var resolved = Path.IsPathRooted(js) ? js : Path.Combine(config.Path, js);
                    if (!File.Exists(resolved)) {
                        Document._logger.WriteError($"JS file '{resolved}' not found.");
                        success = false;
                        continue;
                    }

                    try {
                        var jsContent = File.ReadAllText(resolved, Encoding.UTF8);
                        head.AddJsInline(jsContent);
                    } catch (Exception ex) {
                        Document._logger.WriteError($"Failed to read JS file '{resolved}'. {ex.Message}");
                        success = false;
                    }
                }
            } else {
                foreach (var css in headerLinks.Css) {
                    var cssContent = ReadEmbeddedResource(css, false);
                    head.AddCssInline(cssContent);
                }

                foreach (var js in headerLinks.Js) {
                    var jsContent = ReadEmbeddedResource(js);
                    head.AddJsInline(jsContent);
                }
            }
        } else if (config.LibraryMode == LibraryMode.OfflineWithFiles && !fromFiles) {
            foreach (var css in headerLinks.Css) {
                var fileName = Path.GetFileName(css);
                var linkPath = string.IsNullOrEmpty(config.StylePath)
                    ? fileName
                    : Path.Combine(config.StylePath, fileName);
                head.AddCssLink(linkPath.Replace('\\', '/'));
            }

            foreach (var js in headerLinks.Js) {
                var jsContent = ReadEmbeddedResource(js);
                var fileName = Path.GetFileName(js);
                var linkPath = string.IsNullOrEmpty(config.ScriptPath)
                    ? fileName
                    : Path.Combine(config.ScriptPath, fileName);
                head.AddJsLink(linkPath.Replace('\\', '/'));

                var baseDir = Path.GetDirectoryName(config.Path) ?? string.Empty;
                var jsFileName = Path.Combine(baseDir, linkPath);
                var jsDirectory = Path.GetDirectoryName(jsFileName);
                if (!string.IsNullOrEmpty(jsDirectory)) {
                    try {
                        Directory.CreateDirectory(jsDirectory);
                    } catch (Exception ex) {
                        Document._logger.WriteError($"Failed to create directory '{jsDirectory}'. {ex.Message}");
                    }
                }

                FileWriteLock.Semaphore.Wait();
                try {
                    File.WriteAllText(jsFileName, jsContent, Encoding.UTF8);
                } catch (Exception ex) {
                    Document._logger.WriteError($"Failed to write file '{jsFileName}'. {ex.Message}");
                } finally {
                    FileWriteLock.Semaphore.Release();
                }
            }
        }

        foreach (var style in headerLinks.CssStyle) {
            head.AddCssStyle(style);
        }

        foreach (var script in headerLinks.JsScript) {
            head.AddJsInline(script);
        }

        return success;
    }

    private static string ReadEmbeddedResource(string resourceName, bool script = true) {
        var assembly = Assembly.GetExecutingAssembly();
        var prefix = script ? "HtmlForgeX.Resources.Scripts." : "HtmlForgeX.Resources.Styles.";
        using var stream = assembly.GetManifestResourceStream(prefix + resourceName);
        if (stream == null) {
            throw new ArgumentException($"Resource not found: {resourceName}");
        }
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
}