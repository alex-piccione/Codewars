using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;


public class LoopDetector
{
    public class Node
    {
        public Node? next;
    }

    // Helper method to create a chain with a loop
    public static Node createChain(int nonLoopSize, int loopSize)
    {
        Node head = new();
        Node current = head;
        Node? loopStart = null;

        for (int i = 0; i < (nonLoopSize+loopSize-1); i++)
        {
            Node next = new();
            current.next = next;

            if (i == nonLoopSize)
                loopStart = current;

            // move on
            current = next;
        }

        // close the loop
        current.next = loopStart;

        return head;
    }
}

public class Kata
{
    public static int getLoopSize(LoopDetector.Node startNode)
    {
        System.Collections.Generic.List<LoopDetector.Node> nodes = [];

        while (true)
        {
            var nextNode = startNode.next ?? throw new System.Exception("not a chain");
            if (nodes.Contains(nextNode))
                return nodes.Count - nodes.IndexOf(nextNode);
            else
            {
                nodes.Add(nextNode);
                startNode = nextNode;
            }
        }
    }
}



[TestFixture]
public class Tests
{
    [Test, Order(1)]
    public void FourNodesWithLoopSize3()
    {
        var n1 = new LoopDetector.Node();
        var n2 = new LoopDetector.Node();
        var n3 = new LoopDetector.Node();
        var n4 = new LoopDetector.Node();
        n1.next = n2;
        n2.next = n3;
        n3.next = n4;
        n4.next = n2;
        Assert.That(Kata.getLoopSize(n1), Is.EqualTo(3));
    }

    [Test, Order(2)]
    public void RandomChainNodesWithLoopSize30()
    {
        var n1 = LoopDetector.createChain(3, 30);
        Assert.That(Kata.getLoopSize(n1), Is.EqualTo(30));
    }

    [Test, Order(3)]
    public void RandomLongChainNodesWithLoopSize1087()
    {
        var n1 = LoopDetector.createChain(3904, 1087);
        Assert.That(Kata.getLoopSize(n1), Is.EqualTo(1087));
    }
}
