using System;
using System.Collections.Generic;

namespace Students_Management_System
{
    struct Student
    {
        public string Name;
        public int ID;
        public float Grade;
    }

    internal class Program
    {
        static List<Student> students = new List<Student>();

        static int ShowMenu()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("   Welcome to Student Management System  ");
            Console.WriteLine("=========================================\n");
            Console.WriteLine("Please choose an option:\n");
            Console.WriteLine(" 1 : Add a new Student");
            Console.WriteLine(" 2 : Show All Students");
            Console.WriteLine(" 3 : Search for a Student");
            Console.WriteLine(" 4 : Update Student Data");
            Console.WriteLine(" 5 : Delete Student Data");
            Console.WriteLine(" 6 : Show Statistics");
            Console.WriteLine(" 0 : Exit");

            Console.Write("\nYour choice: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        static void AddStudent()
        {
            Console.Write("Please Enter Student Name: ");
            string name = Console.ReadLine();

            Console.Write("Please Enter Student ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Please Enter Student Grade: ");
            float grade = float.Parse(Console.ReadLine());

            Student stu = new Student();
            stu.Name = name;
            stu.ID = id;
            stu.Grade = grade;
            students.Add(stu);
            Console.WriteLine("\n Student Added Successfully (: \n");
        }

        static void ShowAllStudents()
        {
            if (students.Count > 0)
            {
                Console.WriteLine("{0,-10} {1,-20} {2,-10}", "ID", "Name", "Grade");
                foreach (var s in students)
                {
                    Console.WriteLine("{0,-10} {1,-20} {2,-10}", s.ID, s.Name, s.Grade);
                }
            }
            else
            {
                Console.WriteLine(" There are no students yet.\n");
            }
        }

        static void SearchForStudent()
        {
            Console.WriteLine("Search by:");
            Console.WriteLine(" 0 : Name");
            Console.WriteLine(" 1 : ID");
            Console.Write("Your choice: ");
            int option2 = int.Parse(Console.ReadLine());

            bool found = false;

            if (option2 == 0)
            {
                Console.Write("Enter Student Name: ");
                string stu_name = Console.ReadLine();

                foreach (var s in students)
                {
                    if (s.Name == stu_name)
                    {
                        Console.WriteLine($"\nStudent Info:\n Name: {s.Name}\n ID: {s.ID}\n Grade: {s.Grade}\n");
                        found = true;
                        break;
                    }
                }

                if (!found)
                    Console.WriteLine(" No Student found with this Name.\n");
            }
            else if (option2 == 1)
            {
                Console.Write("Enter Student ID: ");
                int stu_id = int.Parse(Console.ReadLine());

                foreach (var s in students)
                {
                    if (s.ID == stu_id)
                    {
                        Console.WriteLine($"\nStudent Info:\n Name: {s.Name}\n ID: {s.ID}\n Grade: {s.Grade}\n");
                        found = true;
                        break;
                    }
                }

                if (!found)
                    Console.WriteLine(" No Student found with this ID.\n");
            }
            else
            {
                Console.WriteLine(" Invalid Option.\n");
            }
        }

        static void UpdateStudentData()
        {
            Console.Write("Enter Student Name to Update: ");
            string name = Console.ReadLine();

            bool found = false;

            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Name == name)
                {
                    Student stu = students[i];

                    Console.Write("Enter new Name: ");
                    stu.Name = Console.ReadLine();

                    Console.Write("Enter new ID: ");
                    stu.ID = int.Parse(Console.ReadLine());

                    Console.Write("Enter new Grade: ");
                    stu.Grade = float.Parse(Console.ReadLine());

                    students[i] = stu;
                    Console.WriteLine("\nStudent Updated Successfully!\n");
                    found = true;
                    break;
                }
            }

            if (!found)
                Console.WriteLine(" No Student found with this Name.\n");
        }

        static void DeleteStudentData()
        {
            Console.Write("Enter Student Name to Delete: ");
            string name = Console.ReadLine();

            bool found = false;

            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Name == name)
                {
                    students.RemoveAt(i);
                    Console.WriteLine("\nStudent Deleted Successfully!\n");
                    found = true;
                    break;
                }
            }

            if (!found)
                Console.WriteLine(" No Student found with this Name.\n");
        }

        static void ShowStatistics()
        {
            int count = students.Count;
            if (count == 0)
            {
                Console.WriteLine(" No Students available.\n");
            }
            else
            {
                float min = students[0].Grade;
                float max = students[0].Grade;
                float sum = 0;

                foreach (var s in students)
                {
                    if (s.Grade < min) min = s.Grade;
                    if (s.Grade > max) max = s.Grade;
                    sum += s.Grade;
                }

                float avg = sum / count;

                Console.WriteLine($"Students Number = {count}");
                Console.WriteLine($"Maximum Grade  = {max}");
                Console.WriteLine($"Minimum Grade  = {min}");
                Console.WriteLine($"Average Grade  = {avg}\n");
            }
        }

        static int Exit()
        {
            Console.WriteLine("Are you sure you want to exit?");
            Console.WriteLine(" 0 : Yes");
            Console.WriteLine(" 1 : No");
            Console.Write("Your choice: ");
            return int.Parse(Console.ReadLine());
        }

        static void Main(string[] args)
        {
            while (true)
            {
                int option = ShowMenu();
                Console.Clear();

                if (option == 0)
                {
                    if (Exit() == 0) break;
                }
                else if (option == 1)
                    AddStudent();
                else if (option == 2)
                    ShowAllStudents();
                else if (option == 3)
                    SearchForStudent();
                else if (option == 4)
                    UpdateStudentData();
                else if (option == 5)
                    DeleteStudentData();
                else if (option == 6)
                    ShowStatistics();
                else
                    Console.WriteLine(" Invalid Option.\n");

                Console.WriteLine("\nPress any key to return to menu...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
