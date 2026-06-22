using System;
using System.Collections.Generic; // Added for List<string> to work correctly

// Set console encoding to support Cyrillic characters
Console.OutputEncoding = System.Text.Encoding.UTF8;

// --- Task 1: Variables and types ---
Console.WriteLine("--- Задача 1: Змінні та типи ---");

int a = 67;
string b = "сікссевен";
bool c = true;
double d = 6.7;

// Print all variables in one line
Console.WriteLine($"{a} {b} {c} {d}");

// Nullable integer. We use '?' because a regular int cannot be null.
int? e = null;


// --- Task 2: Conditions and loops ---
Console.WriteLine("--- Задача 2: Умови та цикли ---");
Console.Write("Введіть число: ");
string input = Console.ReadLine();

// Check if the user input is a valid integer
if (int.TryParse(input, out int number))
{
    // Check if the number is even or odd
    if (number % 2 == 0)
    {
        Console.WriteLine("Парне");
    }
    else
    {
        Console.WriteLine("Непарне");
    }

    // Print numbers from 1 to user number using a for loop
    Console.WriteLine("Вивід через цикл for:");
    for (int i = 1; i <= number; i++)
    {
        Console.Write($"{i} ");
    }
    Console.WriteLine();

    // Print numbers from 1 to user number using a while loop
    Console.WriteLine("Вивід через цикл while:");
    int current = 1;
    while (current <= number)
    {
        Console.Write($"{current} ");
        current++;
    }
    Console.WriteLine();
}
else
{
    // Show error if input is not a number
    Console.WriteLine("Помилка: введено не коректне число.");
}

Console.WriteLine();


// --- Task 3: Methods ---
Console.WriteLine("--- Задача 3: Методи ---");

// Method to add two numbers
int Add(int a, int b)
{
    return a + b;
}

// Method to create a greeting message
string Greet(string nameParam)
{
    return $"Привіт, {nameParam}!";
}

// Call the methods and save results
int sumResult = Add(24, 43);
string greetingResult = Greet("Максим");

// Print method results
Console.WriteLine($"Результат додавання (Add): {sumResult}");
Console.WriteLine($"Результат привітання (Greet): {greetingResult}");
Console.WriteLine();


// --- Task 4: Arrays and list ---
Console.WriteLine("--- Задача 4: Масиви та список ---");

// Create an array of 5 numbers
int[] numbersArray = { 6, 7, 67, 6, 7 };
int maxNumber = numbersArray[0];

// Find the maximum number manually
for (int i = 1; i < numbersArray.Length; i++)
{
    if (numbersArray[i] > maxNumber)
    {
        maxNumber = numbersArray[i];
    }
}
Console.WriteLine($"Максимум у масиві: {maxNumber}");

// Create a List of strings and add 3 names
List<string> namesList = new List<string>();
namesList.Add("Андрій");
namesList.Add("Марія");
namesList.Add("Дмитро");

// Print all names using a foreach loop
Console.WriteLine("Імена зі списку:");
foreach (string personName in namesList)
{
    Console.WriteLine(personName);
}

Console.WriteLine();


// --- Task 5: First class ---
Console.WriteLine("--- Задача 5: Перший клас ---");

// Create two objects of the Person class
Person person1 = new Person("Іван", 20);
Person person2 = new Person("Олена", 25);

// Call the method for each person
person1.Introduce();
person2.Introduce();


// Define the Person class
class Person
{
    // Class fields
    public string Name;
    public int Age;

    // Constructor to set values when object is created
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    // Class method to print information
    public void Introduce()
    {
        Console.WriteLine($"Привіт, я {Name}, мені {Age} років");
    }
}