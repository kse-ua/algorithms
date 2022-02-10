namespace Kse.Algorithms.Samples
{
    public static class Sortings
    {
        public static void HeapSort(int[] elements)
        {
            //build heap
            for (int i = 0; i < elements.Length; i++)
            {
                HeapifyUp(i);
            }

            //put maximum to the end
            for (int j = elements.Length - 1; j > 1; j--)
            {
                Swap(0, j);
                HeapifyDown(0, j - 1);
            }
            
            void HeapifyUp(int index)
            {
                var current = index;
                while (Heapify(GetParentIndex(current)))
                {
                    current = GetParentIndex(current);
                }
            }
            
            bool Heapify(int index)
            {
                var left = GetLeftChildIndex(index);
                if (left >= elements.Length)
                {
                    return false;
                }

                if (elements[index] < elements[left])
                {
                    Swap(index, left);
                    return true;
                }

                var right = GetRightChildIndex(index);
                if (right >= elements.Length)
                {
                    return false;
                }

                if (elements[index] < elements[right])
                {
                    Swap(index, right);
                    return true;
                }

                return false;
            }
            
            void HeapifyDown(int index, int maxIndex)
            {
                var left = GetLeftChildIndex(index);
                var right = GetRightChildIndex(index);
                if (left >= maxIndex)
                {
                    return;
                }

                if (elements[index] < elements[left] && (right >= elements.Length || elements[left] > elements[right]))
                {
                    Swap(index, left);
                    HeapifyDown(left, maxIndex);
                    return;
                }

                if (right >= maxIndex)
                {
                    return;
                }

                if (elements[index] < elements[right])
                {
                    Swap(index, right);
                    HeapifyDown(right, maxIndex);
                }
            }
            
            void Swap(int indexA, int indexB)
            {
                (elements[indexA], elements[indexB]) = (elements[indexB], elements[indexA]);
            }

            int GetLeftChildIndex(int index) => index * 2 + 1;

            int GetRightChildIndex(int index) => index * 2 + 2;

            int GetParentIndex(int index) => (index - 1) / 2;
        }
    }
}