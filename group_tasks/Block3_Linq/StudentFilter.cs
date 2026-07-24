using System;
using System.Collections.Generic;
using System.Text;

namespace group_tasks.Block3_Linq
{
    public record Student(string Name, int Grade);

    public class StudentFilter
    {
        public static List<string> GetTopStudentNames(List<Student> students)
        {
            // Один LINQ-запит для фільтрації, сортування та вибірки імен
            var result = students
                .Where(s => s.Grade >= 60)
                .OrderByDescending(s => s.Grade)
                .Select(s => s.Name)
                .ToList();

            return result;
        }
    }
}
