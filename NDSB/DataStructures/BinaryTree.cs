namespace NDSB
{
    public class BinaryTree<T>
    {
        private T _nodeValue;
        private BinaryTree<T> _leftChild;
        private BinaryTree<T> _rightChild;

        public BinaryTree(T node)
        {
            _nodeValue = node;
            _leftChild = null;
            _rightChild = null;
        }

        public BinaryTree()
        {

        }

        public T Node
        {
            get { return _nodeValue; }
            set { _nodeValue = value; }
        }

        public BinaryTree<T> RightChild
        {
            get { return _rightChild; }
            set { _rightChild = value; }
        }

        public BinaryTree<T> LeftChild
        {
            get { return _leftChild; }
            set { _leftChild = value; }
        }
    }
}
