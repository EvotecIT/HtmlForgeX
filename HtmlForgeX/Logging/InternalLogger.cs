using System.Globalization;

namespace HtmlForgeX.Logging;

/// <summary>
/// Simple logging facility used internally by the library to capture verbose
/// or warning messages. Consumers can subscribe to expose logging information
/// to their own infrastructure.
/// </summary>
public class InternalLogger {
    private readonly object _lock = new object();

    /// <summary>
    /// Occurs when a verbose message is logged.
    /// </summary>
    public event EventHandler<LogEventArgs>? OnVerboseMessage;

    /// <summary>
    /// Occurs when a warning message is logged.
    /// </summary>
    public event EventHandler<LogEventArgs>? OnWarningMessage;

    /// <summary>
    /// Occurs when an error message is logged.
    /// </summary>
    public event EventHandler<LogEventArgs>? OnErrorMessage;

    /// <summary>
    /// Occurs when a debug message is logged.
    /// </summary>
    public event EventHandler<LogEventArgs>? OnDebugMessage;

    /// <summary>
    /// Occurs when a progress message is logged.
    /// </summary>
    public event EventHandler<LogEventArgs>? OnProgressMessage;

    /// <summary>
    /// Occurs when an information message is logged.
    /// </summary>
    public event EventHandler<LogEventArgs>? OnInformationMessage;

