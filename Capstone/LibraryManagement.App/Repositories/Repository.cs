namespace LibraryManagement.App.Repositories;

public class Repository<T> : IRepository<T>
{
    private readonly List<T> _items = new();

    public void Add(T item)
    {
        _items.Add(item);
    }

    /// <summary>
    /// Removes an item from the repository.
    /// </summary>
    /// <param name="item">The item to remove.</param>
    public void Remove(T item)
    {
        _items.Remove(item);
    }

    /// <summary>
    /// Gets an item by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the item.</param>
    /// <returns>The matching item, or null if it does not exist.</returns>
    public T? GetById(int id)
    {
        foreach (var item in _items)
        {
            var property = typeof(T).GetProperty("Id");

            if (property == null)
                continue;

            var value = property.GetValue(item);

            if (value is int itemId && itemId == id)
                return item;
        }

        return default;
    }

    public IEnumerable<T> GetAll()
    {
        return _items;
    }
}