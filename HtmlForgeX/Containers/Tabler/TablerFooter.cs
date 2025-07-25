using System.Text;

namespace HtmlForgeX.Containers.Tabler
{
    /// <summary>
    /// Tabler footer component for professional site footers
    /// </summary>
    public class TablerFooter : Element
    {
        private readonly List<TablerFooterColumn> _columns = new();
        private string? _copyright;
        private string? _companyName;
        private string? _companyUrl;
        private readonly List<TablerFooterLink> _bottomLinks = new();
        private readonly List<TablerFooterSocialLink> _socialLinks = new();
        private TablerFooterStyle _style = TablerFooterStyle.Default;
        private bool _sticky = false;
        private bool _transparent = false;

        /// <summary>
        /// Initializes a new instance of the TablerFooter class
        /// </summary>
        public TablerFooter() : base()
        {
        }

        /// <summary>
        /// Registers the required libraries for this component
        /// </summary>
        protected internal override void RegisterLibraries()
        {
            if (Document != null)
            {
                Document.AddLibrary(Libraries.Tabler);
            }
        }

        /// <summary>
        /// Set footer style
        /// </summary>
        public TablerFooter Style(TablerFooterStyle style)
        {
            _style = style;
            return this;
        }

        /// <summary>
        /// Make footer sticky
        /// </summary>
        public TablerFooter Sticky(bool sticky = true)
        {
            _sticky = sticky;
            return this;
        }

        /// <summary>
        /// Make footer transparent
        /// </summary>
        public TablerFooter Transparent(bool transparent = true)
        {
            _transparent = transparent;
            return this;
        }

        /// <summary>
        /// Set copyright text
        /// </summary>
        public TablerFooter Copyright(string text)
        {
            _copyright = text;
            return this;
        }

        /// <summary>
        /// Set company name and URL
        /// </summary>
        public TablerFooter Company(string name, string? url = null)
        {
            _companyName = name;
            _companyUrl = url;
            return this;
        }

        /// <summary>
        /// Add footer column
        /// </summary>
        public TablerFooter Column(string title, Action<TablerFooterColumn> configure)
        {
            var column = new TablerFooterColumn(title);
            configure(column);
            _columns.Add(column);
            return this;
        }

        /// <summary>
        /// Add bottom link
        /// </summary>
        public TablerFooter Link(string text, string href)
        {
            _bottomLinks.Add(new TablerFooterLink { Text = text, Href = href });
            return this;
        }

        /// <summary>
        /// Add social media link
        /// </summary>
        public TablerFooter Social(TablerSocialPlatform platform, string url)
        {
            _socialLinks.Add(new TablerFooterSocialLink { Platform = platform, Url = url });
            return this;
        }

        /// <summary>
        /// Add custom social link
        /// </summary>
        public TablerFooter Social(TablerIconType icon, string url, string? label = null)
        {
            _socialLinks.Add(new TablerFooterSocialLink { Icon = icon, Url = url, Label = label });
            return this;
        }

