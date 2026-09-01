using LibraryManagement.App.Interfaces;

namespace LibraryManagement.App.Models;

/// <summary>
/// Represents a book in the library.
/// </summary>
public class Book : IBorrowable, ISearchable
{
    /// <summary>
    /// Gets the unique identifier of the book.
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Gets or sets the title of the book.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets the author of the book.
    /// </summary>
    public string Author { get; set; }

    /// <summary>
    /// Gets a value indicating whether the book is currently borrowed.
    /// </summary>
    public bool IsBorrowed { get; private set; }

    /// <summary>
    /// Creates a new book.
    /// </summary>
    public Book(int id, string title, string author)
    {
        if (id <= 0)
            throw new ArgumentException("Book ID must be greater than zero.");

        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty.");

        if (string.IsNullOrWhiteSpace(author))
            throw new ArgumentException("Author cannot be empty.");

        Id = id;
        Title = title;
        Author = author;
        IsBorrowed = false;
    }

    /// <summary>
    /// Borrows the book for a member.
    /// </summary>
    public void Borrow(Member member)
    {
        if (IsBorrowed)
            throw new InvalidOperationException("Book is already borrowed.");

        if (member == null)
            throw new ArgumentNullException(nameof(member));

        IsBorrowed = true;

        member.BorrowedBooks.Add(this);
    }

    /// <summary>
    /// Returns the book to the library.
    /// </summary>
    public void Return()
    {
        if (!IsBorrowed)
            throw new InvalidOperationException("Book is not currently borrowed.");

        IsBorrowed = false;
    }

    /// <summary>
    /// Determines whether the book matches the specified search term.
    /// </summary>
    public bool Matches(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return false;

        return Title.Contains(
                   searchTerm,
                   StringComparison.OrdinalIgnoreCase)
               ||
               Author.Contains(
                   searchTerm,
                   StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Returns a string representation of the book.
    /// </summary>
    public override string ToString()
    {
        string status = IsBorrowed ? "Borrowed" : "Available";

        return $"{Id} - {Title} by {Author} ({status})";
    }
}