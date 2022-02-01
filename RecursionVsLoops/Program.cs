using System;
using System.Collections.Generic;
using System.Numerics;

namespace RecursionVsLoops
{
    class Program
    {
        static void Main(string[] args)
        {
            var leaf = new Node
            (
                "Node 5000",
                null
            );

            var previous = leaf;

            for (var i = 4999; i >= 1; i--)
            {
                previous = new Node($"Node {i}", previous);
            }

            var resultOfRecursion = TraverseTreeUsingRecursion(previous);

            var resultOfLooping = TraverseTreeUsingLoops(previous);

            Console.WriteLine(FibonacciUsingRecursion(40));

            Console.WriteLine(FibonacciUsingLoops(40));

            Console.ReadLine();
        }

        public static List<string> TraverseTreeUsingRecursion(Node root)
        {
            var result = new List<string> { root.Name };

            if (root.Next != null)
            {
                result.AddRange(TraverseTreeUsingRecursion(root.Next));
            }

            return result;
        }

        public static List<string> TraverseTreeUsingLoops(Node root)
        {
            var result = new List<string>();

            var node = root;

            while (node != null)
            {
                result.Add(node.Name);
                node = node.Next;
            }

            return result;
        }

        public static int FibonacciUsingRecursion(int num)
        {
            if (num == 0) return 0;
            if (num == 1) return 1;

            return FibonacciUsingRecursion(num - 1) + FibonacciUsingRecursion(num - 2);
        }

        public static int FibonacciUsingLoops(int num)
        {
            if (num == 0) return 0;
            if (num == 1) return 1;

            var minusTwo = 0;
            var minusOne = 1;
            var sum = 0;

            for (var i = 2; i <= num; i++)
            {
                sum = minusOne + minusTwo;
                minusTwo = minusOne;
                minusOne = sum;
            }

            return sum;
        }
    }

    public class Node
    {
        public string Name { get; }
        public Node Next { get; }

        public Node(string name, Node next)
        {
            Name = name;
            Next = next;
        }
    }
}