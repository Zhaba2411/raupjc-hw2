using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    public class GenericList <T> : IGenericList<T>
    {
        private T[] _internalStorage;
        private int _size = 0;
        private int _internalStorageSize;
        public int Count
        {
            get { return _size; }
        }

        public GenericList()
        {
            _internalStorageSize = 4;
            _internalStorage = new T[_internalStorageSize];
        }

        public GenericList(int initialSize)
        {
            if (initialSize < 0)
            {
                throw new Exception("Array length cannot be negative!");
            }
            else
            {
                _internalStorage = new T[initialSize];
                _internalStorageSize = initialSize;
            }
        }

        public void Add(T item)
        {
            if (_size == _internalStorage.Length)
            {
                _internalStorageSize = _internalStorage.Length * 2;
                T[] temp = new T[_internalStorageSize];
                for (int i = 0; i < _size; i++)
                {
                    temp[i] = _internalStorage[i];
                }
                _internalStorage = new T[_internalStorageSize];
                for (int i = 0; i < _size; i++)
                {
                    _internalStorage[i] = temp[i];
                }
            }

            _internalStorage[_size] = item;
            _size++;
        }

        public bool Remove(T item)
        {
            if (!_internalStorage.Contains(item))
            {
                return false;
            }

            for (int i = 0; i < _size; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    RemoveAt(i);
                    break;
                }
            }
            return true;
        }

        public bool RemoveAt(int index)
        {
            if (index < 0 || index > _size - 1)
            {
                return false;
            }
            for (int i = index; i < _size - 1; i++)
            {
                _internalStorage[i] = _internalStorage[i + 1];
            }

            _size--;
            return true;
        }

        public T GetElement(int index)
        {
            if (index < 0 || index > _size - 1)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                return _internalStorage[index];
            }
        }

        public int IndexOf(T item)
        {
            if (Contains(item))
            {
                for (int i = 0; i < _size; i++)
                {
                    if (_internalStorage[i].Equals(item))
                    {
                        return i;
                    }
                }
            }

            throw new Exception("Element not found!");
        }

        public void Clear()
        {
            _internalStorage = new T[_internalStorageSize];
            _size = 0;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new GenericListEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
