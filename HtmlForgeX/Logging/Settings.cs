namespace HtmlForgeX.Logging;

/// <summary>
/// Settings for the DnsClientX library.
/// Provides interface for setting logging levels and number of threads to use.
/// </summary>
public class Settings {
    /// <summary>
    /// The logger instance.
    /// </summary>
    protected static InternalLogger _logger = new InternalLogger();

    /// <summary>
    /// Lock object used to synchronize access to <see cref="_logger" />.
    /// </summary>
    private static readonly object LoggerLock = new();

    /// <summary>
    /// Gets or sets a value indicating whether error logging is enabled.
    /// </summary>
    public bool Error {
        get {
            lock (LoggerLock) {
                return _logger.IsError;
            }
        }
        set {
            lock (LoggerLock) {
                _logger.IsError = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets a value indicating whether verbose logging is enabled.
    /// </summary>
    public bool Verbose {
        get {
            lock (LoggerLock) {
                return _logger.IsVerbose;
            }
        }
        set {
            lock (LoggerLock) {
                _logger.IsVerbose = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets a value indicating whether warning logging is enabled.
    /// </summary>
    public bool Warning {
        get {
            lock (LoggerLock) {
                return _logger.IsWarning;
            }
        }
        set {
            lock (LoggerLock) {
                _logger.IsWarning = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets a value indicating whether progress logging is enabled.
    /// </summary>
    public bool Progress {
        get {
            lock (LoggerLock) {
                return _logger.IsProgress;
            }
        }
        set {
            lock (LoggerLock) {
                _logger.IsProgress = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets a value indicating whether debug logging is enabled.
    /// </summary>
    public bool Debug {
        get {
            lock (LoggerLock) {
                return _logger.IsDebug;
            }
        }
        set {
            lock (LoggerLock) {
                _logger.IsDebug = value;
            }
        }
    }

}
