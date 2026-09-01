using LibraryManagement.App.Interfaces;

namespace LibraryManagement.App.Models;

public class Book : IBorrowable, ISearchable
{
    public int Id { get; }

    public string Title { get; set; }

    public string Author { get; set; }

    public bool IsBorrowed { get; private set; }

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

    public override string ToString()
    {
        string status = IsBorrowed ? "Borrowed" : "Available";

        return $"{Id} - {Title} by {Author} ({status})";
    }
}