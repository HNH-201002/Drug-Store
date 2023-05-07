using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugStore
{
    public class LinkedList<T>
    {
        private Node<T> head;
        private int count;

        public LinkedList()
        {
            head = null;
            count = 0;
        }

        public void Add(T data)
        {
            Node<T> newNode = new Node<T>(data);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node<T> currentNode = head;
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Next = newNode;
            }

            count++;
        }
        public List<Node<T>> Search(T data)
        {
            List<Node<T>> foundNodes = new List<Node<T>>();
            Node<T> current = head;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    foundNodes.Add(current);
                }

                current = current.Next;
            }

            return foundNodes;
        }

        public Node<T> GetHead()
        {
            return head;
        }

        public Node<T> GetNext(Node<T> currentNode)
        {
            return currentNode.Next;
        }
        public void Remove(T data)
        {
            if (head == null)
            {
                return;
            }

            if (head.Data.Equals(data))
            {
                head = head.Next;
                count--;
                return;
            }

            Node<T> previousNode = head;
            Node<T> currentNode = head.Next;
            while (currentNode != null && !currentNode.Data.Equals(data))
            {
                previousNode = currentNode;
                currentNode = currentNode.Next;
            }

            if (currentNode != null)
            {
                previousNode.Next = currentNode.Next;
                count--;
            }
        }

        public void Edit(int index, T newData)
        {
            if (index < 0 || index >= count)
            {
                throw new System.ArgumentOutOfRangeException("Index out of range.");
            }

            Node<T> currentNode = head;
            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode.Next;
            }

            currentNode.Data = newData;
        }
        public bool Contains(T data)
        {
            Node<T> currentNode = head;
            while (currentNode != null && !currentNode.Data.Equals(data))
            {
                currentNode = currentNode.Next;
            }

            return currentNode != null;
        }

        public int Count()
        {
            return count;
        }
    }
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }
}
