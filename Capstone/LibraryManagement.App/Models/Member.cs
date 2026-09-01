namespace LibraryManagement.App.Models;

/// <summary>
/// Represents a library member.
/// </summary>
public class Member : Person
{
    /// <summary>
    /// Gets the books currently borrowed by the member.
    /// </summary>
    public List<Book> BorrowedBooks { get; } = new();

    /// <summary>
    /// Initializes a new library member.
    /// </summary>
    public Member(int id, string name)
        : base(id, name)
    {
    }
}