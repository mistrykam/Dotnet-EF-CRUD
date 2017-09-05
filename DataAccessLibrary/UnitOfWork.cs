using Entities.Framework;

namespace EFDataAccess
{
    public class SchoolUnitOfWork : ISchoolUnitOfWork
    {
        readonly SchoolDbContext _context;

        public ITeacherRepository TeacherRepository { get; }
        public IStudentRepository StudentRepository { get; }

        public SchoolUnitOfWork(SchoolDbContext schoolContext)
        {
            _context = schoolContext;

            TeacherRepository = new TeacherRepository(_context);
            StudentRepository = new StudentRespository(_context);
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
