using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using Entities;
using Entities.Framework;

namespace EFDataAccess
{
    internal class TeacherRepository : EntityFrameworkRespository<int, Teacher>, ITeacherRepository
    {
        public TeacherRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Teacher> GetTeacherAndStudents(int TeacherId)
        {
            return Context.Set<Teacher>().Where(t => t.TeacherId == TeacherId).Include(s => s.Students);
        }
    }
}
