using System.Net;
using System.Net.Sockets;
using System.Reflection;
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
        _ = Task.Run(async () =>
        {
            var context = await listener.GetContextAsync();
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes("test");
            context.Response.StatusCode = (int)HttpStatusCode.OK;
            context.Response.ContentType = "text/plain";
            context.Response.ContentLength64 = bytes.Length;
            context.Response.KeepAlive = false;
            using (var stream = context.Response.OutputStream)
            {
                await stream.WriteAsync(bytes, 0, bytes.Length);
                await stream.FlushAsync();
            }
            context.Response.Close();
            listener.Close();
        });
        return prefix;
    }

    private static async Task RunTestAsync(string extension, string folder) {
        string prefix = StartServer();
        string url = $"{prefix}file{extension}";
        string tempDir = Path.Combine(TestUtilities.GetFrameworkSpecificTempPath(), Guid.NewGuid().ToString());
        var downloader = new LibraryDownloader();
        var method = typeof(LibraryDownloader).GetMethod("DownloadFileAsync", BindingFlags.Instance | BindingFlags.NonPublic);
        await (Task)method!.Invoke(downloader, new object[] { tempDir, url })!;
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


}
