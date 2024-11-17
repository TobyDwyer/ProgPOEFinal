using MunicipalAppProgPoe.Models;

namespace MunicipalAppProgPoe.Utils
{
    public class AVLNode
    {
        public ServiceRequestModel Data { get; set; }
        public AVLNode? Left { get; set; }
        public AVLNode? Right { get; set; }
        public int Height { get; set; }

        public AVLNode( ServiceRequestModel data )
        {
            Data = data;
            Height = 1;
        }
    }

    public class AVLTree
    {
        public AVLNode? Root { get; private set; }

        public void Insert( ServiceRequestModel request )
        {
            Root = Insert(Root, request);
        }

        private AVLNode Insert( AVLNode? node, ServiceRequestModel request )
        {
            if (node == null) return new AVLNode(request);

            if (request.Id < node.Data.Id)
                node.Left = Insert(node.Left, request);
            else if (request.Id > node.Data.Id)
                node.Right = Insert(node.Right, request);
            else
                return node;

            node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
            return Balance(node);
        }

        private AVLNode Balance( AVLNode node )
        {
            int balance = GetBalance(node);

            if (balance > 1)
            {
                if (GetBalance(node.Left) >= 0)
                    return RotateRight(node);
                else
                {
                    node.Left = RotateLeft(node.Left);
                    return RotateRight(node);
                }
            }

            if (balance < -1)
            {
                if (GetBalance(node.Right) <= 0)
                    return RotateLeft(node);
                else
                {
                    node.Right = RotateRight(node.Right);
                    return RotateLeft(node);
                }
            }

            return node;
        }

        private AVLNode RotateRight( AVLNode y )
        {
            AVLNode x = y.Left!;
            AVLNode T2 = x.Right!;

            x.Right = y;
            y.Left = T2;

            y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
            x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;

            return x;
        }

        private AVLNode RotateLeft( AVLNode x )
        {
            AVLNode y = x.Right!;
            AVLNode T2 = y.Left!;

            y.Left = x;
            x.Right = T2;

            x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
            y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;

            return y;
        }

        private int GetHeight( AVLNode? node ) => node?.Height ?? 0;
        private int GetBalance( AVLNode node ) => GetHeight(node.Left) - GetHeight(node.Right);

        public ServiceRequestModel? Search( int id )
        {
            AVLNode? current = Root;
            while (current != null)
            {
                if (id == current.Data.Id)
                    return current.Data;
                current = id < current.Data.Id ? current.Left : current.Right;
            }
            return null;
        }

        public List<ServiceRequestModel> InOrderTraversal()
        {
            var result = new List<ServiceRequestModel>();
            InOrderTraversal(Root, result);
            return result;
        }

        private void InOrderTraversal( AVLNode? node, List<ServiceRequestModel> result )
        {
            if (node != null)
            {
                InOrderTraversal(node.Left, result);
                result.Add(node.Data);
                InOrderTraversal(node.Right, result);
            }
        }
    }
}
