using System.Collections.Generic;

namespace Task2
{
    public interface IGenericList <T> : IEnumerable<T>
    {
        void Add(T item);

        bool Remove(T item);

        bool RemoveAt(int index);

        T GetElement(int index);

        int IndexOf(T item);

        int Count { get; }

        void Clear();

        bool Contains(T item);
    }
}
