namespace HtmlForgeX;

/// <summary>
/// Represents an email library containing only inline CSS. These
/// libraries are tailored specifically for the restrictive environment
/// of email clients and therefore do not include any external resources
/// or JavaScript.
/// </summary>
public class EmailLibrary {
    /// <summary>
    /// Gets or sets the name of the library.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the version of the library.
    /// </summary>
    public string Version { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description of the library.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Collection of inline CSS content.
    /// </summary>
    public List<string> InlineCss { get; set; } = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailLibrary"/> class.
    /// </summary>
    public EmailLibrary() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailLibrary"/> class with basic information.
    /// </summary>
    /// <param name="name">The name of the library.</param>
    /// <param name="version">The version of the library.</param>
    /// <param name="description">The description of the library.</param>
    public EmailLibrary(string name, string version = "", string description = "") {
        Name = name;
        Version = version;
        Description = description;
    }

    /// <summary>
    /// Adds inline CSS to the library.
    /// </summary>
    /// <param name="css">The CSS content to add.</param>
    /// <returns>The EmailLibrary object, allowing for method chaining.</returns>
    public EmailLibrary AddCss(string css) {
        if (!InlineCss.Contains(css)) {
            InlineCss.Add(css);
        }

        return this;
    }
}

/// <summary>
/// Converter for mapping email library enums to library objects.
/// </summary>
public static class EmailLibrariesConverter {
    /// <summary>
    /// Maps an email library enum to its corresponding library object.
    /// </summary>
    /// <param name="library">The library enum to map.</param>
    /// <returns>The corresponding EmailLibrary object.</returns>
    public static EmailLibrary MapLibraryEnumToLibraryObject(EmailLibraries library) {
        return library switch {
            EmailLibraries.EmailCore => GetEmailCoreLibrary(),
            EmailLibraries.TablerEmail => GetTablerEmailLibrary(),
            EmailLibraries.EmailButtons => GetEmailButtonsLibrary(),
            EmailLibraries.EmailTables => GetEmailTablesLibrary(),
            _ => new EmailLibrary()
        };
    }

