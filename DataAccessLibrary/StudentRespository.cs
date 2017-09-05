using System.Data.Entity;
using Entities;
using Entities.Framework;

namespace EFDataAccess
{
    internal class StudentRespository : EntityFrameworkRespository<int, Student>, IStudentRepository
    {
        public StudentRespository(DbContext context) : base(context)
        {
        }
    }
}
