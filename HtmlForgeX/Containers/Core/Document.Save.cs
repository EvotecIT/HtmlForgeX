using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

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
                System.IO.Directory.CreateDirectory(directory);
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Failed to create directory '{directory}'. {ex.Message}");
            }
        }
        try
        {
            FileWriteLock.Semaphore.Wait();
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
        if (!Helpers.Open(path, openInBrowser))
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
    public async Task SaveAsync(string path, bool openInBrowser = false, string scriptPath = "", string stylePath = "")
    {
        PathUtilities.Validate(path);
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
                System.IO.Directory.CreateDirectory(directory);
            }
            catch (Exception ex)
            {
                _logger.WriteError($"Failed to create directory '{directory}'. {ex.Message}");
            }
        }
        await FileWriteLock.Semaphore.WaitAsync().ConfigureAwait(false);
        try
        {
#if NET5_0_OR_GREATER
            await File.WriteAllTextAsync(path, ToString(), Encoding.UTF8).ConfigureAwait(false);
#else
            using var writer = new StreamWriter(path, false, Encoding.UTF8);
            await writer.WriteAsync(ToString()).ConfigureAwait(false);
#endif
        }
        catch (Exception ex)
        {
            _logger.WriteError($"Failed to write file '{path}'. {ex.Message}");
        }
        finally
        {
            FileWriteLock.Semaphore.Release();
        }
        if (!Helpers.Open(path, openInBrowser))
        {
            _logger.WriteError($"Failed to open file '{path}' using the default application.");
        }
    }
}

