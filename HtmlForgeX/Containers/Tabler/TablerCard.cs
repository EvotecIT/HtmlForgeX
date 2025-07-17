using System.Linq;

using HtmlForgeX.Extensions;

namespace HtmlForgeX;

/// <summary>
/// Provides a fluent API for building Tabler-styled card components.
/// </summary>
public class TablerCard : Element {
    private TablerCardFooter PrivateFooter { get; set; } = new TablerCardFooter();
    private TablerCardHeader? PrivateHeader { get; set; }
    private TablerCardBody? PrivateBody { get; set; }
    private List<TablerCardImage> CardImages { get; set; } = new List<TablerCardImage>();

    /// <summary>
    /// Gets or sets arbitrary HTML content to place inside the card body.
    /// </summary>
    public string? CardContent { get; set; }

    /// <summary>
    /// Gets or sets custom CSS applied to the inner card container.
    /// </summary>
    public string? CardInnerStyle { get; set; }

    private string? CardOuterStyle { get; set; }

    // Enhanced card properties following existing patterns
    /// <summary>
    /// Gets or sets a value indicating whether the card is rendered as a link.
    /// </summary>
    public bool IsLink { get; set; }

    /// <summary>
    /// Gets or sets the hyperlink URL if <see cref="IsLink"/> is enabled.
    /// </summary>
    public string? LinkUrl { get; set; }

    /// <summary>
    /// Gets or sets the visual effect used when hovering the card link.
    /// </summary>
    public string? LinkEffect { get; set; } // "rotate", "pop", or null for default

    /// <summary>Gets or sets a value indicating whether the card is active.</summary>
    public bool IsActive { get; set; }

    /// <summary>Gets or sets a value indicating whether the card is inactive.</summary>
    public bool IsInactive { get; set; }

    /// <summary>Gets or sets whether the card should stack its child elements.</summary>
    public bool IsStacked { get; set; }

    /// <summary>Gets or sets a value indicating whether the card has no border.</summary>
    public bool IsBorderless { get; set; }

    /// <summary>
    /// Gets or sets the card rotation effect ("left" or "right").
    /// </summary>
    public string? CardRotation { get; set; } // "left", "right", or null

    // Status indicators
    /// <summary>Gets or sets the ribbon/status element position.</summary>
    public string? StatusPosition { get; set; } // "top", "bottom", "start", "end"

    /// <summary>Gets or sets the color of the status ribbon.</summary>
    public TablerColor? StatusColor { get; set; }

    // Ribbon
    /// <summary>Gets or sets optional ribbon text.</summary>
    public string? RibbonText { get; set; }

    /// <summary>Gets or sets an icon displayed inside the ribbon.</summary>
    public TablerIconType? RibbonIcon { get; set; }

    /// <summary>Gets or sets ribbon placement relative to the card.</summary>
    public string? RibbonPosition { get; set; } // "top", "bottom", etc

    /// <summary>Gets or sets the ribbon color.</summary>
    public TablerColor? RibbonColor { get; set; }

    // Stamp
    /// <summary>Gets or sets a small stamp icon shown in the card corner.</summary>
    public TablerIconType? StampIcon { get; set; }

    /// <summary>Gets or sets the background color for the stamp icon.</summary>
    public TablerColor? StampIconBackgroundColor { get; set; }

    /// <summary>Gets or sets the color of the stamp icon.</summary>
    public TablerColor? StampIconColor { get; set; }

    // Progress
    /// <summary>Gets or sets the progress bar value.</summary>
    public double? ProgressValue { get; set; }

    /// <summary>Gets or sets the color of the progress bar.</summary>
    public TablerColor? ProgressColor { get; set; }

    // Background
    /// <summary>Gets or sets the card background color.</summary>
    public TablerColor? BackgroundColor { get; set; }

    /// <summary>Gets or sets a value indicating whether a light background is used.</summary>
    public bool IsBackgroundLight { get; set; }

    /// <summary>
    /// Gets or sets a custom background color used when <see cref="BackgroundColor"/> is <c>null</c>.
    /// </summary>
    public RGBColor? CustomBackgroundColor { get; set; }

    /// <summary>
    /// Gets or sets a custom text color used when <see cref="TextColor"/> is <c>null</c>.
    /// </summary>
    public RGBColor? CustomTextColor { get; set; }

    private int Number { get; set; }

    /// <summary>
    /// Initializes or configures TablerCard.
    /// </summary>
    public TablerCard() {
        // Cards should not have column classes - those belong on the column container
    }

    /// <summary>
    /// Initializes or configures TablerCard.
    /// </summary>
    public TablerCard(int number) {
        // Deprecated: column classes should not be on cards
        // Keep for backward compatibility but don't set column classes
        Number = number;
    }

