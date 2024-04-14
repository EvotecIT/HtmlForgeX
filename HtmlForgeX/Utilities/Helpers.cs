using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace HtmlForgeX;

internal static class Helpers {
    /// <summary>
    /// Opens up any file using assigned Application
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="open"></param>
    public static void Open(string filePath, bool open) {
        if (open) {
            ProcessStartInfo startInfo = new ProcessStartInfo(filePath) {
                UseShellExecute = true
            };
            Process.Start(startInfo);
        }
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
        }

        //file is not locked
        return false;
    }

}
