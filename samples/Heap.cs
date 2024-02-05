using System;
using System.Text;

public class Heap
{
    private readonly List<int> heap;

    private int Size => heap.Count;

    public Heap()
    {
        heap = new List<int>();
    }

    private int Parent(int index) => (index - 1) / 2;
    private int LeftChild(int index) => 2 * index + 1;
    private int RightChild(int index) => 2 * index + 2;

    private void Swap(int i, int j)
    {
        (heap[i], heap[j]) = (heap[j], heap[i]);
    }

    private void HeapifyUp(int index)
    {
        while (index > 0 && heap[index] < heap[Parent(index)])
        {
            Swap(index, Parent(index));
            index = Parent(index);
        }
    }

    private void HeapifyDown(int index)
    {
        int minIndex = index;
        int leftChild = LeftChild(index);
        int rightChild = RightChild(index);

        if (leftChild < Size && heap[leftChild] < heap[minIndex])
        {
            minIndex = leftChild;
        }

        if (rightChild < Size && heap[rightChild] < heap[minIndex])
        {
            minIndex = rightChild;
        }

        if (index != minIndex)
        {
            Swap(index, minIndex);
            HeapifyDown(minIndex);
        }
    }

    public void Insert(int value)
    {
        heap.Add(value);
        HeapifyUp(Size - 1);
    }

    public int ExtractMin()
    {
        if (Size == 0)
        {
            throw new Exception("Heap is empty. Cannot extract minimum element.");
        }

        var min = heap[0];
        heap[0] = heap[Size - 1];
        HeapifyDown(0);

        heap.RemoveAt(Size - 1);
        return min;
    }

    public override string ToString()
    {
        var result = "";
        for (int i = 0; i < Size; i++)
        {
            result += heap[i] + " ";
        }
        return result;
    }
}
