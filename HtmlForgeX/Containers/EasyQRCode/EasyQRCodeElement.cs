namespace HtmlForgeX;

public class EasyQRCodeElement : Element {
    public string Id { get; set; }
    private string PrivateText { get; set; }

    public EasyQRCodeElement(string text) {
        // Libraries will be registered via RegisterLibraries method
        Id = GlobalStorage.GenerateRandomId("QrCode");
        PrivateText = text;
    }

    /// <summary>
    /// Registers the required libraries for EasyQRCodeElement.
    /// </summary>
    protected internal override void RegisterLibraries() {
        Document?.Configuration.Libraries.TryAdd(Libraries.EasyQRCode, 0);
    }

    public override string ToString() {
        var divTag = new HtmlTag("div").Class("qrcode").Id(Id);

        var scriptTag = new HtmlTag("script").Value($@"
            var options = {{
                ""text"": ""{PrivateText}""
            }};
        new QRCode(document.getElementById(""{Id}""), options);
    ");

        return divTag + scriptTag.ToString();
    }
}
