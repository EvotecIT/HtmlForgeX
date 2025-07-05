namespace HtmlForgeX.Resources;

internal class StarRatingLibrary : Library {
    public StarRatingLibrary() {
        Header = new LibraryLinks {
            CssLink = ["https://cdn.jsdelivr.net/npm/star-rating.js/dist/star-rating.min.css"],
            Css = ["star-rating.min.css"],
            JsLink = ["https://cdn.jsdelivr.net/npm/star-rating.js/dist/star-rating.min.js"],
            Js = ["star-rating.min.js"]
        };
        Comment = "Star rating library";
        LicenseLink = "https://github.com/pryley/star-rating.js/blob/master/LICENSE";
        License = "MIT";
        SourceCodes = "https://github.com/pryley/star-rating.js";
    }
}
