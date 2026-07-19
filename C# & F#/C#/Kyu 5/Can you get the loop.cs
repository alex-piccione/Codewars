using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kyu_5_Can_you_get_the_loop {

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
        // OK but maybe too slow
        public static int getLoopSize_slow(LoopDetector.Node startNode)
        {
            HashSet<LoopDetector.Node> nodes = [];

            while (true)
            {
                var nextNode = startNode.next ?? throw new System.Exception("not a chain");
                if (nodes.Contains(nextNode))
                    return nodes.Count - nodes.TakeWhile(x => x != nextNode).Count();

                nodes.Add(nextNode);
                startNode = nextNode;
            }
        }

        
        public static int getLoopSize(LoopDetector.Node startNode)
        {
            HashSet<LoopDetector.Node> tortoiseNodes = [];

            var rabbitNode = startNode;

            while (true)
            {
                var tortoiseNode = startNode.next ?? throw new System.Exception("not a chain");

                // search for a node in the loop
                if (tortoiseNodes.Contains(rabbitNode))
                {
                    // run from the beginning to count the nodes in the loop
                    var node = rabbitNode;
                    int count = 0;
                    while(node.next != rabbitNode)
                    {
                        node = node.next ?? throw new System.Exception("not a chain");
                        count++;
                    }

                    return count+1;
                }
                else
                {
                    tortoiseNodes.Add(tortoiseNode);
                    startNode = tortoiseNode;

                    rabbitNode = rabbitNode.next?.next?.next?.next?.next ?? throw new System.Exception("not a chain");
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

        [Test, Order(4)]
        public void ChainNodesWithLoopSize1()
        {
            var n1 = LoopDetector.createChain(0, 2);
            Assert.That(Kata.getLoopSize(n1), Is.EqualTo(2));
        }

        [Test, Order(5)]
        public void LongChain()
        {
            var n1 = LoopDetector.createChain(0, int.MaxValue/100);
            Assert.That(Kata.getLoopSize(n1), Is.EqualTo(int.MaxValue/100));
        }

        [Test, Order(6)]
        public void VeryLongChain()
        {
            var n1 = LoopDetector.createChain(0, int.MaxValue / 10);
            Assert.That(Kata.getLoopSize(n1), Is.EqualTo(int.MaxValue / 10));
        }

        [Test, Order(7)]
        public void LonghestChain()
        {
            var n1 = LoopDetector.createChain(0, int.MaxValue);
            Assert.That(Kata.getLoopSize(n1), Is.EqualTo(int.MaxValue));
        }
    }

}