    /// <summary>
    /// Initializes or configures Content.
    /// </summary>
    public TablerCard Content(string content) {
        CardContent = content;
        return this;
    }

    /// <summary>
    /// Initializes or configures Style.
    /// </summary>
    public TablerCard Style(string style) {
        CardInnerStyle = style;
        return this;
    }

    /// <summary>
    /// Initializes or configures Footer.
    /// </summary>
    public TablerCardFooter Footer() {
        PrivateFooter = new TablerCardFooter();
        return PrivateFooter;
    }


    /// <summary>
    /// Initializes or configures Footer.
    /// </summary>
    public TablerCard Footer(Action<TablerCardFooter> footer) {
        var footerElement = new TablerCardFooter();
        // Ensure Document and Email references are properly set
        footerElement.Document = this.Document;
        footerElement.Email = this.Email;
        footer(footerElement);
        PrivateFooter = footerElement;
        return this;
    }

    /// <summary>
    /// Add a proper header with fluent API (no raw HTML)
    /// </summary>
    public TablerCard Header(Action<TablerCardHeader> header) {
        PrivateHeader = new TablerCardHeader();
        // Ensure Document and Email references are properly set
        PrivateHeader.Document = this.Document;
        PrivateHeader.Email = this.Email;
        header(PrivateHeader);
        return this;
    }

