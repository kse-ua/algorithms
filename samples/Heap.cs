namespace Kse.Algorithms.Samples
{
    using System.Collections.Generic;

    public class Heap
    {
        private readonly List<int> _elements = new List<int>();

        public void Add(int value)
        {
            _elements.Add(value);
            HeapifyUp(_elements.Count - 1);
        }

        private void HeapifyUp(int index)
        {
            var current = index;
            while (Heapify(GetParentIndex(current)))
            {
                current = GetParentIndex(current);
            }
        }

        private void HeapifyDown(int index)
        {
            var left = GetLeftChildIndex(index);
            var right = GetRightChildIndex(index);
            if (left >= _elements.Count)
            {
                return;
            }

            if (_elements[index] < _elements[left] && (right >= _elements.Count || _elements[left] > _elements[right]))
            {
                Swap(index, left);
                HeapifyDown(left);
                return;
            }

            if (right >= _elements.Count)
            {
                return;
            }

            if (_elements[index] < _elements[right])
            {
                Swap(index, right);
                HeapifyDown(right);
            }
        }

        public int PopMax()
        {
            var value = _elements[0];
            Swap(0, _elements.Count - 1);
            _elements.RemoveAt(_elements.Count - 1);

            HeapifyDown(0);

            return value;
        }

        private bool Heapify(int index)
        {
            var left = GetLeftChildIndex(index);
            if (left >= _elements.Count)
            {
                return false;
            }

            if (_elements[index] < _elements[left])
            {
                Swap(index, left);
                return true;
            }

            var right = GetRightChildIndex(index);
            if (right >= _elements.Count)
            {
                return false;
            }

            if (_elements[index] < _elements[right])
            {
                Swap(index, right);
                return true;
            }

            return false;
        }

        private void Swap(int indexA, int indexB)
        {
            var tmp = _elements[indexA];
            _elements[indexA] = _elements[indexB];
            _elements[indexB] = tmp;
        }

        private int GetLeftChildIndex(int index) => index * 2 + 1;

        private int GetRightChildIndex(int index) => index * 2 + 2;

        private int GetParentIndex(int index) => (index - 1) / 2;
    }
}