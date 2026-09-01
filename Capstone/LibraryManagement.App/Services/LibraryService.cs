using LibraryManagement.App.Attributes;
using LibraryManagement.App.Delegates;
using LibraryManagement.App.Models;
using LibraryManagement.App.Repositories;

namespace LibraryManagement.App.Services;

public class LibraryService
{
    private readonly IRepository<Book> _bookRepository;
    private readonly IRepository<Member> _memberRepository;

    public event BookEventHandler? OnBookBorrowed;

    public LibraryService(
        IRepository<Book> bookRepository,
        IRepository<Member> memberRepository)
    {
        _bookRepository = bookRepository;
        _memberRepository = memberRepository;
    }

    public List<Book> GetBooks()
    {
        return _bookRepository.GetAll().ToList();
    }

    public async Task<List<Book>> GetBooksAsync()
    {
        await Task.Delay(300);

        return _bookRepository.GetAll().ToList();
    }

    [AuditLog("Search for a book")]
    public Book? SearchBook(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return null;

        return _bookRepository
            .GetAll()
            .FirstOrDefault(book => book.Matches(searchTerm));
    }

    public async Task<Book?> SearchBookAsync(string searchTerm)
    {
        await Task.Delay(300);

        return SearchBook(searchTerm);
    }

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

    public async Task BorrowBookAsync(int bookId, int memberId)
    {
        await Task.Delay(300);

        BorrowBook(bookId, memberId);
    }
}