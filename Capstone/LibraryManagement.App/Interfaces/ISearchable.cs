namespace LibraryManagement.App.Interfaces;

/// <summary>
/// Defines searchable behavior.
/// </summary>
public interface ISearchable
{
    /// <summary>
    /// Determines whether the object matches a search term.
    /// </summary>
    bool Matches(string searchTerm);
}