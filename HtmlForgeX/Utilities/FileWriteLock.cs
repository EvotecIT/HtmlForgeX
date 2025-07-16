namespace HtmlForgeX;

internal static class FileWriteLock {
    private static System.Threading.SemaphoreSlim _semaphore = new(1, 1);

    internal static System.Threading.SemaphoreSlim Semaphore => _semaphore;

    internal static void DisposeSemaphore() {
        _semaphore.Dispose();
        _semaphore = new System.Threading.SemaphoreSlim(1, 1);
    }
}