    /// <summary>
    /// Add a proper body with fluent API (no raw HTML)
    /// </summary>
    public TablerCard Body(Action<TablerCardBody> body) {
        PrivateBody = new TablerCardBody();
        // Ensure Document and Email references are properly set
        PrivateBody.Document = this.Document;
        PrivateBody.Email = this.Email;
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

    /// <summary>
    /// Called when this card is added to a document - ensures all child components have Document reference
    /// </summary>
    protected internal override void OnAddedToDocument() {
        // Ensure Document and Email references are propagated to all child components FIRST
        if (PrivateHeader != null) {
            PrivateHeader.Document = this.Document;
            PrivateHeader.Email = this.Email;
            PrivateHeader.OnAddedToDocument();
        }
        if (PrivateBody != null) {
            PrivateBody.Document = this.Document;
            PrivateBody.Email = this.Email;
            PrivateBody.OnAddedToDocument();
        }
        if (PrivateFooter != null) {
            PrivateFooter.Document = this.Document;
            PrivateFooter.Email = this.Email;
            PrivateFooter.OnAddedToDocument();
        }

        // Now call base implementation to register libraries
        base.OnAddedToDocument();
    }

    /// <summary>
    /// Override to ensure child components register their libraries after Document reference is set
    /// </summary>
    protected internal override void RegisterLibraries() {
        // Register libraries for child components that have Document references
        if (PrivateHeader != null && PrivateHeader.Document != null) {
            PrivateHeader.RegisterLibraries();
        }
        if (PrivateBody != null && PrivateBody.Document != null) {
            PrivateBody.RegisterLibraries();
        }
        if (PrivateFooter != null && PrivateFooter.Document != null) {
            PrivateFooter.RegisterLibraries();
        }

        // Call base implementation
        base.RegisterLibraries();
    }

    /// <summary>
    /// Initializes or configures ToString.
    /// </summary>
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

        // Custom RGB background colors
        if (CustomBackgroundColor != null) {
            cardTag.Style("background-color", CustomBackgroundColor.ToString());
            if (CustomTextColor != null) {
                cardTag.Style("color", CustomTextColor.ToString());
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

        // Add background images - these should be applied to the card element itself
        var backgroundImages = CardImages.Where(img => {
            var property = img.GetType().GetProperty("Position", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var pos = property?.GetValue(img)?.ToString();
            return pos == "Background";
        });

        foreach (var image in backgroundImages) {
            // Get the image URL and apply it as background to the card
            var urlProperty = image.GetType().GetProperty("ImageUrl", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var imageUrl = urlProperty?.GetValue(image)?.ToString();

            if (!string.IsNullOrEmpty(imageUrl)) {
                // Check if image is embedded as base64
                var embedProperty = image.GetType().GetProperty("EmbedAsBase64", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                var isEmbedded = (bool)(embedProperty?.GetValue(image) ?? false);

                string finalUrl = imageUrl;
                if (isEmbedded) {
                    var base64Property = image.GetType().GetProperty("Base64Data", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                    var mimeProperty = image.GetType().GetProperty("MimeType", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                    var base64Data = base64Property?.GetValue(image)?.ToString();
                    var mimeType = mimeProperty?.GetValue(image)?.ToString();

                    if (!string.IsNullOrEmpty(base64Data) && !string.IsNullOrEmpty(mimeType)) {
                        finalUrl = "data:" + mimeType + ";base64," + base64Data;
                    }
                }

                cardTag.Style("background-image", "url(" + finalUrl + ")");
                cardTag.Style("background-size", "cover");
                cardTag.Style("background-position", "center");
                classes.Add("card-img-background");

                // Get effect class if any
                var effectProperty = image.GetType().GetProperty("Effect", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                var effect = effectProperty?.GetValue(image);
                if (effect != null) {
                    var effectMethod = effect.GetType().GetMethod("ToTablerImageEffectClass");
                    var effectClass = effectMethod?.Invoke(effect, null)?.ToString();
                    if (!string.IsNullOrEmpty(effectClass)) {
                        classes.Add(effectClass);
                    }
                }
            }
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


    /// <summary>
    /// Initializes or configures Add.
    /// </summary>
    public TablerCard Add(Action<TablerCard> config) {
        config(this);
        return this;
    }

    // Enhanced card methods following existing patterns
    /// <summary>
    /// Initializes or configures AsLink.
    /// </summary>
    public TablerCard AsLink(string url, string? effect = null) {
        IsLink = true;
        LinkUrl = url;
        LinkEffect = effect; // "rotate", "pop", or null
        return this;
    }

    /// <summary>
    /// Initializes or configures AsActive.
    /// </summary>
    public TablerCard AsActive() {
        IsActive = true;
        return this;
    }

    /// <summary>
    /// Initializes or configures AsInactive.
    /// </summary>
    public TablerCard AsInactive() {
        IsInactive = true;
        return this;
    }

    /// <summary>
    /// Initializes or configures AsStacked.
    /// </summary>
    public TablerCard AsStacked() {
        IsStacked = true;
        return this;
    }

    /// <summary>
    /// Initializes or configures AsBorderless.
    /// </summary>
    public TablerCard AsBorderless() {
        IsBorderless = true;
        return this;
    }

    /// <summary>
    /// Initializes or configures Rotate.
    /// </summary>
    public TablerCard Rotate(string direction) {
        CardRotation = direction; // "left" or "right"
        return this;
    }

    /// <summary>
    /// Initializes or configures StatusIndicator.
    /// </summary>
    public TablerCard StatusIndicator(string position, TablerColor color) {
        StatusPosition = position; // "top", "bottom", "start", "end"
        StatusColor = color;
        return this;
    }

    /// <summary>
    /// Initializes or configures Ribbon.
    /// </summary>
    public TablerCard Ribbon(string text, TablerColor? color = null, string position = "top") {
        RibbonText = text;
        RibbonColor = color ?? TablerColor.Red;
        RibbonPosition = position;
        return this;
    }

    /// <summary>
    /// Initializes or configures Ribbon.
    /// </summary>
    public TablerCard Ribbon(TablerIconType icon, TablerColor? color = null, string position = "top") {
        RibbonIcon = icon;
        RibbonColor = color ?? TablerColor.Yellow;
        RibbonPosition = position;
        return this;
    }

    /// <summary>
    /// Initializes or configures Stamp.
    /// </summary>
    public TablerCard Stamp(TablerIconType icon, TablerColor? backgroundColor = null, TablerColor? iconColor = null) {
        StampIcon = icon;
        StampIconBackgroundColor = backgroundColor ?? TablerColor.Yellow;
        StampIconColor = iconColor;
        return this;
    }

    /// <summary>
    /// Initializes or configures Progress.
    /// </summary>
    public TablerCard Progress(double percentage, TablerColor? color = null) {
        ProgressValue = Math.Max(0, Math.Min(percentage, 100));
        ProgressColor = color;
        return this;
    }

    /// <summary>
    /// Initializes or configures Background.
    /// </summary>
    public TablerCard Background(TablerColor color, bool isLight = false) {
        BackgroundColor = color;
        IsBackgroundLight = isLight;
        return this;
    }

    /// <summary>
    /// Set custom background color using RGBColor for precise color control
    /// </summary>
    public TablerCard Background(RGBColor backgroundColor, RGBColor? textColor = null) {
        CustomBackgroundColor = backgroundColor;
        CustomTextColor = textColor;
        return this;
    }

    /// <summary>
    /// Set custom background color using hex string for precise color control
    /// </summary>
    public TablerCard Background(string hexBackgroundColor, string? hexTextColor = null) {
        CustomBackgroundColor = new RGBColor(hexBackgroundColor);
        if (!string.IsNullOrEmpty(hexTextColor)) {
            CustomTextColor = new RGBColor(hexTextColor);
        }
        return this;
    }
}