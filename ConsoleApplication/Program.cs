using System;
using System.Linq;
using EFDataAccess;
using Entities;

namespace ConsoleApplication
{
    class Program
    {
        static void CleanSchool()
        {
            Console.WriteLine("\nRemoving all students and teachers...\n");

            using (SchoolUnitOfWork unitOfWork = new SchoolUnitOfWork(new SchoolDbContext()))
            {
                unitOfWork.StudentRepository.RemoveRange(unitOfWork.StudentRepository.GetAll());
                unitOfWork.TeacherRepository.RemoveRange(unitOfWork.TeacherRepository.GetAll());
                unitOfWork.Commit();
            }
        }

        static void PopulateSchool()
        {
            Console.WriteLine("\nAdding students and teachers...\n");

            using (SchoolUnitOfWork schoolUnitOfWork = new SchoolUnitOfWork(new SchoolDbContext()))
            {
                Teacher teacher1 = new Teacher() { FirstName = "Mathew", LastName = "Ernsto" };

                teacher1.Students.Add(new Student() { FirstName = "Michael", LastName = "Wong" });
                teacher1.Students.Add(new Student() { FirstName = "Janice", LastName = "Song" });
                teacher1.Students.Add(new Student() { FirstName = "Jules", LastName = "Bong" });

                schoolUnitOfWork.TeacherRepository.Add(teacher1);

                Teacher teacher2 = new Teacher() { FirstName = "Susan", LastName = "Pulling" };

                teacher2.Students.Add(new Student() { FirstName = "Debra", LastName = "Stafford" });
                teacher2.Students.Add(new Student() { FirstName = "Millie", LastName = "Himpton" });
                teacher2.Students.Add(new Student() { FirstName = "Jill", LastName = "Abbie" });

                schoolUnitOfWork.TeacherRepository.Add(teacher2);

                schoolUnitOfWork.Commit();

                Console.WriteLine("\nteacherRepo.FindById({0})", teacher1.TeacherId);
                teacher1 = schoolUnitOfWork.TeacherRepository.Get(teacher1.TeacherId);
                Console.WriteLine(teacher1);

                Console.WriteLine("Removing teacher with id = {0}", teacher1.TeacherId);
                schoolUnitOfWork.TeacherRepository.Remove(teacher1);

                Console.WriteLine("\nteacherRepo.Find(p => p.FirstName.Contains(\"a\"):");
                var listOfTeachers = schoolUnitOfWork.TeacherRepository.Get(p => p.FirstName.Contains("a"));

                foreach (Teacher t in listOfTeachers)
                    Console.WriteLine(t);

                Console.WriteLine("\nList of all students:");
                foreach (Student s in schoolUnitOfWork.StudentRepository.GetAll())
                    Console.WriteLine(s);


                var teacherWithStudents = schoolUnitOfWork.TeacherRepository.GetTeacherAndStudents(teacher2.TeacherId);

                Console.WriteLine("\n{0} with students", teacher2);

                foreach (Student s in teacher2.Students)
                {
                    Console.WriteLine(string.Format("\t{0}", s));
                }
            }
        }

        static void UpdateTeacher()
        {
            Console.WriteLine("Update teacher...");

            // Get a teacher to update

            Teacher teacher;

            using (SchoolUnitOfWork schoolUnitOfWork = new SchoolUnitOfWork(new SchoolDbContext()))
            {
                teacher = schoolUnitOfWork.TeacherRepository.Get(12);

                Console.WriteLine("\tBefore:: " + teacher);            
            }

            // change the last name
            teacher.LastName = DateTime.Now.ToString();

            using (SchoolUnitOfWork schoolUnitOfWork = new SchoolUnitOfWork(new SchoolDbContext()))
            {
                schoolUnitOfWork.TeacherRepository.Add(teacher);
                schoolUnitOfWork.Commit();
            }

            using (SchoolUnitOfWork schoolUnitOfWork = new SchoolUnitOfWork(new SchoolDbContext()))
            {
                teacher = schoolUnitOfWork.TeacherRepository.Get(12);

                Console.WriteLine("\tAfter:: " + teacher);
            }
        }

        static void Main(string[] args)
        {
            CleanSchool();
            PopulateSchool();
            UpdateTeacher();

            Console.Write("Press any keys to continue...");
            Console.ReadKey();
        }
    }
}