using StudentsDataLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAndSearchingData
{
    public class Program
    {
        static void Main(string[] args)
        {
            var studentDatabase = new StudentsDataBase();

            while (true)
            {
                Console.WriteLine("1. Display all students");
                Console.WriteLine("2. Search for a student by name");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        studentDatabase.DisplayStudents();
                        break;
                    case 2:
                        Console.Write("Enter the name of the student you want to search for: ");
                        string searchName = Console.ReadLine();
                        studentDatabase.SearchStudentByName(searchName);
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }


    
    }
}
