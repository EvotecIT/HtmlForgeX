using System.Linq;
using HtmlForgeX.Extensions;

namespace HtmlForgeX;

public partial class TablerCardEnhanced {
    /// <summary>
    /// Initializes or configures ToString.
    /// </summary>
    public override string ToString() {
        // Get base card HTML
        var baseCardHtml = base.ToString();

        // Parse the base card to inject our enhancements
        var cardTag = IsLink ? new HtmlTag("a") : new HtmlTag("div");

        // Build CSS classes from base
        var classes = new List<string> { "card" };

        // Note: CardOuterStyle is private in base class, using base logic

        // Add enhanced states
        if (IsActive) classes.Add("card-active");
        if (IsInactive) classes.Add("card-inactive");
        if (IsStacked) classes.Add("card-stacked");
        if (IsBorderless) classes.Add("card-borderless");

        if (CardRotation == "left") classes.Add("card-rotate-left");
        else if (CardRotation == "right") classes.Add("card-rotate-right");

        if (IsLink) {
            classes.Add("card-link");
            if (LinkEffect == "rotate") classes.Add("card-link-rotate");
            else if (LinkEffect == "pop") classes.Add("card-link-pop");
            cardTag.Attribute("href", LinkUrl ?? "#");
        }

        if (BackgroundColor.HasValue) {
            if (IsBackgroundLight) {
                classes.Add($"bg-{BackgroundColor.Value.ToTablerString()}-lt");
            } else {
                classes.Add(BackgroundColor.Value.ToTablerBackground());
                classes.Add($"text-{BackgroundColor.Value.ToTablerString()}-fg");
            }
        }

        cardTag.Class(string.Join(" ", classes));

        // Add status indicator
        if (!string.IsNullOrEmpty(StatusPosition) && StatusColor.HasValue) {
            var statusDiv = new HtmlTag("div");
            var positionClass = StatusPosition switch {
                "top" => "card-status-top",
                "bottom" => "card-status-bottom",
                "start" => "card-status-start",
                "end" => "card-status-end",
                _ => "card-status-top"
            };
            statusDiv.Class($"{positionClass} {StatusColor.Value.ToTablerBackground()}");
            cardTag.Value(statusDiv);
        }

        // Add ribbon
        if (!string.IsNullOrEmpty(RibbonText) || RibbonIcon.HasValue) {
            var ribbonDiv = new HtmlTag("div");
            var ribbonClasses = new List<string> { "ribbon" };

            if (!string.IsNullOrEmpty(RibbonPosition) && RibbonPosition != "top") {
                ribbonClasses.Add($"ribbon-{RibbonPosition}");
            } else {
                ribbonClasses.Add("ribbon-top");
            }

            if (RibbonColor.HasValue) {
                ribbonClasses.Add(RibbonColor.Value.ToTablerBackground());
            } else {
                ribbonClasses.Add("bg-red");
            }

            ribbonDiv.Class(string.Join(" ", ribbonClasses));

            if (RibbonIcon.HasValue) {
                ribbonDiv.Value(new TablerIconElement(RibbonIcon.Value));
            } else if (!string.IsNullOrEmpty(RibbonText)) {
                ribbonDiv.Value(RibbonText);
            }

            cardTag.Value(ribbonDiv);
        }

        // Add stamp
        if (StampIcon.HasValue) {
            var stampDiv = new HtmlTag("div").Class("card-stamp");
            var stampIconDiv = new HtmlTag("div");

            var stampClasses = new List<string> { "card-stamp-icon" };
            if (StampIconBackgroundColor.HasValue) {
                stampClasses.Add(StampIconBackgroundColor.Value.ToTablerBackground());
            } else {
                stampClasses.Add("bg-yellow");
            }

            if (StampIconColor.HasValue) {
                stampClasses.Add(StampIconColor.Value.ToTablerText());
            }

            stampIconDiv.Class(string.Join(" ", stampClasses));
            stampIconDiv.Value(new TablerIconElement(StampIcon.Value));
            stampDiv.Value(stampIconDiv);
            cardTag.Value(stampDiv);
        }

        // Handle side images with row layout
        if (!string.IsNullOrEmpty(ImageUrl) && (ImagePosition == "left" || ImagePosition == "right")) {
            var rowDiv = new HtmlTag("div").Class("row row-0");

            var imageCol = new HtmlTag("div").Class("col-3");
            if (ImagePosition == "right") {
                imageCol.Class("order-md-last");
            }

            var img = new HtmlTag("img")
                .Attribute("src", ImageUrl)
                .Class("w-100 h-100 object-cover")
                .Class(ImagePosition == "left" ? "card-img-start" : "card-img-end");

            if (!string.IsNullOrEmpty(ImageAlt)) {
                img.Attribute("alt", ImageAlt);
            }

            imageCol.Value(img);
            rowDiv.Value(imageCol);

            var contentCol = new HtmlTag("div").Class("col");

            // Add enhanced header
            if (!string.IsNullOrEmpty(HeaderTitle) || HeaderAvatar != null || HeaderActions.Any() || HasHeaderTabs || HasHeaderPills) {
                contentCol.Value(BuildCardHeader());
            }

            // Add body
            var bodyDiv = new HtmlTag("div").Class("card-body");
            if (!string.IsNullOrEmpty(CardContent)) {
                bodyDiv.Value(CardContent);
            }
            if (!string.IsNullOrEmpty(CardInnerStyle)) {
                bodyDiv.Attribute("style", CardInnerStyle!);
            }
            foreach (var child in Children.WhereNotNull()) {
                bodyDiv.Value(child);
            }
            contentCol.Value(bodyDiv);

            // Add enhanced footer
            if (!string.IsNullOrEmpty(FooterText) || FooterActions.Any() || FooterAvatars.Any() || FooterHasSwitch) {
                contentCol.Value(BuildCardFooter());
            }

            rowDiv.Value(contentCol);
            cardTag.Value(rowDiv);
        } else {
            // Normal layout

            // Add top image
            if (!string.IsNullOrEmpty(ImageUrl) && ImagePosition == "top") {
                cardTag.Value(BuildCardImage());
            }

            // Add enhanced header
            if (!string.IsNullOrEmpty(HeaderTitle) || HeaderAvatar != null || HeaderActions.Any() || HasHeaderTabs || HasHeaderPills) {
                cardTag.Value(BuildCardHeader());
            }

            // Add body
            var bodyDiv = new HtmlTag("div").Class("card-body");
            if (!string.IsNullOrEmpty(CardContent)) {
                bodyDiv.Value(CardContent);
            }
            if (!string.IsNullOrEmpty(CardInnerStyle)) {
                bodyDiv.Attribute("style", CardInnerStyle!);
            }
            foreach (var child in Children.WhereNotNull()) {
                bodyDiv.Value(child);
            }
            cardTag.Value(bodyDiv);

            // Add enhanced footer
            if (!string.IsNullOrEmpty(FooterText) || FooterActions.Any() || FooterAvatars.Any() || FooterHasSwitch) {
                cardTag.Value(BuildCardFooter());
            }

            // Add bottom image
            if (!string.IsNullOrEmpty(ImageUrl) && ImagePosition == "bottom") {
                cardTag.Value(BuildCardImage());
            }
        }

        // Add progress bar
        if (ProgressValue.HasValue) {
            var progressDiv = new HtmlTag("div").Class("progress progress-sm card-progress");
            var progressBar = new HtmlTag("div");

            var progressClasses = new List<string> { "progress-bar" };
            if (ProgressColor.HasValue) {
                progressClasses.Add(ProgressColor.Value.ToTablerBackground());
            }

            progressBar.Class(string.Join(" ", progressClasses));
            progressBar.Attribute("style", $"width: {ProgressValue.Value:F1}%");
            progressBar.Attribute("role", "progressbar");
            progressBar.Attribute("aria-valuenow", ProgressValue.Value.ToString("F1"));
            progressBar.Attribute("aria-valuemin", "0");
            progressBar.Attribute("aria-valuemax", "100");
            progressBar.Attribute("aria-label", $"{ProgressValue.Value:F1}% Complete");

            var hiddenSpan = new HtmlTag("span").Class("visually-hidden").Value($"{ProgressValue.Value:F1}% Complete");
            progressBar.Value(hiddenSpan);

            progressDiv.Value(progressBar);
            cardTag.Value(progressDiv);
        }

        return cardTag.ToString();
    }
}
