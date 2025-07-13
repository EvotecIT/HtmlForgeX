using System.Linq;

using HtmlForgeX.Extensions;

namespace HtmlForgeX;

public class TablerCard : Element {
    private TablerCardFooter PrivateFooter { get; set; } = new TablerCardFooter();
    private TablerCardHeader? PrivateHeader { get; set; }
    private TablerCardBody? PrivateBody { get; set; }
    private List<TablerCardImage> CardImages { get; set; } = new List<TablerCardImage>();

    public string? CardContent { get; set; }
    public string? CardInnerStyle { get; set; }

    private string? CardOuterStyle { get; set; }

    // Enhanced card properties following existing patterns
    public bool IsLink { get; set; }
    public string? LinkUrl { get; set; }
    public string? LinkEffect { get; set; } // "rotate", "pop", or null for default

    public bool IsActive { get; set; }
    public bool IsInactive { get; set; }
    public bool IsStacked { get; set; }
    public bool IsBorderless { get; set; }

    public string? CardRotation { get; set; } // "left", "right", or null

    // Status indicators
    public string? StatusPosition { get; set; } // "top", "bottom", "start", "end"
    public TablerColor? StatusColor { get; set; }

    // Ribbon
    public string? RibbonText { get; set; }
    public TablerIconType? RibbonIcon { get; set; }
    public string? RibbonPosition { get; set; } // "top", "bottom", etc
    public TablerColor? RibbonColor { get; set; }

    // Stamp
    public TablerIconType? StampIcon { get; set; }
    public TablerColor? StampIconBackgroundColor { get; set; }
    public TablerColor? StampIconColor { get; set; }

    // Progress
    public double? ProgressValue { get; set; }
    public TablerColor? ProgressColor { get; set; }

    // Background
    public TablerColor? BackgroundColor { get; set; }
    public bool IsBackgroundLight { get; set; }

    private int Number { get; set; }

    public TablerCard() {
        CardOuterStyle = $"col";
    }

    public TablerCard(int number) {
        CardOuterStyle = $"col-{number}";
    }

    public TablerCard Content(string content) {
        CardContent = content;
        return this;
    }

    public TablerCard Style(string style) {
        CardInnerStyle = style;
        return this;
    }

    public TablerCardFooter Footer() {
        PrivateFooter = new TablerCardFooter();
        return PrivateFooter;
    }


    public TablerCard Footer(Action<TablerCardFooter> footer) {
        var footerElement = new TablerCardFooter();
        footer(footerElement);
        PrivateFooter = footerElement;
        return this;
    }

    /// <summary>
    /// Add a proper header with fluent API (no raw HTML)
    /// </summary>
    public TablerCard Header(Action<TablerCardHeader> header) {
        PrivateHeader = new TablerCardHeader();
        header(PrivateHeader);
        return this;
    }

    /// <summary>
    /// Add a proper body with fluent API (no raw HTML)
    /// </summary>
    public TablerCard Body(Action<TablerCardBody> body) {
        PrivateBody = new TablerCardBody();
        body(PrivateBody);
        return this;
    }

    /// <summary>
    /// Add an image with proper positioning (no raw HTML)
    /// </summary>
    public TablerCard Image(Action<TablerCardImage> image) {
        var cardImage = new TablerCardImage();
        image(cardImage);
        CardImages.Add(cardImage);
        return this;
    }

