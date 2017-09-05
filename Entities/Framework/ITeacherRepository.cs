using Entities;
using System.Collections.Generic;

namespace Entities.Framework
{
    public interface ITeacherRepository : IRepository<int, Teacher>
    {
        IEnumerable<Teacher> GetTeacherAndStudents(int TeacherId);
    }
}
