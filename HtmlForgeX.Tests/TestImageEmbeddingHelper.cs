using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestImageEmbeddingHelper {
    private static int GetFreePort() {
        TcpListener listener = new(IPAddress.Loopback, 0);
        listener.Start();
        int port = ((IPEndPoint)listener.LocalEndpoint).Port;
        listener.Stop();
        return port;
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

    [TestMethod]
    public void EmbedFromUrl_InvalidUrl_ReturnsFailure() {
        string prefix = StartErrorServer();
        string url = $"{prefix}image.png";
        var result = ImageEmbeddingHelper.EmbedFromUrl(url, 5);
        Assert.IsFalse(result.Success);
        Assert.AreEqual($"HTTP error while downloading {url}", result.ErrorMessage);
    }
}