using System;
using System.Collections.Generic;
using System.Text;

namespace group_tasks.Block1_Generics
{
    public class MyStack<T>
    {
        // Внутрішній список для збереження елементів стеку
        private readonly List<T> _items = new List<T>();
                
        public void Push(T item)
        {
            _items.Add(item);
        }
                
        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Стек порожній!");
            }
                        
            T lastItem = _items[_items.Count - 1];

            _items.RemoveAt(_items.Count - 1);

            return lastItem;
        }
                
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Стек порожній!");
            }

            return _items[_items.Count - 1];
        }
                
        public bool IsEmpty()
        {
            return _items.Count == 0;
        }
    }
}
