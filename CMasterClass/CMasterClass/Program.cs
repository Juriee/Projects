using System;

public class Node
{
    public Node LeftChild { get; private set; }
    public Node RightChild { get; private set; }

    public Node(Node leftChild, Node rightChild)
    {
        this.LeftChild = leftChild;
        this.RightChild = rightChild;
    }

    public int Height()
    {
        return 0;
    }

    public static void Main(string[] args)
    {
        Node leaf1 = new Node(null, null);
        Node leaf2 = new Node(null, null);
        Node node = new Node(leaf1, null);
        Node root = new Node(node, leaf2);
        

        Console.WriteLine(root.Height());
    }
}