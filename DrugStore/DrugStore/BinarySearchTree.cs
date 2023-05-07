using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugStore
{
    public class BinarySearchTree<T> where T : class, IDrug
    {
        public BSTNode<T> root; // Nút gốc của cây

        public class BSTNode<T>
        {
            public string Key { get; set; }
            public T Data { get; set; }
            public BSTNode<T> Left { get; set; }
            public BSTNode<T> Right { get; set; }

            public BSTNode(string key, T data)
            {
                Key = key;
                Data = data;
                Left = null;
                Right = null;
            }
        }
        public List<T> Search<T>(string value, BSTNode<T> root) where T : class, IDrug
        {
            List<T> results = new List<T>();
            var current = root;

            while (current != null)
            {
                T data = current.Data as T;
                if (data == null)
                {
                    // The data in the current node is not of type T
                    // Move to the next node in the BST
                    if (string.Compare(value, current.Data.Name, StringComparison.OrdinalIgnoreCase) < 0)
                    {
                        current = current.Left;
                    }
                    else
                    {
                        current = current.Right;
                    }
                }
                else if (data.Name.StartsWith(value, StringComparison.OrdinalIgnoreCase))
                {
                    results.Add(data);
                    current = current.Right;
                }
                else if (string.Compare(value, data.Name, StringComparison.OrdinalIgnoreCase) < 0)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }

            return results;
        }


        public void AddOrUpdate(T data)
        {
            root = AddOrUpdate(root, data);
        }

        private BSTNode<T> AddOrUpdate<T>(BSTNode<T> node, T data) where T : class, IDrug
        {
            int counter = CountNodes(node);
            if (node == null)
            {
                node = new BSTNode<T>((counter - 1).ToString(), data);
            }
            else if (data.Name.CompareTo(node.Data.Name) < 0)
            {
                node.Left = AddOrUpdate(node.Left, data);
                node = RotateRight(node); // rotate right to ensure balance
            }
            else if (data.Name.CompareTo(node.Data.Name) > 0)
            {
                node.Right = AddOrUpdate(node.Right, data);
                node = RotateLeft(node); // rotate left to ensure balance
            }
            else
            {
                node.Data = data; // Ghi đè dữ liệu nếu nút đã tồn tại
            }

            return node;
        }
        private int CountNodes<T>(BSTNode<T> node) where T : class, IDrug
        {
            if (node == null)
            {
                return 0;
            }
            return 1 + CountNodes(node.Left) + CountNodes(node.Right);
        }
        private BSTNode<T> RotateLeft<T>(BSTNode<T> node) where T : class, IDrug
        {
            BSTNode<T> temp = node.Right;
            node.Right = temp.Left;
            temp.Left = node;
            return temp;
        }

        private BSTNode<T> RotateRight<T>(BSTNode<T> node) where T : class, IDrug
        {
            BSTNode<T> temp = node.Left;
            node.Left = temp.Right;
            temp.Right = node;
            return temp;
        }
        public List<T> FilterByType<T>(string type, BSTNode<T> root) where T : class, IDrug
        {
            List<T> results = new List<T>();
            FilterByTypeHelper(type, root, results);
            return results;
        }

        private void FilterByTypeHelper<T>(string type, BSTNode<T> node, List<T> results) where T : class, IDrug
        {
            if (node != null)
            {
                T data = node.Data as T;
                if (data == null)
                {
                    // The data in the current node is not of type T
                    // Move to the next node in the BST
                    FilterByTypeHelper(type, node.Left, results);
                    FilterByTypeHelper(type, node.Right, results);
                }
                else if (data.DrugTypes == type)
                {
                    results.Add(data);
                    // Continue searching in the left and right subtrees
                    FilterByTypeHelper(type, node.Left, results);
                    FilterByTypeHelper(type, node.Right, results);
                }
                else if (data.DrugTypes.CompareTo(type) < 0)
                {
                    // The current node's type is less than the target type
                    // Search in the right subtree only
                    FilterByTypeHelper(type, node.Right, results);
                }
                else
                {
                    // The current node's type is greater than the target type
                    // Search in the left subtree only
                    FilterByTypeHelper(type, node.Left, results);
                }
            }
        }
        public void DeleteNode(T data)
        {
            root = DeleteNode(root, data.ID.ToString());
        }
        private BSTNode<T> DeleteNode(BSTNode<T> node, string key)
        {
            if (node == null)
            {
                // Trường hợp không tìm thấy nút cần xóa, trả về null để không làm gì cả
                return null;
            }

            int compare = key.CompareTo(node.Key);
            if (compare < 0)
            {
                node.Left = DeleteNode(node.Left, key); // Tìm kiếm nút cần xóa trong cây con bên trái
            }
            else if (compare > 0)
            {
                node.Right = DeleteNode(node.Right, key); // Tìm kiếm nút cần xóa trong cây con bên phải
            }
            else
            {
                // Trường hợp tìm thấy nút cần xóa

                if (node.Left == null && node.Right == null)
                {
                    // Trường hợp nút cần xóa không có con
                    return null;
                }
                else if (node.Left == null)
                {
                    // Trường hợp nút cần xóa chỉ có con bên phải
                    return node.Right;
                }
                else if (node.Right == null)
                {
                    // Trường hợp nút cần xóa chỉ có con bên trái
                    return node.Left;
                }
                else
                {
                    // Trường hợp nút cần xóa có cả hai con

                    // Tìm nút trái nhất trong cây con bên phải của nút cần xóa
                    BSTNode<T> minRight = node.Right;
                    while (minRight.Left != null)
                    {
                        minRight = minRight.Left;
                    }

                    // Thay đổi giá trị của nút cần xóa thành giá trị của nút trái nhất
                    node.Key = minRight.Key;
                    node.Data = minRight.Data;

                    // Xóa nút trái nhất
                    node.Right = DeleteNode(node.Right, minRight.Key);
                }
            }

            return node;
        }

        public int CountNodes()
        {
            return countNodes(root);
        }

        private int countNodes(BSTNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }
            return 1 + countNodes(node.Left) + countNodes(node.Right);
        }
        // Phương thức đệ quy thực hiện duyệt cây nhị phân theo thứ tự In-order và thực hiện một hành động trên mỗi nút
        private void InOrderTraversal(BSTNode<T> node, ref List<T> drugs)
        {
            if (node == null)
            {
                return;
            }

            InOrderTraversal(node.Left, ref drugs);
            drugs.Add(node.Data);
            InOrderTraversal(node.Right, ref drugs);
        }
        public List<T> GetNodes()
        {
            List<T> drugs = new List<T>();
            InOrderTraversal(root, ref drugs);
            return drugs;
        }


    }
}
