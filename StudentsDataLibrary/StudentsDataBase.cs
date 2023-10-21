using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDataLibrary
{
    public class StudentsDataBase
    {
        private List<Student> students;

        public StudentsDataBase()
        {
            students = new List<Student>();
            ReadStudentDataFromFile(@"C:\Users\SAI PAVAN KUMAR\source\repos\SortingAndSearchingData\SortingAndSearchingStudentsData.txt"); 
        }

        public void ReadStudentDataFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                foreach (var line in File.ReadLines(fileName))
                {
                    var parts = line.Split(',');
                    if (parts.Length == 5)
                    {
                        var student = new Student
                        {
                            Id = int.Parse(parts[0]),
                            Name = parts[1],                            
                            Address = parts[2],
                            Class = parts[3],
                            Grade = int.Parse(parts[4])
                        };
                        students.Add(student);
                    }
                }
            }
            else
            {
                Console.WriteLine("Student data file not found.");
            }


        }

        public void DisplayStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No student data available.");
                return;
            }

            Console.WriteLine("Students (Sorted by Name):");
            var sortedStudents = students.OrderBy(s => s.Name).ToList();

            foreach (var student in sortedStudents)
            {
                Console.WriteLine($"Name: {student.Name}, Id: {student.Id}, Address: {student.Address}, Class: {student.Class}, Grade: {student.Grade}");
            }
        }

        public void SearchStudentByName(string searchName)
        {
            var foundStudents = students
                .Where(s => IsNameMatch(s.Name, searchName))
                .ToList();

            if (foundStudents.Count == 0)
            {
                Console.WriteLine("No students found with the given name.");
            }
            else
            {
                Console.WriteLine("Found Students:");
                foreach (var student in foundStudents)
                {
                    Console.WriteLine($"Name: {student.Name}, Id: {student.Id}, Address: {student.Address}, Class: {student.Class}, Grade: {student.Grade}");
                }
            }
        }

        private bool IsNameMatch(string studentName, string searchName)
        {
            return studentName.Equals(searchName, StringComparison.OrdinalIgnoreCase);
        }
    }
}