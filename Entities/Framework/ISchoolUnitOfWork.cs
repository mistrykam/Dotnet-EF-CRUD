using System;

namespace Entities.Framework
{
    /// <summary>
    /// Unit of Work for the School
    /// </summary>
    public interface ISchoolUnitOfWork : IUnitOfWork, IDisposable
    {
        ITeacherRepository TeacherRepository { get; }
        IStudentRepository StudentRepository { get; }
    }
}
