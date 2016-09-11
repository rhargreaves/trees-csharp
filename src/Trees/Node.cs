using System.Collections.Generic;

namespace Trees
{
    public class Node
    {
        public Node Left;
        public Node Right;
        public int Val;

        public Node(int val, Node left = null, Node right = null)
        {
            this.Val = val;
            this.Left = left;
            this.Right = right;
        }

        public SearchResult BreadthFirstSearch(int i)
        {
            List<int> traversalHistory = new List<int>();
            Queue<Node> nodesToSearch = new Queue<Node>();
            nodesToSearch.Enqueue(this);
            while (nodesToSearch.Count != 0)
            {
                var current = nodesToSearch.Dequeue();
                if(current.Left != null)
                    nodesToSearch.Enqueue(current.Left);
                if (current.Right != null)
                    nodesToSearch.Enqueue(current.Right);

                traversalHistory.Add(current.Val);

                if (current.Val == i)
                    return new SearchResult { Node = current, TraversalHistory = traversalHistory };
            }
            return new SearchResult {Node = null, TraversalHistory = traversalHistory};
        }

        public SearchResult DepthFirstSearch(int i)
        {
            List<int> traversalHistory = new List<int>();
            Stack<Node> nodesToSearch = new Stack<Node>();
            nodesToSearch.Push(this);
            while (nodesToSearch.Count != 0)
            {
                var current = nodesToSearch.Pop();
                if (current.Right != null)
                    nodesToSearch.Push(current.Right);
                if (current.Left != null)
                    nodesToSearch.Push(current.Left);

                traversalHistory.Add(current.Val);

                if (current.Val == i)
                    return new SearchResult { Node = current, TraversalHistory = traversalHistory };
            }
            return new SearchResult { Node = null, TraversalHistory = traversalHistory };
        }
    }
}