using System;
using System.Collections;
using System.Collections.Generic;

namespace Task2
{
    class GenericListEnumerator<T> : IEnumerator<T>

    {
        private GenericList<T> _list;
        private int _position = -1;

        public GenericListEnumerator (GenericList<T> list)
        {
            _list = list;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            _position++;
            return (_position < _list.Count);
        }

        public void Reset()
        {
            _position = -1;
        }

        public T Current
        {
            get
            {
                try
                {
                    return _list.GetElement(_position);
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

    }
}
