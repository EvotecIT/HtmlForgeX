namespace HtmlForgeX;

/// <summary>
/// Defines predefined table styles for email components.
/// </summary>
public enum EmailTableStyle {
    /// <summary>Simple clean table with minimal styling</summary>
    Simple,
    /// <summary>Striped table with alternating row colors</summary>
    Striped,
    /// <summary>Bordered table with borders around cells</summary>
    Bordered,
    /// <summary>Compact table with reduced padding</summary>
    Compact,
    /// <summary>Feature comparison table with enhanced styling</summary>
    FeatureComparison,
    /// <summary>Data report table with professional styling</summary>
    DataReport,
    /// <summary>Invoice table with billing-specific styling</summary>
    Invoice,
    /// <summary>Team members table with contact styling</summary>
    TeamMembers,
    /// <summary>Product catalog table with e-commerce styling</summary>
    ProductCatalog,
    /// <summary>Statistics table with metrics styling</summary>
    Statistics
}

/// <summary>
/// Extension helpers for <see cref="EmailTableStyle"/>.
/// </summary>
public static class EmailTableStyleExtensions {
    public static (string cssClass, bool striped, bool bordered, string headerStyle, string cellStyle, string borderColor, string stripeColor) GetStyle(this EmailTableStyle style) {
        return style switch {
            EmailTableStyle.Simple => (
                "email-table-simple",
                false,
                false,
                "text-transform: uppercase; font-weight: 600; color: #667382; font-size: 12px; background-color: #f8fafc; text-align: left; vertical-align: top;",
                "color: #374151; font-size: 14px; line-height: 1.5; text-align: left; vertical-align: top;",
                "#e5e7eb",
                "#f9fafb"
            ),
            EmailTableStyle.Striped => (
                "email-table-striped",
                true,
                false,
                "text-transform: uppercase; font-weight: 600; color: #667382; font-size: 12px; background-color: #f8fafc; text-align: left; vertical-align: top;",
                "color: #374151; font-size: 14px; line-height: 1.5; text-align: left; vertical-align: top;",
                "#e5e7eb",
                "#f9fafb"
            ),
            EmailTableStyle.Bordered => (
                "email-table-bordered",
                false,
                true,
                "text-transform: uppercase; font-weight: 600; color: #667382; font-size: 12px; background-color: #f8fafc; border-bottom: 2px solid #e5e7eb; text-align: left; vertical-align: top;",
                "color: #374151; font-size: 14px; line-height: 1.5; border-bottom: 1px solid #e5e7eb; text-align: left; vertical-align: top;",
                "#e5e7eb",
                "#f9fafb"
            ),
            EmailTableStyle.Compact => (
                "email-table-compact",
                false,
                false,
                "text-transform: uppercase; font-weight: 600; color: #667382; font-size: 11px; background-color: #f8fafc; text-align: left; vertical-align: top;",
                "color: #374151; font-size: 13px; line-height: 1.4; text-align: left; vertical-align: top;",
                "#e5e7eb",
                "#f9fafb"
            ),
            EmailTableStyle.FeatureComparison => (
                "email-table-feature-comparison",
                true,
                true,
                "text-transform: uppercase; font-weight: 700; color: #ffffff; font-size: 12px; background-color: #4f46e5; text-align: center; vertical-align: top;",
                "color: #374151; font-size: 14px; line-height: 1.5; text-align: center; border-bottom: 1px solid #e5e7eb; vertical-align: top;",
                "#d1d5db",
                "#f3f4f6"
            ),
            EmailTableStyle.DataReport => (
                "email-table-data-report",
                true,
                false,
                "text-transform: uppercase; font-weight: 600; color: #374151; font-size: 12px; background-color: #f3f4f6; border-bottom: 1px solid #d1d5db; text-align: left; vertical-align: top;",
                "color: #1f2937; font-size: 14px; line-height: 1.5; font-weight: 500; text-align: left; vertical-align: top;",
                "#d1d5db",
                "#f9fafb"
            ),
            EmailTableStyle.Invoice => (
                "email-table-invoice",
                false,
                true,
                "text-transform: uppercase; font-weight: 600; color: #374151; font-size: 12px; background-color: #f8fafc; border-bottom: 2px solid #059669; text-align: left; vertical-align: top;",
                "color: #374151; font-size: 14px; line-height: 1.5; border-bottom: 1px solid #e5e7eb; text-align: left; vertical-align: top;",
                "#e5e7eb",
                "#f9fafb"
            ),
            EmailTableStyle.TeamMembers => (
                "email-table-team-members",
                true,
                false,
                "text-transform: uppercase; font-weight: 600; color: #4f46e5; font-size: 12px; background-color: #f8fafc; text-align: left; vertical-align: top;",
                "color: #374151; font-size: 14px; line-height: 1.5; text-align: left; vertical-align: top;",
                "#e5e7eb",
                "#f8fafc"
            ),
            EmailTableStyle.ProductCatalog => (
                "email-table-product-catalog",
                true,
                true,
                "text-transform: uppercase; font-weight: 600; color: #ffffff; font-size: 12px; background-color: #059669; text-align: center; vertical-align: top;",
                "color: #374151; font-size: 14px; line-height: 1.5; text-align: center; border-bottom: 1px solid #e5e7eb; vertical-align: top;",
                "#d1d5db",
                "#f0fdf4"
            ),
            EmailTableStyle.Statistics => (
                "email-table-statistics",
                false,
                true,
                "text-transform: uppercase; font-weight: 700; color: #1f2937; font-size: 12px; background-color: #f3f4f6; border-bottom: 2px solid #6b7280; text-align: left; vertical-align: top;",
                "color: #374151; font-size: 16px; line-height: 1.5; font-weight: 600; border-bottom: 1px solid #e5e7eb; text-align: left; vertical-align: top;",
                "#9ca3af",
                "#f9fafb"
            ),
            _ => (
                "email-table-simple",
                false,
                false,
                "text-transform: uppercase; font-weight: 600; color: #667382; font-size: 12px; background-color: #f8fafc; text-align: left; vertical-align: top;",
                "color: #374151; font-size: 14px; line-height: 1.5; text-align: left; vertical-align: top;",
                "#e5e7eb",
                "#f9fafb"
            )
        };
    }
}