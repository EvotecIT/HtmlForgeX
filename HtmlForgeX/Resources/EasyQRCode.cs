using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlForgeX.Resources;

/// <summary>
/// Provides metadata for the EasyQRCode library used to generate QR codes on
/// the client side. Embedding this library allows documents to display QR
/// codes without additional services.
/// </summary>
public class EasyQRCode : Library {
    /// <summary>
    /// Initializes a new instance of the <see cref="EasyQRCode"/> class.
    /// </summary>
    public EasyQRCode() {
        // CSS styles and JS go in HEAD
        Header = new LibraryLinks {
            JsLink = ["https://cdn.jsdelivr.net/npm/easyqrcodejs@4.6.0/dist/easy.qrcode.min.js"],
            Js = ["easy.qrcode.min.js"],
            CssStyle = [
                new Style {
                    Selector = ".qrcode",
                    Properties = new Dictionary<string, string> {
                        ["margin"] = "5px",
                    }
                },
                new Style {
                    Selector = ".qrcode canvas",
                    Properties = new Dictionary<string, string> {
                        ["width"] = "100%",
                        ["height"] = "100%",
                    }
                }
            ]
        };

        // No footer scripts needed
        Footer = new LibraryLinks();

        // No body scripts needed
        Body = new LibraryLinks();

        Comment = "EasyQRCode library for generating QR codes";
        LicenseLink = "";
    }
}