namespace Kse.Algorithms.Samples
{
    using System;

    public class ArrayList
    {
        private int[] _array = new int[10];

        private int _pointer = 0;

        public void Add(int element)
        {
            _array[_pointer] = element;
            _pointer += 1;

            if (_pointer == _array.Length)
            {
                var extendedArray = new int[_array.Length * 2];
                for (var i = 0; i < _array.Length; i++)
                {
                    extendedArray[i] = _array[i];
                }

                _array = extendedArray;
                //this also can be achieved via
                //Array.Resize(ref _array, _array.Length * 2);
            }
        }

        public void Remove(int element)
        {
            for (var i = 0; i < _pointer; i++)
            {
                if (_array[i] == element)
                {
                    for (var j = i; j < _pointer - 1; j++)
                    {
                        _array[j] = _array[j + 1];
                    }

                    _pointer -= 1;
                    return;
                }
            }
        }

        public int GetAt(int index)
        {
            return _array[index];
        }

        public int IndexOf(int element)
        {
            for (var i = 0; i < _array.Length; i++)
            {
                if (_array[i] == element)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Contains(int element)
        {
            return IndexOf(element) != -1;
        }

        public int Count()
        {
            return _pointer;
        }
    }
}