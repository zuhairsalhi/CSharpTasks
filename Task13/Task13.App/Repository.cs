using System;
using System.Collections.Generic;
using System.Linq;

namespace Task13.App
{
    /// <summary>
    /// Provides an in-memory repository for storing entities.
    /// </summary>
    /// <typeparam name="T">
    /// The type of entity stored in the repository.
    /// </typeparam>
    public class Repository<T> where T : IEntity
    {
        private readonly List<T> _items = new List<T>();

        /// <summary>
        /// Adds an item to the repository.
        /// </summary>
        /// <param name="item">The item to add.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the item is null.
        /// </exception>
        public void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            _items.Add(item);
        }

        /// <summary>
        /// Removes an item using its ID.
        /// </summary>
        /// <param name="id">The ID of the item to remove.</param>
        /// <returns>
        /// True if the item was removed; otherwise false.
        /// </returns>
        public bool Remove(int id)
        {
            T? item = _items.FirstOrDefault(x => x.Id == id);

            if (item == null)
            {
                return false;
            }

            return _items.Remove(item);
        }

        /// <summary>
        /// Gets an item using its ID.
        /// </summary>
        /// <param name="id">The ID of the item to find.</param>
        /// <returns>
        /// The item if found; otherwise null.
        /// </returns>
        public T? GetById(int id)
        {
            return _items.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Gets all items in the repository.
        /// </summary>
        /// <returns>A list containing all items.</returns>
        /// <example>
        /// <code>
        /// Repository&lt;Product&gt; repository =
        ///     new Repository&lt;Product&gt;();
        ///
        /// List&lt;Product&gt; products =
        ///     repository.GetAll();
        /// </code>
        /// </example>
        public List<T> GetAll()
        {
            return _items;
        }
    }
}