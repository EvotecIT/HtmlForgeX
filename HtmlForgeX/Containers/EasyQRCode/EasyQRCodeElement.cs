namespace HtmlForgeX;

public class EasyQRCodeElement : Element {
    public string Id { get; set; }
    private string PrivateText { get; set; }

    public EasyQRCodeElement(string text) {
        GlobalStorage.Libraries.TryAdd(Libraries.EasyQRCode, 0);
        Id = GlobalStorage.GenerateRandomId("QrCode");
        PrivateText = text;
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
