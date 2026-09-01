using System.Reflection;
using LibraryManagement.App.Attributes;
using LibraryManagement.App.Models;
using LibraryManagement.App.Repositories;
using LibraryManagement.App.Services;

var bookRepository = new Repository<Book>();
var memberRepository = new Repository<Member>();

var libraryService = new LibraryService(
    bookRepository,
    memberRepository);

var fileService = new LibraryFileService();

libraryService.OnBookBorrowed += HandleBookBorrowed;

var book1 = new Book(
    1,
    "Clean Code",
    "Robert C. Martin");

var book2 = new Book(
    2,
    "The Pragmatic Programmer",
    "Andrew Hunt");

var member = new Member(
    1,
    "Zuhair");

var librarian = new Librarian(
    1,
    "Library Admin");

bookRepository.Add(book1);
bookRepository.Add(book2);
memberRepository.Add(member);

Console.WriteLine("LIBRARY MANAGEMENT SYSTEM");

Console.WriteLine();
Console.WriteLine($"Librarian: {librarian}");

Console.WriteLine();
Console.WriteLine(" Async Library Operations ");

Console.WriteLine();
Console.WriteLine("Loading books asynchronously.");

var books = await libraryService.GetBooksAsync();

foreach (var book in books)
{
    Console.WriteLine(book);
}

Console.WriteLine();
Console.WriteLine("Borrowing book asynchronously.");

await libraryService.BorrowBookAsync(1, 1);

Console.WriteLine();
Console.WriteLine(" Books After Borrowing ");

books = await libraryService.GetBooksAsync();

foreach (var book in books)
{
    Console.WriteLine(book);
}

Console.WriteLine();
Console.WriteLine(" Searching Asynchronously ");

var foundBook = await libraryService.SearchBookAsync("Pragmatic");

if (foundBook != null)
{
    Console.WriteLine($"Found: {foundBook}");
}
else
{
    Console.WriteLine("Book not found.");
}

Console.WriteLine();
Console.WriteLine(" Exception Handling ");

try
{
    Console.WriteLine("Trying to borrow the same book again.");

    await libraryService.BorrowBookAsync(1, 1);
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Unexpected error: {ex.Message}");
}
finally
{
    Console.WriteLine("Operation finished.");
}

Console.WriteLine();
Console.WriteLine(" JSON Persistence ");

var filePath = Path.Combine(
    AppContext.BaseDirectory,
    "library.json");

await fileService.SaveBooksAsync(
    books,
    filePath);

Console.WriteLine($"Books saved to: {filePath}");

var loadedBooks = await fileService.LoadBooksAsync(filePath);

Console.WriteLine();
Console.WriteLine("Loaded Books:");

foreach (var book in loadedBooks)
{
    Console.WriteLine(book);
}

Console.WriteLine();
Console.WriteLine(" Audit Log Scanner ");

var methods = typeof(LibraryService)
    .GetMethods(BindingFlags.Public | BindingFlags.Instance);

foreach (var method in methods)
{
    var auditLog = method.GetCustomAttribute<AuditLogAttribute>();

    if (auditLog != null)
    {
        Console.WriteLine($"Method: {method.Name}");
        Console.WriteLine($"Description: {auditLog.Description}");
        Console.WriteLine();
    }
}

Console.WriteLine("Capstone Completed");

static void HandleBookBorrowed(string memberName, string bookTitle)
{
    Console.WriteLine(
        $"EVENT: {memberName} borrowed \"{bookTitle}\"");
}