    private static EmailLibrary GetEmailCoreLibrary() {
        var library = new EmailLibrary("EmailCore", "1.0.0", "Core email styling and layout components");

        var coreStyles = @"
        /* Email Core Styles */
        .btn {
            color: #ffffff;
            text-decoration: none;
            white-space: nowrap;
            font-weight: 500;
            font-size: 16px;
            border-radius: 8px;
            line-height: 125%;
            display: block;
            padding: 12px 32px;
            border: 1px solid;
        }

        .btn-span {
            font-size: 14px;
            text-decoration: none;
            white-space: nowrap;
            font-weight: 500;
            line-height: 100%;
        }

        .bg-blue {
            background-color: #066FD1;
            border-color: #066FD1;
        }

        .bg-secondary {
            background-color: #f0f1f3;
            border-color: #e8ebee;
        }

        .box {
            background-color: #ffffff;
            border-radius: 8px;
            -webkit-box-shadow: 0 1px 4px rgba(0, 0, 0, 0.05);
            box-shadow: 0 1px 4px rgba(0, 0, 0, 0.05);
            border: 1px solid #e8ebee;
        }

        .content {
            padding: 48px;
        }

        .text-center {
            text-align: center;
        }

        .text-right {
            text-align: right;
        }

        .text-muted {
            color: #667382;
        }

        .rounded {
            border-radius: 4px;
        }

        .p-lg {
            padding: 24px;
        }

        .bg-light {
            background-color: #f6f6f6;
        }

        .font-strong {
            font-weight: 600;
        }

        .h1 {
            font-size: 30px;
            line-height: 126%;
            color: #111827;
            margin: 0;
        }

        .h2 {
            font-size: 24px;
            line-height: 130%;
            color: #111827;
            margin: 0;
        }

        .h3 {
            font-size: 20px;
            line-height: 120%;
            color: #111827;
            margin: 0;
        }

        .h4 {
            font-size: 16px;
            font-weight: 500;
            color: #111827;
            margin: 0 0 0.5em;
        }

        /* Dark mode styles */
        .theme-dark .box {
            background-color: #2b3648 !important;
            color: rgba(255, 255, 255, 0.7) !important;
            border-color: #2b3648 !important;
        }

        .theme-dark .text-muted {
            color: rgba(255, 255, 255, 0.4) !important;
        }

        .theme-dark .h1, .theme-dark .h2, .theme-dark .h3, .theme-dark .h4 {
            color: rgba(255, 255, 255, 0.9) !important;
        }

        /* Dark mode body and backgrounds */
        .theme-dark body {
            background-color: #1f2937 !important;
            color: rgba(255, 255, 255, 0.8) !important;
        }

        .theme-dark .main {
            background-color: #1f2937 !important;
        }

        /* Dark mode buttons */
        .theme-dark .btn {
            background-color: #374151 !important;
            border-color: #4b5563 !important;
            color: rgba(255, 255, 255, 0.9) !important;
        }

        .theme-dark .bg-blue {
            background-color: #1d4ed8 !important;
            border-color: #1d4ed8 !important;
        }

        .theme-dark .bg-secondary {
            background-color: #374151 !important;
            border-color: #4b5563 !important;
            color: rgba(255, 255, 255, 0.8) !important;
        }

        /* Dark mode text colors */
        .theme-dark .text-center,
        .theme-dark .text-right,
        .theme-dark .text-left {
            color: rgba(255, 255, 255, 0.8) !important;
        }

        /* Dark mode backgrounds */
        .theme-dark .bg-light {
            background-color: #374151 !important;
        }

        /* Dark mode links */
        .theme-dark a {
            color: #60a5fa !important;
        }

        .theme-dark a:hover {
            color: #93c5fd !important;
        }

        /* Dark mode tables */
        .theme-dark .email-table th {
            color: rgba(255, 255, 255, 0.6) !important;
            background-color: #374151 !important;
        }

        .theme-dark .email-table td {
            color: rgba(255, 255, 255, 0.8) !important;
            border-color: #4b5563 !important;
        }

        .theme-dark .email-table .border-top {
            border-color: #4b5563 !important;
        }

        .theme-dark .email-table .product-image {
            background-color: #4b5563 !important;
        }

        .theme-dark .email-table .product-description {
            color: rgba(255, 255, 255, 0.6) !important;
        }

        /* Enhanced dark mode table styling */
        .theme-dark .email-table {
            background-color: #2b3648 !important;
            border-color: #4b5563 !important;
        }

        .theme-dark .email-table tbody tr:nth-child(even) {
            background-color: #374151 !important;
        }

        .theme-dark .email-table tbody tr:nth-child(odd) {
            background-color: #2b3648 !important;
        }

        .theme-dark .email-table tbody tr:hover {
            background-color: #4b5563 !important;
        }

        .theme-dark .email-table th {
            background-color: #1f2937 !important;
            color: rgba(255, 255, 255, 0.9) !important;
            border-bottom: 2px solid #4b5563 !important;
        }

        .theme-dark .email-table td {
            border-top: 1px solid #4b5563 !important;
            border-bottom: 1px solid #4b5563 !important;
        }

        .theme-dark .email-table .text-muted {
            color: rgba(255, 255, 255, 0.5) !important;
        }

        .theme-dark .email-table .rounded {
            background-color: #374151 !important;
        }

        .theme-dark .email-table .bg-light {
            background-color: #374151 !important;
        }

        /* Auto dark mode table styling */
        @media (prefers-color-scheme: dark) {
            .auto-dark-mode .email-table {
                background-color: #2b3648 !important;
                border-color: #4b5563 !important;
            }

            .auto-dark-mode .email-table th {
                background-color: #1f2937 !important;
                color: rgba(255, 255, 255, 0.9) !important;
                border-bottom: 2px solid #4b5563 !important;
            }

            .auto-dark-mode .email-table td {
                color: rgba(255, 255, 255, 0.8) !important;
                border-color: #4b5563 !important;
            }

            .auto-dark-mode .email-table tbody tr:nth-child(even) {
                background-color: #374151 !important;
            }

            .auto-dark-mode .email-table tbody tr:nth-child(odd) {
                background-color: #2b3648 !important;
            }

            /* Restore other auto dark mode styles */
            .auto-dark-mode .box {
                background-color: #2b3648 !important;
                color: rgba(255, 255, 255, 0.7) !important;
                border-color: #2b3648 !important;
            }

            .auto-dark-mode .text-muted {
                color: rgba(255, 255, 255, 0.4) !important;
            }

            .auto-dark-mode .h1, .auto-dark-mode .h2, .auto-dark-mode .h3, .auto-dark-mode .h4 {
                color: rgba(255, 255, 255, 0.9) !important;
            }

            .auto-dark-mode body {
                background-color: #1f2937 !important;
                color: rgba(255, 255, 255, 0.8) !important;
            }

            .auto-dark-mode .main {
                background-color: #1f2937 !important;
            }

            .auto-dark-mode .bg-blue {
                background-color: #1d4ed8 !important;
                border-color: #1d4ed8 !important;
            }

            .auto-dark-mode .bg-secondary {
                background-color: #374151 !important;
                border-color: #4b5563 !important;
                color: rgba(255, 255, 255, 0.8) !important;
            }

            .auto-dark-mode a {
                color: #60a5fa !important;
            }

            /* Dark mode image swapping for auto mode */
            .auto-dark-mode .dark-img {
                display: block !important;
                width: auto !important;
                overflow: visible !important;
                float: none !important;
                max-height: inherit !important;
                max-width: inherit !important;
                line-height: auto !important;
                margin-top: 0px !important;
                visibility: inherit !important;
            }

            .auto-dark-mode .light-img {
                display: none !important;
            }
        }

        /* Dark mode image swapping CSS */
        .theme-dark .dark-img {
            display: block !important;
            width: auto !important;
            overflow: visible !important;
            float: none !important;
            max-height: inherit !important;
            max-width: inherit !important;
            line-height: auto !important;
            margin-top: 0px !important;
            visibility: inherit !important;
        }

        .theme-dark .light-img {
            display: none !important;
        }

        /* Outlook-specific dark mode image support */
        [data-ogsc] .dark-img {
            display: block !important;
            width: auto !important;
            overflow: visible !important;
            float: none !important;
            max-height: inherit !important;
            max-width: inherit !important;
            line-height: auto !important;
            margin-top: 0px !important;
            visibility: inherit !important;
        }

        [data-ogsc] .light-img {
            display: none !important;
        }

        /* Enhanced link styling for dark mode */
        .theme-dark a {
            color: #60a5fa !important;
            text-decoration: none !important;
        }

        .theme-dark a:hover {
            color: #93c5fd !important;
            text-decoration: underline !important;
        }

        .theme-dark a:visited {
            color: #a78bfa !important;
        }

        .theme-dark a:active {
            color: #c4b5fd !important;
        }";

        library.AddCss(coreStyles);
        return library;
    }

