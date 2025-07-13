namespace HtmlForgeX;

public class Span : Element {
    public string? Content { get; set; }
    public RGBColor? Color { get; set; }
    public RGBColor? BackGroundColor { get; set; }
    public string? FontSize { get; set; }
    public string? LineHeight { get; set; }
    public FontWeight? FontWeight { get; set; }
    public FontStyle? FontStyle { get; set; }
    public FontVariant? FontVariant { get; set; }
    public string? FontFamily { get; set; }
    public Alignment? Alignment { get; set; }
    public TextDecoration? TextDecoration { get; set; }
    public TextTransform? TextTransform { get; set; }
    public Direction? Direction { get; set; }
    public Display? Display { get; set; }
    public double? Opacity { get; set; }

    public List<Span> HtmlSpans { get; } = new List<Span>();
    private Span Parent { get; set; }
    private Span _rootParent; // Track the root parent for AppendContent chains
    
    public Span(Span? parent = null) {
        this.Parent = parent ?? this;  // If no parent is provided, assume this is the root.
        this._rootParent = this.Parent;
    }

    public virtual Span AppendContent(string content) {
        var newSpan = new Span(this) {
            Content = content
        };
        // Keep appended spans on the parent collection so they appear
        // alongside the original span when rendered.
        this.Parent.HtmlSpans.Add(newSpan);
        
        // Create a wrapper span that represents the entire chain
        // This wrapper will always return the root parent so users can add it to the document
        var chainWrapper = new AppendContentChain(this._rootParent, newSpan);
        return chainWrapper;
    }
    
    // Inner class to handle AppendContent chains properly
    private class AppendContentChain : Span {
        private readonly new Span _rootParent;
        private readonly Span _currentSpan;
        
        public AppendContentChain(Span rootParent, Span currentSpan) : base(rootParent) {
            this._rootParent = rootParent;
            this._currentSpan = currentSpan;
        }
        
        public override Span WithColor(RGBColor color) {
            _currentSpan.Color = color;
            return _rootParent;
        }
        
        public override Span WithBackgroundColor(RGBColor backgroundColor) {
            _currentSpan.BackGroundColor = backgroundColor;
            return _rootParent;
        }
        
        public override Span WithFontSize(string fontSize) {
            _currentSpan.FontSize = fontSize;
            return _rootParent;
        }
        
        public override Span WithFontWeight(FontWeight fontWeight) {
            _currentSpan.FontWeight = fontWeight;
            return _rootParent;
        }
        
        public override Span WithFontStyle(FontStyle fontStyle) {
            _currentSpan.FontStyle = fontStyle;
            return _rootParent;
        }
        
        public override Span WithAlignment(Alignment alignment) {
            _currentSpan.Alignment = alignment;
            return _rootParent;
        }
        
        public override Span WithOpacity(double? opacity) {
            _currentSpan.Opacity = opacity;
            return _rootParent;
        }
        
        public override Span WithLineHeight(string lineHeight) {
            _currentSpan.LineHeight = lineHeight;
            return _rootParent;
        }
        
        public override Span WithFontVariant(FontVariant fontVariant) {
            _currentSpan.FontVariant = fontVariant;
            return _rootParent;
        }
        
        public override Span WithFontFamily(string fontFamily) {
            _currentSpan.FontFamily = fontFamily;
            return _rootParent;
        }
        
        public override Span WithTextDecoration(TextDecoration textDecoration) {
            _currentSpan.TextDecoration = textDecoration;
            return _rootParent;
        }
        
        public override Span WithTextTransform(TextTransform textTransform) {
            _currentSpan.TextTransform = textTransform;
            return _rootParent;
        }
        
        public override Span WithDirection(Direction direction) {
            _currentSpan.Direction = direction;
            return _rootParent;
        }
        
        public override Span WithDisplay(Display display) {
            _currentSpan.Display = display;
            return _rootParent;
        }
        
        public override Span AppendContent(string content) {
            // Delegate to root parent's AppendContent
            return _rootParent.AppendContent(content);
        }
        
        public override string ToString() {
            // Always render the complete root parent chain
            return _rootParent.ToString();
        }
    }
    
    // Inner class to handle AddContent chains properly
    private class AddContentChain : Span {
        private readonly new Span _rootParent;
        private readonly Span _currentSpan;
        
        public AddContentChain(Span rootParent, Span currentSpan) : base() {
            this._rootParent = rootParent;
            this._currentSpan = currentSpan;
        }
        