        /// <summary>
        /// Renders the footer to HTML string
        /// </summary>
        /// <returns>HTML representation of the footer</returns>
        public override string ToString()
        {
            var footer = new HtmlTag("footer");
            footer.Class("footer");
            footer.Class("d-print-none");
            
            if (_style == TablerFooterStyle.Dark)
            {
                footer.Class("footer-dark");
            }
            else if (_style == TablerFooterStyle.Light)
            {
                footer.Class("footer-light");
            }
            else
            {
                footer.Class("footer-transparent");
            }
            
            if (_sticky)
                footer.Class("footer-sticky");
            if (_transparent && _style != TablerFooterStyle.Dark && _style != TablerFooterStyle.Light)
                footer.Class("footer-transparent");

            var container = new HtmlTag("div").Class("container-xl");

            // Multi-column section
            if (_columns.Any())
            {
                var row = new HtmlTag("div").Class("row").Class("text-center").Class("align-items-center").Class("flex-row-reverse");
                
                var socialCol = new HtmlTag("div").Class("col-12").Class("col-lg-auto").Class("mt-3").Class("mt-lg-0");
                if (_socialLinks.Any())
                {
                    socialCol.Value(RenderSocialLinks());
                }
                row.Value(socialCol.ToString());
                
                var linksCol = new HtmlTag("div").Class("col-lg-auto").Class("ms-lg-auto");
                var linksList = new HtmlTag("ul").Class("list-inline").Class("list-inline-dots").Class("mb-0");
                foreach (var column in _columns)
                {
                    foreach (var link in column.Links)
                    {
                        var li = new HtmlTag("li").Class("list-inline-item");
                        var a = new HtmlTag("a").Attribute("href", link.Href).Class("link-secondary").Value(link.Text);
                        li.Value(a.ToString());
                        linksList.Value(li.ToString());
                    }
                }
                linksCol.Value(linksList.ToString());
                row.Value(linksCol.ToString());
                
                var copyrightCol = new HtmlTag("div").Class("col-12").Class("col-lg-auto").Class("mt-3").Class("mt-lg-0");
                copyrightCol.Value(RenderCopyright());
                row.Value(copyrightCol.ToString());
                
                container.Value(row.ToString());
            }
            else
            {
                // Simple footer
                var row = new HtmlTag("div").Class("row").Class("text-center").Class("align-items-center").Class("flex-row-reverse");
                
                // Right side - social links
                if (_socialLinks.Any())
                {
                    var socialCol = new HtmlTag("div").Class("col-lg-auto").Class("ms-lg-auto");
                    socialCol.Value(RenderSocialLinks());
                    row.Value(socialCol.ToString());
                }
                
                // Left side - copyright
                var copyrightCol = new HtmlTag("div").Class("col-12").Class("col-lg-auto").Class("mt-3").Class("mt-lg-0");
                copyrightCol.Value(RenderCopyright());
                row.Value(copyrightCol.ToString());
                
                container.Value(row.ToString());

                // Bottom links
                if (_bottomLinks.Any())
                {
                    var linksRow = new HtmlTag("div").Class("row").Class("text-center").Class("align-items-center").Class("flex-row-reverse");
                    var linksCol = new HtmlTag("div").Class("col-12").Class("col-lg-auto").Class("mt-3").Class("mt-lg-0");
                    var linksList = new HtmlTag("ul").Class("list-inline").Class("list-inline-dots").Class("mb-0");
                    
                    foreach (var link in _bottomLinks)
                    {
                        var li = new HtmlTag("li").Class("list-inline-item");
                        var a = new HtmlTag("a").Attribute("href", link.Href).Class("link-secondary").Value(link.Text);
                        li.Value(a.ToString());
                        linksList.Value(li.ToString());
                    }
                    
                    linksCol.Value(linksList.ToString());
                    linksRow.Value(linksCol.ToString());
                    container.Value(linksRow.ToString());
                }
            }

            footer.Value(container.ToString());
            return footer.ToString();
        }

        /// <summary>
        /// Renders the copyright section
        /// </summary>
        /// <returns>HTML string for the copyright section</returns>
        private string RenderCopyright()
        {
            var list = new HtmlTag("ul").Class("list-inline").Class("list-inline-dots").Class("mb-0");
            var li = new HtmlTag("li").Class("list-inline-item");
            
            if (!string.IsNullOrEmpty(_copyright))
            {
                li.Value(_copyright);
            }
            else
            {
                var year = DateTime.Now.Year;
                var text = $"Copyright &copy; {year}";
                
                if (!string.IsNullOrEmpty(_companyName))
                {
                    if (!string.IsNullOrEmpty(_companyUrl))
                    {
                        var link = new HtmlTag("a").Attribute("href", _companyUrl!).Class("link-secondary").Value(_companyName);
                        text += " " + link.ToString();
                    }
                    else
                    {
                        text += $" {_companyName}";
                    }
                }
                
                li.Value(text + ". All rights reserved.");
            }
            
            list.Value(li.ToString());
            return list.ToString();
        }

        /// <summary>
        /// Renders the social media links section
        /// </summary>
        /// <returns>HTML string for the social links section</returns>
        private string RenderSocialLinks()
        {
            var list = new HtmlTag("ul").Class("list-inline").Class("list-inline-dots").Class("mb-0");
            
            foreach (var social in _socialLinks)
            {
                var li = new HtmlTag("li").Class("list-inline-item");
                var link = new HtmlTag("a");
                link.Attribute("href", social.Url);
                link.Class("link-secondary");
                link.Attribute("target", "_blank");
                link.Attribute("rel", "noopener");
                
                if (!string.IsNullOrEmpty(social.Label))
                {
                    link.Attribute("aria-label", social.Label!);
                }
                else if (social.Platform.HasValue)
                {
                    link.Attribute("aria-label", social.Platform.ToString()!);
                }
                
                if (social.Icon.HasValue)
                {
                    link.Value(TablerIconLibrary.GetIcon(social.Icon.Value).ToString());
                }
                else if (social.Platform.HasValue)
                {
                    var iconType = GetSocialIcon(social.Platform.Value);
                    link.Value(TablerIconLibrary.GetIcon(iconType).ToString());
                }
                
                li.Value(link.ToString());
                list.Value(li.ToString());
            }
            
            return list.ToString();
        }

