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
            if (System.Threading.Interlocked.Decrement(ref _activeDocuments) == 0)
            {
                FileWriteLock.DisposeSemaphore();
            }
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
