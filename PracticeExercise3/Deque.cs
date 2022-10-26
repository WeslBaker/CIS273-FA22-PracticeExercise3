using System;
using System.Collections.Generic;

namespace PracticeExercise3
{
	public class Deque<T> : IDeque<T>
	{
        private LinkedList<T> linkedList;

		public Deque()
		{
            linkedList = new LinkedList<T>();
		}

        public bool IsEmpty => Length == 0;

        public int Length => linkedList.Count;

        public T Front => IsEmpty ? throw new EmptyQueueException() : linkedList.First.Value;

        public T Back => IsEmpty ? throw new EmptyQueueException() : linkedList.Last.Value;

        public void AddBack(T item)
        {
            linkedList.AddLast(item);
            return;
        }

        public void AddFront(T item)
        {
            linkedList.AddFirst(item);
            return;
        }

        public T RemoveBack()
        {
            T nodeToRemove = linkedList.Last.Value;
            linkedList.RemoveLast();
            return nodeToRemove;
        }

        public T RemoveFront()
        {
            if(IsEmpty)
            {
                throw new EmptyQueueException();
            }
            T nodeToRemove = linkedList.First.Value;
            linkedList.RemoveFirst();
            return nodeToRemove;
        }

        public override string ToString()
        {
            string result = "<Back> ";

            var currentNode = linkedList.Last;
            while (currentNode != null)
            {
                result += currentNode.Value;
                if (currentNode.Previous != null)
                {
                    result += " → ";
                }
                currentNode = currentNode.Previous;
            }

            result += " <Front>";

            return result;
        }
    }
}

