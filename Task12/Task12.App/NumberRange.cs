using System;
using System.Collections;
using System.Collections.Generic;

namespace Task12.App
{
    public class NumberRange : IEnumerable<int>, IEnumerator<int>
    {
        private readonly int _start;
        private readonly int _end;

        private int _current;

        public NumberRange(int start, int end)
        {
            _start = start;
            _end = end;
            _current = start - 1;
        }

        public int Current
        {
            get
            {
                return _current;
            }
        }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (_current < _end)
            {
                _current++;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            _current = _start - 1;
        }

        public void Dispose()
        {
        }

        public IEnumerator<int> GetEnumerator()
        {
            Reset();
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}