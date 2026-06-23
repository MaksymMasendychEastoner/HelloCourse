using System;
using System.Collections.Generic; // Required for List, Dictionary, HashSet
using System.Linq;                // Required for LINQ queries

namespace DotNetCourseLesson2
{
     
    // BLOCK 0: CLASS AND STRUCTURE DECLARATIONS

    // Task 1: Person class with properties and age validation
    class Person
    {
        public string Name { get; init; }

        private int _age;
        public int Age
        {
            get => _age;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Age cannot be negative!");
                _age = value;
            }
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void Introduce()
        {
            Console.WriteLine($"Привіт, я {Name}, мені {Age} років");
        }
    }

    // Task 2: BankAccount class with proper access modifiers and encapsulation
    class BankAccount
    {
        private decimal _balance;
        public string Owner { get; private set; }
        public decimal Balance => _balance;

        public BankAccount(string owner, decimal initialBalance)
        {
            Owner = owner;
            _balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
                _balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount > 0 && _balance >= amount)
                _balance -= amount;
        }

        private void RecalculateInterest()
        {
            /* internal logic */
        }
    }

    // Task 5: Static utility class for the Generic Swap method
    static class Utils
    {
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }

    // Task 6: Custom implementation of a Generic Stack data structure
    class CustomStack<T>
    {
        private readonly List<T> _items = new List<T>();

        public bool IsEmpty => _items.Count == 0;

        public void Push(T item)
        {
            _items.Add(item);
        }

        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is empty.");

            int lastIndex = _items.Count - 1;
            T topItem = _items[lastIndex];
            _items.RemoveAt(lastIndex);
            return topItem;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is empty.");

            return _items[^1];
        }
    }

    // Task 7: Student record declaration
    record Student(string Name, int Grade);


    
     
    class Program
    {
        static void Main(string[] args)
        {
            // Set console encoding to correctly display Cyrillic characters
            Console.OutputEncoding = System.Text.Encoding.UTF8;

             
            // BLOCK 1: Properties and Access Modifiers
             

            Console.WriteLine("--- Block 1. Task 1: Properties (Person) ---");
            try
            {
                Person person1 = new Person("Іван", 20);
                person1.Introduce();

                Console.WriteLine("Attempting to set a negative age...");
                person1.Age = -5; // This will throw an exception
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Validation caught: {ex.Message}");
            }
            Console.WriteLine("\n--- Block 1. Task 2: Access Modifiers (BankAccount) ---");
BankAccount account = new BankAccount("Максим", 1000);
account.Deposit(500);
account.Withdraw(200);
Console.WriteLine($"Account balance ({account.Owner}): {account.Balance} UAH");


 
// BLOCK 2: Collections
 

Console.WriteLine("\n--- Block 2. Task 3: Dictionary (Word Count) ---");
string text = "apple banana apple cherry banana apple";

// Split text into words by spaces
string[] words = text.Split(' ');
Dictionary<string, int> wordCounts = new Dictionary<string, int>();

foreach (var word in words)
{
    if (wordCounts.ContainsKey(word))
        wordCounts[word]++;
    else
        wordCounts[word] = 1;
}

// Sort words by count in descending order using LINQ
var sortedWords = wordCounts.OrderByDescending(pair => pair.Value);

foreach (var pair in sortedWords)
{
    Console.WriteLine($"{pair.Key} = {pair.Value}");
}

Console.WriteLine("\n--- Block 2. Task 4: HashSet (Set Operations) ---");
HashSet<string> group1 = new HashSet<string> { "Олег", "Юля", "Влад", "Аня" };
HashSet<string> group2 = new HashSet<string> { "Влад", "Аня", "Петро", "Дмитро" };

// 1. Intersection (Students in both groups)
HashSet<string> intersectSet = new HashSet<string>(group1);
intersectSet.IntersectWith(group2);
Console.WriteLine("В обох групах: " + string.Join(", ", intersectSet));

// 2. Difference (Students only in the first group)
HashSet<string> exceptSet = new HashSet<string>(group1);
exceptSet.ExceptWith(group2);
Console.WriteLine("Тільки в першій групі: " + string.Join(", ", exceptSet));

// 3. Union (All unique students combined)
HashSet<string> unionSet = new HashSet<string>(group1);
unionSet.UnionWith(group2);
Console.WriteLine("Усі унікальні студенти: " + string.Join(", ", unionSet));


 
// BLOCK 3: Generics
 

Console.WriteLine("\n--- Block 3. Task 5: Generic Method Swap ---");
int aVal = 5, bVal = 10;
Console.WriteLine($"Before Swap: a = {aVal}, b = {bVal}");
Utils.Swap(ref aVal, ref bVal);
Console.WriteLine($"After Swap: a = {aVal}, b = {bVal}");

string xStr = "hello", yStr = "world";
Console.WriteLine($"Before Swap: x = {xStr}, y = {yStr}");
Utils.Swap(ref xStr, ref yStr);
Console.WriteLine($"After Swap: x = {xStr}, y = {yStr}");

Console.WriteLine("\n--- Block 3. Task 6: Generic Class Stack ---");
CustomStack<int> stack = new CustomStack<int>();
stack.Push(10);
stack.Push(20);
stack.Push(30);

Console.WriteLine($"Top element (Peek): {stack.Peek()}");
Console.WriteLine($"Removed element (Pop): {stack.Pop()}");
Console.WriteLine($"New top element (Peek): {stack.Peek()}");
Console.WriteLine($"Is stack empty? {stack.IsEmpty}");


 
// BLOCK 4: LINQ
 
Console.WriteLine("\n--- Block 4. Task 7: Basic LINQ ---");
var students = new List<Student>
            {
                new("Олег", 85),
                new("Юля", 92),
                new("Влад", 78),
                new("Аня", 92),
                new("Петро", 65)
            };

// 1. All students with a grade higher than 80
var highGraders = students.Where(s => s.Grade > 80);
Console.WriteLine("Оцінка > 80: " + string.Join(", ", highGraders.Select(s => $"{s.Name} ({s.Grade})")));

// 2. Names sorted by grade descending
var sortedNames = students.OrderByDescending(s => s.Grade).Select(s => s.Name);
Console.WriteLine("Імена за спаданням оцінки: " + string.Join(", ", sortedNames));

// 3. Average grade of the group
double averageGrade = students.Average(s => s.Grade);
Console.WriteLine($"Середня оцінка по групі: {averageGrade:F1}");

// 4. Student with the highest grade
var topStudent = students.MaxBy(s => s.Grade);
Console.WriteLine($"Топ студент: {topStudent.Name} ({topStudent.Grade})");

// 5. Grouping students by grade
var groupedStudents = students.GroupBy(s => s.Grade);
Console.WriteLine("Групування:");
foreach (var group in groupedStudents)
{
    var names = group.Select(s => s.Name);
    Console.WriteLine($"  {group.Key}: [{string.Join(", ", names)}]");
}

Console.WriteLine("\n--- Block 4. Task 8: Deferred Execution ---");
var numbers = new List<int> { 1, 2, 3, 4, 5 };
var query = numbers.Where(x => x > 2);
numbers.Add(6);
numbers.Add(7);

// Query executes here because of the foreach loop (Deferred Execution)
Console.WriteLine("Query execution results:");
foreach (var n in query)
    Console.WriteLine(n);
        }
    }
}