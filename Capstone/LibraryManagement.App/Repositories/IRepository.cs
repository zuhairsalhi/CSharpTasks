namespace LibraryManagement.App.Repositories;

/// <summary>
/// Defines generic repository operations.
/// </summary>
/// <typeparam name="T">The type of entity stored in the repository.</typeparam>
public interface IRepository<T>
{
    /// <summary>
    /// Adds an entity to the repository.
    /// </summary>
    void Add(T item);

    /// <summary>
    /// Gets an entity by its identifier.
    /// </summary>
    T? GetById(int id);

    /// <summary>
    /// Gets all entities.
    /// </summary>
    IEnumerable<T> GetAll();
}