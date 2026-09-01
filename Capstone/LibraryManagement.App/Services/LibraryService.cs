using LibraryManagement.App.Attributes;
using LibraryManagement.App.Delegates;
using LibraryManagement.App.Models;
using LibraryManagement.App.Repositories;

namespace LibraryManagement.App.Services;

/// <summary>
/// Provides business operations for managing the library.
/// </summary>
public class LibraryService
{
    private readonly IRepository<Book> _bookRepository;
    private readonly IRepository<Member> _memberRepository;

    /// <summary>
    /// Occurs when a book is successfully borrowed.
    /// </summary>
    public event BookEventHandler? OnBookBorrowed;

    /// <summary>
    /// Initializes a new instance of the LibraryService class.
    /// </summary>
    public LibraryService(
        IRepository<Book> bookRepository,
        IRepository<Member> memberRepository)
    {
        _bookRepository = bookRepository;
        _memberRepository = memberRepository;
    }

    /// <summary>
    /// Gets all books from the repository.
    /// </summary>
    public List<Book> GetBooks()
    {
        return _bookRepository.GetAll().ToList();
    }

    /// <summary>
    /// Gets all books asynchronously.
    /// </summary>
    public async Task<List<Book>> GetBooksAsync()
    {
        await Task.Delay(300);

        return _bookRepository.GetAll().ToList();
    }

    /// <summary>
    /// Searches for a book by title or author.
    /// </summary>
    [AuditLog("Search for a book")]
    public Book? SearchBook(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return null;

        return _bookRepository
            .GetAll()
            .FirstOrDefault(book => book.Matches(searchTerm));
    }

    /// <summary>
    /// Searches for a book asynchronously.
    /// </summary>
    public async Task<Book?> SearchBookAsync(string searchTerm)
    {
        await Task.Delay(300);

        return SearchBook(searchTerm);
    }

    /// <summary>
    /// Borrows a book for a library member.
    /// </summary>
    [AuditLog("Borrow a book for a member")]
    public void BorrowBook(int bookId, int memberId)
    {
        var book = _bookRepository.GetById(bookId);

        if (book == null)
            throw new InvalidOperationException("Book not found.");

        var member = _memberRepository.GetById(memberId);

        if (member == null)
            throw new InvalidOperationException("Member not found.");

        book.Borrow(member);

        OnBookBorrowed?.Invoke(member.Name, book.Title);
    }

    /// <summary>
    /// Borrows a book asynchronously.
    /// </summary>
    public async Task BorrowBookAsync(int bookId, int memberId)
    {
        await Task.Delay(300);

        BorrowBook(bookId, memberId);
    }
}