        /// <summary>
        /// Gets the appropriate icon type for a social platform
        /// </summary>
        /// <param name="platform">Social platform</param>
        /// <returns>Corresponding Tabler icon type</returns>
        private TablerIconType GetSocialIcon(TablerSocialPlatform platform)
        {
            return platform switch
            {
                TablerSocialPlatform.Facebook => TablerIconType.BrandFacebook,
                TablerSocialPlatform.Twitter => TablerIconType.BrandTwitter,
                TablerSocialPlatform.Instagram => TablerIconType.BrandInstagram,
                TablerSocialPlatform.LinkedIn => TablerIconType.BrandLinkedin,
                TablerSocialPlatform.YouTube => TablerIconType.BrandYoutube,
                TablerSocialPlatform.GitHub => TablerIconType.BrandGithub,
                TablerSocialPlatform.Discord => TablerIconType.BrandDiscord,
                TablerSocialPlatform.Slack => TablerIconType.BrandSlack,
                _ => TablerIconType.Link
            };
        }

        /// <summary>
        /// Create footer with fluent configuration
        /// </summary>
        public static TablerFooter Create(Action<TablerFooter> configure)
        {
            var footer = new TablerFooter();
            configure(footer);
            return footer;
        }
    }

    /// <summary>
    /// Footer column with links
    /// </summary>
    public class TablerFooterColumn
    {
        /// <summary>
        /// Gets the column title
        /// </summary>
        public string Title { get; }
        
        /// <summary>
        /// Gets the list of links in this column
        /// </summary>
        public List<TablerFooterLink> Links { get; } = new();

        /// <summary>
        /// Initializes a new instance of the TablerFooterColumn class
        /// </summary>
        /// <param name="title">Column title</param>
        public TablerFooterColumn(string title)
        {
            Title = title;
        }

        /// <summary>
        /// Adds a link to the column
        /// </summary>
        /// <param name="text">Link text</param>
        /// <param name="href">Link href URL</param>
        /// <returns>This TablerFooterColumn instance for method chaining</returns>
        public TablerFooterColumn Link(string text, string href)
        {
            Links.Add(new TablerFooterLink { Text = text, Href = href });
            return this;
        }
    }

    /// <summary>
    /// Footer link
    /// </summary>
    public class TablerFooterLink
    {
        /// <summary>
        /// Gets or sets the link text
        /// </summary>
        public string Text { get; set; } = "";
        
        /// <summary>
        /// Gets or sets the link href URL
        /// </summary>
        public string Href { get; set; } = "";
    }

    /// <summary>
    /// Footer social media link
    /// </summary>
    public class TablerFooterSocialLink
    {
        /// <summary>
        /// Gets or sets the social platform (optional)
        /// </summary>
        public TablerSocialPlatform? Platform { get; set; }
        
        /// <summary>
        /// Gets or sets the custom icon type (optional)
        /// </summary>
        public TablerIconType? Icon { get; set; }
        
        /// <summary>
        /// Gets or sets the social link URL
        /// </summary>
        public string Url { get; set; } = "";
        
        /// <summary>
        /// Gets or sets the accessibility label (optional)
        /// </summary>
        public string? Label { get; set; }
    }

    /// <summary>
    /// Defines footer style options
    /// </summary>
    public enum TablerFooterStyle
    {
        /// <summary>
        /// Default footer style
        /// </summary>
        Default,
        
        /// <summary>
        /// Dark footer style
        /// </summary>
        Dark,
        
        /// <summary>
        /// Light footer style
        /// </summary>
        Light
    }

    /// <summary>
    /// Defines social media platform options
    /// </summary>
    public enum TablerSocialPlatform
    {
        /// <summary>
        /// Facebook social platform
        /// </summary>
        Facebook,
        
        /// <summary>
        /// Twitter social platform
        /// </summary>
        Twitter,
        
        /// <summary>
        /// Instagram social platform
        /// </summary>
        Instagram,
        
        /// <summary>
        /// LinkedIn social platform
        /// </summary>
        LinkedIn,
        
        /// <summary>
        /// YouTube social platform
        /// </summary>
        YouTube,
        
        /// <summary>
        /// GitHub social platform
        /// </summary>
        GitHub,
        
        /// <summary>
        /// Discord social platform
        /// </summary>
        Discord,
        
        /// <summary>
        /// Slack social platform
        /// </summary>
        Slack
    }
}
