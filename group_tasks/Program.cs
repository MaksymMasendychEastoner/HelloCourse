using group_tasks.Block1_Generics;

var numbersStack = new MyStack<int>();

numbersStack.Push(10);
numbersStack.Push(20);

Console.WriteLine($"Верхній елемент (Peek): {numbersStack.Peek()}"); // 20
Console.WriteLine($"Забрали елемент (Pop): {numbersStack.Pop()}");   // 20
Console.WriteLine($"Чи порожній стек? {numbersStack.IsEmpty()}");     // False