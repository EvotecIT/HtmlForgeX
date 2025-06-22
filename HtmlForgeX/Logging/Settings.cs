using System.Threading;

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
    private static readonly ReaderWriterLockSlim LoggerLock = new();

    /// <summary>
    /// Gets or sets a value indicating whether error logging is enabled.
    /// </summary>
    public bool Error {
        get {
            LoggerLock.EnterReadLock();
            try {
                return _logger.IsError;
            } finally {
                LoggerLock.ExitReadLock();
            }
        }
        set {
            LoggerLock.EnterWriteLock();
            try {
                _logger.IsError = value;
            } finally {
                LoggerLock.ExitWriteLock();
            }
        }
    }

    /// <summary>
    /// Gets or sets a value indicating whether verbose logging is enabled.
    /// </summary>
    public bool Verbose {
        get {
            LoggerLock.EnterReadLock();
            try {
                return _logger.IsVerbose;
            } finally {
                LoggerLock.ExitReadLock();
            }
        }
        set {
            LoggerLock.EnterWriteLock();
            try {
                _logger.IsVerbose = value;
            } finally {
                LoggerLock.ExitWriteLock();
            }
        }
    }

    /// <summary>
    /// Gets or sets a value indicating whether warning logging is enabled.
    /// </summary>
    public bool Warning {
        get {
            LoggerLock.EnterReadLock();
            try {
                return _logger.IsWarning;
            } finally {
                LoggerLock.ExitReadLock();
            }
        }
        set {
            LoggerLock.EnterWriteLock();
            try {
                _logger.IsWarning = value;
            } finally {
                LoggerLock.ExitWriteLock();
            }
        }
    }

    /// <summary>
    /// Gets or sets a value indicating whether progress logging is enabled.
    /// </summary>
    public bool Progress {
        get {
            LoggerLock.EnterReadLock();
            try {
                return _logger.IsProgress;
            } finally {
                LoggerLock.ExitReadLock();
            }
        }
        set {
            LoggerLock.EnterWriteLock();
            try {
                _logger.IsProgress = value;
            } finally {
                LoggerLock.ExitWriteLock();
            }
        }
    }

    /// <summary>
    /// Gets or sets a value indicating whether debug logging is enabled.
    /// </summary>
    public bool Debug {
        get {
            LoggerLock.EnterReadLock();
            try {
                return _logger.IsDebug;
            } finally {
                LoggerLock.ExitReadLock();
            }
        }
        set {
            LoggerLock.EnterWriteLock();
            try {
                _logger.IsDebug = value;
            } finally {
                LoggerLock.ExitWriteLock();
            }
        }
    }

}
