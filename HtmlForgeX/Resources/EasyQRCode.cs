using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlForgeX.Resources;
public class EasyQRCode : Library {
    public EasyQRCode() {
        Header = new LibraryLinks {
            JsLink = [
                "https://cdn.jsdelivr.net/npm/easyqrcodejs@4.6.1/dist/easy.qrcode.min.js"
            ],
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
        Comment = "EasyQRCode library";
        LicenseLink = "";
    }
}
