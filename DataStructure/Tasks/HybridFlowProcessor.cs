using System;
using Tasks.DoNotChange;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        private readonly IDoublyLinkedList<T> _doublyList;

        public HybridFlowProcessor()
        {
            _doublyList = new DoublyLinkedList<T>();
        }

        public T Dequeue()
        {
            try
            {
                return _doublyList.RemoveAt(0);
            }
            catch (IndexOutOfRangeException e)
            {
                throw new InvalidOperationException(e.Message, e);
            }
        }

        public void Enqueue(T item)
        {
            _doublyList.Add(item);
        }

        public T Pop()
        {

            try
            {
                return _doublyList.RemoveAt(0);
            }
            catch (IndexOutOfRangeException e)
            {
                throw new InvalidOperationException(e.Message, e);
            }
        }

        public void Push(T item)
        {
            _doublyList.AddAt(0, item);
        }
    }
}
