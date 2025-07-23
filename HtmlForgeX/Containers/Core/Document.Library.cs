namespace HtmlForgeX;

public partial class Document
{
    /// <summary>
    /// Adds a predefined library.
    /// </summary>
    /// <param name="library">Library identifier.</param>
    public void AddLibrary(Libraries library)
    {
        Configuration.Libraries.TryAdd(library, 0);
    }

    /// <summary>
    /// Adds a predefined library with a custom load order weight.
    /// </summary>
    /// <param name="library">Library identifier.</param>
    /// <param name="weight">Ordering weight. Lower values load first.</param>
    public void AddLibrary(Libraries library, byte weight)
    {
        Configuration.Libraries.AddOrUpdate(library, weight, (_, _) => weight);
    }

    /// <summary>
    /// Adds a custom library definition.
    /// </summary>
    /// <param name="library">Library to add.</param>
    /// <returns><see langword="true"/> if the library was added successfully; otherwise <see langword="false"/>.</returns>
    public bool AddLibrary(Library library)
    {
        return LibraryRegistrar.RegisterLibrary(this, this.Head, library, true);
    }
}

