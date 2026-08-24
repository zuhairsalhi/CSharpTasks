using System;
using System.Collections.Generic;
using System.Linq;

namespace Task10.App
{
    public class Repository<T> where T : IEntity
    {
        private readonly List<T> _items = new List<T>();

        public void Add(T item)
        {
            _items.Add(item);
        }

        public void Remove(int id)
        {
            T item = _items.FirstOrDefault(x => x.Id == id);

            if (item != null)
            {
                _items.Remove(item);
            }
        }

        public T GetById(int id)
        {
            return _items.FirstOrDefault(x => x.Id == id);
        }

        public List<T> GetAll()
        {
            return _items;
        }
    }
}