        public override Span WithColor(RGBColor color) {
            _currentSpan.Color = color;
            return this; // Return this wrapper to maintain the same reference while continuing to style current span
        }
        
        public override Span WithBackgroundColor(RGBColor backgroundColor) {
            _currentSpan.BackGroundColor = backgroundColor;
            return this;
        }
        
        public override Span WithFontSize(string fontSize) {
            _currentSpan.FontSize = fontSize;
            return this;
        }
        
        public override Span WithFontWeight(FontWeight fontWeight) {
            _currentSpan.FontWeight = fontWeight;
            return this;
        }
        
        public override Span WithFontStyle(FontStyle fontStyle) {
            _currentSpan.FontStyle = fontStyle;
            return this;
        }
        
        public override Span WithAlignment(Alignment alignment) {
            _currentSpan.Alignment = alignment;
            return this;
        }
        
        public override Span WithOpacity(double? opacity) {
            _currentSpan.Opacity = opacity;
            return this;
        }
        
        public override Span WithLineHeight(string lineHeight) {
            _currentSpan.LineHeight = lineHeight;
            return this;
        }
        
        public override Span WithFontVariant(FontVariant fontVariant) {
            _currentSpan.FontVariant = fontVariant;
            return this;
        }
        
        public override Span WithFontFamily(string fontFamily) {
            _currentSpan.FontFamily = fontFamily;
            return this;
        }
        
        public override Span WithTextDecoration(TextDecoration textDecoration) {
            _currentSpan.TextDecoration = textDecoration;
            return this;
        }
        
        public override Span WithTextTransform(TextTransform textTransform) {
            _currentSpan.TextTransform = textTransform;
            return this;
        }
        
        public override Span WithDirection(Direction direction) {
            _currentSpan.Direction = direction;
            return this;
        }
        
        public override Span WithDisplay(Display display) {
            _currentSpan.Display = display;
            return this;
        }
        
        public override Span AddContent(string content) {
            // Delegate to root parent's AddContent
            return _rootParent.AddContent(content);
        }
        
        public override Span AppendContent(string content) {
            // For AppendContent, we need to add the span to the same parent collection as the current span
            var newSpan = new Span(_rootParent) {
                Content = content
            };
            _rootParent.HtmlSpans.Add(newSpan);
            
            // Return an AppendContentChain wrapper that points to the same root
            var appendWrapper = new AppendContentChain(_rootParent, newSpan);
            return appendWrapper;
        }
        
        public override string ToString() {
            // Always render the complete root parent 
            return _rootParent.ToString();
        }
    }

    public virtual Span AddContent(string content) {
        var newSpan = new Span { Content = content };
        this.Add(newSpan);  // Add to children of this HtmlElement
        
        // Create a wrapper that represents the chain but applies styling to the new span
        var chainWrapper = new AddContentChain(this, newSpan);
        return chainWrapper;
    }

    public Span Add(string content) {
        var newSpan = new Span { Content = content };
        this.Add(newSpan);  // Add to children of this HtmlElement
        return newSpan;  // Return new span for modification
    }

    public virtual Span WithColor(RGBColor color) {
        this.Color = color;
        return this;
    }

    public virtual Span WithBackgroundColor(RGBColor backgroundColor) {
        BackGroundColor = backgroundColor;
        return this;
    }


    public virtual Span WithFontSize(string fontSize) {
        FontSize = fontSize;
        return this;
    }

    public virtual Span WithLineHeight(string lineHeight) {
        LineHeight = lineHeight;
        return this;
    }

    public virtual Span WithFontWeight(FontWeight fontWeight) {
        FontWeight = fontWeight;
        return this;
    }

    public virtual Span WithFontStyle(FontStyle fontStyle) {
        FontStyle = fontStyle;
        return this;
    }

    public virtual Span WithFontVariant(FontVariant fontVariant) {
        FontVariant = fontVariant;
        return this;
    }

    public virtual Span WithFontFamily(string fontFamily) {
        FontFamily = fontFamily;
        return this;
    }

    public virtual Span WithAlignment(Alignment alignment) {
        Alignment = alignment;
        return this;
    }

    public virtual Span WithTextDecoration(TextDecoration textDecoration) {
        TextDecoration = textDecoration;
        return this;
    }

    public virtual Span WithTextTransform(TextTransform textTransform) {
        TextTransform = textTransform;
        return this;
    }

    public virtual Span WithDirection(Direction direction) {
        Direction = direction;
        return this;
    }

