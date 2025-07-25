using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;

namespace HtmlForgeX;

internal static class Helpers {
    internal static OSPlatform? PlatformOverride { get; set; }
    /// <summary>
    /// Opens up any file using assigned Application
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="open"></param>
    public static bool Open(string filePath, bool open) {
        if (!open) {
            return true;
        }

        if (!File.Exists(filePath)) {
            return false;
        }

        try {
            bool isWindows = PlatformOverride.HasValue ? PlatformOverride.Value == OSPlatform.Windows : RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            bool isOsx = PlatformOverride.HasValue ? PlatformOverride.Value == OSPlatform.OSX : RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
            bool isLinux = PlatformOverride.HasValue ? PlatformOverride.Value == OSPlatform.Linux : RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

            Process? process = null;

            if (isWindows) {
                process = Process.Start(new ProcessStartInfo("cmd", $"/c start \"\" \"{filePath}\"") {
                    CreateNoWindow = true
                });
            } else if (isOsx) {
                process = Process.Start("open", filePath);
            } else if (isLinux) {
                process = Process.Start("xdg-open", filePath);
            } else {
                Document._logger.WriteError($"Unsupported operating system while opening '{filePath}'.");
                return false;
            }

            if (process is null) {
                return false;
            }

            process.WaitForExit();
            if (process.ExitCode != 0) {
                return false;
            }
        } catch (Win32Exception ex) {
            Document._logger.WriteError($"Failed to open '{filePath}'. {ex.Message}");
            return false;
        } catch (FileNotFoundException ex) {
            Document._logger.WriteError($"Failed to open '{filePath}'. {ex.Message}");
            return false;
        } catch (Exception) {
            return false;
        }

        return true;
    }

    /// <summary>
    /// Checks if file is locked/used by another process
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    public static bool IsFileLocked(this FileInfo file) {
        if (!file.Exists) {
            return false;
        }
        try {
            using var stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            stream.Close();
        } catch (IOException) {
            //the file is unavailable because it is:
            //still being written to
            //or being processed by another thread
            //or does not exist (has already been processed)
            return true;
        } catch (UnauthorizedAccessException) {
            //the file is unavailable because it is:
            //still being written to
            //or being processed by another thread
            //or does not exist (has already been processed)
            return true;
        }

        //file is not locked
        return false;
    }

    /// <summary>
    /// Checks if file is locked/used by another process
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public static bool IsFileLocked(this string fileName) {
        if (!File.Exists(fileName)) {
            return false;
        }
        try {
            var file = new FileInfo(fileName);
            using var stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            stream.Close();
        } catch (IOException) {
            //the file is unavailable because it is:
            //still being written to
            //or being processed by another thread
            //or does not exist (has already been processed)
            return true;
        } catch (UnauthorizedAccessException) {
            //the file is unavailable because it is:
            //still being written to
            //or being processed by another thread
            //or does not exist (has already been processed)
            return true;
        }

        //file is not locked
        return false;
    }

    public static string HtmlEncode(string value) {
        return WebUtility.HtmlEncode(value);
    }

    public static string UrlEncode(string url) {
        if (string.IsNullOrEmpty(url)) {
            return string.Empty;
        }

        var encoded = Uri.EscapeDataString(url);
        encoded = encoded.Replace("%3A", ":")
                         .Replace("%2F", "/")
                         .Replace("%3F", "?")
                         .Replace("%3D", "=")
                         .Replace("%26", "&");
        return encoded;
    }

}