using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using System.Net;
using System.IO;

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

            if (isWindows) {
                using Process? process = Process.Start(new ProcessStartInfo("cmd", $"/c start \"\" \"{filePath}\"") {
                    CreateNoWindow = true
                });
            } else if (isOsx) {
                using Process? process = Process.Start("open", filePath);
            } else if (isLinux) {
                using Process? process = Process.Start("xdg-open", filePath);
            } else {
                Document._logger.WriteError($"Unsupported operating system while opening '{filePath}'.");
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
        try {
            using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None)) {
                stream.Close();
            }
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
        try {
            var file = new FileInfo(fileName);
            using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None)) {
                stream.Close();
            }
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

}