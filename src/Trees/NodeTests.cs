using NUnit.Framework;

namespace Trees
{
    public class NodeTests
    {
        private Node _nodeToFind;
        private Node _root;

        [SetUp]
        public void Before_each()
        {
            _nodeToFind = new Node(4);
            _root = new Node(1,
                new Node(2, new Node(5)), new Node(3, _nodeToFind));
        }

        [Test]
        public void Can_search_using_BFS()
        {
            var result = _root.BreadthFirstSearch(4);

            Assert.That(result.Node, Is.EqualTo(_nodeToFind));
            Assert.That(result.TraversalHistory, Is.EquivalentTo(new[] {1, 2, 3, 5, 4}));
        }

        [Test]
        public void Can_search_using_DFS()
        {
            var result = _root.DepthFirstSearch(4);

            Assert.That(result.Node, Is.EqualTo(_nodeToFind));
            Assert.That(result.TraversalHistory, Is.EquivalentTo(new[] {1, 2, 5, 3, 4}));
        }
    }
}