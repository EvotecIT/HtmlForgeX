using System.Net;
using System.Net.Http;
using System.Net.Sockets;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestLibraryDownloader {
    private static int GetFreePort() {
        TcpListener listener = new(IPAddress.Loopback, 0);
        listener.Start();
        int port = ((IPEndPoint)listener.LocalEndpoint).Port;
        listener.Stop();
        return port;
    }

    private static string StartServer() {
        int port = GetFreePort();
        string prefix = $"http://localhost:{port}/";
        HttpListener listener = new();
        listener.Prefixes.Add(prefix);
        listener.Start();
        _ = Task.Run(async () => {
            var context = await listener.GetContextAsync();
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes("test");
            context.Response.StatusCode = (int)HttpStatusCode.OK;
            context.Response.ContentType = "text/plain";
            context.Response.ContentLength64 = bytes.Length;
            context.Response.KeepAlive = false;
            using (var stream = context.Response.OutputStream) {
                await stream.WriteAsync(bytes, 0, bytes.Length);
                await stream.FlushAsync();
            }
            context.Response.Close();
            listener.Close();
        });
        return prefix;
    }

    private static string StartErrorServer() {
        int port = GetFreePort();
        string prefix = $"http://localhost:{port}/";
        HttpListener listener = new();
        listener.Prefixes.Add(prefix);
        listener.Start();
        _ = Task.Run(async () => {
            var context = await listener.GetContextAsync();
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.KeepAlive = false;
            context.Response.Close();
            listener.Close();
        });
        return prefix;
    }

    private static async Task RunTestAsync(string extension, string folder) {
        string prefix = StartServer();
        string url = $"{prefix}file{extension}";
        string tempDir = Path.Combine(TempPath.Get(), Guid.NewGuid().ToString());
        var downloader = new LibraryDownloader();
        await downloader.DownloadFileAsync(tempDir, url);
        string expected = Path.Combine(tempDir, folder, $"file{extension}");
        Assert.IsTrue(File.Exists(expected));
        Directory.Delete(tempDir, true);
    }

    [DataTestMethod]
    [DataRow(".css", "Styles")]
    [DataRow(".js", "Scripts")]
    [DataRow(".woff", "Fonts")]
    [DataRow(".svg", "Images")]
    public async Task DownloadFilePlacesCorrectly(string extension, string folder) {
        await RunTestAsync(extension, folder);
    }

    [TestMethod]
    public async Task DownloadFileDisposesFileOnError() {
        string prefix = StartErrorServer();
        string url = $"{prefix}file.css";
        string tempDir = Path.Combine(TempPath.Get(), Guid.NewGuid().ToString());
        var downloader = new LibraryDownloader();
        await Assert.ThrowsExceptionAsync<HttpRequestException>(() => downloader.DownloadFileAsync(tempDir, url));
        string expected = Path.Combine(tempDir, "Styles", "file.css");
        Assert.IsTrue(File.Exists(expected));
        using var fs = File.Open(expected, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
        fs.Close();
        Directory.Delete(tempDir, true);
    }


}