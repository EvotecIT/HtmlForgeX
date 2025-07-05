using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlForgeX.Resources;
public class EasyQRCode : Library {
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
