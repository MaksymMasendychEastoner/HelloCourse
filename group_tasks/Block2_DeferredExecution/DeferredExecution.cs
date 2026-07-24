using System;
using System.Collections.Generic;
using System.Text;

namespace group_tasks.Block2_DeferredExecution
{
    public class DeferredExecutionNotes
    {
        public static void RunDemo()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };

            // LINQ-запит створюється тут, але НЕ виконується
            var evens = numbers.Where(n => n % 2 == 0);
                        
            numbers.Add(6);

            // Запит виконується тут
            foreach (var n in evens)
            {
                Console.WriteLine(n);
            }
        }
    }
}
