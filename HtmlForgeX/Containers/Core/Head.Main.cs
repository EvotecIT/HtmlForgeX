using System;
using HtmlForgeX.Logging;

namespace HtmlForgeX;

/// <summary>
/// Core definition for the <see cref="Head"/> element.
/// </summary>
public partial class Head : Element
{
    private static readonly InternalLogger _logger = new();
    private readonly Document _document;

    /// <summary>
    /// Initializes a new instance of the <see cref="Head"/> class.
    /// </summary>
    /// <param name="document">Owning document.</param>
    public Head(Document document)
    {
        _document = document;
    }
}
