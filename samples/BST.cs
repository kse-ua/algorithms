using System;

// Usage example:
// var bst = new Bst(new[]{10, 3, 5, 7, 9, 6});
// bst.Add(15);
// bst.Add(1);
// bst.Traverse(value => Console.WriteLine(value), TraverseType.Inorder);

public class Bst
{
    private Node _root;

    public Bst(int value)
    {
        _root = new Node(value);
    }

    public Bst()
    {
        
    }
    
    public void Add(int value)
    {
        if (_root == null)
        {
            _root = new Node(value);
        }
        Add(_root, value);
        
        Node Add(Node node, int value)
        {
            if (node.Value > value)
            {
                if (node.Left == null)
                {
                    node.Left = new Node(value);
                }
                else
                {
                    return Add(node.Left, value);
                }
            }
    
            if (node.Value < value)
            {
                if (node.Right == null)
                {
                    node.Right = new Node(value);
                }
                else
                {
                    return Add(node.Right, value);
                }
            }

            return node;
        }
    }

    public void Traverse(Action<int> action, TraverseType type)
    {
        TraverseNode(_root, action, type);
        void TraverseNode(Node node, Action<int> action, TraverseType type)
        {
            if (node == null)
            {
                return;
            }

            switch (type)
            {
                case TraverseType.Preorder:
                    action(node.Value);
                    TraverseNode(node.Left, action, type);
                    TraverseNode(node.Right, action, type);
                    break;
                case TraverseType.Postorder:
                    TraverseNode(node.Left, action, type);
                    TraverseNode(node.Right, action, type);
                    action(node.Value);
                    break;
                case TraverseType.Inorder:
                    TraverseNode(node.Left, action, type);
                    action(node.Value);
                    TraverseNode(node.Right, action, type);
                    break;
            }
            
        }
    }
    
    public Bst(int[] array)
    {
        Array.Sort(array);
            
        _root = CreateInternal(array, 0, array.Length - 1);
        Node CreateInternal(int[] numbers, int start, int end)
        {
            if (end < start)
            {
                return null;
            }

            var middle = (start + end) / 2;
            return new Node(numbers[middle])
            {
                Left = CreateInternal(numbers, start, middle - 1),
                Right = CreateInternal(numbers, middle + 1, end)
            };
        }
    }

    private class Node
    {
        public int Value { get; }
    
        public Node Left { get; set; }
    
        public Node Right { get; set; }

        public Node(int value)
        {
            Value = value;
        }
    }
}

public enum TraverseType
{
    Preorder, Postorder, Inorder
}