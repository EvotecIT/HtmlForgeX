using System.Text.Encodings.Web;
using System.Text.Json;

namespace HtmlForgeX;

/// <summary>
/// Renders a QR code using the EasyQRCode library.
/// </summary>
public class EasyQRCodeElement : Element {
    /// <summary>
    /// Gets the HTML element identifier.
    /// </summary>
    public string Id { get; set; }
    private string PrivateText { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="EasyQRCodeElement"/> class.
    /// </summary>
    /// <param name="text">Text to encode.</param>
    public EasyQRCodeElement(string text) {
        // Libraries will be registered via RegisterLibraries method
        Id = GlobalStorage.GenerateRandomId("QrCode");
        PrivateText = text;
    }

    /// <summary>
    /// Registers the required libraries for EasyQRCodeElement.
    /// </summary>
    protected internal override void RegisterLibraries() {
        Document?.AddLibrary(Libraries.EasyQRCode);
    }

    /// <summary>
    /// Generates the HTML and script elements for the QR code.
    /// </summary>
    /// <returns>The HTML string.</returns>
    public override string ToString() {
        var divTag = new HtmlTag("div").Class("qrcode").Id(Id);

        var encodedText = Helpers.HtmlEncode(PrivateText);

        var serializedText = JsonSerializer.Serialize(
            encodedText,
            new JsonSerializerOptions { Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping }
        );

        var scriptTag = new HtmlTag("script").Value($@"
            var options = {{
                ""text"": {serializedText}
            }};
        new QRCode(document.getElementById(""{Id}""), options);
    ");

        return divTag + scriptTag.ToString();
    }
}
