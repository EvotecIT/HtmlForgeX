namespace HtmlForgeX;

internal static class FileWriteLock {
    internal static readonly System.Threading.SemaphoreSlim Semaphore = new(1, 1);
}
