using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR08
{
    internal class LinkedListVector : IVectorable
    {
        private Node start;
        public LinkedListVector()
        {
            for (int i = 0; i < 5; i++)
                AddEnd(0);
        }
        public LinkedListVector(int length)
        {
            for (int i = 0; i < length; i++)
                AddEnd(0);
        }
        public LinkedListVector(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                AddEnd(array[i]);
            }
        }
        public int Length
        {
            get
            {
                if (start == null)
                    return 0;
                int count = 1;
                Node node = start;
                while (node.next != null)
                {
                    node = node.next;
                    count++;
                }
                return count;
            }
        }
        public int this[int index]
        {
            get
            {
                if (index >= 0 && index < Length)
                {
                    Node node = start;
                    for (int i = 0; i < index; i++)
                        node = node.next;
                    return node.value;
                }
                else
                    throw new IndexOutOfRangeException("Недопустимое значение индекса.");
            }
            set
            {
                if (index >= 0 && index < Length)
                {
                    Node node = start;
                    for (int i = 0; i < index; i++)
                        node = node.next;
                    node.value = value;
                }
                else throw new IndexOutOfRangeException("Недопустимое значение индекса.");
            }
        }
        public void AddEnd(int value)
        {
            Node node = new Node(value);
            if (start == null)
            {
                start = node;
                return;
            }
            Node node1 = start;
            while (node1.next != null)
            {
                node1 = node1.next;
            }
            node1.next = node;
        }
        public void PopEnd()
        {
            if (start == null)
                throw new NullReferenceException("Список пуст.");
            Node node = start;
            while (node != null)
            {
                if (node.next.next == null)
                    node.next = null;
                node = node.next;
            }
        }
        public void AddStart(int value)
        {
            Node node = new Node(value);
            node.next = start;
            start = node;
        }
        public void PopStart()
        {
            if (start == null)
                throw new NullReferenceException("Список пуст");
            start = start.next;
        }
        public double GetNorm()
        {
            double res = 0;
            Node node = start;
            for (int i = 0; i < Length; i++)
            {
                res += Math.Pow(node.value, 2);
                node = node.next;
            }
            return Math.Sqrt(res);
        }
        public void AddIndex(int index, int value)
        {
            if (index > 0 && index < Length)
            {
                Node node = start;
                for (int i = 0; i < index - 1; i++)
                    node = node.next;
                Node node1 = new Node(value);
                node1.next = node.next;
                node.next = node1;
            }
            else if (index == 0)
                AddStart(value);
            else
                throw new IndexOutOfRangeException("Недопустимое значение индекса.");
        }
        public void PopIndex(int index)
        {
            if (index > 0 && index < Length)
            {
                Node node = start;
                for (int i = 0; i < index - 1; i++)
                    node = node.next;
                node.next = node.next.next;
            }
            else if (index == 0)
                PopStart();
            else throw new IndexOutOfRangeException("Недопустимое значение индекса.");
        }
        public int CompareTo(object obj)
        {
            if (obj is IVectorable s)
            {
                return Length.CompareTo(s.Length);
            }
            throw new ArgumentException();
        }
        public override string ToString()
        {
            string res = Length.ToString();
            for (int i = 0; i < Length; i++)
            {
                res += " " + this[i];
            }
            return res;
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType().GetInterface("IVectorable") == null)
            {
                return false;
            }
            IVectorable vector = (IVectorable)obj;
            if (Length != vector.Length)
                return false;
            else
            {
                for (int i = 0; i < Length; i++)
                {
                    if (this[i] != vector[i])
                        return false;
                }
                return true;
            }
        }
        public override int GetHashCode()
        {
            int[] vector = new int[Length];
            for (int i = 0; i < Length; i++)
                vector[i] = this[i];
            return vector.GetHashCode();
        }
        public object Clone()
        {
            LinkedListVector linkedListVector = new LinkedListVector(Length);
            for (int i = 0; i < Length; i++)
            {
                linkedListVector[i] = this[i];
            }
            return linkedListVector;
        }
        class Node
        {
            public int value = 0;
            public Node next = null;
            public Node(int value)
            {
                this.value = value;
            }
        }
    }
}
