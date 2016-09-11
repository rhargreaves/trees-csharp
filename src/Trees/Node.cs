using System.Collections.Generic;

namespace Trees
{
    public class Node
    {
        private readonly Node _left;
        private readonly Node _right;
        private readonly int _val;

        public Node(int val, Node left = null, Node right = null)
        {
            _val = val;
            _left = left;
            _right = right;
        }

        public SearchResult BreadthFirstSearch(int i)
        {
            List<int> traversalHistory = new List<int>();
            Queue<Node> nodesToSearch = new Queue<Node>();
            nodesToSearch.Enqueue(this);
            while (nodesToSearch.Count != 0)
            {
                var current = nodesToSearch.Dequeue();
                if(current._left != null)
                    nodesToSearch.Enqueue(current._left);
                if (current._right != null)
                    nodesToSearch.Enqueue(current._right);

                traversalHistory.Add(current._val);

                if (current._val == i)
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
                if (current._right != null)
                    nodesToSearch.Push(current._right);
                if (current._left != null)
                    nodesToSearch.Push(current._left);

                traversalHistory.Add(current._val);

                if (current._val == i)
                    return new SearchResult { Node = current, TraversalHistory = traversalHistory };
            }
            return new SearchResult { Node = null, TraversalHistory = traversalHistory };
        }
    }
}