    public virtual Span WithDisplay(Display display) {
        Display = display;
        return this;
    }

    public virtual Span WithOpacity(double? opacity) {
        Opacity = opacity;
        return this;
    }

    /// <summary>
    /// Adds colored text to the parent. This creates a new span for the text and returns the parent span for chaining.
    /// </summary>
    /// <param name="text">The text content.</param>
    /// <param name="color">The text color.</param>
    /// <returns>The parent span for method chaining.</returns>
    public Span AddColoredText(string text, RGBColor color) {
        var newSpan = new Span(this) {
            Content = text,
            Color = color
        };
        this.Parent.HtmlSpans.Add(newSpan);
        return this.Parent; // Return parent for chaining
    }

    /// <summary>
    /// Adds styled text to the parent. This creates a new span for the text and returns the parent span for chaining.
    /// </summary>
    /// <param name="text">The text content.</param>
    /// <param name="color">Optional text color.</param>
    /// <param name="fontSize">Optional font size.</param>
    /// <param name="fontWeight">Optional font weight.</param>
    /// <returns>The parent span for method chaining.</returns>
    public Span AddStyledText(string text, RGBColor? color = null, string? fontSize = null, FontWeight? fontWeight = null) {
        var newSpan = new Span(this) {
            Content = text
        };
        if (color != null) newSpan.Color = color;
        if (fontSize != null) newSpan.FontSize = fontSize;
        if (fontWeight != null) newSpan.FontWeight = fontWeight;
        
        this.Parent.HtmlSpans.Add(newSpan);
        return this.Parent; // Return parent for chaining
    }

    public string GenerateStyle() {
        var style = new List<string>();

        if (Color != null) style.Add($"color: {Color.ToHex()}");
        if (BackGroundColor != null) style.Add($"background-color: {BackGroundColor.ToHex()}");
        if (FontSize != null) style.Add($"font-size: {FontSize}");
        if (LineHeight != null) style.Add($"line-height: {LineHeight}");
        if (FontWeight != null) style.Add($"font-weight: {FontWeight?.EnumToString()}");
        if (FontStyle != null) style.Add($"font-style: {FontStyle}");
        if (FontVariant != null) style.Add($"font-variant: {FontVariant?.EnumToString()}");
        if (FontFamily != null) style.Add($"font-family: {FontFamily}");
        if (Alignment != null) style.Add($"text-align: {Alignment}");
        if (TextDecoration != null) style.Add($"text-decoration: {TextDecoration?.EnumToString()}");
        if (TextTransform != null) style.Add($"text-transform: {TextTransform}");
        if (Direction != null) style.Add($"direction: {Direction}");
        if (Display != null) style.Add($"display: {Display?.EnumToString()}");
        if (Opacity != null) style.Add($"opacity: {Opacity}");

        var styleString = string.Join("; ", style);
        return styleString;
    }

    public override string ToString() {
        var styleString = GenerateStyle();
        styleString = !string.IsNullOrEmpty(styleString) ? $" style=\"{Helpers.HtmlEncode(styleString)}\"" : "";

        var childrenHtml = string.Join("", Children.Select(child => child.ToString()));

        var childrenParentHtml = string.Join("", this.Parent.HtmlSpans.Select(child => {
            var childStyle = child.GenerateStyle();
            childStyle = !string.IsNullOrEmpty(childStyle) ? $" style=\"{Helpers.HtmlEncode(childStyle)}\"" : "";
            var content = Helpers.HtmlEncode(child.Content ?? string.Empty);
            return $"<span{childStyle}>{content}</span>";
        }));

        var mainContent = Helpers.HtmlEncode(Content ?? string.Empty);
        
        // If this is a child span created by AppendContent, and it has siblings,
        // render the entire parent chain to ensure all content appears
        if (this.Parent != this && this.Parent.HtmlSpans.Count > 0) {
            // This span is part of an AppendContent chain
            var parentStyleString = this.Parent.GenerateStyle();
            parentStyleString = !string.IsNullOrEmpty(parentStyleString) ? $" style=\"{Helpers.HtmlEncode(parentStyleString)}\"" : "";
            var parentContent = Helpers.HtmlEncode(this.Parent.Content ?? string.Empty);
            
            return $"<span{parentStyleString}>{parentContent}</span>{childrenParentHtml}";
        }
        
        return $"<span{styleString}>{mainContent}{childrenHtml}</span>{childrenParentHtml}";
    }
}
