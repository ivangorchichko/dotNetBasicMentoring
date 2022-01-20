using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        public int Length { get; private set; }

        public Node<T> Head { get; private set; }

        public Node<T> Tail { get; private set; }

        public void Add(T e)
        {
            Node<T> newNode = new Node<T>(e);
            if (Tail == null)
            {
                Head = newNode;
            }
            else
            {
                newNode.Previous = Tail;
                Tail.Next = newNode;
            }

            Tail = newNode;
            Length++;
        }

        public void AddAt(int index, T e)
        {
            var foundElement = GetNodeByIndex(index);

            var insertedNode = new Node<T>(e);

            if (foundElement != null && foundElement.Data != null)
            {
                if (foundElement == Head)
                {
                    foundElement.Previous = insertedNode;
                    insertedNode.Next = foundElement;
                    Head = insertedNode;
                }
                else
                {
                    insertedNode.Next = foundElement;
                    insertedNode.Previous = foundElement.Previous;
                    foundElement.Previous.Next = insertedNode;
                    foundElement.Previous = insertedNode;
                }
                Length++;
            }
            else
            {
                Add(e);
            }
        }

        public T ElementAt(int index)
        {
            var foundNode = GetNodeByIndex(index);
            return foundNode != null? foundNode.Data : throw new IndexOutOfRangeException("Index of DoublyLinkedList out of range!");
        }

        public void Remove(T item)
        {
            Node<T> current = Head;
            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    if (current.Next == null)
                    {
                        Tail = current.Previous;
                    }
                    else
                    {
                        current.Next.Previous = current.Previous;
                    }

                    if (current.Previous == null)
                    {
                        Head = current.Next;
                    }
                    else
                    {
                        current.Previous.Next = current.Next;
                    }

                    current = null;
                    Length--;
                    break;
                }

                current = current.Next;
            }
        }

        public T RemoveAt(int index)
        {
            var removingElement = ElementAt(index);
            Remove(removingElement);
            return removingElement;
        }

        private Node<T> GetNodeByIndex(int index)
        {
            var counter = 0;
            using var enumerator = GetEnumerator();
            do
            {
                if (counter == index)
                {
                    return enumerator.CurrentNode;
                }

                counter++;

            } while (enumerator.MoveNext());
         

            return null;
        }

        public CustomEnumerator GetEnumerator()
        {
            return new CustomEnumerator(this);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public struct CustomEnumerator : IEnumerator<T>
        {
            private readonly DoublyLinkedList<T> _list;
            private Node<T> _node;
            private T _current;
            private int _index;

            public CustomEnumerator(DoublyLinkedList<T> list)
            {
                _list = list;
                _node = list.Head;
                _current = default;
                _index = 0;
            }

            public bool MoveNext()
            {
                if (_node == null)
                {
                    _index = _list.Length + 1;
                    return false;
                }

                ++_index;
                _current = _node.Data;
                _node = _node.Next;
                if (_node == _list.Head)
                {
                    _node = null;
                }
                return true;
            }

            public void Reset()
            {
                _current = default;
                _node = _list.Head;
                _index = 0;
            }

            public T Current => _current;

            public Node<T> CurrentNode => _node;

            object? IEnumerator.Current => Current;

            public void Dispose()
            {
                
            }
        }
    }
}