    private static EmailLibrary GetTablerEmailLibrary() {
        var library = new EmailLibrary("TablerEmail", "1.0.0", "Tabler-based email components and styling");

        var tablerStyles = @"
        /* Tabler Email Styles */
        .tabler-header {
            padding-top: 24px;
            padding-bottom: 24px;
        }

        .tabler-footer {
            padding-top: 48px;
            padding-bottom: 48px;
            color: #667382;
            text-align: center;
        }

        .social-links {
            width: auto;
        }

        .social-link {
            padding-right: 8px;
            padding-left: 8px;
        }

        .social-icon {
            vertical-align: middle;
            width: 24px;
            height: 24px;
        }

        .logo {
            width: 114px;
            height: 32px;
        }

        .view-online {
            color: #8491a1;
            text-decoration: none;
        }";

        library.AddCss(tablerStyles);
        return library;
    }

    private static EmailLibrary GetEmailButtonsLibrary() {
        var library = new EmailLibrary("EmailButtons", "1.0.0", "Email-compatible button components");

        var buttonStyles = @"
        /* Email Button Styles */
        .email-button-table {
            border-collapse: separate;
            width: 100%;
            border-radius: 8px;
        }

        .email-button-cell {
            line-height: 100%;
        }

        .email-button {
            color: #ffffff;
            text-decoration: none;
            white-space: nowrap;
            font-weight: 500;
            font-size: 16px;
            border-radius: 8px;
            line-height: 125%;
            display: block;
            padding: 12px 32px;
            border: 1px solid;
        }

        .email-button-primary {
            background-color: #066FD1;
            border-color: #066FD1;
            color: #ffffff;
        }

        .email-button-secondary {
            background-color: #ffffff;
            border-color: #e8ebee;
            color: #4b5563;
        }

        .email-button:hover {
            text-decoration: none !important;
        }";

        library.AddCss(buttonStyles);
        return library;
    }

    private static EmailLibrary GetEmailTablesLibrary() {
        var library = new EmailLibrary("EmailTables", "1.0.0", "Email-compatible table components");

        var tableStyles = @"
        /* Email Table Styles */
        .email-table {
            border-collapse: collapse;
            width: 100%;
        }

        .email-table th {
            text-transform: uppercase;
            font-weight: 600;
            color: #667382;
            font-size: 12px;
            padding: 0 0 4px;
        }

        .email-table td {
            padding: 4px 12px;
            font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif;
        }

        .email-table .border-top {
            border-top: 1px solid #e8ebee;
        }

        .email-table .product-image {
            width: 64px;
            height: 64px;
            background-color: #f6f6f6;
            border-radius: 4px;
        }

        .email-table .product-name {
            font-weight: 600;
        }

        .email-table .product-description {
            color: #667382;
        }

        .row-table {
            border-collapse: collapse;
            width: 100%;
            table-layout: fixed;
        }

        .col-cell {
            vertical-align: top;
        }

        .col-spacer {
            width: 24px;
        }";

        library.AddCss(tableStyles);
        return library;
    }
}