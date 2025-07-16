namespace HtmlForgeX;

public partial class Document
{
    private bool _disposed;

    /// <summary>
    /// Releases resources used by the <see cref="Document"/>.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        System.GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Disposes managed and unmanaged resources.
    /// </summary>
    /// <param name="disposing">Whether managed resources should be disposed.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            // Release managed resources if needed in the future
        }

        _disposed = true;
    }

    /// <summary>
    /// Finalizer to ensure resources are released.
    /// </summary>
    ~Document()
    {
        Dispose(false);
    }
}
