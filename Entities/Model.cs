using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Entities
{
    public class Teacher
    {  
        [Key]      
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Student> Students { get; set; }

        public Teacher()
        {
            Students = new List<Student>();
        }

        public override string ToString()
        {
            return string.Format("Teacher:: {0} {1} {2}", TeacherId, FirstName, LastName);
        }
    }

    public class Student
    {       
        [Key] 
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return string.Format("Student:: {0} {1} {2}", StudentId, FirstName, LastName);
        }
    }
}