    /// <summary>
    /// Gets or sets a value indicating whether verbose messages should be logged.
    /// </summary>
    public bool IsVerbose { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether error messages should be logged.
    /// </summary>
    public bool IsError { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether warning messages should be logged.
    /// </summary>
    public bool IsWarning { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether debug messages should be logged.
    /// </summary>
    public bool IsDebug { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether information messages should be logged.
    /// </summary>
    public bool IsInformation { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether progress messages should be logged.
    /// </summary>
    public bool IsProgress { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="InternalLogger"/> class.
    /// </summary>
    /// <param name="isVerbose">If set to <c>true</c>, verbose messages will be logged.</param>
    public InternalLogger(bool isVerbose = false) {
        IsVerbose = isVerbose;
    }

    /// <summary>
    /// Writes a progress message to the console and invokes the OnProgressMessage event.
    /// </summary>
    /// <param name="activity">The activity being logged.</param>
    /// <param name="currentOperation">The current operation being logged.</param>
    /// <param name="percentCompleted">The percentage of the operation that is completed.</param>
    /// <param name="currentSteps">The current step of the operation (optional).</param>
    /// <param name="totalSteps">The total steps of the operation (optional).</param>
    public void WriteProgress(string activity, string currentOperation, int percentCompleted, int? currentSteps = null, int? totalSteps = null) {
        LogEventArgs args;
        lock (_lock) {
            args = new LogEventArgs(activity, currentOperation, currentSteps, totalSteps, percentCompleted);
            if (IsProgress) {
                if (currentSteps.HasValue && totalSteps.HasValue) {
                    Console.WriteLine(string.Format(CultureInfo.InvariantCulture, "[progress] activity: {0} / operation: {1} / percent completed: {2}% ({3} out of {4})", activity, currentOperation, percentCompleted, currentSteps, totalSteps));
                } else {
                    Console.WriteLine(string.Format(CultureInfo.InvariantCulture, "[progress] activity: {0} / operation: {1} / percent completed: {2}%", activity, currentOperation, percentCompleted));
                }
            }
        }
        OnProgressMessage?.Invoke(this, args);
    }

    /// <summary>
    /// Writes an error message to the console and invokes the OnErrorMessage event.
    /// </summary>
    /// <param name="message">The error message to be logged.</param>
    public void WriteError(string message) {
        LogEventArgs args;
        lock (_lock) {
            args = new LogEventArgs(message);
            if (IsError) {
                Console.WriteLine("[error] " + message);
            }
        }
        OnErrorMessage?.Invoke(this, args);
    }

    /// <summary>
    /// Writes a formatted error message to the console and invokes the OnErrorMessage event.
    /// </summary>
    /// <param name="message">The error message to be logged, with format items.</param>
    /// <param name="args">An array of objects to write using format.</param>
    public void WriteError(string message, params object[] args) {
        LogEventArgs logArgs;
        lock (_lock) {
            logArgs = new LogEventArgs(string.Format(CultureInfo.InvariantCulture, message, args));
            if (IsError) {
                Console.WriteLine(string.Format(CultureInfo.InvariantCulture, "[error] " + message, args));
            }
        }
        OnErrorMessage?.Invoke(this, logArgs);
    }

    /// <summary>
    /// Writes a warning message to the console and invokes the OnWarningMessage event.
    /// </summary>
    /// <param name="message">The warning message to be logged.</param>
    public void WriteWarning(string message) {
        LogEventArgs args;
        lock (_lock) {
            args = new LogEventArgs(message);
            if (IsWarning) {
                Console.WriteLine("[warning] " + message);
            }
        }
        OnWarningMessage?.Invoke(this, args);
    }

    /// <summary>
    /// Writes a formatted warning message to the console and invokes the OnWarningMessage event.
    /// </summary>
    /// <param name="message">The warning message to be logged, with format items.</param>
    /// <param name="args">An array of objects to write using format.</param>
    public void WriteWarning(string message, params object[] args) {
        LogEventArgs logArgs;
        lock (_lock) {
            logArgs = new LogEventArgs(string.Format(CultureInfo.InvariantCulture, message, args));
            if (IsWarning) {
                Console.WriteLine(string.Format(CultureInfo.InvariantCulture, "[warning] " + message, args));
            }
        }
        OnWarningMessage?.Invoke(this, logArgs);
    }

    /// <summary>
    /// Writes a verbose message to the console and invokes the OnVerboseMessage event.
    /// </summary>
    /// <param name="message">The verbose message to be logged.</param>
    public void WriteVerbose(string message) {
        LogEventArgs args;
        lock (_lock) {
            args = new LogEventArgs(message);
            if (IsVerbose) {
                Console.WriteLine(message);
            }
        }
        OnVerboseMessage?.Invoke(this, args);
    }

    /// <summary>
    /// Writes a formatted verbose message to the console and invokes the OnVerboseMessage event.
    /// </summary>
    /// <param name="message">The verbose message to be logged, with format items.</param>
    /// <param name="args">An array of objects to write using format.</param>
    public void WriteVerbose(string message, params object[] args) {
        LogEventArgs logArgs;
        lock (_lock) {
            logArgs = new LogEventArgs(message, args);
            if (IsVerbose) {
                Console.WriteLine(string.Format(CultureInfo.InvariantCulture, message, args));
            }
        }
        OnVerboseMessage?.Invoke(this, logArgs);
    }

    /// <summary>
    /// Writes a debug message to the console and invokes the OnDebugMessage event.
    /// </summary>
    /// <param name="message">The debug message to be logged.</param>
    /// <param name="args">An array of objects to write using format.</param>
    public void WriteDebug(string message, params object[] args) {
        LogEventArgs logArgs;
        lock (_lock) {
            logArgs = new LogEventArgs(message, args);
            if (IsDebug) {
                Console.WriteLine(string.Format(CultureInfo.InvariantCulture, "[debug] " + message, args));
            }
        }
        OnDebugMessage?.Invoke(this, logArgs);
    }

    /// <summary>
    /// Writes an information message to the console and invokes the OnInformationMessage event.
    /// </summary>
    /// <param name="message">The information message to be logged.</param>
    /// <param name="args">An array of objects to write using format.</param>
    public void WriteInformation(string message, params object[] args) {
        LogEventArgs logArgs;
        lock (_lock) {
            logArgs = new LogEventArgs(message, args);
            if (IsInformation) {
                Console.WriteLine(string.Format(CultureInfo.InvariantCulture, "[information] " + message, args));
            }
        }
        OnInformationMessage?.Invoke(this, logArgs);
    }
}

/// <summary>
/// Represents the arguments for a log event.
/// </summary>
/// <seealso cref="System.EventArgs" />
public class LogEventArgs : EventArgs {
    /// <summary>
    /// Progress percentage
    /// </summary>
    public int? ProgressPercentage { get; set; }

    /// <summary>
    /// Progress total steps
    /// </summary>
    public int? ProgressTotalSteps { get; set; }

    /// <summary>
    /// Progress current steps
    /// </summary>
    public int? ProgressCurrentSteps { get; set; }

    /// <summary>
    /// Progress current operation
    /// </summary>
    public string? ProgressCurrentOperation { get; set; }

    /// <summary>
    /// Progress activity
    /// </summary>
    public string? ProgressActivity { get; set; }

    /// <summary>
    /// Message to be written including arguments substitution
    /// </summary>
    public string? FullMessage { get; set; }

    /// <summary>
    /// Message to be written
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// Gets or sets the arguments.
    /// </summary>
    /// <value>
    /// The arguments.
    /// </value>
    public object[]? Args { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="LogEventArgs"/> class.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="args">The arguments.</param>
    public LogEventArgs(string message, object[] args) {
        Message = message;
        Args = args;
        FullMessage = string.Format(CultureInfo.InvariantCulture, message, args);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="LogEventArgs"/> class.
    /// </summary>
    /// <param name="message">The message.</param>
    public LogEventArgs(string message) {
        Message = message;
        FullMessage = message;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="LogEventArgs"/> class.
    /// </summary>
    /// <param name="activity">The activity.</param>
    /// <param name="currentOperation">The current operation.</param>
    /// <param name="currentSteps">The current steps.</param>
    /// <param name="totalSteps">The total steps.</param>
    /// <param name="percentage">The percentage.</param>
    public LogEventArgs(string activity, string currentOperation, int? currentSteps, int? totalSteps, int? percentage) {
        ProgressActivity = activity;
        ProgressCurrentOperation = currentOperation;
        ProgressCurrentSteps = currentSteps;
        ProgressTotalSteps = totalSteps;
        ProgressPercentage = percentage;
    }
}