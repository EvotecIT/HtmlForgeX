using System;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Threading;

namespace HtmlForgeX;

public partial class Document
{
    /// <summary>
    /// Saves the document to disk.
    /// </summary>
    /// <param name="path">File path.</param>
    /// <param name="openInBrowser">Whether to open the file after saving.</param>
    /// <param name="scriptPath">Optional scripts path.</param>
    /// <param name="stylePath">Optional styles path.</param>
    public void Save(string path, bool openInBrowser = false, string scriptPath = "", string stylePath = "")
    {
        PathUtilities.Validate(path);
        path = System.IO.Path.GetFullPath(path);
        Configuration.Path = path;
        if (!string.IsNullOrEmpty(scriptPath))
        {
            Configuration.ScriptPath = scriptPath;
        }

        if (!string.IsNullOrEmpty(stylePath))
        {
            Configuration.StylePath = stylePath;
        }

        var countErrors = Configuration.Errors.Count;
        if (countErrors > 0)
        {
            Console.WriteLine($"There were {countErrors} found during generation of HTML.");
        }

        var directory = System.IO.Path.GetDirectoryName(path);
        if (!string.IsNullOrEmpty(directory))
        {
            try
            {
                if (!IsUncRoot(directory))
                {
                    System.IO.Directory.CreateDirectory(directory);
                }
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Failed to create directory '{directory}'. {ex.Message}");
            }
        }
        FileWriteLock.Semaphore.Wait();
        try
        {
            File.WriteAllText(path, ToString(), Encoding.UTF8);
        }
        catch (Exception ex)
        {
            _logger.WriteError($"Failed to write file '{path}'. {ex.Message}");
        }
        finally
        {
            FileWriteLock.Semaphore.Release();
        }
        if (openInBrowser && !Helpers.Open(path, openInBrowser))
        {
            _logger.WriteError($"Failed to open file '{path}' using the default application.");
        }
    }

    /// <summary>
    /// Saves the document to disk asynchronously.
    /// </summary>
    /// <param name="path">File path.</param>
    /// <param name="openInBrowser">Whether to open the file after saving.</param>
    /// <param name="scriptPath">Optional scripts path.</param>
    /// <param name="stylePath">Optional styles path.</param>
    public async Task SaveAsync(
        string path,
        bool openInBrowser = false,
        string scriptPath = "",
        string stylePath = "",
        CancellationToken cancellationToken = default)
    {
        PathUtilities.Validate(path);
        path = System.IO.Path.GetFullPath(path);
        Configuration.Path = path;
        if (!string.IsNullOrEmpty(scriptPath))
        {
            Configuration.ScriptPath = scriptPath;
        }

        if (!string.IsNullOrEmpty(stylePath))
        {
            Configuration.StylePath = stylePath;
        }

        var countErrors = Configuration.Errors.Count;
        if (countErrors > 0)
        {
            Console.WriteLine($"There were {countErrors} found during generation of HTML.");
        }

        var directory = System.IO.Path.GetDirectoryName(path);
        if (!string.IsNullOrEmpty(directory))
        {
            try
            {
                if (!IsUncRoot(directory))
                {
                    System.IO.Directory.CreateDirectory(directory);
                }
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Failed to create directory '{directory}'. {ex.Message}");
            }
        }
        await FileWriteLock.Semaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
#if NET5_0_OR_GREATER
            await File.WriteAllTextAsync(path, ToString(), Encoding.UTF8, cancellationToken).ConfigureAwait(false);
#else
            using var writer = new StreamWriter(path, false, Encoding.UTF8);
            cancellationToken.ThrowIfCancellationRequested();
            await writer.WriteAsync(ToString()).ConfigureAwait(false);
#endif
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception ex)
        {
            _logger.WriteError($"Failed to write file '{path}'. {ex.Message}");
        }
        finally
        {
            FileWriteLock.Semaphore.Release();
        }
        if (openInBrowser && !Helpers.Open(path, openInBrowser))
        {
            _logger.WriteError($"Failed to open file '{path}' using the default application.");
        }
    }

    private static bool IsUncRoot(string directory)
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            return false;
        }

        if (string.IsNullOrEmpty(directory))
        {
            return false;
        }

        if (!(directory.StartsWith("\\") || directory.StartsWith("//")))
        {
            return false;
        }

        var unc = directory.TrimStart(System.IO.Path.DirectorySeparatorChar, System.IO.Path.AltDirectorySeparatorChar);
        return unc.Split(System.IO.Path.DirectorySeparatorChar, System.IO.Path.AltDirectorySeparatorChar).Length == 2;
    }
}

