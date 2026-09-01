using System.Text.Json;
using LibraryManagement.App.Models;

namespace LibraryManagement.App.Services;

public class LibraryFileService
{
    private readonly JsonSerializerOptions _options = new()
    {
        WriteIndented = true
    };

    public async Task SaveBooksAsync(
        IEnumerable<Book> books,
        string filePath)
    {
        var json = JsonSerializer.Serialize(books, _options);

        await File.WriteAllTextAsync(filePath, json);
    }

    public async Task<List<Book>> LoadBooksAsync(
        string filePath)
    {
        if (!File.Exists(filePath))
            return new List<Book>();

        var json = await File.ReadAllTextAsync(filePath);

        if (string.IsNullOrWhiteSpace(json))
            return new List<Book>();

        var loadedBooks =
            JsonSerializer.Deserialize<List<Book>>(json, _options)
            ?? new List<Book>();

        return loadedBooks;
    }
}