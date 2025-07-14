namespace HtmlForgeX;

public partial class TablerCardEnhanced {
    #region Image Methods
    /// <summary>
    /// Initializes or configures WithImage.
    /// </summary>
    public TablerCardEnhanced WithImage(string url, string position = "top", string alt = "") {
        ImageUrl = url;
        ImagePosition = position;
        ImageAlt = alt;
        return this;
    }

    /// <summary>
    /// Initializes or configures WithImageSettings.
    /// </summary>
    public TablerCardEnhanced WithImageSettings(bool responsive = true, string aspectRatio = "21x9") {
        ImageResponsive = responsive;
        ImageAspectRatio = aspectRatio;
        return this;
    }
    #endregion

    private HtmlTag BuildCardImage() {
        if (ImageResponsive) {
            var div = new HtmlTag("div");
            var classes = new List<string> {
                "img-responsive",
                $"img-responsive-{ImageAspectRatio}",
                ImagePosition == "top" ? "card-img-top" : "card-img-bottom"
            };

            div.Class(string.Join(" ", classes));
            div.Attribute("style", $"background-image: url({ImageUrl})");

            return div;
        } else {
            var img = new HtmlTag("img");
            img.Attribute("src", ImageUrl);
            img.Class(ImagePosition == "top" ? "card-img-top" : "card-img-bottom");

            if (!string.IsNullOrEmpty(ImageAlt)) {
                img.Attribute("alt", ImageAlt);
            }

            return img;
        }
    }
}
