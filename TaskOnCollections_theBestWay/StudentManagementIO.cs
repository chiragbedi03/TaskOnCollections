using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskOnCollections_theBestWay
{
    class StudentManagementIO
    {
        StudentService studentservice = new StudentService();
        
        public byte Menu()
        {
            Console.WriteLine("Press 1 to Add Student");
            Console.WriteLine("Press 2 to View All Students");
            Console.WriteLine("Press 3 to Update Student");
            Console.WriteLine("Press 4 to Delete Student");
            Console.WriteLine("Press 5 to Exit");
            Console.WriteLine("Enter Your choice:");
            byte option = Convert.ToByte(Console.ReadLine());
            return option;
        }

        public void AddStudent()
        {
            Console.WriteLine("Enter Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter ID:");
            string id = Console.ReadLine();
            Console.WriteLine("Enter Age:");
            byte age = Convert.ToByte(Console.ReadLine());
            Console.WriteLine("Enter Class:");
            byte standard = Convert.ToByte(Console.ReadLine());
            Console.WriteLine("Enter City:");
            string city = Console.ReadLine();

            Student student = studentservice.AddStudent(name, id, age, standard, city);
            Display(student);
            Console.WriteLine("".PadLeft(15,'-'));
        }

        private void Display(Student student)
        {
            if(student == null)
            {
                Console.WriteLine("Student Not Found");
            }
            else
            {
                Console.WriteLine("".PadLeft(15, '-'));
                Console.WriteLine("ID: " + student.ID);
                Console.WriteLine("Name: " + student.Name);
                Console.WriteLine("Age: " + student.Age);
                Console.WriteLine("Class: " + student.Standard);
                Console.WriteLine("City: " + student.City);
            }
        }
        
        public void DisplayAll()
        {
            Console.WriteLine();
            studentservice.DisplayAll();
            Console.WriteLine();
        }

        public void DeleteStudent()
        {
            Console.WriteLine("Enter Id:");
            string id = Console.ReadLine();
            if (studentservice.DeleteStudent(id))
            {
                Console.WriteLine("Student deleted successfully");
            }
            else
            {
                Console.WriteLine("Student Not Found!");
            }
        }

        public void UpdateStudent()
        {
            Console.WriteLine("Press 1 to update age");
            Console.WriteLine("Press 2 to update city");
            Console.WriteLine("Enter Your Choice");
            switch (Convert.ToByte(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine("Enter Id:");
                    string id = Console.ReadLine();
                    Console.WriteLine("Enter Age:");
                    byte age = Convert.ToByte(Console.ReadLine());
                    Display(studentservice.UpdateStudentAge(id, age));
                    break;

                case 2:
                    Console.WriteLine("Enter Id:");
                    string Id = Console.ReadLine();
                    Console.WriteLine("Enter Age:");
                    string city = Console.ReadLine();
                    Display(studentservice.UpdateStudentCity(Id, city));
                    break;

                default:
                    Console.WriteLine("Enter a Valid Option");
                    break;
            }
        }
    }
}