    public override string ToString() {
        // Create the outer card element (div or a for links)
        var cardTag = IsLink ? new HtmlTag("a") : new HtmlTag("div");

        // Build CSS classes
        var classes = new List<string> { "card" };

        if (!string.IsNullOrEmpty(CardOuterStyle)) {
            classes.Add(CardOuterStyle);
        }

        // Card states
        if (IsActive) classes.Add("card-active");
        if (IsInactive) classes.Add("card-inactive");
        if (IsStacked) classes.Add("card-stacked");
        if (IsBorderless) classes.Add("card-borderless");

        // Card rotation
        if (CardRotation == "left") classes.Add("card-rotate-left");
        else if (CardRotation == "right") classes.Add("card-rotate-right");

        // Link effects
        if (IsLink) {
            classes.Add("card-link");
            if (LinkEffect == "rotate") classes.Add("card-link-rotate");
            else if (LinkEffect == "pop") classes.Add("card-link-pop");
            cardTag.Attribute("href", LinkUrl ?? "#");
        }

        // Background colors
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

            // Adjust ribbon width based on text length for better display
            if (!string.IsNullOrEmpty(RibbonText)) {
                var textLength = RibbonText.Length;
                if (textLength > 5) {
                    // Use very aggressive CSS to completely override Tabler's ribbon constraints
                    var minWidth = Math.Max(textLength * 1.2 + 1, 10);
                    ribbonDiv.Attribute("style", $"min-width: {minWidth:F1}rem !important; max-width: none !important; width: auto !important; white-space: nowrap !important; overflow: visible !important; padding: 0.25rem 0.75rem !important; transform: none !important; box-sizing: border-box !important;");
                }
                ribbonDiv.Value(RibbonText);
            } else if (RibbonIcon.HasValue) {
                ribbonDiv.Value(new TablerIconElement(RibbonIcon.Value));
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

        // Add top images first
        var topImages = CardImages.Where(img => {
            var property = img.GetType().GetProperty("Position", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var pos = property?.GetValue(img)?.ToString();
            return pos == "Top";
        });
        foreach (var image in topImages) {
            cardTag.Value(image.ToString());
        }

        // Add header if present
        if (PrivateHeader != null) {
            cardTag.Value(PrivateHeader.ToString());
        }

        // Check for side images that need special layout
        var sideImages = CardImages.Where(img => {
            var property = img.GetType().GetProperty("Position", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var pos = property?.GetValue(img)?.ToString();
            return pos == "Left" || pos == "Right";
        }).ToList();

        if (sideImages.Any()) {
            // Create side layout with first side image
            var sideImage = sideImages.First();
            string bodyContent = "";

            if (PrivateBody != null) {
                bodyContent = PrivateBody.ToString();
            } else if (!string.IsNullOrEmpty(CardContent)) {
                var tempBodyDiv = new HtmlTag("div").Class("card-body").Value(CardContent);
                foreach (var child in Children.WhereNotNull()) {
                    tempBodyDiv.Value(child);
                }
                bodyContent = tempBodyDiv.ToString();
            }

            // Use reflection to call CreateSideLayout
            var method = sideImage.GetType().GetMethod("CreateSideLayout");
            if (method != null) {
                var sideLayout = method.Invoke(sideImage, new object[] { bodyContent })?.ToString();
                cardTag.Value(sideLayout);
            }
        } else {
            // Regular body content (no side images)
            if (PrivateBody != null) {
                cardTag.Value(PrivateBody.ToString());
            } else if (!string.IsNullOrEmpty(CardContent) || Children.Any()) {
                // Fallback to old content for backward compatibility
                var cardBodyDiv = new HtmlTag("div");
                cardBodyDiv.Class("card-body");

                // Add CardContent if present
                if (!string.IsNullOrEmpty(CardContent)) {
                    cardBodyDiv.Value(CardContent);
                }

                if (!string.IsNullOrEmpty(CardInnerStyle)) {
                    cardBodyDiv.Attributes["style"] = CardInnerStyle;
                }

                // Add child elements to the card body (this handles old API usage)
                foreach (var child in Children.WhereNotNull()) {
                    cardBodyDiv.Value(child);
                }

                cardTag.Value(cardBodyDiv);
            }
        }

        // Add background images
        var backgroundImages = CardImages.Where(img => {
            var property = img.GetType().GetProperty("Position", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var pos = property?.GetValue(img)?.ToString();
            return pos == "Background";
        });
        foreach (var image in backgroundImages) {
            cardTag.Value(image.ToString());
        }

        // Add bottom images
        var bottomImages = CardImages.Where(img => {
            var property = img.GetType().GetProperty("Position", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var pos = property?.GetValue(img)?.ToString();
            return pos == "Bottom";
        });
        foreach (var image in bottomImages) {
            cardTag.Value(image.ToString());
        }

        // Add the card footer if present
        if (PrivateFooter != null) {
            cardTag.Value(PrivateFooter);
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


    public TablerCard Add(Action<TablerCard> config) {
        config(this);
        return this;
    }

    // Enhanced card methods following existing patterns
    public TablerCard AsLink(string url, string? effect = null) {
        IsLink = true;
        LinkUrl = url;
        LinkEffect = effect; // "rotate", "pop", or null
        return this;
    }

    public TablerCard AsActive() {
        IsActive = true;
        return this;
    }

    public TablerCard AsInactive() {
        IsInactive = true;
        return this;
    }

    public TablerCard AsStacked() {
        IsStacked = true;
        return this;
    }

    public TablerCard AsBorderless() {
        IsBorderless = true;
        return this;
    }

    public TablerCard Rotate(string direction) {
        CardRotation = direction; // "left" or "right"
        return this;
    }

    public TablerCard StatusIndicator(string position, TablerColor color) {
        StatusPosition = position; // "top", "bottom", "start", "end"
        StatusColor = color;
        return this;
    }

    public TablerCard Ribbon(string text, TablerColor? color = null, string position = "top") {
        RibbonText = text;
        RibbonColor = color ?? TablerColor.Red;
        RibbonPosition = position;
        return this;
    }

    public TablerCard Ribbon(TablerIconType icon, TablerColor? color = null, string position = "top") {
        RibbonIcon = icon;
        RibbonColor = color ?? TablerColor.Yellow;
        RibbonPosition = position;
        return this;
    }

    public TablerCard Stamp(TablerIconType icon, TablerColor? backgroundColor = null, TablerColor? iconColor = null) {
        StampIcon = icon;
        StampIconBackgroundColor = backgroundColor ?? TablerColor.Yellow;
        StampIconColor = iconColor;
        return this;
    }

    public TablerCard Progress(double percentage, TablerColor? color = null) {
        ProgressValue = Math.Max(0, Math.Min(percentage, 100));
        ProgressColor = color;
        return this;
    }

    public TablerCard Background(TablerColor color, bool isLight = false) {
        BackgroundColor = color;
        IsBackgroundLight = isLight;
        return this;
    }
}
