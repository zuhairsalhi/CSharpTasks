namespace LibraryManagement.App.Models;

/// <summary>
/// Represents a librarian.
/// </summary>
public class Librarian : Person
{
    /// <summary>
    /// Initializes a new librarian.
    /// </summary>
    public Librarian(int id, string name)
        : base(id, name)
    {
    }
}